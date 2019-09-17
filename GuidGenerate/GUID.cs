using System;
using System.Collections.Generic;
using System.Text;

namespace GuidGenerate
{
    [AttributeUsage(AttributeTargets.All)]
    class GUID : Attribute
    {
        private string Guid;

        public GUID(string value)
        {
            this.Guid = value;
        }

        public string getGuid()
        {
            return Guid;
        }
    }
}
