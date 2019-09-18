using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GuidGenerate
{
    class GenerateClassEmpty
    {
        public static void generateClass(string templateName, string languageExtension, string package, string className)
        {
            string[] text = readIn(templateName, languageExtension);

            string replaced = "";

            for (int i = 0; i < text.Length; i++)
            {
                replaced = replaced + text[i] + "\n";
            }

            replaced = replaced.Replace("#namespaceName#", package);
            replaced = replaced.Replace("#className#", className);
            replaced = replaced.Replace("#parentClassName#", className + "Algebra");

            writeOut(replaced, className, languageExtension);
        }

                public static string[] readIn(string fileName, string languageExtension)
        {

            string textFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Templates\\", fileName + "." + languageExtension + "T");

            string[] text = File.ReadAllLines(textFile);

            return text;


        }

        public static void writeOut(string text, string fileName, string languageExtension)
        {
            File.WriteAllText(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Generated\\" + fileName + "." + languageExtension), text);

        }
    }
}
