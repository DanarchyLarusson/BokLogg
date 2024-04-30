using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BokLogg.Controller;
using BokLogg.Helper;

namespace BokLogg.View
{
    public class SearchForm
    {
        private readonly BookController bookController;

        public SearchForm(BookController controller)
        {
            bookController = controller;
        }

        public static void SearchOptions()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t\t SÖKALTERNATIV \t\t\t\t\t\t", "SÖKALTERNATIV", ConsoleColor.Yellow);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 1. Sök efter bok \t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 2. Sök efter genre \t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 3. Lager kontroll \t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 4. Tillbaka till huvudmeny \t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            Console.WriteLine("Skriv in siffran efter ditt val:");

            string userInput = Console.ReadLine();
            MenuController.HandleSearchOptionsInput(userInput);
        }

        public void SearchByBookName()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t SÖK EFTER BOK PÅ TITEL ELLER FÖRFATTARE \t\t\t\t", "SÖK EFTER BOK PÅ TITEL ELLER FÖRFATTARE", ConsoleColor.Yellow);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");

            Console.WriteLine("\tAnge titel på boken (lämna tomt för att hoppa över):");
            string title = Console.ReadLine();

            Console.WriteLine("\tAnge författarens namn (lämna tomt för att hoppa över):");
            string author = Console.ReadLine();

            var searchResults = bookController.SearchByTitleAndAuthor(title, author);

            if (searchResults.Count > 0)
            {
                Console.WriteLine("\nResultat:\n");
                foreach (var book in searchResults)
                {
                    Console.WriteLine(book.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nInga resultat hittades.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            MainMenu.MainMenu_();
        }

        public void SearchByGenre()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t   SÖK EFTER BOK PÅ GENRE \t\t\t\t\t\t", "SÖK EFTER BOK PÅ GENRE", ConsoleColor.Yellow);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");

            Console.WriteLine("\tVälj en genre att söka efter:");
            List<string> genres = bookController.GetGenres();
            for (int i = 0; i < genres.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {genres[i]}");
            }
            Console.WriteLine($"\t{genres.Count + 1}. Okänd");

            int selectedGenreIndex;
            string genreInput = Console.ReadLine();
            if (!int.TryParse(genreInput, out selectedGenreIndex) || selectedGenreIndex < 1 || selectedGenreIndex > genres.Count + 1)
            {
                Console.WriteLine("\tOgiltig inmatning. Välj en siffra från listan.");
                Console.ReadKey();
                MainMenu.MainMenu_();
                return;
            }

            string selectedGenre = selectedGenreIndex == genres.Count + 1 ? "Okänd" : genres[selectedGenreIndex - 1];

            var searchResults = bookController.SearchByGenre(selectedGenre);

            if (searchResults.Count > 0)
            {
                Console.WriteLine("\nResultat:\n");
                foreach (var book in searchResults)
                {
                    Console.WriteLine(book.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nInga resultat hittades.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            MainMenu.MainMenu_();
        }


        public void CheckStorage()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t   KONTROLLERA LAGRING \t\t\t\t\t\t", "KONTROLLERA LAGRING", ConsoleColor.Yellow);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");

            Console.WriteLine("Tillgängliga lagringsplatser:");
            var storages = bookController.GetAvailableStorages();
            foreach (var storage in storages)
            {
                Console.WriteLine(storage);
            }

            Console.WriteLine("\nAnge lagringsplatsens namn:");
            string storageName = Console.ReadLine();

            var searchResults = bookController.SearchByStorage(storageName);

            if (searchResults.Count > 0)
            {
                Console.WriteLine("\nBöcker i lagringen:\n");
                foreach (var book in searchResults)
                {
                    Console.WriteLine(book.ToString());
                }
            }
            else
            {
                Console.WriteLine($"\nInga böcker hittades i lagringen \"{storageName}\".");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            MainMenu.MainMenu_();
        }


    }
}


