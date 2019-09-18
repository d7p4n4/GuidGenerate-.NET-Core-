using System;
using System.Collections.Generic;
using System.Text;

namespace GuidGenerate
{
    class PersonAlgebra : Person
    {
        public Boolean hasName()
        {
            if(this.name != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean isGender()
        {
            return this.gender;
        }

        public int countList()
        {
            int i = 0;
            foreach(var o in this.list)
            {
                i = i + 1;
            }
            return i;
        }

        public bool hasListMember()
        {
            int i = 0;
            foreach (var o in this.list)
            {
                i = i + 1;
            }

            if(i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
