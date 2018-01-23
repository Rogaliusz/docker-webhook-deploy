using System.Threading.Tasks;
using docker.webhook.deploy.models;
using docker.webhook.deploy.services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace docker.webhook.deploy.controllers
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
