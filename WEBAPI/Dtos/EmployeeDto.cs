using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Dtos
{
    public class EmployeeDto
    {
          public string  Name { get; set; }

            public string Email { get; set; }

            public string Dob { get; set; }

            public string Department { get; set; }

            public string Gender { get; set; }
    }
}