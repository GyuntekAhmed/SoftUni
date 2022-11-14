namespace ValidationAttributes.Models
{
    using Utilities.Attributes;

    public class Person
    {
        private const int AgeMinValue = 12;
        private const int AgeMaxValue = 90;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(AgeMinValue, AgeMaxValue)]
        public int Age { get; set; }
    }
}
