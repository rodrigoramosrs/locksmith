using Locksmith.CLI.Command;
using Locksmith.Core.Factory;
using Locksmith.Core.Model.Platform;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Locksmith.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractEmbededResources();
            
            var app = new CommandApp<TestSecretCommand>();
            app.Configure(config =>
            {
                config.SetApplicationName("Locksmith");
            });
            PrintHeader();
            app.Run(args);











        }



        private static void PrintHeader()
        {
            Console.WriteLine("             ▒▒▒▒▒▒                                             ");
            Console.WriteLine("           ▒▒▒▒▒▒▒▒▒▒                                           ");
            Console.WriteLine("         ▓▓▒▒      ▒▒▒▒                                         ");
            Console.WriteLine("         ▒▒▒▒      ▒▒▒▒                                         ");
            Console.WriteLine("         ▒▒▒▒      ▒▒▒▒                          ████████       ");
            Console.WriteLine("       ██████████████████                      ██▒▒▒▒▒▒▒▒██     ");
            Console.WriteLine("     ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██    ██████████████████▒▒████▒▒██     ");
            Console.WriteLine("     ██▒▒▒▒▒▒██████▒▒▒▒▒▒██  ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████▒▒██     ");
            Console.WriteLine("     ██▒▒▒▒▒▒██████▒▒▒▒▒▒██  ██▒▒██▒▒████████████▒▒████▒▒██     ");
            Console.WriteLine("     ██▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒██  ██▒▒██▒▒██        ██▒▒▒▒▒▒▒▒██     ");
            Console.WriteLine("     ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██    ██  ██            ████████       ");
            Console.WriteLine("     ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██                                     ");
            Console.WriteLine("       ██████████████████                                       ");
            AnsiConsole.Write(
            new FigletText("Locksmith")
                .LeftAligned()
                .Color(Color.Red));

            AnsiConsole.MarkupLine($"[bold yellow]Just a expert for secrets![/]");
            AnsiConsole.MarkupLine("[bold gray]repo: https://github.com/rodrigoramosrs/locksmith[/]");
        }

        private static void ExtractEmbededResources()
        {

            string resourceName = "Locksmith.CLI.lib.curl.windows.x64.curl_x64.zip";
            string outputName = "curl_x64.zip";
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            if (!Directory.Exists(@".\lib"))
                Directory.CreateDirectory(@".\lib");

            FileStream outputFileStream = new FileStream(@$".\lib\{outputName}", FileMode.OpenOrCreate);
            Stream res = currentAssembly.GetManifestResourceStream(resourceName);
            if (res != null)
            {
                res.CopyTo(outputFileStream);
                res.Close();
            }
            outputFileStream.Close();

            try
            {
                ZipFile.ExtractToDirectory(@$".\lib\{outputName}", @$".\lib");
            }
            catch (Exception)
            {


            }
            

        }
    }
}
