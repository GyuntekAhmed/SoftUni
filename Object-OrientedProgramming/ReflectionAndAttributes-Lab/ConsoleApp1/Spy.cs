using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        private StringBuilder sb;
        private Type classType;
        public Spy()
        {
            sb = new StringBuilder();
        }

        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields
                (BindingFlags.Public | BindingFlags.Instance |
                 BindingFlags.NonPublic | BindingFlags.Static);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {classType}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }
    }
}
