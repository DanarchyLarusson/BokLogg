using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BokLogg.Controller;
using BokLogg.Helper;

namespace BokLogg.View
{
    public class CheckMembersView
    {
        private readonly MemberController memberController;

        public CheckMembersView(MemberController controller)
        {
            memberController = controller;
        }

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t   MEDLEMSÖK OCH LISTA \t\t\t\t\t\t", "MEDLEMSÖK OCH LISTA", ConsoleColor.Yellow);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 1. Visa alla medlemmar \t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 2. Sök efter medlem \t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 3. Ta bort medlem \t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t 4. Tillbaka till huvudmeny \t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t|*****************************************************************************************|");
            Console.WriteLine("Skriv in siffran efter ditt val:");

            string userInput = Console.ReadLine();
            MenuController.HandleMemberSearchOptionsInput(userInput);
        }

        public void DisplayAllMembers()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t\t\t  ALLA MEDLEMMAR \t\t\t\t\t\t", "ALLA MEDLEMMAR", ConsoleColor.Yellow);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");

            var allMembers = memberController.GetAllMembers();

            if (allMembers.Count > 0)
            {
                foreach (var member in allMembers)
                {
                    Console.WriteLine(member.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nInga medlemmar hittades.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            DisplayMenu();
        }

        public void SearchForMember()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t\t   SÖK EFTER MEDLEM \t\t\t\t\t\t", "SÖK EFTER MEDLEM", ConsoleColor.Yellow);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");

            Console.WriteLine("Ange förnamn på medlemmen:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Ange efternamn på medlemmen:");
            string lastName = Console.ReadLine();

            var member = memberController.GetMemberByName(firstName, lastName);

            if (member != null)
            {
                Console.WriteLine("\nMedlem hittades:\n");
                Console.WriteLine(member.ToString());
            }
            else
            {
                Console.WriteLine("\nIngen medlem hittades med angivet namn.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            DisplayMenu();
        }
        public void RemoveMember()
        {
            Console.Clear();
            Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            HelperMethods.WriteColoredText("\t\t\t\t\t\t\t   TA BORT MEDLEM \t\t\t\t\t\t", "TA BORT MEDLEM", ConsoleColor.Yellow);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");

            Console.WriteLine("Ange förnamn på medlemmen:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Ange efternamn på medlemmen:");
            string lastName = Console.ReadLine();

            var member = memberController.GetMemberByName(firstName, lastName);

            if (member != null)
            {
                Console.WriteLine($"\nTa bort {member.FirstName} {member.LastName}? Y/N");
                string confirmation = Console.ReadLine().ToUpper();

                if (confirmation == "Y")
                {
                    memberController.RemoveMember(firstName, lastName);
                    Console.WriteLine("\nMedlem borttagen.");
                }
                else if (confirmation == "N")
                {
                    Console.WriteLine("\nMedlemmen har inte tagits bort.");
                }
                else
                {
                    Console.WriteLine("\nOgiltigt val. Återgår till menyn...");
                }
            }
            else
            {
                Console.WriteLine("\nIngen medlem hittades med angivet namn.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            DisplayMenu();
        }

    }
}

