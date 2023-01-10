using AutoMapper;
using CVManagement.API.Dtos;
using CVManagement.Domain;

namespace CVManagement.API.AutoMapper
{
    public class CVProfile : Profile
    {
        public CVProfile()
        {
            CreateMap<CV, AddCVDto>().ReverseMap();
            CreateMap<CV, CVDto>().ReverseMap();
            CreateMap<PersonalInformation, PersonalInformationDto>().ReverseMap();
            CreateMap<PersonalInformation, AddPersonalInformationDto>().ReverseMap();
            CreateMap<ExperienceInformation, ExperienceInformationDto>().ReverseMap();
            CreateMap<ExperienceInformation, AddExperienceInformationDto>().ReverseMap();
        }
    }
}
