using System;

namespace Animals
{
    public class Cat : Animals
    {
        public Cat(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow meow";
        }
    }
}
