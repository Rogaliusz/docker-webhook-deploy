using System.Threading.Tasks;

namespace Docker.Webhook.Deploy.Services
{
    public class DockerService : IDockerService, IService
    {
        private readonly IShellService _shellService;
        public DockerService(IShellService shellService)
        {
            _shellService = shellService;
        }

        public async Task LoginAsync(string login, string password)
        {
            await _shellService.RunBashScriptAsync("login", $"login password");
        }

        public async Task<string> UpdateImageAsync(string dockerRepository, string dockerContainerName)
        {
            return await _shellService.RunBashScriptAsync("update", $"{dockerRepository} {dockerContainerName}");
        }
    }
}
