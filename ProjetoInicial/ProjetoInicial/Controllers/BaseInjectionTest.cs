using Microsoft.AspNetCore.Mvc;
using ProjetoInicial.Services.ServicesSingleton;
using ProjetoInicial.Services.ServicesTransient;

namespace ProjetoInicial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseInjectionTest : ControllerBase
    {
        private readonly ILifecycleService _service;
        private readonly Lifecycle2Services _service2;
        private readonly ILifecycleTransientService _transientService;
        private readonly Lifecycle2TransientService _transientService2;


        public BaseInjectionTest(ILifecycleService service, Lifecycle2Services service2, ILifecycleTransientService transientService, Lifecycle2TransientService transientService2)
        {
            _service = service;
            _service2 = service2;
            _transientService = transientService;
            _transientService2 = transientService2;
        }

        [HttpGet("Singleton")]
        public IActionResult GetSingleton()
        {
            var result = new List<DateTime>();
            result.Add(_service.DataAtual());
            result.Add(_service2.DataAtual());

            return Ok(result);
        }

        [HttpGet("Transient")]  
        public IActionResult GetTransient()
        {
            var result = new List<DateTime>();
            result.Add(_transientService.DataAtual());
            result.Add(_transientService2.DataAtual());

            return Ok(result);
        }
    }
}
