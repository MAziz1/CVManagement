using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManagement.Domain
{
    public class ExperienceInformation : Entity<int>
    {
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string CompanyField { get; set; }
        public int CVId { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
