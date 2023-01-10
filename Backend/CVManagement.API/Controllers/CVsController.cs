using AutoMapper;
using CVManagement.API.Dtos;
using CVManagement.API.Model;
using CVManagement.Domain;
using CVManagement.Domain.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CVManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVsController : APIController
    {
        private readonly IRepository<CV> _repository;
        private readonly IMapper _mapper;

        public CVsController(IRepository<CV> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public async Task<IActionResult> ListAsync(int page = 1, int pageSize = 10)
        {
            var cvsList = await _repository.GetListAsync(page:page, pageCount: pageSize,includes: nameof(CV.PersonalInformation));
            var totalCount = await _repository.CountAsync(cv => !cv.IsDeleted);
            var cvsListDto = _mapper.Map<List<CVDto>>(cvsList);
            return OkObjectResult(new PagedResult<CVDto> { Data = cvsListDto, RecordsTotal = totalCount, RecordsFiltered = cvsList.Count});
        }

        [HttpGet]
        [ActionName("Get/{id}")]
        public async Task<IActionResult> GetAsync([Required] int id)
        {
            if (id <= 0)
                return BadRequestResult(new List<string> { $"the provided id is not valid id={id}" });

            var entity = await _repository.GetAsync(cv => cv.Id == id, nameof(CV.PersonalInformation), nameof(CV.ExperienceInformation));
            if (entity == null)
                return NotFoundResult(new List<string> { $"there is no CV with the provided Id {id}" });

            var cvDto = _mapper.Map<CVDto>(entity);
            return OkObjectResult(cvDto);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCVAsync(AddCVDto model)
        {
            if (!ModelState.IsValid)
                return BadRequestResult(new List<string> { $"your model is not valid" });
            var entity = _mapper.Map<CV>(model);
            var cvEntity = await _repository.AddAsync(entity);
            
            var cvDto = _mapper.Map<CVDto>(cvEntity);
            return OkObjectResult(cvDto);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCVAsync(UpdateCVDto model)
        {
            if (!ModelState.IsValid)
                return BadRequestResult(new List<string> { $"your model is not valid" });

            var entity = _mapper.Map<CV>(model);
            var cvEntity = await _repository.UpdateAsync(entity);

            var cvDto = _mapper.Map<CVDto>(cvEntity);
            return OkObjectResult(cvDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCVAsync([Required]int id)
        {
            if (id <= 0)
                return BadRequestResult(new List<string> { $"the provided id is not valid id={id}" });

            var entity = await _repository.GetAsync(cv => cv.Id == id);
            if (entity == null)
                return NotFoundResult(new List<string> { $"there is no CV with the provided Id {id}" });

            entity.Delete();
            var cvEntity = await _repository.UpdateAsync(entity);
            var cvDto = _mapper.Map<CVDto>(cvEntity);

            return OkObjectResult(cvDto);
        }
    }
}
