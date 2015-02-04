﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using OMoney.Data.Users;
using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Validation.Users
{
    public class CreateNewUserValidator : IDomainEntityValidator<User>
    {
        private readonly IUserRepository _userRepository;
        private readonly string _password;
        private readonly string _confirmPassword;
        private readonly Regex _rgx;

        public CreateNewUserValidator(IUserRepository userRepository, string password, string confirmPassword)
        {
            _userRepository = userRepository;
            _password = password;
            _confirmPassword = confirmPassword;
            _rgx = new Regex(@"[a-zA-Z0-9-.+]+@[a-zA-Z0-9-.]+\.[a-zA-Z]{2,}");
        }

        public IEnumerable<string> Validate(User user)
        {
            if (user == null) yield return "User is NULL.";
            if (user != null && string.IsNullOrWhiteSpace(user.Email)) yield return "Email is EMPTY.";
            if (user != null && string.IsNullOrWhiteSpace(_password)) yield return "Password is EMPTY.";
            if (user != null && string.IsNullOrWhiteSpace(_confirmPassword)) yield return "Password Confirm is EMPTY.";
            if (user != null && _password != _confirmPassword) yield return "Password and Confirm Password does not match.";
            if (user != null && _userRepository.GetByEmail(user.Email) != null) yield return "User with this email already exists.";
            if (user != null && !_rgx.IsMatch(user.Email)) yield return "Email is incorrect.";
        }
    }
}
