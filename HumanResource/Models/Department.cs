using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Models
{
    public class Department
    {
        public string DepartmentName { get; set; }

        public string DepartmentLocation { get; set; }

        public IEnumerable<Account> Accounts { get;set;}
    }
}
