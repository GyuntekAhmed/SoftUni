using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isPasswordLenghtValid = ValidatePasswordLenght(password);
            bool isPasswordContainsValidSymbol = ValidatePasswordText(password);
            bool isDigitInPasswordAtLeastTwo = ValidatePasswordDigit(password);

            if (!isPasswordLenghtValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!isPasswordContainsValidSymbol)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!isDigitInPasswordAtLeastTwo)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isDigitInPasswordAtLeastTwo&&isPasswordContainsValidSymbol&&isPasswordLenghtValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool ValidatePasswordDigit(string password)
        {
            int count = 0;
            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    count++;
                }
            }

            return count >= 2;
        }

        static bool ValidatePasswordText(string password)
        {
            foreach (char symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }

            }
            return true;
        }

        static bool ValidatePasswordLenght(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }
    }
}
