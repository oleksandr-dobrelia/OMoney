﻿using Moq;
using NUnit.Framework;
using OMoney.Domain.Core.Validation;
using OMoney.Domain.Entities.Entities;
using OMoney.Domain.Services.Notifications.NotificationMessages;

namespace OMoney.Domain.Services.Tests.WhenWorkingWithUserService
{
    [TestFixture]
    public class AndCreatingNewUser
    {
        public UserServiceTestContext TestContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestContext = new UserServiceTestContext();
        }

        [Test]
        public void AndUserIsValid_UserRepositoryCreateMethodShouldBeCalled()
        {
            // Arrange
            // Action
            TestContext.UserService.Create(TestContext.ValidUser);

            // Assert
            TestContext.MockUserRepository.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void AndUserIsValid_NotificationServiceSendEmailMethodShouldBeCalled()
        {
            // Arrange
            // Action
            TestContext.UserService.Create(TestContext.ValidUser);

            // Assert
            TestContext.MockNotificationService.Verify(x => x.SendEmail(It.IsAny<EmailNotificationMessage>()), Times.Once);
        }

        [Test]
        public void AndUserIsInvalid_DomainEntityValidationExceptionShouldBeThrown()
        {
            // Arrange
            // Action
            // Assert
            Assert.Throws<DomainEntityValidationException>(() => TestContext.UserService.Create(null));
        }
    }
}