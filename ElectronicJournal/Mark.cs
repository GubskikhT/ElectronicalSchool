using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal
{
    public enum MarkType
    {
        Scored, Binary
    }

    public struct Mark
    {
        MarkType type;
        int value;
        double weight;

        public Mark(MarkType type, int value, double weight = 1.0)
        {
            this.type = type;
            this.value = value;
            this.weight = weight;
        }

        public MarkType Type
        {
            get { return type; }
        }

        public int Value
        {
            get { return value; }
        }

        public double Weight
        {
            get { return weight; }
        }

        public override string ToString()
        {
            return "" + value;
        }
    }

}
