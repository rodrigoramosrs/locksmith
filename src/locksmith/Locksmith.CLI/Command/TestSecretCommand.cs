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



        private async Task Boot()
        {
            var secretContent = PromptSecret();

            var selectedTestOption = PromptTest();

            var endpoint = PromptEndpoint();

            TestSecret(selectedTestOption, secretContent);

        }

        private void TestSecret(eTestType SelectedTestEnum, string Secret)
        {
            _console.Status()
                            .Start("[yellow]Testing...[/]", ctx =>
                            {
                                ctx.Status("[bold blue]Testing secret agains api, please wait...[/]");
                                Thread.Sleep(1000);
                                KeyChainTesterFactory.TestSecret(SelectedTestEnum, Secret);
                            });
        }

        private string PromptSecret()
        {
            return _console.Prompt(
                        new TextPrompt<string>("[grey][[required]][/] [bold red]Paste secret you want to test[/]?"));
        }

        private string PromptEndpoint()
        {
            var selectedTestOption = _console.Prompt(
                        new TextPrompt<string>("[grey][[optional]][/] [bold red]Paste endpoint to test[/]?").AllowEmpty());

            if (!string.IsNullOrEmpty(selectedTestOption))
                _console.WriteLine($"Ok. Let's try {selectedTestOption}.");

            return selectedTestOption;
        }

        private eTestType PromptTest()
        {
            var options = Enum.GetValues(typeof(eTestType)).Cast<eTestType>().Select(x => $"{(int)x} - {x.ToString().Replace("_", " ")}").ToList();

            var selectedTest = _console.Prompt(
                            new SelectionPrompt<string>()
                                .HighlightStyle("red")
                                .Title("[grey][[required]][/] [bold red]Which test do you want to execute[/]?")
                                .PageSize(20)
                                .MoreChoicesText("[grey](Move up and down to reveal more test type)[/]")
                                .AddChoiceGroup("Available tests:", options));

            _console.MarkupLine($"[grey][[required]][/] [bold red]Which test do you want to execute[/]? {selectedTest}");
            
            return (eTestType)Convert.ToInt32(selectedTest.Split(' ')[0]);
            //
        }
    }
}
