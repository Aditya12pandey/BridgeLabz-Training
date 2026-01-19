using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.ExamProctorSystem
{
    internal class ExamProctorMain
    {
        public static void Main(string[] args)
        {
            IExamProctorService service = new ExamProctorUtility();
            int choice;

            do
            {
                Console.WriteLine("1. Visit Question (Push to Stack)");
                Console.WriteLine("2. Go Back (Pop from Stack)");
                Console.WriteLine("3. Answer Question (Store in HashMap)");
                Console.WriteLine("4. View Answer");
                Console.WriteLine("5. Show Navigation History");
                Console.WriteLine("6. Submit Exam (Auto Score)");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine(" Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Question ID to visit: ");
                        int visitId = Convert.ToInt32(Console.ReadLine());
                        service.VisitQuestion(visitId);
                        break;

                    case 2:
                        service.GoBack();
                        break;

                    case 3:
                        Console.Write("Enter Question ID: ");
                        int ansId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Answer (A/B/C/D): ");
                        string answer = Console.ReadLine();

                        service.AnswerQuestion(ansId, answer);
                        break;

                    case 4:
                        Console.Write("Enter Question ID to view answer: ");
                        int viewId = Convert.ToInt32(Console.ReadLine());
                        service.ViewAnswer(viewId);
                        break;

                    case 5:
                        service.ShowNavigationHistory();
                        break;

                    case 6:
                        service.SubmitExam();
                        break;

                    case 0:
                        Console.WriteLine(" Exit. Thank you!");
                        break;

                    default:
                        Console.WriteLine(" Invalid choice! Try again.");
                        break;
                }

            } while (choice != 0);
        }
    }
}
