using System;
using System.Collections.Generic;
using System.Reflection;

namespace GuidGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertGuid.searchForGuid(typeof(Person), "Person", "Person");

            string[] text = InsertGuid.readIn("Template");


            Dictionary<string, string> props = InsertGuid.getProps(typeof(Person));

            Dictionary<string, string> attrs = InsertGuid.getAttrs(typeof(Person));

            Boolean classAttr = InsertGuid.hasClassAttr(typeof(Person));

            string generated = GenerateClass.generateClass(text, "GuidGenerate", "Osztaly", classAttr, props, attrs);

            InsertGuid.writeOut(generated, "uj");
        }
    }
}
