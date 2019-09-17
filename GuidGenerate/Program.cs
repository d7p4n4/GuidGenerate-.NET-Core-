using System;

namespace GuidGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertGuid.searchForGuid(typeof(Person), "Person", "Person");
        }
    }
}
