using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokLogg.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
        public string Condition { get; set; }
        public string Storage { get; set; }
        public string Genre { get; set; } 
        public string Format { get; set; }
        public DateTime DateOfRegistry { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"--------------------------------\n" +
                   $"Titel: {Title}\n" +
                   $"Författare: {Author}\n" +
                   $"Utgivningsår: {ReleaseYear}\n" +
                   $"Status: {Condition}\n" +
                   $"Låda: {Storage}\n" +
                   $"Genre: {Genre}\n" +
                   $"Format: {Format}\n" +
                   $"Logg Datum: {DateOfRegistry.ToString("d")}\n" +
                   $"--------------------------------\n";
        }
    }
}

