using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Docker.Webhook.Deploy.Services
{
    interface IShellService
    {
        Task<string> RunBashCommandAsync(string command);
    }
}
