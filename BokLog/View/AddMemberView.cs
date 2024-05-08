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
    public class AddMemberView
    {
        private readonly MemberController memberController;

        public AddMemberView(MemberController controller)
        {
            memberController = controller;
        }

        public void AddMember()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                HelperMethods.WriteColoredText("\t\t\t\t\t REGISTRERA NY MEDLEM \t\t\t\t\t", "REGISTRERA NY MEDLEM", ConsoleColor.Yellow);
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine("\t|*****************************************************************************************|");

                Console.WriteLine("Ange förnamn:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Ange efternamn:");
                string lastName = Console.ReadLine();

                Member newMember = new Member
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                memberController.AddMember(newMember);

                Console.WriteLine("Medlemmen har registrerats!");
                Console.WriteLine("Tryck på valfri tangent för att fortsätta registrera, eller 'x' för att gå tillbaka till menyn...");
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
