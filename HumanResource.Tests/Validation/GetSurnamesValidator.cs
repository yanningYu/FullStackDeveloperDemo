using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;

using HumanResource.Models;
using HumanResource.Validators;

using NUnit.Framework;

namespace HumanResource.Tests.Validation
{
    [TestFixture]
    public class GetSurnamesValidatorTest
    {
        private HumanResourceContext context = new HumanResourceContext();
        [SetUp]
        public void Setup()
        {
            this.FillContextData();
        }

        [Test]
        public void ValidationRequest_AllCheckPass_ReturnPassValidationResult()
        {
            //arrange
            var department = "Purchasing";

            // act
            var res = new GetSurnameValidator().ValidateRequest(department, context);

            //assert
            res.PassedValidation.Should().BeTrue();
        }

        [TestCase("")]
        [TestCase(null)]
        public void ValidationRequest_DepartmentNullOrEmpty_ReturnFaildValidationResult(string department)
        {

            // act
            var res = new GetSurnameValidator().ValidateRequest(department, context);

            //assert
            res.Errors.Should().Contain("Department's value is empty");
        }

        [Test]
        public void ValidationRequest_NotFoundDepartment_ReturnFailedValidationResult()
        {
            var department = "Purchasing1";
            
            //act
            var res =  new GetSurnameValidator().ValidateRequest(department, context);

            //assert
            res.PassedValidation.Should().BeFalse();
            res.Errors.Should().Contain("Department can not be found");
        }

        private void FillContextData()
        {
            var johnsSmith = new Account
            {
                Surname = "Smith",
                Forename = "Johns",
                Title = "Mr"
            };
            var steveJohn = new Account
            {
                Surname = "Jones",
                Forename = "Steve",
                Title = "Mr"
            };
            var lisaBradshaw = new Account
            {
                Surname = "Bradshaw",
                Forename = "Lisa",
                Title = "Mrs"
            };
            var joanneThompson = new Account
            {
                Surname = "Thompson",
                Forename = "Joanne",
                Title = "Miss"
            };
            var davidJohnson = new Account
            {
                Surname = "Johnson",
                Forename = "David",
                Title = "Mr"
            };
            this.context.Accounts = new List<Models.Account>()
            {
                johnsSmith,
                steveJohn,
                lisaBradshaw,
                joanneThompson,
                davidJohnson
            };

            this.context.Department = new List<Department>
            {
                new Department
                {
                    DepartmentName = "Purchasing",
                    DepartmentLocation = "Top floor",
                    Accounts = new List<Account>
                    {
                        johnsSmith,
                        steveJohn,
                        lisaBradshaw
                    }
                },

                new Department
                {
                    DepartmentName = "Sales",
                    DepartmentLocation = "Bottom floor",
                    Accounts = new List<Account>
                    {
                        lisaBradshaw,
                        joanneThompson,
                        davidJohnson
                    }
                }
            };
        }
    }
}
