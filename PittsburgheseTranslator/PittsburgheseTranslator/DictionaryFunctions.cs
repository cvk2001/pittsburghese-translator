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
                        pgheseDictionary[wordLine[0]] = wordLine[1];
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
            return true;

        }
    }
    
}
