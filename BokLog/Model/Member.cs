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
        public DateTime DateOfRegistry { get; set; } = DateTime.Now;
        public int NumberOfLoans { get; set; }
        public int NumberOfOverdueBooks { get; set; }
        public int NumberOfFailedReturns { get; set; }

        public override string ToString()
        {
            // Create a string representation of the member
            string memberInfo = $"--------------------------------\n" +
                                $"Namn: {FirstName} {LastName}\n" +
                                $"Registrerad: {DateOfRegistry.ToString("d")}\n" +
                                $"Antal Lån: {NumberOfLoans}\n" +
                                $"Försenade Lån: {NumberOfOverdueBooks}\n" +
                                $"Ej Återlämnande lån: {NumberOfFailedReturns}\n" +
                                $"--------------------------------\n";

            return memberInfo;
        }
    }

}
