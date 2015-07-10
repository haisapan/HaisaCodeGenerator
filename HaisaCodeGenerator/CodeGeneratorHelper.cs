using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Razor.Generator;
using CodeGeneratorBase;
using RazorEngine;
using RazorEngine.Templating;


namespace HaisaCodeGenerator
{
    public  class CodeGeneratorHelper
    {
        public static void RunGenerate()
        {
            //var template = "";

            var templateFile =@"E:\Project\CodeGenerator\HaisaCodeGenerator\HaisaCodeGenerator\Templates\1.cshtml";

            var generator = new CodeGeneratorCodeBase();
              var viewBag = new DynamicViewBag();
            viewBag.AddValue("test","hello haisa");

            var result=generator.RunGenerate(templateFile,
                new{
                Name = "hiasa"
            }, 
            viewBag);

        }
    }
}
