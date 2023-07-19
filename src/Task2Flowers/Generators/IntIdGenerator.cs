namespace Task2Flowers.Generators
{
    public class IntIdGenerator
    {
        private int value;

        public IntIdGenerator()
        {
            this.value = 1;
        }

        public IntIdGenerator(int initialValue)
        {
            this.value = initialValue;
        }
        public int GetNextValue()
        {
            return this.value++;
        }
        public int GetCurrentValue()
        {
            return this.value;
        }
    }
}
