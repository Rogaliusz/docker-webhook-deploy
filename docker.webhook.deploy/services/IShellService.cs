using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Docker.Webhook.Deploy.Services
{
    public interface IShellService
    {
        Task<string> RunBashCommandAsync(string command);

        Task<string> RunBashScriptAsync(string script, string arguments);
    }
}
