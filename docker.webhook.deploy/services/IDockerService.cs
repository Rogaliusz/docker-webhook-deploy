using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace docker.webhook.deploy.services
{
    public interface IDockerService
    {
        Task LoginAsync(string login, string password);

        Task UpdateImage(DockerService dockerService);
    }
}
