using System.Text;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;

        public Renovator(string name, string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;

        }

        public string Name { get; private set; }
        public string Type { get; private set; }
        public double Rate { get; private set; }
        public int Days { get; private set; }

        public bool Hired { get; set; } = false;

        public bool Paid { get; set; } = false;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {this.Name}");
            sb.AppendLine($"--Specialty: {this.Type}");
            sb.AppendLine($"--Rate per day: {this.Rate} BGN");
            return sb.ToString().TrimEnd();
        }
    }
}
