using System;
using System.Collections.Generic;

namespace CVManagement.Domain
{
    public class CV : Entity<int>
    {
        public string Name { get; set; }

        public int PersonalInformationId { get; set; }
        public PersonalInformation PersonalInformation { get; set; }

        public List<ExperienceInformation> ExperienceInformation { get; set; }


        public void AddExperienceInformation(ExperienceInformation experienceInformation)
        {
            ExperienceInformation.Add(experienceInformation);
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
