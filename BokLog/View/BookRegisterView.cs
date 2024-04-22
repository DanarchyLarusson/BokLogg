using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BokLog.Controller;
using BokLog.Helper;
using BokLog.Model;

namespace BokLog.View
{
    public class BookRegisterView
    {
        private readonly BookController bookController;

        public BookRegisterView(BookController controller)
        {
            bookController = controller;
        }

        public void RegisterBook()
        {
            Console.Clear();
            Console.WriteLine("|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
            HelperMethods.WriteColoredText("|\t\t\t\t\t REGISTRERA NY BOK \t\t\t\t\t|", "REGISTRERA NY BOK", ConsoleColor.Yellow);
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");

            Console.WriteLine($"|\t\t\t\t\tVald lagring: {bookController.SelectedStorage}\t\t\t\t\t\t|");

            Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|*****************************************************************************************|");

            Console.WriteLine("Ange titel på boken:");
            string title = Console.ReadLine();

            Console.WriteLine("Ange författarens namn:");
            string author = Console.ReadLine();

            Console.WriteLine("Ange utgivningsår (tryck Enter om det är okänt):");
            string releaseYearInput = Console.ReadLine();
            int releaseYear = 0;
            int.TryParse(releaseYearInput, out releaseYear);

            Console.WriteLine("Ange skick (valfritt):");
            string condition = Console.ReadLine();

            Book newBook = new Book
            {
                Title = title,
                Author = author,
                ReleaseYear = releaseYear,
                Condition = condition
            };

            newBook.Storage = bookController.SelectedStorage;

            bookController.AddBook(newBook);

            Console.WriteLine("Boken har registrerats!");
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
        }
    }
}
