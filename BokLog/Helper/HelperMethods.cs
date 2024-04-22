using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BokLog.View;

namespace BokLog.Helper
{
    public static class HelperMethods
    {
        public static void WriteColoredText(string text, string targetWord, ConsoleColor color)
        {
            int index = 0;

            while (index < text.Length)
            {
                int wordIndex = text.IndexOf(targetWord, index, StringComparison.OrdinalIgnoreCase);
                if (wordIndex == -1)
                {
                    Console.Write(text.Substring(index));
                    break;
                }

                if (wordIndex > index)
                {
                    Console.Write(text.Substring(index, wordIndex - index));
                }

                Console.ForegroundColor = color;
                Console.Write(targetWord);
                Console.ResetColor();

                index = wordIndex + targetWord.Length;
            }
            Console.WriteLine();
        }

        public static string ReadLine()
        {
            string userInput = Console.ReadLine();
            string exit = "exit";

            if (userInput.ToLower() == exit)
            {
                MainMenu.MainMenu_();
            }

            return userInput;
        }

        public static void WriteLineFitBox(string left, string line, string right, int lineLength)
        {
            if (line.Length < lineLength)
            {
                Console.Write(left); Console.Write(line.PadRight(lineLength)); Console.WriteLine(right);
            }
            else if (line.Length > lineLength)
            {
                Console.Write(left); Console.Write(line.Substring(0, lineLength)); Console.WriteLine(right);
            }
            else
            {
                Console.Write(left); Console.Write(line); Console.WriteLine(right);
            }
        }
    }
}
