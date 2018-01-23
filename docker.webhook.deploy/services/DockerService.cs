using System.Threading.Tasks;

namespace Docker.Webhook.Deploy.Services
{
    public class DockerService : IDockerService, IService
    {
        public Task LoginAsync(string login, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UpdateImageAsync(DockerService dockerService)
        {
            throw new System.NotImplementedException();
        }
    }
}
