using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchool
{
    public struct Mark
    {
        int value;

        public Mark(int value)
        {
            this.value = value;
        }

        public int Value
        {
            get { return value; }
        }

        public override string ToString()
        {
            return "" + value;
        }
    }

}
