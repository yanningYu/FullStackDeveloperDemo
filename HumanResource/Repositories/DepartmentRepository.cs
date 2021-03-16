using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using HumanResource.Validators;

namespace HumanResource.Repositories
{
    public class DepartmentRepository
    {
        private readonly HumanResourceContext context = new HumanResourceContext();

        public DepartmentRepository(HumanResourceContext context)
        {
            this.context = context;
        }

        public IEnumerable<string> GetSurnames(string departmentName)
        {
            var validationResult = new GetSurnameValidator().ValidateRequest(departmentName, context);
            if (!validationResult.PassedValidation)
            {
                throw new ArgumentException(validationResult.Errors.First());
            }

            var department = context.Department
                .FirstOrDefault(x => x.DepartmentName == departmentName);

            return department.Accounts.Select(x => x.Surname);
        }
    }
}
