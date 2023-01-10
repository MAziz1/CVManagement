using System.ComponentModel.DataAnnotations;

namespace CVManagement.API.Dtos
{
    public class AddPersonalInformationDto
    {
        [Required]
        public string FullName { get; set; }
        public string CityName { get; set; }
        public string Email { get; set; }
        [Required]
        public string MobileNumber { get; set; }
    }
}
