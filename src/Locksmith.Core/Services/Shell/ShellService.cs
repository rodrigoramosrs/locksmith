using Locksmith.Core.Services.Shell.Utils;
using Shell.NET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Locksmith.Core.Services.Shell
{
    public static class ShellService
    {
        public static string Execute(string command)
        {
            return ShellUtils.Shell.ExecuteShellCommand($@"{command}");
        }

    }
}
