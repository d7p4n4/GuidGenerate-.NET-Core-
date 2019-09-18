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


            Dictionary<string, string> props = InsertGuid.getProps(typeof(PersonStart));

            Dictionary<string, string> attrs = InsertGuid.getAttrs(typeof(PersonStart));

            Boolean classAttr = InsertGuid.hasClassAttr(typeof(PersonStart));

            GenerateClass.generateClass("Template", "GuidGenerate", "Person", classAttr, props, attrs);

            /*InsertGuid.writeOut(generated, "Person");

            string[] algebraText = GenerateClassAlgebra.readIn("Template");
            string algebra = GenerateClassAlgebra.generateClass(algebraText, "GuidGenerate", "Person", props);
            GenerateClassAlgebra.writeOut(algebra, "Person");*/
        }
    }
}
