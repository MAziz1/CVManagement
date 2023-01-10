using AutoMapper;
using CVManagement.Domain.IRepository;
using CVManagement.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CVManagement.API.Dtos;
using System.Collections.Generic;

namespace CVManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceInformationController : APIController
    {
        private readonly IRepository<ExperienceInformation> _repository;
        private readonly IRepository<CV> _cvRepository;
        private readonly IMapper _mapper;

        public ExperienceInformationController(IRepository<ExperienceInformation> repository,
            IRepository<CV> cvRepository, IMapper mapper)
        {
            _repository = repository;
            _cvRepository = cvRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCVExperiences([Required] int cvId)
        {
            var cvEntity = await _cvRepository.GetAsync(cv => cv.Id == cvId, nameof(CV.ExperienceInformation));
            if (cvEntity == null)
                return NotFoundResult(new List<string> { $"there is no CV with the provided Id {cvId}" });
            var experienceInfos = cvEntity.ExperienceInformation;
            var experienceInfosDto = _mapper.Map<List<ExperienceInformationDto>>(experienceInfos);
            return OkObjectResult(experienceInfosDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddExperience([Required]int cvId, AddExperienceInformationDto model)
        {
            if (cvId <= 0)
                return BadRequestResult(new List<string> { $"the provided id is not valid cvId={cvId}" });

            if(!ModelState.IsValid)
                return BadRequestResult(new List<string> { $"your model is not valid" });

            var cvEntity = await _cvRepository.GetAsync(cv => cv.Id == cvId);
            if (cvEntity == null)
                return NotFoundResult(new List<string> { $"there is no CV with the provided Id {cvId}" });

            var experienceInformation = _mapper.Map<ExperienceInformation>(model);
            await _repository.AddAsync(experienceInformation);

            var experienceInformationDto = _mapper.Map<ExperienceInformationDto>(experienceInformation);
            return OkObjectResult(experienceInformationDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExperience(UpdateExperienceInformationDto model)
        {
            if (!ModelState.IsValid)
                return BadRequestResult(new List<string> { $"your model is not valid" });

            var experienceInfo = await _repository.GetAsync(info => info.Id == model.Id);
            if (experienceInfo == null)
                return NotFoundResult(new List<string> { $"there is no experience information with the provided Id {model.Id}" });

            var experienceInformation = _mapper.Map<ExperienceInformation>(model);
            await _repository.UpdateAsync(experienceInformation);

            var experienceInformationDto = _mapper.Map<ExperienceInformationDto>(experienceInformation);
            return OkObjectResult(experienceInformationDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteExperience([Required]int id)
        {
            var experienceInfo = await _repository.GetAsync(info => info.Id == id);
            if (experienceInfo == null)
                return NotFoundResult(new List<string> { $"there is no experience information with the provided Id {id}" });

            experienceInfo.Delete();
            await _repository.UpdateAsync(experienceInfo);
            return OkObjectResult("Deleted Successfully");
        }
    }
}
