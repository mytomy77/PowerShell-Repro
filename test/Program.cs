using System;
using System.Diagnostics;
using System.IO;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = "'" + Directory.GetCurrentDirectory().Replace(@"\\", @"\") + @"\test.ps1'""";
            var _proc = new Process();
            // REPLACE WITH DIRECTORY OF YOUR PWSH
            _proc.StartInfo.FileName = @"C:\Program Files\PowerShell\6\pwsh.EXE";
            var arguement = @"-command "". " + command;
            _proc.StartInfo.Arguments = arguement;
            _proc.StartInfo.UseShellExecute = false;
            _proc.StartInfo.RedirectStandardInput = true;
            _proc.StartInfo.RedirectStandardError = true;
            _proc.StartInfo.RedirectStandardOutput = true;
            
            // ******************************************************************
            // Setting this line to true causes powershell core to exit code 1
            _proc.StartInfo.CreateNoWindow = true; 
            // ******************************************************************

            var response = _proc.Start();
            _proc.WaitForExit();
            Console.WriteLine(_proc.StandardOutput.ReadToEnd());
            Console.WriteLine(_proc.StandardError.ReadToEnd());
            Console.WriteLine($"exited with exit code {_proc.ExitCode}");
        }
    }
}
