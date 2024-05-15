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

            Console.WriteLine("Ange Telefon nummer:");
            string phone = Console.ReadLine();

            Console.WriteLine("Ange Mail:");
            string email = Console.ReadLine();

            Member newMember = new Member
            {
                FirstName = firstName,
                LastName = lastName,
                ContactNumber = phone,
                Email = email
            };

            memberController.AddMember(newMember);

            Console.WriteLine("Medlemmen har registrerats!");
            Console.WriteLine("Tryck på valfri tangent för att gå till huvudmenyn...");
            Console.ReadKey();
            MainMenu.MainMenu_();
        }

    }
}
