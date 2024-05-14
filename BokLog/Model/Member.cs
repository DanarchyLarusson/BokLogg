using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokLogg.Model
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfRegistry { get; set; } = DateTime.Now;
        public int NumberOfLoans { get; set; }
        public int NumberOfOverdueBooks { get; set; }

        public override string ToString()
        {
            string memberInfo = $"--------------------------------\n" +
                                $"Namn: {FirstName} {LastName}\n" +
                                $"Telefon: {ContactNumber}\n" +
                                $"Mail: {Email}\n" +
                                $"Registrerad: {DateOfRegistry.ToString("d")}\n" +
                                $"Antal Lån: {NumberOfLoans}\n" +
                                $"Försenade Lån: {NumberOfOverdueBooks}\n" +
                                $"--------------------------------\n";

            return memberInfo;
        }
    }

}
