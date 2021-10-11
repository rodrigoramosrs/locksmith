using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Locksmith.Core.Model.Request
{
    public class RequestModel
    {
        public RequestModel()
        {
            Headers = new Dictionary<string, string>();
        }
        public string Url { get; set; } 
        public string Content { get; set; }
        public string Method { get; set; }
        public Dictionary<string,string> Headers { get; set; }
}
}
