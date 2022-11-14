namespace ValidationAttributes.Utilities.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }


        public override bool IsValid(object obj)
        {
            if (obj is int val)
            {
                return val >= minValue && val <= maxValue;
            }

            return false;
        }
    }
}
