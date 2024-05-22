using Collibri.Dtos;
using Collibri.Repositories.DbImplementation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Collibri.Controllers
{
    [ApiController]
    [Route("/v1/login")]
    public class LoginController : Controller
    {
        private readonly DbLoginRepository _loginRepository;
        
        public LoginController(DbLoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<IActionResult> LoggingInRequestAsync([FromBody] LoginInfoDTO loginInfo)
        {
            var response = await _loginRepository.LoggingInRequestAsync(loginInfo);

            return response == null ? NotFound() : Ok(JsonConvert.SerializeObject(response));
        }
    }   
}