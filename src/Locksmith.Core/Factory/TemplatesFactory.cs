using Locksmith.Core.Model.Template;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Locksmith.Core.Factory
{
    public static class TemplatesFactory
    {
        private static readonly IDeserializer _ymlDesserializer;
        static TemplatesFactory()
        {
            _ymlDesserializer = new DeserializerBuilder()
                     .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
                     .Build();
        }
        public static List<TemplateModel> GetTemplatesFromFolder(string Folder = @".\Templates")
        {
            List<TemplateModel> result = new List<TemplateModel>();

            foreach (var ymlFile in Directory.GetFiles(Folder, "*.yml", SearchOption.AllDirectories))
            {
                result.Add(_ymlDesserializer.Deserialize<TemplateModel>(File.ReadAllText(ymlFile)));
            }

            return result;
        }

        //private static string CreateSampleYML()
        //{

        //    var serializer = new SerializerBuilder()
        //                    .WithNamingConvention(UnderscoredNamingConvention.Instance)
        //                    .Build();
        //    TemplateModel teste = new TemplateModel();
        //    teste.commands = new List<TemplateCommandModel>();
        //    teste.commands.Add(new TemplateCommandModel()
        //    {
        //        tool=  "curl",
        //        command = "\"api_endpoint_here\" -H \"x - api - key: your_api_key\"",
        //        parameters = new List<TemplateParameterModel>()
        //        {
        //            new TemplateParameterModel()
        //            {
        //                description = "description",
        //                key = "key"
                       
        //            },
        //            new TemplateParameterModel()
        //            {
        //                description = "description1",
        //                key = "key1"
        //            }
        //        }
        //    });

        //    var result =  serializer.Serialize(teste);
        //    return result;
        //}
    }
}
