using BokLogg.Controller;
using BokLogg.Helper;
using BokLogg.Model;

namespace BokLogg.View
{
    public static class LoaningMenu
    {
        private static readonly BookController bookController = new BookController();
        private static readonly MemberController memberController = new MemberController();
        private static readonly LoanController loanController = new LoanController();

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t   BOKUTLÅNING \t\t\t\t\t\t", "BOKUTLÅNING", ConsoleColor.Yellow);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 1. Låna ut bok \t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 2. Kolla aktiva lån och återlämna bok \t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 3. Kolla retur låda \t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 4. Tillbaka till huvudmeny \t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            Console.WriteLine("Skriv in siffran efter ditt val:");

            string userInput = Console.ReadLine();
            MenuController.HandleLoaningMenuInput(userInput);
        }

        public static void LoanBook()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t   VÄLJ LAGRING \t\t\t\t\t\t");

            Console.WriteLine("Tillgängliga lagringsplatser:");
            var storages = bookController.GetAvailableStorages();
            foreach (var storage in storages)
            {
                Console.WriteLine(storage);
            }

            Console.WriteLine("\nAnge lagringsplatsens namn:");
            string storageName = Console.ReadLine();

            var books = bookController.SearchByStorage(storageName);

            if (books.Count > 0)
            {
                Console.WriteLine("\nBöcker i lagringen:\n");
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {books[i].Title} av {books[i].Author}");
                }

                Console.WriteLine("\nAnge numret på boken du vill låna:");
                if (int.TryParse(Console.ReadLine(), out int bookIndex) && bookIndex > 0 && bookIndex <= books.Count)
                {
                    Book selectedBook = books[bookIndex - 1];
                    Member member = PromptForMember();
                    if (member != null)
                    {
                        loanController.LoanBookToMember(selectedBook, member);
                        Console.WriteLine("Boken har lånats ut.");
                    }
                    else
                    {
                        Console.WriteLine("Ingen medlem hittades med angivet namn.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }
            else
            {
                Console.WriteLine($"\nInga böcker hittades i lagringen \"{storageName}\".");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            DisplayMenu();
        }

        public static void CheckActiveLoansAndReturn()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t   AKTIVA LÅN \t\t\t\t\t\t");

            var activeLoans = loanController.GetActiveLoans();

            if (activeLoans.Count > 0)
            {
                for (int i = 0; i < activeLoans.Count; i++)
                {
                    var loan = activeLoans[i];
                    var overdueDays = (DateTime.Today - loan.ReturnDate).Days;

                    string overdueText = overdueDays > 0 ? $" - FÖRSENAD {overdueDays} dagar" : "";
                    Console.WriteLine($"{i + 1}. {loan.book.Title} av {loan.book.Author}, lånad av {loan.member.FirstName} {loan.member.LastName}, Återlämningsdatum: {loan.ReturnDate.ToShortDateString()}{overdueText}");
                }

                Console.WriteLine("\nAnge numret på lånet du vill återlämna (eller skriv 'X' för att återgå):");
                string input = Console.ReadLine();

                if (input?.ToLower() == "x")
                {
                    Console.WriteLine("Återgår till menyn...");
                    DisplayMenu();
                    return;
                }

                if (int.TryParse(input, out int loanIndex) && loanIndex > 0 && loanIndex <= activeLoans.Count)
                {
                    var selectedLoan = activeLoans[loanIndex - 1];
                    Console.WriteLine($"Vill du återlämna boken \"{selectedLoan.book.Title}\"? (ja/nej)");
                    string confirm = Console.ReadLine();

                    if (confirm?.ToLower() == "ja")
                    {
                        loanController.ReturnBook(selectedLoan);
                        Console.WriteLine("Boken har återlämnats och lagts i återlämningsboxen.");
                    }
                    else
                    {
                        Console.WriteLine("Återlämning avbröts.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }
            else
            {
                Console.WriteLine("Inga aktiva lån hittades.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            DisplayMenu();
        }


        public static void CheckReturnBox()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t   RETUR LÅDA \t\t\t\t\t\t");
            Console.WriteLine("\nDessa böcker behöver återlämnas till deras ursprungliga lagring.\n");

            var returnBox = loanController.GetReturnBox();

            if (returnBox.Count > 0)
            {
                for (int i = 0; i < returnBox.Count; i++)
                {
                    var book = returnBox[i];
                    Console.WriteLine($"{i + 1}. {book.Title} av {book.Author}, Ursprunglig lagring: {book.Storage}");
                }

                Console.WriteLine("\nAnge numret på boken du vill återlämna till lagringen:");
                if (int.TryParse(Console.ReadLine(), out int bookIndex) && bookIndex > 0 && bookIndex <= returnBox.Count)
                {
                    var selectedBook = returnBox[bookIndex - 1];
                    Console.WriteLine($"Har boken \"{selectedBook.Title}\" återlämnats till tillhörande lager? (ja/nej)");
                    string confirm = Console.ReadLine();

                    if (confirm?.ToLower() == "ja")
                    {
                        loanController.RemoveFromReturnBox(selectedBook);
                        Console.WriteLine("Boken har återlämnats till lagringen och tagits bort från retur lådan.");
                    }
                    else
                    {
                        Console.WriteLine("Återlämning avbröts.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }
            else
            {
                Console.WriteLine("Inga böcker finns i retur lådan.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            DisplayMenu();
        }

        private static Member PromptForMember()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t   SÖK EFTER MEDLEM \t\t\t\t\t\t");

            Console.WriteLine("Ange förnamn på medlemmen:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Ange efternamn på medlemmen:");
            string lastName = Console.ReadLine();

            return memberController.GetMemberByName(firstName, lastName);
        }
    }
}
