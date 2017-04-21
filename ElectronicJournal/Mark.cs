namespace ElectronicSchool
{

    public struct Mark
    {
        public uint Value { get; private set; }
        public uint MaxValue { get; private set; }
        public double Weight { get; private set; }

        public Mark(uint value, uint maxValue = 5, double weight = 1.0)
        {
            this.Value = value;
            this.MaxValue = maxValue;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

}
