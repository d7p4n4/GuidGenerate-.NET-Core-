using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GuidGenerate
{
    public class InsertGuid
    {

        public static Dictionary<string, string> getProps(Type anyType)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            PropertyInfo[] prop = anyType.GetProperties();

            foreach(var p in prop)
            {
                props.Add(p.Name, p.PropertyType.ToString().Substring(p.PropertyType.ToString().IndexOf(".") + 1));
            }

            return props;
        }

        public static Dictionary<string, string> getAttrs(Type anyType)
        {
            Dictionary<string, string> attrs = new Dictionary<string, string>();

            PropertyInfo[] prop = anyType.GetProperties();

            foreach (var p in prop)
            {
                Object[] attr = p.GetCustomAttributes(typeof(GUID), false);
                if(attr.Length != 0)
                {
                    GUID guid = (GUID)attr[0];
                    attrs.Add(p.Name, guid.getGuid());
                }
                else
                {
                    attrs.Add(p.Name, "");
                }
            }

            return attrs;
        }

        public static Boolean hasClassAttr(Type anyType)
        {
            Boolean value = false;

            Attribute classAttr = anyType.GetCustomAttribute(typeof(GUID), false);

            if(classAttr != null)
            {
                value = true;
            }

            return value;
        }
        public static string searchForGuid(Type anyType, string fileNameIn, string fileNameOut)
        {
            List<string> propWithoutGuid = new List<string>();
            string[] text = readIn(fileNameIn);
            string replaced = "";
            string newLine = "";

            foreach (string line in text)
            {
                Console.WriteLine(line);
            }

            PropertyInfo[] prop = anyType.GetProperties();
            Attribute classAttr = anyType.GetCustomAttribute(typeof(GUID), false);
            Console.WriteLine(prop.Length);

            for (int i = 0; i < prop.Length; i++)
            {
                Object[] attrs = prop[i].GetCustomAttributes(typeof(GUID), false);
                if (attrs.Length == 0)
                {
                    propWithoutGuid.Add("" + prop[i].Name);
                }
            }

            for (int i = 0; i < text.Length; i++)
            {

                foreach (string propName in propWithoutGuid)
                {
                    if (text[i].Contains(propName + " { get; set; }"))
                    {
                        newLine = "        [GUID(\"0000-" + i + "\")]\n";
                        break;
                    }
                }

                if (text[i].Contains("class"))
                {
                    if (classAttr == null)
                    {
                        newLine = "    [GUID(\"0000-" + i + "\")]\n";
                    }
                }
                replaced = replaced + newLine + text[i] + "\n";
                newLine = "";
                Console.WriteLine(text[i]);
            }

            Console.WriteLine(replaced);

            writeOut(replaced, fileNameOut);
            return replaced;
        }

        public static string[] readIn(string fileName)
        {

            string textFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).FullName, fileName + ".cs");
            Console.WriteLine(textFile);

            string[] text = File.ReadAllLines(textFile);

            return text;


        }

        public static void writeOut(string text, string fileName)
        {
            System.IO.File.WriteAllText(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).FullName + "\\" + fileName + ".cs"), text);
            Console.WriteLine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\" + fileName + ".cs");
        }
    }
}
