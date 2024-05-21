using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using BokLogg.Model;
using BokLogg.View;

namespace BokLogg.Controller
{
    public class LoanController
    {
        private List<Loan> loans;
        private string relativePathLoans;
        private string relativePathReturnBox;

        private static readonly ErrorExceptions errorExceptions = new ErrorExceptions();

        public LoanController()
        {
            string dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            relativePathLoans = Path.Combine(dataDirectory, "loans.json");
            relativePathReturnBox = Path.Combine(dataDirectory, "returnBox.json");

            loans = LoadLoansFromJson(relativePathLoans);
        }

        private List<Loan> LoadLoansFromJson(string path)
        {
            try
            {
                string jsonData = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Loan>>(jsonData);
            }
            catch (Exception)
            {
                ErrorExceptions.LoadLoansError();
                return new List<Loan>();
            }
        }

        private void SaveLoansToJson(List<Loan> loans, string path)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(loans, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, jsonData);
            }
            catch
            {
                ErrorExceptions.SaveLoanError();
            }
        }

        public List<Loan> GetActiveLoans()
        {
            return loans.Where(loan => loan.IsLoaned).ToList();
        }

        public void LoanBookToMember(Book book, Member member)
        {
            Loan loan = new Loan
            {
                IsLoaned = true,
                book = book,
                member = member,
                LoanDate = DateTime.Today,
                ReturnDate = DateTime.Today.AddDays(28)
            };
            loans.Add(loan);
            SaveLoansToJson(loans, relativePathLoans);
        }

        public void ReturnBook(Loan loan)
        {
            loans.Remove(loan);
            SaveLoansToJson(loans, relativePathLoans);

            var returnBox = LoadLoansFromJson(relativePathReturnBox);
            returnBox.Add(loan);
            SaveLoansToJson(returnBox, relativePathReturnBox);
        }
        public List<Book> GetReturnBox()
        {
            var returnBoxLoans = LoadLoansFromJson(relativePathReturnBox);
            return returnBoxLoans.Select(loan => loan.book).ToList();
        }

        public void RemoveFromReturnBox(Book book)
        {
            var returnBoxLoans = LoadLoansFromJson(relativePathReturnBox);
            var loanToRemove = returnBoxLoans.FirstOrDefault(loan => loan.book.Title == book.Title && loan.book.Author == book.Author);
            if (loanToRemove != null)
            {
                returnBoxLoans.Remove(loanToRemove);
                SaveLoansToJson(returnBoxLoans, relativePathReturnBox);
            }
        }
    }
}


