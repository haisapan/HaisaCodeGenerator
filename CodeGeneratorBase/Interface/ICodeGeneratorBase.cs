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
        string RunGenerate(string filePath,  object model = null);
        string RunGenerate(string filePath, object model = null,  DynamicViewBag viewBag = null);
        void RunGenerate(string filePath, string outputFilePath,object model = null);

        void RunGenerate(string filePath, string outputFilePath, object model = null, DynamicViewBag viewBag = null);
    }
}
