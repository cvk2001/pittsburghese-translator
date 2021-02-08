using System;
using System.Collections.Generic;
using System.Text;

namespace PittsburgheseTranslator
{
    public class UI
    {
        private DictionaryFunctions functions { get; set; } = new DictionaryFunctions();
        public void Start()
        {
            //DictionaryFunctions functions = new DictionaryFunctions();
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
            do
            {
                Console.WriteLine("Please select from the following options:\n" +
                    "1)Define a word\n" +
                    "2)See a List of Pittsburghese words\n" +
                    "3)Exit\n");
                choice = Console.ReadLine();
            } while (choice != "1" && choice != "2" && choice != "3");
            return choice;
                      
        }
        public bool MainMenuOptions(string choice)
        {
            bool searchAgain = true;
            switch(choice)
            {
                case "1":
                    WordToSearch();
                    break;
                case "2":
                    WordList();
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
        public string WordToSearch()
        {
            Console.WriteLine("Please enter the Pittsburghese word you would like to look up: ");
            string inputWord = Console.ReadLine();
            return "";
        }
        public bool WordList()
        {
            return true;
        }
    }
}
