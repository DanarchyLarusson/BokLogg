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
    public class BookRemovalView
    {
        private readonly BookController bookController;

        public BookRemovalView(BookController controller)
        {
            bookController = controller;
        }

        public static void ShowStorageListAndSelect()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t VÄLJ LAGRING ATT TA BORT FRÅN \t\t\t\t", "VÄLJ LAGRING ATT TA BORT FRÅN", ConsoleColor.Yellow);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");

            var bookController = new BookController();
            var storages = bookController.GetAvailableStorages();

            for (int i = 0; i < storages.Count; i++)
            {
                Console.WriteLine($"|\t{i + 1}. {storages[i]}\t\t\t\t\t\t\t\t\t|");
            }

            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            Console.WriteLine("Skriv in numret för lagringen att ta bort böcker ifrån:");

            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int storageIndex) && storageIndex > 0 && storageIndex <= storages.Count)
            {
                string selectedStorage = storages[storageIndex - 1];
                ShowBookListAndSelect(selectedStorage);
            }
            else
            {
                // Handle invalid input
            }
        }

        public static void ShowBookListAndSelect(string selectedStorage)
        {
            Console.Clear();
            Console.WriteLine("|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
            HelperMethods.WriteColoredText($"|\t\t\t\t\t BÖCKER I LAGRINGEN \"{selectedStorage}\" \t\t\t\t|", $"BÖCKER I LAGRINGEN \"{selectedStorage}\"", ConsoleColor.Yellow);
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");

            var bookController = new BookController();
            var booksInStorage = bookController.SearchByStorage(selectedStorage);

            for (int i = 0; i < booksInStorage.Count; i++)
            {
                Console.WriteLine($"|\t{i + 1}. {booksInStorage[i].Title} by {booksInStorage[i].Author}\t\t\t\t|");
            }

            Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|*****************************************************************************************|");
            Console.WriteLine("Skriv in numret för boken att ta bort:");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int bookIndex) && bookIndex > 0 && bookIndex <= booksInStorage.Count)
            {
                Book bookToRemove = booksInStorage[bookIndex - 1];
                ShowConfirmationAndRemove(selectedStorage, bookToRemove);
            }
            else
            {
                // Handle invalid input
            }
        }

        public static void ShowConfirmationAndRemove(string selectedStorage, Book bookToRemove)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("|***************************************** BOKLOGG **************************************|");
                Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
                Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
                HelperMethods.WriteColoredText($"|\t\t\t\t\t BEKRÄFTA BORTTAGNING AV BOKEN \t\t\t\t|", $"BEKRÄFTA BORTTAGNING AV BOKEN", ConsoleColor.Yellow);
                Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");

                Console.WriteLine($"Bok att ta bort: {bookToRemove.Title} by {bookToRemove.Author}");
                Console.WriteLine($"Från lagringen: {selectedStorage}");
                Console.WriteLine("\nÄr du säker på att du vill ta bort denna bok? (Ja/Nej):");

                string userInput = Console.ReadLine();
                if (userInput.Equals("Ja", StringComparison.OrdinalIgnoreCase))
                {
                    var bookController = new BookController();
                    bookController.RemoveBookFromStorage(selectedStorage, bookToRemove);
                    Console.WriteLine("Boken har tagits bort.");
                    break;
                }
                else if (userInput.Equals("Nej", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Borttagningen avbröts.");
                    break;
                }
                else if (userInput.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    MainMenu.MainMenu_();
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Vänligen ange 'Ja', 'Nej' eller 'x' för att avsluta.");
                }

                Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }
    }
}
