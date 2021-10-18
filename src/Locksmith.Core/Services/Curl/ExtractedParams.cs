using System;
using System.Collections.Generic;
using System.Text;

namespace Locksmith.Core.Services.Curl
{
    public class ExtractedParams
    {
        public string Method { get; set; }
        public string URL { get; set; }
        public List<object> Headers { get; set; } = new List<object>();
        public List<object> Data { get; set; } = new List<object>();
        public string RawCurl { get; set; }

    }
}
