using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GuidGenerate
{
    class GenerateClass
    {
        public static void generateClass(string fileName, string languageExtension, string package, string className, Boolean classAttr, Dictionary<string, string> map, Dictionary<string, string> guid)
        {
            string[] text = readIn(fileName, languageExtension);
            string replaced = "";

            for (int i = 0; i < text.Length; i++)
            {
                if(text[i].Equals("#constructor#"))
                {
                    string propNames = "";
                    string newLine = "";

                    foreach(var pair in map)
                    {
                        propNames = propNames + pair.Key + ", ";
                    }
                    newLine = text[i + 1].Replace("#allProps#", propNames.Substring(0, propNames.Length - 2)) + "\n";
                    foreach(var pair in map)
                    {
                        newLine = newLine + text[i + 2].Replace("#prop#", pair.Key) + "\n";
                    }
                    newLine = newLine + text[i + 3];

                    replaced = replaced + "\n" + newLine;

                    i = i + 3;
                }
                else if (text[i].Equals("#properties#"))
                {
                    foreach (var pair in map)
                    {
                        foreach (var g in guid)
                        {
                            if (g.Key.Equals(pair.Key) && g.Value.Equals(""))
                            {
                                Guid id = Guid.NewGuid();
                                string newLine = "";

                                if (languageExtension.Equals("cs"))
                                {
                                    newLine = "            [GUID(\"" + id + "\")]\n";
                                } else if (languageExtension.Equals("java"))
                                {
                                    newLine = "            @GUID(\"" + id + "\")\n";
                                }
                                newLine = newLine + text[i + 1].Replace("#type#", pair.Value);
                                newLine = newLine.Replace("#prop#", pair.Key);

                                replaced = replaced + "\n" + newLine;
                                break;
                            }
                            else if (g.Key.Equals(pair.Key))
                            {
                                string newLine = "";

                                if (languageExtension.Equals("cs"))
                                {
                                    newLine = "            [GUID(\"" + g.Value + "\")]\n";
                                }
                                else if (languageExtension.Equals("java"))
                                {
                                    newLine = "            @GUID(\"" + g.Value + "\")\n";
                                }
                                newLine = newLine + text[i + 1].Replace("#type#", pair.Value);
                                newLine = newLine.Replace("#prop#", pair.Key);

                                replaced = replaced + "\n" + newLine;
                                break;
                            }
                        }
                    }
                    i++;
                }
                else if (text[i].Equals("#getter#"))
                {
                    foreach (var pair in map)
                    {
                        string newLine = text[i + 1].Replace("#type#", pair.Value);
                        newLine = newLine.Replace("#prop#", pair.Key.Substring(0, 1).ToUpper() + pair.Key.Substring(1));

                        replaced = replaced + "\n" + newLine;

                        newLine = text[i + 2].Replace("#prop#", pair.Key);
                        replaced = replaced + "\n" + newLine + "\n        }\n";
                    }
                    i = i + 3;
                }
                else if (text[i].Equals("#setter#"))
                {
                    foreach (var pair in map)
                    {
                        string newLine = text[i + 1].Replace("#prop#", pair.Key.Substring(0, 1).ToUpper() + pair.Key.Substring(1));
                        newLine = newLine.Replace("#type#", pair.Value);

                        replaced = replaced + "\n" + newLine;

                        newLine = text[i + 2].Replace("#prop#", pair.Key);
                        replaced = replaced + "\n" + newLine + "\n        }\n";
                    }
                    i = i + 3;
                }
                else if (!classAttr && text[i].Contains("public class #className#"))
                {
                    if (text[i].Contains("#className#"))
                    {
                        Guid id = Guid.NewGuid();
                        string newLine = "";

                        if (languageExtension.Equals("cs"))
                        {
                            newLine = "            [GUID(\"" + id + "\")]\n";
                        }
                        else if (languageExtension.Equals("java"))
                        {
                            newLine = "            @GUID(\"" + id + "\")\n";
                        }
                        replaced = replaced + newLine + text[i];
                    }
                }
                else
                {
                    replaced = replaced + "\n" + text[i];
                }
            }
            replaced = replaced.Replace("#namespaceName#", package);
            replaced = replaced.Replace("#className#", className + "Base");

            writeOut(replaced, className, languageExtension);

            GenerateClassAlgebra.generateClass(fileName, languageExtension, package, className, map);
        }

        public static string[] readIn(string fileName, string languageExtension)
        {

            string textFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Templates\\", fileName + "Base." + languageExtension + "T");

            string[] text = File.ReadAllLines(textFile);

            return text;


        }

        public static void writeOut(string text, string fileName, string languageExtension)
        {
            System.IO.File.WriteAllText(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Generated\\" + fileName + "Base." + languageExtension), text);

        }
    }
}
