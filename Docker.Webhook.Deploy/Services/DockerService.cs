using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Docker.Webhook.Deploy.Services
{
    public class DockerService : IDockerService, IService
    {
        private readonly IShellService _shellService;
        private readonly ILogger _logger;
        public DockerService(IShellService shellService, ILogger<DockerService> logger)
        {
            _shellService = shellService;
            _logger = logger;
        }

        public async Task LoginAsync(string login, string password)
        {
            var result = await _shellService.RunBashScriptAsync("Scripts/login.sh", $"login password");
            _logger.LogInformation($"Got result from login async {result}");
        }

        public async Task<string> UpdateImageAsync(string dockerRepository, string dockerContainerName)
        {
            var result = await _shellService.RunBashScriptAsync("Scripts/update.sh", $"{dockerRepository} {dockerContainerName}");
            _logger.LogInformation($"Got result from updateImage async {result}");
            return result;
        }
    }
}
