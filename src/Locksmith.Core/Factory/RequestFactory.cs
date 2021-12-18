using Locksmith.Core.Model.Request;
using Locksmith.Core.Services.Curl;
using Locksmith.Core.Services.Shell;
using Locksmith.Core.Services.Shell.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Locksmith.Core.Factory
{
    public static class RequestFactory
    {
        public async static Task<HttpResponseMessage> ExecuteRequest(RequestModel requestModel)
        {
            if (requestModel == null) throw new ArgumentException("requestModel cannot be null");

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod(requestModel.Method), requestModel.Url))
                {
                    request.Content = new StringContent(requestModel.Content);
                    foreach (var item in requestModel.Headers)
                    {
                        request.Content.Headers.Add(item.Key, item.Value);
                    }

                    return await httpClient.SendAsync(request);
                }
            }
        }


        public static string ExecuteCurlRequest(string CurlCommand)
        {
            string result;
            string rootPath = @".\curl";
            if (OSUtils.IsWin())
                rootPath = OSUtils.GetWindowsShortPath($"{Environment.CurrentDirectory}\\lib\\curl.exe");
            else
                CurlCommand = CurlCommand.Replace("\\\"", "\"");

            result = ShellService.Execute($@"{rootPath} {CurlCommand}");
            return result;
        }

    }
}
