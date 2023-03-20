using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Core.Contract
{
    public class EmployeeDtoInsert
    {
        public String Name { get; set; }
        public String Username { get; set; }
        public double HoursPerWeek { get; set; }
        public String Email { get; set; }
        public String Role {get; set;}
        public String Status {get; set;}
    }
}