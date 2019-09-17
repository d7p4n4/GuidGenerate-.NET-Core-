﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GuidGenerate
{
    [AttributeUsage(AttributeTargets.All)]
    class GUID : Attribute
    {
        private string guid;

        public GUID()
        {
            this.guid = Guid.NewGuid().ToString();
        }

        public GUID(string value)
        {
            this.guid = value;
        }

        public string getGuid()
        {
            return guid;
        }
    }
}
