using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HaisaCodeGenerator
{
    public class CodeGeneratorHelper
    {
        private void RunGenerate()
        {
            var template = "";

            var templateFile =
                @"D:\Users\haisa.pan\Documents\Visual Studio 2013\Projects\HaisaCodeGenerator\HaisaCodeGenerator\1.cshtml";
            string content = System.IO.File.ReadAllText(templateFile);
            var result = Engine.Razor.RunCompile(content, "new", null,
                new
                {
                    Name = "haisa"
                });
            var test = "";
        }
    }
}
