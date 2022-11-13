namespace CommandPattern.Core.Commands
{
    using Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        private const int SUCCESS_EXIT_CODE = 0;

        public string Execute(string[] args)
        {
            Environment.Exit(SUCCESS_EXIT_CODE);

            return null;
        }
    }
}
