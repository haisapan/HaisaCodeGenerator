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
using Encoding = System.Text.Encoding;

namespace CodeGeneratorBase
{
    public class CodeGeneratorCodeBase:ICodeGeneratorBase
    {
        /// <summary>
        /// Current generator encoding
        /// </summary>
        public Encoding CurrentEncoding { get; set; }
        public CodeGeneratorCodeBase():this(Encoding.UTF8)
        {
        }

        /// <summary>
        /// Ctor
        /// sometime wrong encoding may cause issue of different culture, user can set it self here
        /// </summary>
        /// <param name="encoding"></param>
        public CodeGeneratorCodeBase(Encoding encoding)
        {
            CurrentEncoding = encoding;
        }

        public string RunGenerateFromString(string content, object model = null, DynamicViewBag viewBag = null)
        {
                var result = Engine.Razor.RunCompile(content, "new", null, model);
                return result;
        }

        public string RunGenerate(string filePath, object model = null, DynamicViewBag viewBag = null)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("the complie file not exist:" + filePath);
            }

            using (StreamReader reader = new StreamReader(filePath, CurrentEncoding)) //Encoding.GetEncoding("gb2312")
            {
                var content = reader.ReadToEnd();
                var result = Engine.Razor.RunCompile(content, "new", null, model, viewBag);
                return result;
            }

        }

        public void RunGenerateAndOutPut(string filePath,object model, string outputFilePath )
        {
            this.RunGenerateAndOutPut(filePath, model, null, outputFilePath);
        }

        public void RunGenerateAndOutPut(string filePath, object model, DynamicViewBag viewBag, string outputFilePath)
        {
            var result = RunGenerate(filePath, model, viewBag);
            var directory=Path.GetDirectoryName(outputFilePath);
            if (string.IsNullOrEmpty(directory))
            {
                throw new Exception("the output filepath is not valid: "+outputFilePath);
            }
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            StreamWriter writer = new StreamWriter(outputFilePath, false, CurrentEncoding);
            //writer.AutoFlush = true;
            writer.Write(result);
            writer.Flush();
           
        }
    }
}
