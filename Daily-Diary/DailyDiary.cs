using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Daily_Diary
{
    public class DailyDiary
    {
       static string currentDir = Environment.CurrentDirectory;
        string diaryFilePath = Path.Combine(currentDir, "diary.txt");


        public void ReadDiaryFile()
        {
            try
            {
                string[] lines = File.ReadAllLines(diaryFilePath);
                if(lines.Length > 0)
                { 
                foreach(string line in lines)
                {
                    Console.WriteLine(line);
                }
                }else
                {
                    Console.WriteLine("No Data...");
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Diary file not found!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred while reading the diary: " + ex.Message);
            }
        }



        public void AddEntry(string date, string content)
        {
           

            Entry entry = new Entry(date, content);

            try
            {
                using(StreamWriter writer = File.AppendText(diaryFilePath))
                {
                    writer.WriteLine(entry);
                }

                Console.WriteLine("Entry added successfully!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred while adding the entry: " + ex.Message);
            }

        }



        public void DeleteEntry()
        {
            Console.WriteLine("\nEnter the line number of the entry to delete:");
            if(int.TryParse(Console.ReadLine(), out int lineNumber))
            {
                try
                {
                    List<string> lines = File.ReadAllLines(diaryFilePath).ToList();

                    if(lineNumber > 0 && lineNumber <= lines.Count)
                    {
                        lines.RemoveAt(lineNumber - 1);
                        File.WriteAllLines(diaryFilePath, lines);
                        Console.WriteLine("Entry deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid line number!");
                    }
                }
                catch(FileNotFoundException)
                {
                    Console.WriteLine("Diary file not found!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("An error occurred while deleting the entry: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Line number must be a positive integer.");
            }
        }


        public int CountLines()
        {
            try
            {
                int lineCount = File.ReadLines(diaryFilePath).Count();
                Console.WriteLine("Total number of lines in the diary: " + lineCount);
                return lineCount;
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Diary file not found!");
                return -1;
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred while counting the lines: " + ex.Message);
                return -1;
            }
            
        }

        public void SearchEntries()
        {
            Console.WriteLine("\nEnter the search criteria (date (YYYY-MM-DD) or keyword):");
            string searchCriteria = Console.ReadLine();

            try
            {
                List<Entry> entries = new List<Entry>();

                using(StreamReader reader = new StreamReader(diaryFilePath))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                        if(parts.Length == 2)
                        {
                            Entry entry = new Entry(parts[0], parts[1]);
                            entries.Add(entry);
                        }
                    }
                }

                List<Entry> matchingEntries = entries
                    .Where(e => e.Date.Contains(searchCriteria) || e.Content.Contains(searchCriteria))
                    .ToList();

                if(matchingEntries.Count > 0)
                {
                    Console.WriteLine("Matching Entries:");
                    foreach(Entry entry in matchingEntries)
                    {
                        Console.WriteLine(entry);
                    }
                }
                else
                {
                    Console.WriteLine("No matching entries found.");
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Diary file not found!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred while searching the entries: " + ex.Message);
            }
        }

    }
}
