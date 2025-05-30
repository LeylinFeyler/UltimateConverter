using System.Diagnostics;

namespace UltimateConverter.Services
{
    public class ExternalToolRunner
    {
        public static void RunCommand(string command, string args)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true 
                }
            };

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            // if (output.Length > 0)
            // {
            //     Console.WriteLine("Command Output:\n" + output);
            // }
            // if (error.Length > 0)
            // {
            //     Console.WriteLine("Command Error:\n" + error);
            // }
        }
    }
}