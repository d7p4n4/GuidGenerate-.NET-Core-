using System;
using System.Collections.Generic;
using System.Text;

namespace GuidGenerate
{
    class GenerateClass
    {
        public static string generateClass(string[] text, string package, string namespaceName, Boolean classAttr, Dictionary<string, string> map, Dictionary<string, string> guid)
        {
            string replaced = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals("#properties#"))
                {
                    foreach (var pair in map)
                    {
                        foreach (var g in guid)
                        {
                            Console.WriteLine(g.Key + pair.Key + " value: " + g.Value);
                            if (g.Key.Equals(pair.Key) && g.Value.Equals(""))
                            {
                                string rand = RandomString.randomString(8);

                                string newLine = "            [GUID(\"" + rand + "\")]\n";
                                newLine = newLine + text[i + 1].Replace("#type#", pair.Value);
                                newLine = newLine.Replace("#prop#", pair.Key);

                                replaced = replaced + "\n" + newLine;
                                break;
                            }
                            else if (g.Key.Equals(pair.Key))
                            {
                                string newLine = "            [GUID(\"" + g.Value + "\")]\n";
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
                        newLine = newLine.Replace("#getProp#", "get" + pair.Key);

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
                        string newLine = text[i + 1].Replace("#setProp#", "set" + pair.Key);
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
                        string rand = RandomString.randomString(8);

                        string newLine = "\n       [GUID(\"" + rand + "\")]\n";
                        replaced = replaced + newLine + text[i];
                    }
                }
                else
                {
                    replaced = replaced + "\n" + text[i];
                }
            }
            replaced = replaced.Replace("#namespaceName#", package);
            
            replaced = replaced.Replace("#className#", namespaceName);

            return replaced;
        }
    }
}
