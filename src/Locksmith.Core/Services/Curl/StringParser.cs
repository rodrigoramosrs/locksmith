using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace Locksmith.Core.Services.Curl
{
    internal class StringParser
    {
        public HttpRequestMessage CreateHttpRequest(string RequestString)
        {
            string contentType = "text/plain";
            ExtractedParams details = Parse(RequestString);
            var request = new HttpRequestMessage();
            request.Method = new HttpMethod(details.Method);
            request.RequestUri = new Uri(details.URL);

            var hdrs = details.Headers.ToArray();
            foreach (var hd in hdrs)
            {
                if (hd.GetType() != typeof(string)) continue;
                string hdr = (string)hd;
                if (hdr == "") { continue; }
                var res = hdr.Split(':');
                string section = res[0].Trim();
                switch (section.ToLower())
                {
                    case "authorization":
                        request.Headers.TryAddWithoutValidation("Authorization", res[1].Trim());
                        break;
                    case "content-type":
                        contentType = res[1].Trim();
                        break;
                }
            }
            foreach (var content in details.Data)
            {
                string cnt = (string)content;
                cnt = cnt.Replace("\\\"", "\"");
                request.Content = new StringContent(cnt, Encoding.UTF8, contentType);
            }
            return request;
        }

        public ExtractedParams Parse(string RequestString)
        {

            RequestString = RequestString.Replace("\\\r\n", "").Replace("\r\n", "").Replace("\n", "");
            ExtractedParams p = new ExtractedParams();
            p.RawCurl = RequestString;
            bool hasPostData = false;
            StringBuilder postData = new StringBuilder();

            List<Dictionary<string, string>> x = new List<Dictionary<string, string>>();
            string[] options = RequestString.Split(new string[] { " --", " -" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in options)
            {
                bool matchd = false;
                int delimiter = item.IndexOf(" ");
                Dictionary<string, string> itm = new Dictionary<string, string>();
                string trimmed = item.Trim(new char[] { '\'', ' ' });
                if (delimiter <= 0)
                {
                    if (trimmed.IndexOf("http") != 0) { p.URL = trimmed; continue; }
                    continue;
                };
                string key = item.Substring(0, delimiter).Trim(new char[] { '-' });
                string value = item.Substring(delimiter).Trim().Trim(new char[] { '\'', '"' });
                switch (key.ToLower())
                {
                    case "header":
                    case "h":
                        p.Headers.Add(value); matchd = true;
                        break;
                    case "data":
                    case "d":
                        p.Data.Add(value); matchd = true;
                        break;
                    case "url":
                        p.URL = value; matchd = true;
                        break;
                    case "request":
                    case "x":
                        int notClean = value.IndexOf(" ");
                        p.Method = (notClean == -1) ? value : value.Substring(0, notClean); matchd = true;
                        break;
                    case "f":
                        string[] kv = value.Split('=');
                        postData.AppendUrlEncoded(kv[0].Trim(new char[] { '\'' }), kv[1].Trim(new char[] { '\'' })); hasPostData = true; matchd = true;
                        break;
                    case "u":
                        var dict = new Dictionary<string, string>();
                        var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(value));
                        dict.Add("Authorization", $"Basic {base64authorization}");
                        p.Headers.Add(dict);
                        matchd = true;
                        //request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");
                        break;
                };
                if (!matchd)
                {
                    if (trimmed.IndexOf("http") != -1) { p.URL = trimmed.Substring(trimmed.IndexOf("http")); continue; }
                }
                string pattern = @"(http|smtp|https):\/\/([\w,.,\/,-?=])*";
                Regex rg = new Regex(pattern);
                if (!rg.IsMatch(p.URL)) { p.URL = ""; }
                if (string.IsNullOrEmpty(p.URL))
                {
                    MatchCollection found = rg.Matches(trimmed);
                    if (found.Count > 0) { p.URL = found[0].Value; }
                }
            };

            if (hasPostData)
            {
                p.Data.Add(postData.ToString());
            }

            //return x;
            return p;
        }
    }
}
