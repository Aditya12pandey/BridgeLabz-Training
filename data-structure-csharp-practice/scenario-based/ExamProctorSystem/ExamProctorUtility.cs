using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.ExamProctorSystem
{
    internal class ExamProctorUtility : IExamProctorService
    {

        private class StackNode
        {
            public int Data;
            public StackNode Next;

            public StackNode(int data)
            {
                Data = data;
                Next = null;
            }
        }

        private class CustomStack
        {
            private StackNode top;

            public CustomStack()
            {
                top = null;
            }

            public void Push(int value)
            {
                StackNode newNode = new StackNode(value);
                newNode.Next = top;
                top = newNode;
            }

            public int Pop()
            {
                if (top == null) return -1;

                int value = top.Data;
                top = top.Next;
                return value;
            }

            public void Display()
            {
                if (top == null)
                {
                    Console.WriteLine(" Navigation history is empty.");
                    return;
                }

                Console.WriteLine(" Navigation Stack (Last visited first):");
                StackNode temp = top;
                while (temp != null)
                {
                    Console.WriteLine("Question ID: " + temp.Data);
                    temp = temp.Next;
                }
            }
        }

        private class MapEntry
        {
            public int Key;
            public string Value;
            public MapEntry Next;

            public MapEntry(int key, string value)
            {
                Key = key;
                Value = value;
                Next = null;
            }
        }

        private class CustomHashMap
        {
            private MapEntry[] buckets;
            private int size;

            public CustomHashMap(int size)
            {
                this.size = size;
                buckets = new MapEntry[size];
            }

            private int GetIndex(int key)
            {
                return Math.Abs(key) % size;
            }

            public void Put(int key, string value)
            {
                int index = GetIndex(key);

                if (buckets[index] == null)
                {
                    buckets[index] = new MapEntry(key, value);
                    return;
                }

                MapEntry temp = buckets[index];
                while (temp != null)
                {
                    if (temp.Key == key)
                    {
                        temp.Value = value;
                        return;
                    }

                    if (temp.Next == null)
                        break;

                    temp = temp.Next;
                }

                temp.Next = new MapEntry(key, value);
            }

            public string Get(int key)
            {
                int index = GetIndex(key);

                MapEntry temp = buckets[index];
                while (temp != null)
                {
                    if (temp.Key == key)
                        return temp.Value;

                    temp = temp.Next;
                }

                return null;
            }

            public void DisplayAll()
            {
                Console.WriteLine("\n Stored Answers (questionId -> answer):");
                bool found = false;

                for (int i = 0; i < size; i++)
                {
                    MapEntry temp = buckets[i];
                    while (temp != null)
                    {
                        Console.WriteLine($"{temp.Key} -> {temp.Value}");
                        found = true;
                        temp = temp.Next;
                    }
                }

                if (!found)
                    Console.WriteLine(" No answers submitted yet.");
            }
        }

        private CustomStack navigationStack;
        private CustomHashMap answersMap;

        private int totalQuestions;
        private int[] questionIds;
        private string[] correctAnswers;

        public ExamProctorUtility()
        {
            navigationStack = new CustomStack();
            answersMap = new CustomHashMap(10);

            totalQuestions = 5;
            questionIds = new int[] { 101, 102, 103, 104, 105 };
            correctAnswers = new string[] { "A", "C", "B", "D", "A" };
        }

        public void VisitQuestion(int questionId)
        {
            if (!IsValidQuestion(questionId))
            {
                Console.WriteLine(" Invalid Question ID!");
                return;
            }

            navigationStack.Push(questionId);
            Console.WriteLine($" Visited Question {questionId}");
        }

        public void GoBack()
        {
            int popped = navigationStack.Pop();

            if (popped == -1)
                Console.WriteLine("No previous question found (Stack empty).");
            else
                Console.WriteLine($" Going back from Question {popped}");
        }

        public void AnswerQuestion(int questionId, string answer)
        {
            if (!IsValidQuestion(questionId))
            {
                Console.WriteLine(" Invalid Question ID!");
                return;
            }

            if (string.IsNullOrWhiteSpace(answer))
            {
                Console.WriteLine(" Answer cannot be empty!");
                return;
            }

            answersMap.Put(questionId, answer.Trim().ToUpper());
            Console.WriteLine($" Answer saved for Question {questionId}");
        }

        public void ViewAnswer(int questionId)
        {
            string ans = answersMap.Get(questionId);

            if (ans == null)
                Console.WriteLine($" No answer found for Question {questionId}");
            else
                Console.WriteLine($" Question {questionId} Answer: {ans}");
        }

        public void ShowNavigationHistory()
        {
            navigationStack.Display();
        }

        public void SubmitExam()
        {
            Console.WriteLine("\n Submitting Exam...");

            answersMap.DisplayAll();

            int score = CalculateScore();
            Console.WriteLine("\n Final Score: " + score + " / " + totalQuestions);

            Console.WriteLine(" Exam Submitted Successfully!");
        }

        private int CalculateScore()
        {
            int score = 0;

            for (int i = 0; i < totalQuestions; i++)
            {
                int qId = questionIds[i];
                string correct = correctAnswers[i];

                string studentAnswer = answersMap.Get(qId);

                if (studentAnswer != null && studentAnswer.Equals(correct, StringComparison.OrdinalIgnoreCase))
                    score++;
            }

            return score;
        }

        private bool IsValidQuestion(int questionId)
        {
            for (int i = 0; i < totalQuestions; i++)
            {
                if (questionIds[i] == questionId)
                    return true;
            }
            return false;
        }
    }
}
