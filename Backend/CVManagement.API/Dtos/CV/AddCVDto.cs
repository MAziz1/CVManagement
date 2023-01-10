using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CVManagement.API.Dtos
{
    public class AddCVDto
    {
        [Required]
        public string Name { get; set; }
        public AddPersonalInformationDto PersonalInformation { get; set; }
        public List<AddExperienceInformationDto> ExperienceInformation { get; set; }

    }
}
