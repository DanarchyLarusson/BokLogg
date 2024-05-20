using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BokLogg.View;

namespace BokLogg.Controller
{
    public static class MenuController
    {
        private static readonly BookController bookController = new BookController();
        private static readonly StorageView storageView = new StorageView(bookController);
        private static readonly BookRegisterView bookRegisterView = new BookRegisterView(bookController);
        private static readonly SearchForm searchForm = new SearchForm(bookController);
        private static readonly BookRemovalView bookRemovalView = new BookRemovalView(bookController);
        private static readonly MemberController memberController = new MemberController();
        private static readonly CheckMembersView checkMembersView = new CheckMembersView(memberController);
        private static readonly AddMemberView addMemberView = new AddMemberView(memberController);

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
                        bookRemovalView.ShowStorageListAndSelect();
                        break;
                    case 5:
                        addMemberView.AddMember();
                        break;
                    case 6:
                        CheckMembersView.DisplayMenu();
                        break;
                    case 7:
                        LoaningMenu.DisplayMenu();
                        break;
                    case 8:
                        SalesManagementView.DisplayMenu();
                        break;
                    case 9:
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
                MainMenu.MainMenu_();
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
                    searchForm.SearchByGenre();
                    break;
                case "3":
                    searchForm.CheckStorage();
                    break;
                case "4":
                    MainMenu.MainMenu_();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, Försök igen.");
                    break;
            }
        }

        public static void HandleMemberSearchOptionsInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    checkMembersView.DisplayAllMembers();
                    break;
                case "2":
                    checkMembersView.SearchForMember();
                    break;
                case "3":
                    checkMembersView.RemoveMember();
                    break;
                case "4":
                    MainMenu.MainMenu_();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, Försök igen.");
                    break;
            }
        }

        public static void HandleLoaningMenuInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    LoaningMenu.LoanBook();
                    break;
                case "2":
                    LoaningMenu.CheckActiveLoansAndReturn();
                    break;
                case "3":
                    LoaningMenu.CheckReturnBox();
                    break;
                case "4":
                    MainMenu.MainMenu_();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    Console.ReadKey();
                    LoaningMenu.DisplayMenu();
                    break;
            }
        }

        public static void SalesHandleMenuInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    SalesManagementView.SellBook();
                    break;
                case "2":
                    SalesManagementView.DisplaySalesHistory();
                    break;
                case "3":
                    MainMenu.MainMenu_();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    SalesManagementView.DisplayMenu();
                    break;
            }
        }
    }
}
