using Deneme.Authorization.Nuget.Business.Abstraction;
using Deneme.Authorization.Nuget.Model.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Deneme.Core.Api;

namespace SOD.Api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class PersonnelController : BaseApiController
    {
        public readonly IPersonnelService _personnelService;

        public PersonnelController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personnelService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_personnelService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] PersonnelModel newModel)
        {



            return Ok(_personnelService.Add(newModel));
        }

        [HttpPut]
        public IActionResult Update([FromBody] PersonnelModel updateModel)
        {
            return Ok(_personnelService.Update(updateModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_personnelService.DeleteById(id));
        }
    }
}
