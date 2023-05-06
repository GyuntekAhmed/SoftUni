namespace SulsApp
{
    public static class Program
    {
        public static void Main()
        {
            var db = new SulsDbContext();
            db.Database.EnsureCreated();
        }
    }
}