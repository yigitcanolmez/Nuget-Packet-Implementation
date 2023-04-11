using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Deneme.Core.Api;
using SOD.Business;
using SOD.Model;

namespace SOD.Api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class StudentController : BaseApiController
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_studentService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] StudentModel newModel)
        {
            return Ok(_studentService.Add(newModel));
        }

        [HttpPut]
        public IActionResult Update([FromBody] StudentModel updateModel)
        {
            return Ok(_studentService.Update(updateModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_studentService.DeleteById(id));
        }
    }

}

