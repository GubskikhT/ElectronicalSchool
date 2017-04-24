using ElectronicJournal;
using System;
using System.Runtime.Serialization;

namespace ElectronicSchool
{
    [DataContract]
    public struct Mark
    {
        [DataMember]
        public uint Value { get; private set; }

        [DataMember]
        public double Weight { get; private set; }

        public Mark(uint value, double weight = 1.0)
        {
            this.Value = Math.Min(AppConfiguration.MaxMarkValue, Math.Max(AppConfiguration.MinMarkValue, value));
            this.Weight = weight;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

}
