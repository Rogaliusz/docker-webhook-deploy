using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace docker.webhook.deploy.services
{
    interface IShellService
    {
        Task<string> RunBashCommandAsync(string command);
    }
}
