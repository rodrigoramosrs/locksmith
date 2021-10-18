using Locksmith.Core.Model.Core;
using Locksmith.Core.Model.Platform;
using Locksmith.Core.Model.Request;
using Locksmith.Core.Model.Template;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Locksmith.Core.Factory
{
    public static class KeyChainTesterFactory
    {
        public static List<KeychainTestResult> TestSecret(TemplateModel testTemplate, Dictionary<int, Dictionary<int, string>> secretParameters)
        {
            List<KeychainTestResult> result = new List<KeychainTestResult>();

            for (int i = 0; i < testTemplate.commands.Count; i++)
            {
                var currentCommandTest = testTemplate.commands[i];
                var currentParameter = secretParameters[i];

                string output = RunSecretTest(currentCommandTest, currentParameter);

                result.Add(new KeychainTestResult() { RawResponse = output });
            }

            return result;// RequestFactory.ExecuteRequest(requestObj).GetAwaiter().GetResult();
        }

        private static string RunSecretTest(TemplateCommandModel templateCommand, Dictionary<int, string> parametersValue)
        {
            string result = string.Empty;
            string command = templateCommand.command;

            for (int i = 0; i < templateCommand.parameters.Count; i++)
            {
                var parameter = templateCommand.parameters[i];
                var parameterValue = parametersValue[i];

                command = command.Replace(parameter.key, parameterValue);
            }

            switch (templateCommand.tool.ToLower())
            {
                case "curl":
                default:
                    result = Factory.RequestFactory.ExecuteCurlRequest(command);
                    break;
            }

            return result;
        }


    }
}
