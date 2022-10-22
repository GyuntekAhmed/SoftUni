using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count => Multiprocessor.Count;


        public void Add(CPU cpu)
        {
            if (Capacity >= Count)
            {
                
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            foreach (var item in Multiprocessor)
            {
                if (item.Brand == brand)
                {
                    Multiprocessor.Remove(item);
                    return true;
                }
            }

            return false;
        }

        public CPU MostPowerful()
        {
            var PowerFul = Multiprocessor.Max(x => x.Frequency);
            var best = Multiprocessor.FirstOrDefault(x => x.Frequency == PowerFul);

            return best;
        }

        public CPU GetCPU(string brand)
        {
            foreach (var cpu in Multiprocessor)
            {
                if (cpu.Brand == brand)
                {
                    return cpu;
                }
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {this.Model}:");

            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
