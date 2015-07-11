using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Razor.Generator;
using CodeGeneratorBase;
using RazorEngine;
using RazorEngine.Templating;
using Encoding = System.Text.Encoding;


namespace HaisaCodeGenerator
{
    public  class CodeGeneratorHelper
    {
        public static void RunGenerate()
        {
            //var template = "";

            var templateFile = @"E:\Project\CodeGenerator\HaisaCodeGenerator\HaisaCodeGenerator\Templates\ListTemplate.cshtml";
            var outputFile = @"E:\Project\CodeGenerator\HaisaCodeGenerator\HaisaCodeGenerator\Views\Home\ListTemplate.cshtml";

            var generator = new CodeGeneratorCodeBase(Encoding.UTF8);
              var viewBag = new DynamicViewBag();
            viewBag.AddValue("test","hello haisa");

            //var result = generator.RunGenerate(templateFile,
            //    new
            //    {
            //        Name = "hiasa"
            //    },
            //viewBag);

            generator.RunGenerateAndOutPut(templateFile,
            new
            {
                Name = "hiasa"
            },
            viewBag, outputFile);

        }
    }
}
