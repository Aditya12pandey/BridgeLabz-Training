using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased
{
    internal class Temprature
    {
        static void AnalyzeTemperatures(float[,] temps)
        {
            float hottestAvg = 0;
            float coldestAvg = 0;
            int hottestDay = 0;
            int coldestDay = 0;

            for (int day = 0; day < 7; day++)
            {
                float sum = 0;

                for (int hour = 0; hour < 24; hour++)
                {
                    sum += temps[day, hour];
                }

                float avg = sum / 24;
                Console.WriteLine("Day " + (day + 1) + " Average Temperature: " + avg);

                if (day == 0)
                {
                    hottestAvg = avg;
                    coldestAvg = avg;
                }
                else
                {
                    if (avg > hottestAvg)
                    {
                        hottestAvg = avg;
                        hottestDay = day;
                    }

                    if (avg < coldestAvg)
                    {
                        coldestAvg = avg;
                        coldestDay = day;
                    }
                }
            }

            Console.WriteLine("\nHottest Day: Day " + (hottestDay + 1));
            Console.WriteLine("Coldest Day: Day " + (coldestDay + 1));
        }

        static void Main()
        {
            float[,] temperatures = new float[7, 24];
            Random rand = new Random();

            Console.WriteLine("Generating random hourly temperatures...\n");

            for (int day = 0; day < 7; day++)
            {
                Console.WriteLine("Day " + (day + 1));
                for (int hour = 0; hour < 24; hour++)
                {
                    // Random temperature between 15 and 40
                    temperatures[day, hour] = rand.Next(15, 41);
                    Console.WriteLine("Hour " + (hour + 1) + ": " + temperatures[day, hour]);
                }
                Console.WriteLine();
            }

            AnalyzeTemperatures(temperatures);
        }
    }
}
