using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HumanResource.Models;

namespace HumanResource
{
    public class HumanResourceContext
    {
        public List<Account> Accounts { get; set; } = new List<Account>();

        public List<Department> Department { get; set; } = new List<Department>();

    }
}
