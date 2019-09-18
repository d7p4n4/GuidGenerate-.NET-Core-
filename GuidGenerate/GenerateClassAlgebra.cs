using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GuidGenerate
{
    class GenerateClassAlgebra
    {
        public static string generateClass(string[] text, string package, string className, Dictionary<string, string> map)
        {
            string replaced = "";
            string newLine = "";

            for(int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("#has#"))
                {
                    foreach(var p in map)
                    {
                        if(!p.Value.StartsWith("List") && !p.Value.StartsWith("Boolean") && !p.Value.StartsWith("Dictionary"))
                        {
                            newLine = text[i + 1].Replace("#propName#", p.Key.Substring(0, 1).ToUpper() + p.Key.Substring(1)) + "\n";
                            newLine = newLine + text[i + 2].Replace("#propName#", p.Key.Substring(0, 1).ToUpper() + p.Key.Substring(1)) + "\n";
                            newLine = newLine + "\n" + text[i + 3] + "\n" + text[i + 4] + "\n" + text[i + 5] + "\n" +
                                text[i+6] + "\n" + text[i+7] + "\n" + text[i+8] + "\n" + text[i+9];
                            replaced = replaced + newLine + "\n\n";
                        }
                    }

                    i = i + 9;
                }
                else if (text[i].Contains("#is#"))
                {
                    foreach (var p in map)
                    {
                        if (p.Value.StartsWith("Boolean"))
                        {
                            newLine = text[i + 1].Replace("#propName#", p.Key.Substring(0,1).ToUpper() + p.Key.Substring(1)) + "\n";
                            newLine = newLine + text[i + 2].Replace("#propName#", p.Key.Substring(0, 1).ToUpper() + p.Key.Substring(1)) + "\n";
                            newLine = newLine + "\n" + text[i + 3] + "\n";
                            replaced = replaced + newLine + "\n\n";
                        }
                    }

                    i = i + 3;
                }
                else if (text[i].Contains("#count#"))
                {
                    foreach (var p in map)
                    {
                        if (p.Value.StartsWith("List") || p.Value.StartsWith("Dictionary"))
                        {
                            newLine = text[i + 1].Replace("#propName#", p.Key.Substring(0, 1).ToUpper() + p.Key.Substring(1));
                            newLine = newLine + "\n" + text[i + 2] + "\n" + "\n" + text[i + 3] + "\n" + text[i + 4] + "\n";
                            newLine = newLine + text[i + 5].Replace("#propName#", p.Key.Substring(0, 1).ToUpper() + p.Key.Substring(1));
                            newLine = newLine + "\n" + text[i + 6] + "\n" + text[i + 7] + "\n" + text[i + 8] + "\n" +
                                text[i + 9] + "\n" + text[i + 10] + "\n" + text[i + 11] + "\n";
                            replaced = replaced + newLine + "\n\n";
                        }
                    }

                    i = i + 11;
                }
                else if (text[i].Contains("#countMember#"))
                {
                    foreach (var p in map)
                    {
                        if (p.Value.StartsWith("List") || p.Value.StartsWith("Dictionary"))
                        {
                            newLine = text[i + 1].Replace("#propName#", p.Key.Substring(0, 1).ToUpper() + p.Key.Substring(1));
                            newLine = newLine + "\n" + text[i + 2] + "\n" + "\n" + text[i + 3] + "\n" + text[i + 4] + "\n";
                            newLine = newLine + text[i + 5].Replace("#propName#", p.Key.Substring(0, 1).ToUpper() + p.Key.Substring(1));
                            newLine = newLine + "\n" + text[i + 6] + "\n" + text[i + 7] + "\n" + text[i + 8] + "\n" +
                                text[i + 9] + "\n" + text[i + 10] + "\n" + text[i + 11] + "\n" + text[i + 12] + "\n" + 
                                text[i + 13] + "\n" + text[i + 14] + "\n" + text[i + 15] + "\n" + text[i + 16] + "\n" + 
                                text[i + 17] + "\n" + text[i + 18] + "\n";
                            replaced = replaced + newLine + "\n\n";
                        }
                    }

                    i = i + 18;
                }
                else
                {
                    replaced = replaced + newLine + text[i] + "\n";
                }
                
                newLine = "";
            }
            replaced = replaced.Replace("#namespaceName#", package);
            replaced = replaced.Replace("#className#", className + "Algebra");
            replaced = replaced.Replace("#parentClassName#", className + "Base");

            return replaced;
        }

            public static string[] readIn(string fileName)
        {

            string textFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, fileName + "Algebra.txt");
            Console.WriteLine(textFile);

            string[] text = File.ReadAllLines(textFile);

            return text;


        }

        public static void writeOut(string text, string fileName)
        {
            File.WriteAllText(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\" + fileName + "Algebra.cs"), text);

        }
    }
}
