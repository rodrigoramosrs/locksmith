using System;
using System.Collections.Generic;
using System.Text;

namespace Locksmith.Core.Model.Template
{
    public class TemplateModel
    {
        public string title { get; set; }
        public string url { get; set; }
        public string details { get; set; }
        public List<TemplateCommandModel> commands { get; set; }
        public string regex { get; set; }

    }
}
