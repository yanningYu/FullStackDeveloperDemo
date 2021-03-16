using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Validators
{
    public class ValidationResult
    {
        public bool PassedValidation { get; set; }
        public List<string> Errors { get; set; }

        public ValidationResult(bool passedValidation)
        {
            PassedValidation = passedValidation;
            Errors = new List<string>();
        }
    }
}
