
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        private string model;

        public Smartphone(string model)
        {
            this.model = model;
        }

        public string Website(string website)
        {

            bool hasDigit = website.Any(char.IsDigit);
            if (hasDigit)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Invalid URL!");
                return sb.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Browsing: {website}!");
                return sb.ToString();
            }
        }

        public string PhoneNumber(string phoneNumber)
        {
            bool hasCharacter = phoneNumber.Any(char.IsLetter);
            if (hasCharacter)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Invalid number!");
                return sb.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Calling... {phoneNumber}");
                return sb.ToString();
            }
        }
    }
}
