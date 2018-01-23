using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Docker.Webhook.Deploy.Services
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

        public async Task<string> RunBashScriptAsync(string script, string arguments)
        {
            var escapedArgs = arguments.Replace("\"", "\\\"");
            var scriptPath = Path.Combine("Scripts", $"{script}.sh");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = scriptPath,
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
