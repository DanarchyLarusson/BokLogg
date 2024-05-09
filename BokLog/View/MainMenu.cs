using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BokLogg.Controller;
using BokLogg.Helper;

namespace BokLogg.View
{
    public class MainMenu
    {
        public static void MainMenu_()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t\t HUVUDMENY \t\t\t\t\t\t\t\t", "HUVUDMENY", ConsoleColor.Blue);
            Console.WriteLine("\t\t\t Välj alternativ via att skriva in siffra och tryck Enter \t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 01.- Låda \t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 02.- Registrera nya böcker \t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 03.- Sök böcker \t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 04.- Ta bort böcker \t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 05.- Lägg till ny Medlem \t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 06.- Medlemslista \t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 07.- Avsluta \t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("|*******************************************************************************************************|");
            Console.WriteLine("Skriv in siffran efter ditt val:");

            MenuController.HandleMenuInput(HelperMethods.ReadLine());
        }

    }
}
