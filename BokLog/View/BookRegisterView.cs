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

                Console.WriteLine("\nVälj genre för boken:");
                List<string> genres = bookController.GetGenres();
                for (int i = 0; i < genres.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {genres[i]}");
                }
                Console.WriteLine($"{genres.Count + 1}. Okänd");

                int genreIndex;
                do
                {
                    Console.WriteLine("\nVälj genre för boken:");
                    for (int i = 0; i < genres.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {genres[i]}");
                    }
                    Console.WriteLine($"{genres.Count + 1}. Okänd");

                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out genreIndex) && (genreIndex >= 1 && genreIndex <= genres.Count + 1))
                    {
                        break;  
                    }
                    Console.WriteLine("Ogiltig inmatning. Välj en siffra från listan.");
                } while (true);



                string selectedGenre = genreIndex == genres.Count + 1 ? "Unknown" : genres[genreIndex - 1];

                Console.WriteLine("\nVälj format för boken:");
                List<string> formats = bookController.GetFormats();
                for (int i = 0; i < formats.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {formats[i]}");
                }

                int formatIndex;
                do
                {
                    Console.WriteLine("\nVälj format för boken:");
                    for (int i = 0; i < formats.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {formats[i]}");
                    }

                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out formatIndex) && (formatIndex >= 1 && formatIndex <= formats.Count))
                    {
                        break;  
                    }
                    Console.WriteLine("Ogiltig inmatning. Välj en siffra från listan.");
                } while (true);



                string selectedFormat = formats[formatIndex - 1];

                Book newBook = new Book
                {
                    Title = title,
                    Author = author,
                    ReleaseYear = releaseYear,
                    Condition = condition,
                    Genre = selectedGenre,
                    Format = selectedFormat
                };

                newBook.Storage = bookController.SelectedStorage;

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


    }
}


