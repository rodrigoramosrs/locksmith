using System;
using System.Collections.Generic;
using System.Text;

namespace Locksmith.Core.Model.Core
{
    public class KeychainTestResult
    {
        public bool RawResponse { get; set; }
        public bool Success { get; set; }

        public string Info { get; set; }

        public string DocumentationUrl { get; set; }
    }
}
