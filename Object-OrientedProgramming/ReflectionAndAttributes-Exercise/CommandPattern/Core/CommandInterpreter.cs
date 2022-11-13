
namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Common;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandSplit = args.Split();

            string commandName = commandSplit[0];
            string[] commandArgs = commandSplit.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command" &&
                                     t.GetInterfaces().Any(i => i == typeof(ICommand)));
            if (commandType == null)
            {
                throw new InvalidOperationException
                    (string.Format(ErrorMessages.InvalidCommandType, $"{commandName}Command"));
            }
            
            object commandInstance = Activator.CreateInstance(commandType);

            MethodInfo commandMethod = commandType
                .GetMethods()
                .First(m => m.Name == "Execute");

            string result = (string)commandMethod.Invoke(commandInstance, new object[] { commandArgs });

            return result;
        }
    }
}
