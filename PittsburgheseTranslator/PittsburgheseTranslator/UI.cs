using System;
using System.Collections.Generic;
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
            

            return true;
        }



}
}
