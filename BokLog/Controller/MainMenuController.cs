using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BokLog;
using BokLog.View;

namespace BokLog.Controller
{
    public static class MenuController
    {
        private static readonly BookController bookController = new BookController();
        private static readonly StorageView storageView = new StorageView(bookController);
        private static readonly BookRegisterView bookRegisterView = new BookRegisterView(bookController);
        private static readonly SearchForm searchForm = new SearchForm(bookController);
        private static readonly BookRemovalView bookRemovalView = new BookRemovalView(bookController);

        public static void HandleMenuInput(string userInput)
        {
            if (int.TryParse(userInput, out int userInputInt))
            {
                switch (userInputInt)
                {
                    case 1:
                        StorageView.ShowStorageMenu();
                        break;
                    case 2:
                        bookRegisterView.RegisterBook();
                        break;
                    case 3:
                        SearchForm.SearchOptions();
                        break;
                    case 4:
                        BookRemovalView.ShowStorageListAndSelect();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, Försök igen.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        public static void HandleStorageMenuInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    storageView.ShowExistingStorages();
                    break;
                case "2":
                    storageView.CreateNewStorage();
                    break;
                case "3":
                    MainMenu.MainMenu_();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, Försök igen.");
                    break;
            }
        }

        public static void HandleSearchOptionsInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    searchForm.SearchByBookName();
                    break;
                case "2":
                    searchForm.CheckStorage();
                    break;
                case "3":
                    MainMenu.MainMenu_();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, Försök igen.");
                    break;
            }
        }
    }
}



