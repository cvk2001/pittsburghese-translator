using System;
using System.Collections.Generic;
using System.Text;

namespace PittsburgheseTranslator.classes
{
    public class Questions
    {
        public int correctAnswer;
        public string quizQuestion;
        public List<string> answers = new List<string>();
        public string QuizQuestion
        {
            get
            {
                return quizQuestion;
            }
        }
        public string[] Answers
        {
            get
            {
                return answers.ToArray();
            }

        }
        public Questions(string line)
        {
            if (!String.IsNullOrEmpty(line))
            {
                string[] parts = line.Split("|");
                quizQuestion = parts[0];
                for (int i = 1; i < parts.Length; i++)
                {
                    string answer = parts[i].Trim();
                    if (answer.EndsWith("*"))
                    {
                        answer = answer.Substring(0, parts[i].Length - 1);
                        correctAnswer = i - 1;
                    }
                    answers.Add(answer);
                }

            }
        }
        public bool IsCorrectAnswer(int selectedAnswer)
        {
            return correctAnswer == selectedAnswer;
        }
    }
}
