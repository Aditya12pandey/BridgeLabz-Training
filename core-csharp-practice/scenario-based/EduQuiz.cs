using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//This C# program conducts a simple quiz of 10 questions by taking answers from the student.
//It compares the student’s answers with a predefined correct answer key.
//For each question, it displays whether the answer is correct or incorrect and calculates the total score.
//Finally, it computes and prints the student’s percentage based on the score obtained.
namespace BridgeLabzTraning.ScenarioBased
{
    internal class EduQuiz
    {
        public static void Main()
        {
            string[] CorrectAnswer = { "A", "D", "C", "B", "D", "A", "A", "C", "B", "A" };
#pragma warning disable CS8601 // Possible null reference assignment.
            string[] StudentAnswer = new string[10];
#pragma warning restore CS8601 // Possible null reference assignment.
            for(int i = 0; i < StudentAnswer.Length; i++)
            {
                Console.WriteLine("Enter answer no."+(i+1) );
                StudentAnswer[i] = Console.ReadLine().ToUpper();
            }
            int StudentScore = CalculateScore(CorrectAnswer, StudentAnswer);
            Console.WriteLine(StudentScore);
            double percentage = ((StudentScore * 100) / 10);
            Console.WriteLine("Student Percentage = " + percentage+"%");

        }

        static int CalculateScore(string[] CorrectAnswer, string[] StudentAnswer)
        {

            int Score = 0;
            for(int i = 0; i < StudentAnswer.Length; i++)
            {
                if (StudentAnswer[i].Equals(CorrectAnswer[i]) )
                {
                    Score += 1;
                    Console.WriteLine("Question-" + i +" Correct");
                }
                else
                {
                    Console.WriteLine("Question " + i + " Incorrect");
                }
            }


            return Score;
        }


    }



}

