using Locksmith.Core.Factory;
using Locksmith.Core.Model.Platform;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locksmith.CLI.Command
{
    public class TestSecretCommand : Command<TestSecretCommand.Settings>
    {
        private readonly IAnsiConsole _console;

        public class Settings : CommandSettings
        {
            [CommandArgument(0, "[EXAMPLE]")]
            [Description("The example to run.\nIf none is specified, all examples will be listed")]
            public string Name { get; set; }

            [CommandOption("-s|--secret")]
            [Description("Secret to test")]
            public bool Secret { get; set; }

            [CommandOption("-t|--Test")]
            [Description("Select test do you want")]
            public int Test { get; set; }

        }


        public TestSecretCommand(IAnsiConsole console)
        {
            _console = console;
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            Boot().GetAwaiter().GetResult();
            return 0;
        }



        private async static Task Boot()
        {
            var options = Enum.GetNames(typeof(eTestType)).Select(x => x.Replace("_", " ")).ToList();

            string secretContent = PromptSecret();

            string selectedTestOption = SelectTest(options);

            string endpoint = PromptEndpoint();

            AnsiConsole.WriteLine($"Ok. Let's try {selectedTestOption}.");

            var SelectedTestEnum = Enum.Parse(typeof(eTestType), selectedTestOption.Replace(" ", "_"));

            TestSecret((eTestType)SelectedTestEnum, secretContent);

        }

        private static void TestSecret(eTestType SelectedTestEnum, string Secret)
        {
            AnsiConsole.Status()
                            .Start("[yellow]Testing...[/]", ctx =>
                            {
                                ctx.Status("[bold blue]Testing secret agains api, please wait...[/]");
                                Thread.Sleep(1000);
                                KeyChainTesterFactory.TestSecret(SelectedTestEnum, Secret);
                            });
        }

        private static string PromptSecret()
        {
            return AnsiConsole.Prompt(
                        new TextPrompt<string>("[grey][[required]][/] [bold red]Paste secret you want to test[/]?"));
        }

        private static string PromptEndpoint()
        {
            return AnsiConsole.Prompt(
                        new TextPrompt<string>("[grey][[optional]][/] [bold red]Paste endpoint to test[/]?").AllowEmpty());
        }

        private static string SelectTest(List<string> options)
        {
            return AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .HighlightStyle("red")
                                .Title("[grey][[required]][/] [bold red]Which test do you want to execute[/]?")
                                .PageSize(20)
                                .MoreChoicesText("[grey](Move up and down to reveal more test type)[/]")
                                .AddChoiceGroup("Available tests:", options));
        }
    }
}
