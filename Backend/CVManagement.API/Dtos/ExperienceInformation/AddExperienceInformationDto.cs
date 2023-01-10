using System.ComponentModel.DataAnnotations;

namespace CVManagement.API.Dtos
{
    public class AddExperienceInformationDto
    {
        [Required]
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string CompanyField { get; set; }
        public int CVId { get; set; }
    }
}
