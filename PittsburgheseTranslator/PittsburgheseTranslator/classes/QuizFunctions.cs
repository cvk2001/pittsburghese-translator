using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PittsburgheseTranslator.classes
{
    public class QuizFunctions
    {
        public List<Questions> GetQuestions()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "pghquiz.txt";
            string filePath = Path.Combine(directory, fileName);
            List<Questions> answers = new List<Questions>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        answers.Add(new Questions(line));

                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("file not found...the count down has begun");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went horribly wrong");
            }
            return answers;
        }
    }
}
