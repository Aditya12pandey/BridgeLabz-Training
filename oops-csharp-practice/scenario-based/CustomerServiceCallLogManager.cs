using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased
{
    class CallLog
    {
        public string PhoneNumber;
        public string Message;
        public DateTime Timestamp;

        // Constructor
        public CallLog(string phoneNumber, string message, DateTime timestamp)
        {
            PhoneNumber = phoneNumber;
            Message = message;
            Timestamp = timestamp;
        }

        public void Display()
        {
            Console.WriteLine("Phone: " + PhoneNumber);
            Console.WriteLine("Message: " + Message);
            Console.WriteLine("Time: " + Timestamp);
            Console.WriteLine("-------------------------");
        }
    }

    // ---------- CallLogManager Class ----------
    class CallLogManager
    {
        private CallLog[] logs;
        private int count;

        public CallLogManager(int size)
        {
            logs = new CallLog[size];
            count = 0;
        }

        // Add a new call log
        public void AddCallLog(string phone, string message, DateTime time)
        {
            if (count < logs.Length)
            {
                logs[count] = new CallLog(phone, message, time);
                count++;
            }
            else
            {
                Console.WriteLine("Call log storage is full.");
            }
        }

        // Search logs by keyword in message
        public void SearchByKeyword(string keyword)
        {
            Console.WriteLine("\nSearch Results for keyword: " + keyword);
            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (logs[i].Message.Contains(keyword))
                {
                    logs[i].Display();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No logs found with given keyword.");
            }
        }

        // Filter logs by time range
        public void FilterByTime(DateTime start, DateTime end)
        {
            Console.WriteLine("\nLogs between " + start + " and " + end);
            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (logs[i].Timestamp >= start && logs[i].Timestamp <= end)
                {
                    logs[i].Display();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No logs found in this time range.");
            }
        }
    }
    internal class CustomerServiceCallLogManager
    {
        static void Main()
        {
            CallLogManager manager = new CallLogManager(10);

            // Adding call logs
            manager.AddCallLog("9876543210", "Network issue in my area", DateTime.Now.AddHours(-5));
            manager.AddCallLog("9123456780", "Internet is very slow", DateTime.Now.AddHours(-3));
            manager.AddCallLog("9988776655", "Billing issue this month", DateTime.Now.AddHours(-1));

            // Search by keyword
            manager.SearchByKeyword("issue");

            // Filter by time range
            DateTime startTime = DateTime.Now.AddHours(-4);
            DateTime endTime = DateTime.Now;
            manager.FilterByTime(startTime, endTime);
        }
    }
}
