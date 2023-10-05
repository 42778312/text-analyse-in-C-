using System;
using System.IO;

class Program
{
    static void Main()
    {
        // -----------------------------------------------------------
        Console.WriteLine("Enter the path to the text file:");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath)) // check if the path is correct 
        {
            string fileContent = File.ReadAllText(filePath); // Display the File content 

            Console.WriteLine("\nFile Content:");
            Console.WriteLine(fileContent); 
         //___________________________________________________________
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Count words");
                Console.WriteLine("2. Count characters (excluding spaces)");
                Console.WriteLine("0. Exit");

                if (int.TryParse(Console.ReadLine(), out int option)) // read the input and convert it to number
                {
                    switch (option)
                    {
                        case 1:
                            int wordCount = CountWords(fileContent);
                            Console.WriteLine($"Word count: {wordCount}");
                            break;

                        case 2:
                            int charCount = CountCharacters(fileContent);
                            Console.WriteLine($"Character count (excluding spaces): {charCount}");
                            break;

                        case 0:
                            return; // Exit the program

                        default:
                            Console.WriteLine("Invalid option. Please choose 1, 2, or 0.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                }
            }
        }
        else
        {
            Console.WriteLine("File not found. Please provide a valid file path.");
        }
    }

    static int CountWords(string text)
    {
        string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;   // split the input text into an array
    }

    static int CountCharacters(string text)
    {
        // Exclude spaces by removing them from the text
        string textWithoutSpaces = text.Replace(" ", string.Empty);
        return textWithoutSpaces.Length;
    }
}
