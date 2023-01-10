using CVManagement.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace CVManagement.API.Controllers
{
    public class APIController : ControllerBase
    {
        protected OkObjectResult OkObjectResult<T>(T data) where T : class
        {
            var response = new Response<T> 
            { 
                Status = HttpStatusCode.OK,
                Data = data,
            };
            return Ok(response);
        }

        protected BadRequestObjectResult BadRequestResult(List<string> errors)
        {
            var response = new Response<object>
            {
                Status = HttpStatusCode.BadRequest,
                Errors = errors,
                Data = null,
            };
            return BadRequest(response);
        }

        protected NotFoundObjectResult NotFoundResult(List<string> errors)
        {
            var response = new Response<object>
            {
                Status = HttpStatusCode.OK,
                Errors = errors,
                Data = null,
            };
            return NotFound(response);
        }
    }
}
