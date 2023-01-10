using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManagement.Domain
{
    public class PersonalInformation : Entity<int>
    {
        public string FullName { get; set; }
        public string CityName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
