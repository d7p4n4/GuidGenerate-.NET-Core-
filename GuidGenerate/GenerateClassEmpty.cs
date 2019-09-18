using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GuidGenerate
{
    class GenerateClassEmpty
    {
        public static void generateClass(string templateName, string package, string className)
        {
            string[] text = readIn(templateName);

            string replaced = "";

            for (int i = 0; i < text.Length; i++)
            {
                replaced = replaced + text[i] + "\n";
            }

            replaced = replaced.Replace("#namespaceName#", package);
            replaced = replaced.Replace("#className#", className);
            replaced = replaced.Replace("#parentClassName#", className + "Algebra");

            writeOut(replaced, className);
        }

                public static string[] readIn(string fileName)
        {

            string textFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, fileName + ".txt");

            string[] text = File.ReadAllLines(textFile);

            return text;


        }

        public static void writeOut(string text, string fileName)
        {
            File.WriteAllText(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Generated\\" + fileName + ".cs"), text);

        }
    }
}
