using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Mvc;
using CodeGeneratorBase.Interface;
using RazorEngine;
using RazorEngine.Templating;

namespace CodeGeneratorBase
{
    public class CodeGeneratorCodeBase:ICodeGeneratorBase
    {
        //public DynamicViewBag ViewBag { get; set; }

        public CodeGeneratorCodeBase()
        {
            
        }

        public string RunGenerateFromString(string content, object model = null, DynamicViewBag viewBag = null)
        {
                var result = Engine.Razor.RunCompile(content, "new", null, model);
                return result;
        }
        //public string RunGenerate(string filePath, object model = null)
        //{
        //    return this.RunGenerate(filePath, model, null);
        //}

        public string RunGenerate(string filePath, object model = null, DynamicViewBag viewBag = null)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("the complie file not exist:" + filePath);
            }

            string content = File.ReadAllText(filePath);
            var result = Engine.Razor.RunCompile(content, "new", null, model, viewBag);
            return result;
            //if (viewBag != null){

            //    var result = Engine.Razor.RunCompile(content, "new", null, model, viewBag);
            //    return result;
            //}
            //else
            //{
            //    var result = Engine.Razor.RunCompile(content, "new", null, model);
            //    return result;
            //}
        }

        public void RunGenerateAndOutPut(string filePath,object model, string outputFilePath )
        {
            this.RunGenerateAndOutPut(filePath, model, null, outputFilePath);
        }

        public void RunGenerateAndOutPut(string filePath, object model, DynamicViewBag viewBag, string outputFilePath)
        {
            var result = RunGenerate(filePath, model, viewBag);
            using (FileStream fileStream = new FileStream(outputFilePath, FileMode.OpenOrCreate))
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(result);
                fileStream.Write(bytes,0, bytes.Length);
            }
        }
    }
}
