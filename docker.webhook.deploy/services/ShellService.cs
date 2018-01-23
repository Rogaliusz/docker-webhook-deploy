using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace docker.webhook.deploy.services
{
    public class ShellService : IShellService, IService
    {
        public async Task<string> RunBashCommandAsync(string command)
        {
            var escapedArgs = command.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            var result = await process.StandardOutput.ReadToEndAsync();
            process.WaitForExit();
            return result;
        }
    }
}
