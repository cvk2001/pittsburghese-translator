using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PittsburgheseTranslator
{
    public class DictionaryFunctions
    {
        public Dictionary<string, string> pgheseDictionary { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> createDictionary()
        {

            string directory = Environment.CurrentDirectory;
            string fileName = "pittsburghese.txt";
            string fullPath = Path.Combine(directory, fileName);
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] wordLine = sr.ReadLine().Split('|');
                        pgheseDictionary[wordLine[0].ToLowerInvariant()] = wordLine[1];
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Something must have happened to the file.  Please contact support!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Please contact support");
            }
            return pgheseDictionary;
        }
        public bool WordList()
        {
            foreach (KeyValuePair<string, string> kvp in pgheseDictionary)
            {
                Console.WriteLine(kvp.Key);
            }
            Console.WriteLine();
            return true;

        }
        // fix return type when I fix formatting and add a 'continue playing' feature
        public SearchResult WordToSearch(string wordInput)//find word.  send result to ui.  
        {
            bool wordFound = false;
            string definition = "";
            foreach (KeyValuePair<string,string> kvp in pgheseDictionary)
            {
                if (kvp.Key == wordInput)
                {
                    
                    wordFound = true;
                    definition = kvp.Value;
                }
                             
            }
            if (wordFound == true)
            {
                SearchResult searchResult = new SearchResult();
                searchResult.word = wordInput;
                searchResult.definition = definition;
                return searchResult;

            }else //make a throw and custom error
            {
                Console.WriteLine("\nThe word was not found.  Maybe it has a different spelling or maybe it is not in the dictionary yet\n" +
                    "Please try again or check the word list");
            }
            return null;

            //UI ui = new UI();
            //ui.TryAgain("");


        }
    }
    
}
