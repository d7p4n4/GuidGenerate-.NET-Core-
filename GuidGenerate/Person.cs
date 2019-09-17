using System;

namespace GuidGenerate
{
    public class Person
    {
        [GUID()]
        public string name { get; set; }
        public string address { get; set; }

    }
}
