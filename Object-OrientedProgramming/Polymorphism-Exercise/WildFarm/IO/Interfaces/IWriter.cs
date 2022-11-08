namespace WildFarm.IO.Interfaces
{
    public interface IWriter
    {
        // Every type in c# can be casted as an object
        void Write(object value);

        void WriteLine(object value);
    }
}
