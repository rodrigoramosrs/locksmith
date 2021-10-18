using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Locksmith.Core.Services.Shell.Utils
{
    public static class OSUtils
    {
        public static bool IsWin() =>
                  RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public static bool IsMac() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static bool IsGnuLinux() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        public static string GetCurrent()
        {
            return
            (IsWin() ? "win" : null) ??
            (IsMac() ? "mac" : null) ??
            (IsGnuLinux() ? "linux" : null);
        }


        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetShortPathName(
                   [MarshalAs(UnmanagedType.LPTStr)]
                   string path,
                   [MarshalAs(UnmanagedType.LPTStr)]
                   StringBuilder shortPath,
                   int shortPathLength
                   );

        public static string GetWindowsShortPath(string Path)
        {
            StringBuilder shortPath = new StringBuilder(255);
            GetShortPathName(Path, shortPath, shortPath.Capacity);
            return shortPath.ToString();
        }
    }
}
