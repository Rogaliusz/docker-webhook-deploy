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
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "sh";
            psi.Arguments = $"-c \"{script} {arguments}\"";
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            var proc = new Process
            {
                StartInfo = psi
            };

            proc.Start();

            var error = string.Empty;
            var output = string.Empty;

            var list = new List<Task>()
            {
                proc.StandardError.ReadToEndAsync().ContinueWith( r => error = r.Result),
                proc.StandardOutput.ReadToEndAsync().ContinueWith(r => output = r.Result)
            };

            await Task.WhenAll(list);

            if (!string.IsNullOrEmpty(error))
                return "error: " + error;

            proc.WaitForExit();

            return output;
        }
    }
}
