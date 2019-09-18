using System;
using System.Collections.Generic;
using System.Text;

namespace GuidGenerate
{
    class GenerateClass
    {
        public static string generateClass(string[] text, string package, string className, Boolean classAttr, Dictionary<string, string> map, Dictionary<string, string> guid)
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
                            if (g.Key.Equals(pair.Key) && g.Value.Equals(""))
                            {
                                Guid id = Guid.NewGuid();

                                string newLine = "            [GUID(\"" + id + "\")]\n";
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
                        newLine = newLine.Replace("#getProp#", "get" + pair.Key.Substring(0, 1).ToUpper() + pair.Key.Substring(1));

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
                        string newLine = text[i + 1].Replace("#setProp#", "set" + pair.Key.Substring(0, 1).ToUpper() + pair.Key.Substring(1));
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

                        string newLine = "\n       [GUID(\"" + id + "\")]\n";
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

            return replaced;
        }
    }
}
