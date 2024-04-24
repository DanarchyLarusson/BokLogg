using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BokLog.Controller;
using BokLog.Helper;

namespace BokLog.View
{
    public class StorageView
    {
        private readonly BookController bookController;

        public StorageView(BookController controller)
        {
            bookController = controller;
        }

        public static void ShowStorageMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("|***************************************** BOKLOGG **************************************|");
                Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
                Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
                HelperMethods.WriteColoredText("|\t\t\t\t\t LAGRINGSALTERNATIV \t\t\t\t\t|", "LAGRINGSALTERNATIV", ConsoleColor.Yellow);
                Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
                Console.WriteLine("|\t\t\t\t\t\t 1. Välj befintlig lagring \t\t\t\t\t\t|");
                Console.WriteLine("|\t\t\t\t\t\t 2. Skapa ny lagring \t\t\t\t\t\t\t|");
                Console.WriteLine("|\t\t\t\t\t\t 3. Gå tillbaka till huvudmeny \t\t\t\t\t|");
                Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t\t\t|");
                Console.WriteLine("|*****************************************************************************************|");
                Console.WriteLine("Skriv in siffran efter ditt val:");

                string userInput = HelperMethods.ReadLine();
                MenuController.HandleStorageMenuInput(userInput);
            }
        }

        public void ShowExistingStorages()
        {
            List<string> storages = bookController.GetAvailableStorages();

            Console.WriteLine("Tillgängliga lagringsalternativ:");
            foreach (string storage in storages)
            {
                Console.WriteLine(storage);
            }

            Console.WriteLine("Välj en lagring genom att skriva dess namn:");
            string selectedStorage = Console.ReadLine();

            if (!storages.Contains(selectedStorage))
            {
                Console.WriteLine($"\nDet finns ingen låda kallad '{selectedStorage}', vill du skapa '{selectedStorage}' som ny låda? (Ja/Nej):");
                string confirmation = Console.ReadLine();

                if (confirmation.Equals("Ja", StringComparison.OrdinalIgnoreCase))
                {
                    bookController.SelectOrCreateStorage(selectedStorage);
                    Console.WriteLine($"Ny lagring '{selectedStorage}' skapad.");
                    Console.ReadKey();
                    MainMenu.MainMenu_();
                }
                else
                {
                    Console.WriteLine("Skapandet av ny lagring avbröts.");
                    MainMenu.MainMenu_();
                    return; 
                }
            }
            else
            {
                bookController.SelectOrCreateStorage(selectedStorage);
                Console.WriteLine($"Vald lagring: {selectedStorage}");
            }

            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            MainMenu.MainMenu_();
        }


        public void CreateNewStorage()
        {
            Console.WriteLine("Skriv in namnet för den nya lagringen:");
            string newStorageName = Console.ReadLine();
            bookController.SelectOrCreateStorage(newStorageName);
            Console.WriteLine($"Skapade ny lagring: {newStorageName}");
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            MainMenu.MainMenu_();
        }
    }
}

