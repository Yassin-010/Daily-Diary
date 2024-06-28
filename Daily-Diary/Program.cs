namespace Daily_Diary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DailyDiary diary = new DailyDiary();
            Console.WriteLine("Welcome to the Daily Manager!");

            while(true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Read diary");
                Console.WriteLine("2. Add entry");
                Console.WriteLine("3. Delete entry");
                Console.WriteLine("4. Count lines");
                Console.WriteLine("5. Search entries");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                    diary.ReadDiaryFile();
                    break;
                    case "2":
                    Console.WriteLine("\nEnter the date (YYYY-MM-DD):");
                    string date = Console.ReadLine();

                    Console.WriteLine("Enter the content:");
                    string content = Console.ReadLine();

                    diary.AddEntry(date, content);
                    break;
                    case "3":
                    diary.DeleteEntry();
                    break;
                    case "4":
                    diary.CountLines();
                    break;
                    case "5":
                    diary.SearchEntries();
                    break;
                    case "6":
                    Console.WriteLine("Exiting the Daily Diary Manager...");
                    return;
                    default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
                }
            }
        }
    }
}
