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
        public async Task<string> RunBashCommandAsync(string myBatchFile)
        {
            var command = "sh";
            var argss = $"{myBatchFile}";

            var processInfo = new ProcessStartInfo();
            processInfo.UseShellExecute = false;
            processInfo.FileName = command;   // 'sh' for bash 
            processInfo.Arguments = argss;    // The Script name 

            var process = Process.Start(processInfo);   // Start that process.
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
