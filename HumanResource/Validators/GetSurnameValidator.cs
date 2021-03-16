using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Validators
{
    public class GetSurnameValidator
    {

        public ValidationResult ValidateRequest(string request, HumanResourceContext context)
        {
            var result = new ValidationResult(true);

            if (InputEmptyDepartment(request, result))
                return result;

            if (NotFoundDepartment(request, result, context))
                return result;

            return result;
        }

        private bool InputEmptyDepartment(string department, ValidationResult result){
            if(string.IsNullOrEmpty(department)){
                result.PassedValidation = false;
                result.Errors.Add("Department's value is empty");
            }
            return false;
        }

        private bool NotFoundDepartment(string department, ValidationResult result,HumanResourceContext context)
        {
            if(!context.Department.Any(x => x.DepartmentName == department)){
                result.PassedValidation = false;
                result.Errors.Add("Department can not be found");
            }
            return false;
        }

    }

   
}
