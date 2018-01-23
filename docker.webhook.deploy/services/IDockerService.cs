using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Docker.Webhook.Deploy.Services
{
    public interface IDockerService
    {
        Task LoginAsync(string login, string password);

        Task<string> UpdateImageAsync(string dockerRepository, string dockerContainerName);
    }
}
