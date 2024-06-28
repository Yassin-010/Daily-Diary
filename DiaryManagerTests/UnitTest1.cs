using Daily_Diary;

namespace DiaryManagerTests
{
    public class UnitTest1
    {
        static string currentDir = Environment.CurrentDirectory;
        string diaryFilePath = Path.Combine(currentDir, "diary.txt");


        [Fact]
        public void ReadDiaryFile_SuccessfullyReadsFileContent()
        {
            // Arrange
            DailyDiary diary = new DailyDiary();
            string testDiaryFilePath = Path.Combine(currentDir, "diary.txt");

            string[] sampleContent = { "Entry 1", "Entry 2", "Entry 3" };
            File.WriteAllLines(testDiaryFilePath, sampleContent);

            // Act
            using(StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw); 
                diary.ReadDiaryFile();
                string output = sw.ToString().Trim();

                // Assert
                Assert.Equal(string.Join(Environment.NewLine, sampleContent), output);
            }

            // Clean up the test diary file
            File.Delete(testDiaryFilePath);
        }
    
    [Fact]
        public void AddEntry_IncreasesTotalCount()
        {
            // Arrange
            DailyDiary diary = new DailyDiary();
            int initialCount = diary.CountLines();

            // Act
            diary.AddEntry("1999 - 23 - 12", "this is new contecnt");
            int updatedCount = diary.CountLines();

            // Assert
            Assert.True(updatedCount > initialCount, "Adding a new entry should increase the total count of entries.");
        
        }
    }
}