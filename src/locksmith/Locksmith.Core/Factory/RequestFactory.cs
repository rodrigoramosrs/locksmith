using Locksmith.Core.Model.Request;
using Locksmith.Core.Services.Curl;
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


        public async static Task<string> ExecuteCurlRequest(string CurlCommand)
        {

            string contentResult = "";

            using (var request = new StringParser().CreateHttpRequest(CurlCommand))
            {
                
                HttpClient client = new HttpClient();
                var requestResult = await client.SendAsync(request);
                contentResult = await requestResult.Content.ReadAsStringAsync();
                try
                {
                    requestResult.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    Console.WriteLine(requestResult.ReasonPhrase);
                    Console.WriteLine(contentResult);
                }
                return contentResult;
            }
        }

    }
}
