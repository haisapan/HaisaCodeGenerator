using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using RazorEngine.Templating;

namespace CodeGeneratorBase.Interface
{
    public interface ICodeGeneratorBase
    {
        string RunGenerateFromString(string content, object model = null, DynamicViewBag viewBag = null);
        string RunGenerate(string filePath, object model = null,  DynamicViewBag viewBag = null);
        void RunGenerateAndOutPut(string filePath, object model , string outputFilePath);

        void RunGenerateAndOutPut(string filePath, object model , DynamicViewBag viewBag, string outputFilePath);
    }
}
