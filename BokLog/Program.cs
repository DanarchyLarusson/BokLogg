using BokLogg.Helper;
using BokLogg.View;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\t|***************************************** BOKLOGG **************************************|");
        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");
        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t");

        Console.WriteLine("Skapar backup för data filer. Vänligen vänta");

        CreateBackupOfJsonFiles();

        Console.WriteLine("Backups skapade, Tryck valfri tangent för att fortsätta");
        Console.ReadLine();

        MainMenu.MainMenu_();
    }

    private static void CreateBackupOfJsonFiles()
    {
        string dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        string[] jsonFiles = new string[]
        {
            "booklog.json",
            "storages.json",
            "earnings.json",
            "people.json",
            "loan.json",
            "returnbox.json"
        };

        foreach (var jsonFile in jsonFiles)
        {
            string filePath = Path.Combine(dataDirectory, jsonFile);
            BackupFile(filePath);
        }
    }

    private static void BackupFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string backupPath = filePath.Replace(".json", "BACKUP.json");
                File.Copy(filePath, backupPath, true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade vid skapandet av säkerhetskopior för {filePath}: {ex.Message}");
        }
    }
}
