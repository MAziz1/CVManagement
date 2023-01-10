using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CVManagement.API.Dtos
{
    public class CVDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public PersonalInformationDto PersonalInformation { get; set; }
        public List<ExperienceInformationDto> ExperienceInformation { get; set; }
    }
}
