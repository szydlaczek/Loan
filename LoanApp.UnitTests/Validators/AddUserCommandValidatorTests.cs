using FluentValidation.TestHelper;
using LoanApp.Application.Users.Commands.CreateUser;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoanApp.UnitTests.Validators
{
    public class AddUserCommandValidatorTests
    {
        private CreateUserCommandValidator validator;
        public AddUserCommandValidatorTests()
        {
            validator = new CreateUserCommandValidator();
        }

        [Fact]
        public void Should_have_error_when_FirstName_is_null()
        {
            var result=validator.ShouldHaveValidationErrorFor(p => p.FirstName, null as string);
            Assert.Single(result);
        }
        [Fact]
        public void Should_have_error_when_LastName_is_null()
        {
            var result = validator.ShouldHaveValidationErrorFor(p => p.LastName, null as string);
            Assert.Single(result);
        }
        [Fact]
        public void Should_have_error_when_EmailAddres_is_incorrect_format()
        {
            var result = validator.ShouldHaveValidationErrorFor(p => p.EmailAddress, "Test.com");
            Assert.Single(result);
        }

    }
}
