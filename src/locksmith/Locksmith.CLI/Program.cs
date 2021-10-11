using Locksmith.CLI.Command;
using Locksmith.Core.Factory;
using Locksmith.Core.Model.Platform;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Locksmith.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
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

            AnsiConsole.MarkupLine($"[bold yellow]Just a secret tester![/]");
            AnsiConsole.MarkupLine("[bold gray]repo: https://github.com/rodrigoramosrs/locksmith[/]");
        }
    }
}
