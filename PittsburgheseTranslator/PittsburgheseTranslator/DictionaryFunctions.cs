using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PittsburgheseTranslator
{
    public class DictionaryFunctions
    {
        
        private bool createDictionary()
        {Dictionary<string, string> pgheseDictionary = new Dictionary<string, string>();
            
            string directory = Environment.CurrentDirectory;
            string fileName = "pittsburghese.txt";
            string fullPath=Path.Combine(directory, fileName);
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    string[] wordLine = sr.ReadLine().Split('|');
                    pgheseDictionary[wordLine[0]] = wordLine[1];
                }
            }catch(FileNotFoundException e)
            {
                Console.WriteLine("Something must have happened to the file.  Please contact support!");
            }catch (Exception e)
            {
                Console.WriteLine("Please contact support");
            }
            return true;
        }
    }
    
    
}
