# Daily Diary Console Application

This console application allows users to manage a daily diary stored in a text file. Users can read the diary, add new entries, delete specific entries, count the total number of lines, and search for entries based on a keyword.

## Prerequisites

- [.NET runtime](https://dotnet.microsoft.com/download) installed on your machine.

## Usage

1. Clone or download this repository to your local machine.

2. Open a command prompt or terminal and navigate to the project directory.


## When Run The App
The application will display a menu with the following options:
1. Read diary: Displays the content of the diary file.
2. Add entry: Allows you to add a new entry to the diary.
3. Delete entry: Allows you to delete a specific entry from the diary.
4. Count total lines: Counts the total number of lines in the diary.
5. Search entries: Searches for entries containing a specific keyword.
6. Exit: Quits the application.
Choose an option by entering the corresponding number and pressing Enter.
Follow the prompts to perform the desired action. For example, when adding an entry, you will be asked to enter the date and content.
The application will execute the chosen action and display the result or any error messages.
You can continue using the application by selecting another option from the menu.
To exit the application, choose the 6. Exit" option.

## File Structure
The application assumes the existence of a diary.txt file in the same directory as the application. This file stores the diary entries.

If the diary.txt file does not exist, the application will create it when you add the first entry.

## Error Handling
The application incorporates basic error handling to handle exceptions that may occur during file manipulation operations or user input validation. If an error occurs, an error message will be displayed.

## Stretch Goals
The application includes a search feature that allows you to search for entries based on a keyword. To use this feature, select the "5. Search entries" option and enter the keyword when prompted. The application will display the matching entries.
