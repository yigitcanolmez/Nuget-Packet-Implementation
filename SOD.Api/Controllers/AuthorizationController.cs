using Deneme.Authorization.Nuget.Business.Abstraction;
using Deneme.Authorization.Nuget.Model.Model;
using Deneme.Authorization.Nuget.Model.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Deneme.Core.Api;
using SOD.Data;

namespace SOD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : BaseApiController
    {
        private readonly IAuthorizeService<SampleProjectDbContext> _authorizationService;

        public AuthorizationController(IAuthorizeService<SampleProjectDbContext> authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            return Ok(_authorizationService.Login(loginModel));
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] PersonnelModel personnelModel)
        {
            return Ok(_authorizationService.Register(personnelModel));
        }
    }
}
