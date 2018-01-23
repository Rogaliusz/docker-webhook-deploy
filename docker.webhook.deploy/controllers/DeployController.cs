using System.Threading.Tasks;
using Docker.Webhook.Deploy.Models;
using Docker.Webhook.Deploy.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Docker.Webhook.Deploy.Controllers
{
    [Route("[controller]")]
    public class DeployController : Controller
    {
        private readonly IDockerService _dockerService;
        public DeployController(IDockerService dockerService)
        {
            _dockerService = dockerService;
        }
        [HttpGet]
        public async Task<IActionResult> Deploy(DockerQuery dockerQuery)
        {

            return Ok();
        }
    }
}
