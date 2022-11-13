namespace CommandPattern
{
    using Core.IO;
    using Core.IO.Contracts;
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command, reader, writer);
            engine.Run();
        }
    }
}
