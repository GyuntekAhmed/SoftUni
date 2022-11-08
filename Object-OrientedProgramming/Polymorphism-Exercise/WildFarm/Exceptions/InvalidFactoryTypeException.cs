namespace WildFarm.Exceptions
{
    using System;

    public class InvalidFactoryTypeException : Exception
    {
        private const string DefaultMessage = "Invalid animal type!";

        public InvalidFactoryTypeException()
            : base(DefaultMessage)
        {

        }

        public InvalidFactoryTypeException(string message)
            : base(message)
        {

        }
    }
}