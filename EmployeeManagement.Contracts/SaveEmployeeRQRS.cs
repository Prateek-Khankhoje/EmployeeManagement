using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts
{
    public class SaveEmployeeRQ
    {
        public Employee Employee { get; set; }
    }

    public class SaveEmployeeRS
    {
        public int Id { get; set; }
    }


}
