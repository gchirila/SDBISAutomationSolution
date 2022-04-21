using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDBISAutomationSolution.PageObjects.AddAddress.InputData
{
    public class AddAddressBO
    {
        public string FirstName { get; set; } = "Default value";
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Color { get; set; }
    }
}
