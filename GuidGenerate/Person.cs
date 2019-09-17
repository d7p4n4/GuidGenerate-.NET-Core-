using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GuidGenerate
{
    public class Person
    {
        [GUID("0000-8")]
        public string name { get; set; }
        public string address { get; set; }

    }
}
