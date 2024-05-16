using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BokLogg.Controller;
using BokLogg.Helper;
using BokLogg.Model;

namespace BokLogg.View
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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                HelperMethods.WriteColoredText("\t\t\t\t\t REGISTRERA NY BOK \t\t\t\t\t", "REGISTRERA NY BOK", ConsoleColor.Yellow);
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine($"\t\t\t\tVald lagring: {bookController.SelectedStorage}\t\t\t\t\t");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine("\t|*****************************************************************************************|");

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

                string selectedGenre = SelectOption("Välj genre för boken:", bookController.GetGenres(), "Okänd");
                string selectedFormat = SelectOption("Välj format för boken:", bookController.GetFormats());

                Book newBook = new Book
                {
                    Title = title,
                    Author = author,
                    ReleaseYear = releaseYear,
                    Condition = condition,
                    Genre = selectedGenre,
                    Format = selectedFormat,
                    Storage = bookController.SelectedStorage
                };

                bookController.AddBook(newBook);

                Console.Clear();
                Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine("Boken har registrerats!");
                Console.WriteLine("Tryck på valfri tangent för att fortsätta registrera, eller 'x' för att gå tillbaka till menyn...");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine("\t|*****************************************************************************************|");

                var inputKey = Console.ReadKey();

                if (inputKey.KeyChar == 'x' || inputKey.KeyChar == 'X')
                {
                    MainMenu.MainMenu_();
                    break;
                }
            }
        }

        private string SelectOption(string prompt, List<string> options, string additionalOption = null)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(prompt);
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }
                if (additionalOption != null)
                {
                    Console.WriteLine($"{options.Count + 1}. {additionalOption}");
                }

                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= options.Count + (additionalOption != null ? 1 : 0))
                {
                    return selectedIndex == options.Count + 1 && additionalOption != null ? additionalOption : options[selectedIndex - 1];
                }

                Console.WriteLine("Ogiltig inmatning. Vänligen ange en siffra från listan.");
            }
        }
    }
}
