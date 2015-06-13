using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Mvc;
using CodeGeneratorBase.Interface;
using RazorEngine.Templating;

namespace CodeGeneratorBase
{
    public class CodeGeneratorBase:ICodeGeneratorBase
    {
        public DynamicViewBag ViewBag { get; set; }
     
        public CodeGeneratorBase()
        {
            
        }

        public string RunGenerate(string filePath, object model = null)
        {
            throw new NotImplementedException();
        }

        public string RunGenerate(string filePath, object model = null, DynamicViewBag viewBag = null)
        {
            throw new NotImplementedException();
        }

        public void RunGenerate(string filePath, string outputFilePath, object model = null)
        {
            throw new NotImplementedException();
        }

        public void RunGenerate(string filePath, string outputFilePath, object model = null, DynamicViewBag viewBag = null)
        {
            throw new NotImplementedException();
        }
    }
}
