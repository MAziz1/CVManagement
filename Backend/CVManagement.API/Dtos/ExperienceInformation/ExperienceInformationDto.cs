using System.ComponentModel.DataAnnotations;

namespace CVManagement.API.Dtos
{
    public class ExperienceInformationDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string CompanyField { get; set; }
        public bool IsDeleted { get; set; }
    }
}
