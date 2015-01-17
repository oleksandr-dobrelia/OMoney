﻿using System.Web.Http;
using AutoMapper;
using OMoney.Domain.Entities.Entities;
using OMoney.Domain.Entities.Validation;
using OMoney.Domain.Services.Users;
using OMoney.Web.Api.Models;

namespace OMoney.Web.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Register(UserViewModel userModel)
        {
            try
            {
                var user = Mapper.Map<User>(userModel);
                _userService.Create(user);
                return Ok();
            }
            catch (DomainEntityValidationException validationException)
            {
                foreach (var validationError in validationException.ValidationErrors)
                {
                    ModelState.AddModelError("validationError", validationError);
                }
            }

            return BadRequest(ModelState);
        }
    }
}