using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RazorEngine;
using RazorEngine.Templating;


namespace HaisaCodeGenerator
{
    public  class CodeGeneratorHelper
    {
        public static void RunGenerate()
        {
            var template = "";

            var templateFile =
                //@"D:\Users\haisa.pan\Documents\Visual Studio 2013\Projects\HaisaCodeGenerator\HaisaCodeGenerator\1.cshtml";
                @"E:\Project\CodeGenerator\HaisaCodeGenerator\HaisaCodeGenerator\Templates\1.cshtml";
            string content = File.ReadAllText(templateFile);

             var viewBag = new RazorEngine.Templating.DynamicViewBag();
            viewBag.AddValue("test","testValue");
            var result = Engine.Razor.RunCompile(content, "new", null,
                new
                {
                    Name = "haisa"
                },viewBag);

            var test = "";

           

            Engine.Razor.RunCompile("@ViewBag.Name", null, viewBag);

        }
    }
}
