using System.Threading.Tasks;
using Docker.Webhook.Deploy.Models;
using Docker.Webhook.Deploy.Services;
using Docker.Webhook.Deploy.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Docker.Webhook.Deploy.Controllers
{
    [Route("[controller]")]
    public class DeployController : Controller
    {
        private readonly IDockerService _dockerService;
        private readonly CredentialsSettings _credentialsSettings;
        private readonly ILogger _logger;
        public DeployController(IDockerService dockerService, CredentialsSettings credentialsSettings, ILogger<DeployController> logger)
        {
            _dockerService = dockerService;
            _credentialsSettings = credentialsSettings;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Deploy(DockerQuery dockerQuery)
        {
            _logger.LogInformation($"Got http get to deploy controller, with args DockerRepository {dockerQuery.DockerRepository} DockerContainerName {dockerQuery.DockerContainerName}");
            await _dockerService.LoginAsync(_credentialsSettings.Login, _credentialsSettings.Password);
            var response = await _dockerService.UpdateImageAsync(dockerQuery.DockerRepository, dockerQuery.DockerContainerName);
            return Ok(response);
        }
    }
}
