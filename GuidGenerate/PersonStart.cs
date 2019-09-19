using System;
using System.Collections.Generic;

namespace GuidGenerate
{
    [Persistent()]
    public class PersonStart
    {
        public int id { get; set; }
        [GUID()]
        public string name { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public Boolean gender { get; set; }
        public List<string> list { get; set; }

    }
}