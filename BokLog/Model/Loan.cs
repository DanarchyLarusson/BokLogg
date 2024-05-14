using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokLogg.Model
{
    public class Loan
    {
        public bool IsLoaned { get; set; } = false;
        public Book book { get; set; }
        public Member member { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }


        public override string ToString()
        {
            return $"--------------------------------\n" +
                    $"Bok: {book.Title}\n" +
                    $"Lånad av: {member.FirstName} {member.LastName}\n" +
                    $"Utlånad: {LoanDate.ToString("d")}\n" +
                    $"Återlämnings daturm: {ReturnDate.ToString("d")}\n" +
                    $"Tillhörande lager: {book.Storage}\n" +
                    $"--------------------------------\n";
        }
    }

}
