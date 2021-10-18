using Shell.NET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Locksmith.Core.Services.Shell.Utils
{
    public static class ShellUtils
    {
        public class Response
        {
            public int code { get; set; }
            public string stdout { get; set; }
            public string stderr { get; set; }
        }

        public enum Output
        {
            Hidden,
            Internal,
            External
        }

        public static class Shell
        {

            public static string ExecuteShellCommand(string defaultCommand, string WinCommand = "", string LinuxCommand = "", string MacCommand = "")
            {
                string GeneralInformationResult = "";
                if (OSUtils.IsWin())
                {
                    var result = Shell.ExecuteTerminalCommand(string.IsNullOrEmpty(WinCommand) ? defaultCommand : WinCommand);
                    GeneralInformationResult = !string.IsNullOrEmpty(result.stdout.Replace("\n", string.Empty).Replace("\r", string.Empty)) ? result.stdout : result.stderr;
                }
                else if (OSUtils.IsMac())
                {
                    GeneralInformationResult = new Bash().Command(string.IsNullOrEmpty(MacCommand) ? defaultCommand : MacCommand).Output;
                }
                else if (OSUtils.IsGnuLinux())
                {
                    GeneralInformationResult = new Bash().Command(string.IsNullOrEmpty(LinuxCommand) ? defaultCommand : LinuxCommand).Output;
                }


                return GeneralInformationResult;
            }

            private static string GetFileName()
            {
                string fileName = "";
                try
                {
                    switch (OSUtils.GetCurrent())
                    {
                        case "win":
                            fileName = "cmd.exe";
                            break;
                        case "mac":
                        case "gnu":
                            fileName = "/bin/bash";
                            break;
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }

                return fileName;
            }


            private static string CommandConstructor(string cmd, Output? output = Output.Hidden, string dir = "")
            {
                try
                {
                    switch (OSUtils.GetCurrent())
                    {
                        case "win":
                            cmd = cmd.Replace("\"", "\\\"");
                            if (!String.IsNullOrEmpty(dir))
                            {
                                dir = $" \"{dir}\"";
                            }
                            if (output == Output.External)
                            {
                                cmd = $"{Directory.GetCurrentDirectory()}/cmd.win.bat \"{cmd.Replace("\r\n", " && ")}\"{dir}";
                            }

                            cmd = $"/c \"{cmd.Replace("\r\n", " && ")}\"";
                            break;
                        case "mac":
                        case "gnu":
                            cmd = $"-c \"{cmd}\"";
                            break;
                    }

                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }

                return cmd;
            }

            public static Response ExecuteTerminalCommand(string cmd, Output? output = Output.Hidden, string dir = "")
            {
                var result = new Response();
                var stderr = new StringBuilder();
                var stdout = new StringBuilder();
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    if (!cmd.Contains(".exe"))
                    {
                        startInfo.FileName = GetFileName();
                        startInfo.Arguments = CommandConstructor(cmd, output, dir);
                    }
                    else
                    {
                        startInfo.FileName = cmd.Split(' ')[0];
                        int splitIndex = cmd.IndexOf(" ");
                        startInfo.Arguments = cmd.Substring(splitIndex, cmd.Length - splitIndex);
                    }
                    startInfo.RedirectStandardOutput = !(output == Output.External);
                    startInfo.RedirectStandardError = !(output == Output.External);
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = !(output == Output.External);
                    if (!String.IsNullOrEmpty(dir) && output != Output.External)
                    {
                        startInfo.WorkingDirectory = dir;
                    }

                    using (Process process = Process.Start(startInfo))
                    {
                        switch (output)
                        {
                            case Output.Internal:
                                while (!process.StandardOutput.EndOfStream)
                                {
                                    string line = process.StandardOutput.ReadLine();
                                    stdout.AppendLine(line);
                                    Console.WriteLine(line);
                                }

                                while (!process.StandardError.EndOfStream)
                                {
                                    string line = process.StandardError.ReadLine();
                                    stderr.AppendLine(line);
                                    Console.WriteLine(line);
                                }
                                break;
                            case Output.Hidden:
                                stdout.AppendLine(process.StandardOutput.ReadToEnd());
                                stderr.AppendLine(process.StandardError.ReadToEnd());
                                break;
                        }
                        process.WaitForExit();
                        result.stdout = stdout.ToString();
                        result.stderr = stderr.ToString();
                        result.code = process.ExitCode;
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
                return result;
            }
        }
    }
}
