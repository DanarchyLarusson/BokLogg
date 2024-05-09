using BokLogg.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokLogg.View
{
    public class ErrorExceptions
    {
        public static void LoadBooksError()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText($"Fel vid inläsning av böcker från fil", "Fel", ConsoleColor.Red);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Ett fel uppstod vid försök att läsa in böcker från fil.");
            Console.WriteLine("Om filen är korrupt så har den ändrat namn till ''CorruptedBooks.json'' för att kunna återställas");
            Console.WriteLine("En ny boksamling har skapats.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            HelperMethods.ReadLine();
            MainMenu.MainMenu_();
        }

        public static void LoadMembersError()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText($"Fel vid inläsning av böcker från fil", "Fel", ConsoleColor.Red);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Ett fel uppstod vid försök att läsa in medlemmar från fil.");
            Console.WriteLine("En ny lista för medlemmar har skapats.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            HelperMethods.ReadLine();
            MainMenu.MainMenu_();
        }

        public static void LoadStoragesError()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText($"Fel vid inläsning av lagringsplatser från fil", "Fel", ConsoleColor.Red);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Ett fel uppstod vid försök att läsa in lagringsplatser från fil.");
            Console.WriteLine("Om filen är korrupt så har den ändrat namn till ''CorruptedStorages.json'' för att kunna återställas");
            Console.WriteLine("En ny lista över lagringsplatser har skapats.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            HelperMethods.ReadLine();
            MainMenu.MainMenu_();
        }

        public static void SaveBookError()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText($"Felkod", "Error", ConsoleColor.Red);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Ett fel hindrar boken från att läggas till. Vänligen försök igen");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Tryck på valfri tagent för att återgå till huvudmenyn.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            HelperMethods.ReadLine();
            MainMenu.MainMenu_();
        }


        public static void SaveStorageError()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText($"Felkod", "Error", ConsoleColor.Red);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Ett fel hindrar lagringen från att läggas till. Vänligen försök igen med annat namn");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Tryck på valfri tagent för att återgå till huvudmenyn.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            HelperMethods.ReadLine();
            MainMenu.MainMenu_();
        }

        public static void BookRemovalError()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText($"Felkod", "Error", ConsoleColor.Red);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Boken har ej tagits bort, vänligen försök igen.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Tryck på valfri tagent för att återgå till huvudmenyn.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            HelperMethods.ReadLine();
            MainMenu.MainMenu_();
        }

        public static void SaveMemberError()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText($"Felkod", "Error", ConsoleColor.Red);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Ett fel hindrar medlemmen från att läggas till. Vänligen försök igen");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("Tryck på valfri tagent för att återgå till huvudmenyn.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            HelperMethods.ReadLine();
            MainMenu.MainMenu_();
        }
    }
}
