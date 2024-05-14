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
        private string relativePathLoans = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data")), "loans.json");
        private static readonly ErrorExceptions errorExceptions = new ErrorExceptions();

        public LoanController()
        {
            loans = LoadLoansFromJson();
        }

        private List<Loan> LoadLoansFromJson()
        {
            try
            {
                string jsonData = File.ReadAllText(relativePathLoans);
                return JsonSerializer.Deserialize<List<Loan>>(jsonData);
            }
            catch (Exception)
            {
                ErrorExceptions.LoadLoansError();
                return new List<Loan>();
            }
        }

        private void SaveLoansToJson(List<Loan> loans)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(loans, typeof(List<Loan>), new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(relativePathLoans, jsonData);
            }
            catch
            {
                ErrorExceptions.SaveLoanError();
            }
        }

        public List<Loan> GetActiveLoans()
        {
            return loans.Where(loan => loan.IsLoaned && loan.ReturnDate >= DateTime.Today).ToList();
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
            SaveLoansToJson(loans);
        }

        public void ReturnBook(Loan loan)
        {
            loan.IsLoaned = false;
            loan.ReturnDate = DateTime.Today;
            SaveLoansToJson(loans);
        }
    }
}

