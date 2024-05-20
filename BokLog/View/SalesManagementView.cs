using BokLogg.Controller;
using BokLogg.Helper;
using BokLogg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokLogg.View
{
    public static class SalesManagementView
    {
        private static readonly BookController bookController = new BookController();

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t   FÖRSÄLJNINGSHANTERING \t\t\t\t\t", "FÖRSÄLJNINGSHANTERING", ConsoleColor.Yellow);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 1. Sälj Bok \t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 2. Försäljningshistorik \t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 3. Tillbaka till huvudmenyn \t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            Console.WriteLine("Skriv in siffran efter ditt val:");

            string userInput = Console.ReadLine();
            MenuController.SalesHandleMenuInput(userInput);
        }



        public static void SellBook()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t   VÄLJ LAGRING \t\t\t\t\t\t");

            Console.WriteLine("Tillgängliga lagringsplatser:");
            var storages = bookController.GetAvailableStorages();
            for (int i = 0; i < storages.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {storages[i]}");
            }

            Console.WriteLine("\nAnge numret för lagringen där boken finns:");
            if (int.TryParse(Console.ReadLine(), out int storageIndex) && storageIndex > 0 && storageIndex <= storages.Count)
            {
                string selectedStorage = storages[storageIndex - 1];
                var booksInStorage = bookController.SearchByStorage(selectedStorage);

                if (booksInStorage.Count > 0)
                {
                    Console.WriteLine("\nBöcker i lagringen:");
                    for (int i = 0; i < booksInStorage.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {booksInStorage[i].Title} av {booksInStorage[i].Author}");
                    }

                    Console.WriteLine("\nAnge numret på boken du vill sälja:");
                    if (int.TryParse(Console.ReadLine(), out int bookIndex) && bookIndex > 0 && bookIndex <= booksInStorage.Count)
                    {
                        Book selectedBook = booksInStorage[bookIndex - 1];

                        Console.WriteLine("\nAnge försäljningsbeloppet:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal saleAmount))
                        {
                            bookController.SellBook(bookIndex - 1, saleAmount);
                            Console.WriteLine($"Boken \"{selectedBook.Title}\" har sålts för {saleAmount}.");
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt belopp. Försäljningen avbröts.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt val. Försäljningen avbröts.");
                    }
                }
                else
                {
                    Console.WriteLine("Inga böcker hittades i den valda lagringen.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt val. Försäljningen avbröts.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            DisplayMenu();
        }

        public static void DisplaySalesHistory()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t   FÖRSÄLJNINGSHISTORIK \t\t\t\t\t\t");

            var sales = bookController.GetSales();

            var years = sales.Select(s => s.Year).Distinct().OrderByDescending(y => y).ToList();
            if (years.Count > 0)
            {
                Console.WriteLine("Välj år för att visa försäljningshistorik:");
                for (int i = 0; i < years.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {years[i]}");
                }

                if (int.TryParse(Console.ReadLine(), out int yearIndex) && yearIndex > 0 && yearIndex <= years.Count)
                {
                    int selectedYear = years[yearIndex - 1];
                    DisplayMonthlySales(selectedYear);
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Återgår till menyn.");
                }
            }
            else
            {
                Console.WriteLine("Ingen försäljningsdata tillgänglig.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            DisplayMenu();
        }

        private static void DisplayMonthlySales(int year)
        {
            Console.Clear();
            Console.WriteLine($"\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine($"\t\t\t\t\t   FÖRSÄLJNINGSHISTORIK FÖR {year} \t\t\t\t\t\t");

            var sales = bookController.GetSales().Where(s => s.Year == year).ToList();
            var months = sales.Select(s => s.Month).Distinct().OrderByDescending(m => m).ToList();

            if (months.Count > 0)
            {
                Console.WriteLine("Välj månad för att visa försäljningshistorik:");
                for (int i = 0; i < months.Count; i++)
                {
                    int month = months[i];
                    decimal totalAmount = sales.Where(s => s.Month == month).Sum(s => s.Amount);
                    Console.WriteLine($"{i + 1}. {HelperMethods.GetMonthName(month)} - Total försäljning: {totalAmount:C}");
                }

                if (int.TryParse(Console.ReadLine(), out int monthIndex) && monthIndex > 0 && monthIndex <= months.Count)
                {
                    int selectedMonth = months[monthIndex - 1];
                    DisplaySalesDetails(year, selectedMonth);
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Återgår till menyn.");
                }
            }
            else
            {
                Console.WriteLine("Ingen försäljningsdata tillgänglig för det valda året.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            DisplaySalesHistory();
        }

        private static void DisplaySalesDetails(int year, int month)
        {
            Console.Clear();
            Console.WriteLine($"\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine($"\t\t\t\t\t   FÖRSÄLJNINGAR FÖR {HelperMethods.GetMonthName(month)} {year} \t\t\t\t\t\t");

            var sales = bookController.GetSales().Where(s => s.Year == year && s.Month == month).ToList();

            if (sales.Count > 0)
            {
                foreach (var sale in sales)
                {
                    Console.WriteLine($"Försäljningsbelopp: {sale.Amount:C}, Antal sålda artiklar: {sale.ItemsSold}, Datum: {new DateTime(sale.Year, sale.Month, 1).ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("Ingen försäljningsdata tillgänglig för den valda månaden.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            DisplayMonthlySales(year);
        }
    }
}
