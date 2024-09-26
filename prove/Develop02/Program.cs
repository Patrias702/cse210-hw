using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    static List<JournalEntry> journal = new List<JournalEntry>();

    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("\n--- Journal Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1-5): ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    WriteEntry();
                    break;
                case 2:
                    DisplayJournal();
                    break;
                case 3:
                    SaveJournal();
                    break;
                case 4:
                    LoadJournal();
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 5);
    }

    static void WriteEntry()
    {
        Random random = new Random();
        int promptIndex = random.Next(prompts.Count);
        string selectedPrompt = prompts[promptIndex];

        Console.WriteLine($"\nPrompt: {selectedPrompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        JournalEntry entry = new JournalEntry
        {
            Prompt = selectedPrompt,
            Response = response,
            Date = DateTime.Now
        };

        journal.Add(entry);
        Console.WriteLine("Entry saved.");
    }

    static void DisplayJournal()
    {
        Console.WriteLine("\n--- Journal Entries ---");
        foreach (var entry in journal)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    static void SaveJournal()
    {
        Console.Write("Enter a filename to save the journal: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in journal)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved.");
    }

    static void LoadJournal()
    {
        Console.Write("Enter the filename to load the journal from: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            journal.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    JournalEntry entry = new JournalEntry
                    {
                        Date = DateTime.Parse(parts[0]),
                        Prompt = parts[1],
                        Response = parts[2]
                    };
                    journal.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

class JournalEntry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
}
