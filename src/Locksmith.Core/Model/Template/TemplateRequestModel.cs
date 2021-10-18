using System;
using System.Collections.Generic;
using System.Text;

namespace Locksmith.Core.Model.Template
{
    public class TemplateCommandModel
    {
        public string tool { get; set; }
        public string command { get; set; }
        public List<TemplateParameterModel> parameters { get; set; }
    }
}
