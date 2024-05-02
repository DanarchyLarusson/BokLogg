using BokLogg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BokLogg.Controller
{
    public class BookController
    {
        private List<Book> books;
        private List<string> storages;
        private string selectedStorage;
        private string relativePathBooks = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data")), "booklog.json");
        private string relativePathStorages = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data")), "storages.json");

        public BookController()
        {
            books = LoadBooksFromJson();
            storages = LoadStoragesFromJson();
            selectedStorage = storages.FirstOrDefault();
        }

        private List<Book> LoadBooksFromJson()
        {
            try
            {
                string jsonData = File.ReadAllText(relativePathBooks);
                return JsonSerializer.Deserialize<List<Book>>(jsonData);
            }
            catch (Exception)
            {
                // Handle exceptions
                return new List<Book>();
            }
        }

        private List<string> LoadStoragesFromJson()
        {
            try
            {
                string jsonData = File.ReadAllText(relativePathStorages);
                return JsonSerializer.Deserialize<List<string>>(jsonData);
            }
            catch (Exception)
            {
                // Handle exceptions
                return new List<string>();
            }
        }

        private void SaveBooksToJson(List<Book> books)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(books, typeof(List<Book>), new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(relativePathBooks, jsonData);
            }
            catch
            {
                // Handle exceptions
            }
        }

        private void SaveStoragesToJson(List<string> storages)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(storages, typeof(List<string>), new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(relativePathStorages, jsonData);
            }
            catch
            {
                // Handle exceptions
            }
        }

        public List<string> GetAvailableStorages()
        {
            return storages;
        }

        public string SelectOrCreateStorage(string storageName)
        {
            if (!storages.Contains(storageName))
            {
                storages.Add(storageName);
                SaveStoragesToJson(storages);
            }
            selectedStorage = storageName;
            return selectedStorage;
        }

        public string SelectedStorage
        {
            get { return selectedStorage; }
        }

        public void AddBook(Book book)
        {
            book.Storage = selectedStorage;
            books.Add(book);
            SaveBooksToJson(books);
        }
        public List<Book> SearchByTitleAndAuthor(string title, string author)
        {
            title = title.ToLower();
            author = author.ToLower();

            var results = books.Where(book =>
                book.Title.ToLower().Contains(title) &&
                book.Author.ToLower().Contains(author))
                .ToList();

            return results;
        }


        public List<Book> SearchByStorage(string storageName)
        {
            var results = books.Where(book => book.Storage == storageName).ToList();

            return results;
        }

        public void RemoveBook(int bookIndex)
        {
            if (bookIndex >= 0 && bookIndex < books.Count)
            {
                Book bookToRemove = books[bookIndex];

                books.Remove(bookToRemove);

                SaveBooksToJson(books);

            }
            else
            {
                // Handle invalid 
            }
        }
        public void RemoveBookFromStorage(string storageName, Book bookToRemove)
        {
            if (books.Contains(bookToRemove) && bookToRemove.Storage == storageName)
            {
                books.Remove(bookToRemove);
                SaveBooksToJson(books);
            }
            else
            {
                // Handle invalid book or storage
            }
        }
        public List<string> GetGenres()
        {
            return new List<string> { "Antikviteter & Design", "Barn & Ungdom", "Bil & Motor", "Biografi & Genealogi", "Båtar & Nautika", "Data & IT", "Deckare & Thrillers", "Ekonomi & Näringsliv", "Etnologi & Antropologi", "Film & Teater", "Filosofi & Idéhistoria", "Flyg & Järnväg", "Foto", "Hantverk", "Hem & Trädgård", "Historia & Arkeologi", "Hobby & Fritid", "Humor", "Husdjur & Naturbruk", "Jakt & Fiske", "Juridik & Kriminologi", "Konst & Arkitektur", "Litteraturvetenskap", "Lyrik & Dramatik", "Mat & Dryck", "Media & Journalistik", "Medicin & Hälsa", "Militaria", "Musik", "Natur & Miljö", "Naturvet. & Matematik", "Psykologi & Pedagogik", "Religion & Esoterika", "Resor & Geografi", "Samhälle & Politik", "Sci-Fi & Fantasy", "Skönlitteratur", "Sport & Spel", "Språk & Ordböcker", "Teknik", "Topografi & Lokalhist", "Övrigt" };
        }

        public List<Book> SearchByGenre(string genre)
        {
            var results = books.Where(book => book.Genre == genre).ToList();
            return results;
        }

        public List<string> GetFormats()
        {
            return new List<string> { "Inbunden", "Häftad", "Pocket", "Ljudbok", "Tidningar & Tidskrifter", "Noter & Notblad", "Grafik, Kartor", "Brev, Dokument & Handskrifter", "Övrigt" };
        }

    }


}
