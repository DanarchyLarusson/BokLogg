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
            return $"Titel: {Title} - Författare: {Author} - Utgivningsår: {ReleaseYear} - Status: {Condition} - Låda: {Storage} - Genre: {Genre} - Format: {Format} - Logg Datum: {DateOfRegistry.ToString("d")}";
        }
    }
}

