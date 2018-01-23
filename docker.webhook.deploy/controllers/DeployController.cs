using System.Threading.Tasks;
using Docker.Webhook.Deploy.Models;
using Docker.Webhook.Deploy.Services;
using Docker.Webhook.Deploy.Settings;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Docker.Webhook.Deploy.Controllers
{
    [Route("[controller]")]
    public class DeployController : Controller
    {
        private readonly IDockerService _dockerService;
        private readonly CredentialsSettings _credentialsSettings;
        public DeployController(IDockerService dockerService, CredentialsSettings credentialsSettings)
        {
            _dockerService = dockerService;
            _credentialsSettings = credentialsSettings;
        }
        [HttpGet]
        public async Task<IActionResult> Deploy(DockerQuery dockerQuery)
        {
            await _dockerService.LoginAsync(_credentialsSettings.Login, _credentialsSettings.Password);
            var response = await _dockerService.UpdateImageAsync(dockerQuery.DockerRepository, dockerQuery.DockerContainerName);
            return Ok(response);
        }
    }
}
