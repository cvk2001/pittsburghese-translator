using PittsburgheseTranslator.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PittsburgheseTranslator
{
    public class UI
    {
        private DictionaryFunctions Dictionary { get; set; } = new DictionaryFunctions();
        public UI()
        {

        }
        public void Start()
        {
            //DictionaryFunctions functions = new DictionaryFunctions();
            Dictionary.createDictionary();
            Title();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            bool searchAgain = true;
            Console.WriteLine("Welcome to the Pittsburghese Translator.  " +
                "If you are ever in Pittsburgh and hear an odd sounding, slightly slurred word, " +
                "you are probably hearing Pittsburghese.  You have come to the right place.\n");
            Console.WriteLine("This app will give you the definition of these odd sounding words.\n\n");
            do
            {
                searchAgain = MainMenuOptions(MainMenu());

            } while (searchAgain);
            Console.WriteLine("Yinz Have A Great Day 'Nat!!!!!");

        }

        public string MainMenu()
        {
            string choice = "";


            Console.WriteLine("Please select from the following options:\n" +
                "(If you are not sure of the word or spelling, take a look at the list first)\n" +
                "1)Define a word\n" +
                "2)See a List of Pittsburghese words\n" +
                "3)Exit\n");
            choice = Console.ReadLine();
            Console.WriteLine();
            
            while (choice != "1" && choice != "2" && choice != "3")
            {
                Console.WriteLine("Sorry, please choose 1, 2, or 3");
                choice = Console.ReadLine();
                Console.WriteLine();
            }
            return choice;

        }
        public bool MainMenuOptions(string choice)
        {
            string wordInput = "";
            bool searchAgain = true;
            try
            {
                
                switch (choice)
                {
                    case "1":
                        Console.Write("Please enter the odd sounding word you would like to look up: ");
                        wordInput = Console.ReadLine().ToLowerInvariant();
                        Console.WriteLine();
                        DisplayResults(Dictionary.WordToSearch(wordInput));
                        searchAgain = TryAgain();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Here are the words currently in the dictionary");
                        Console.WriteLine();
                        Dictionary.WordList();
                        break;
                    case "3":
                        searchAgain = false;
                        break;
                    default:
                        searchAgain = true;
                        break;

                }
                return searchAgain;
                

            }
            catch (WordNotFound e)
            {
                Console.WriteLine(e.Message);
                MainMenuOptions("1");
            }
            return searchAgain=false;
        }
        private void DisplayResults(SearchResult results)
        {
            Console.WriteLine();
            Console.WriteLine($"{results.word} = {results.definition}");
            Console.WriteLine();

        }
        public bool TryAgain()
        {
            Console.Write("Would you like to play again?(Y/N) ");
            string answer = Console.ReadLine().Trim().ToLower();
            if (answer.StartsWith("n"))
            {

                return false;

            }
            Console.Clear();
            return true;
        }
        private void Title()
        {
            try
            {
                string directory = Environment.CurrentDirectory;
                string fileName = "pghtitle.txt";
                string fullPath = Path.Combine(directory, fileName);
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while(!sr.EndOfStream)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Pittsburghese Translator");
            }
            
        }


    }
}
