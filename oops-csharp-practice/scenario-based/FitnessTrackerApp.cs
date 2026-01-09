using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased
{
    public interface ITrackable
    {
        double CalculateCalories();
        void TrackProgress();
    }

    // Abstract Base Class
    public abstract class Workout
    {
        public int WorkoutId { get; set; }
        public int Duration { get; set; }   // in minutes
        public DateTime Date { get; set; }

        public abstract void DisplayWorkout();
    }

    // Cardio Workout
    public class CardioWorkout : Workout, ITrackable
    {
        public double Distance { get; set; } // in km

        public double CalculateCalories()
        {
            return Distance * 60;
        }

        public void TrackProgress()
        {
            Console.WriteLine("Tracking Cardio Workout Progress...");
        }

        public override void DisplayWorkout()
        {
            Console.WriteLine("\n--- Cardio Workout ---");
            Console.WriteLine($"Workout ID : {WorkoutId}");
            Console.WriteLine($"Duration   : {Duration} minutes");
            Console.WriteLine($"Distance   : {Distance} km");
            Console.WriteLine($"Calories   : {CalculateCalories()}");
            Console.WriteLine($"Date       : {Date.ToShortDateString()}");
        }
    }

    // Strength Workout
    public class StrengthWorkout : Workout, ITrackable
    {
        public int Sets { get; set; }
        public int Repetitions { get; set; }

        public double CalculateCalories()
        {
            return Sets * Repetitions * 0.5;
        }

        public void TrackProgress()
        {
            Console.WriteLine("Tracking Strength Workout Progress...");
        }

        public override void DisplayWorkout()
        {
            Console.WriteLine("\n--- Strength Workout ---");
            Console.WriteLine($"Workout ID : {WorkoutId}");
            Console.WriteLine($"Duration   : {Duration} minutes");
            Console.WriteLine($"Sets       : {Sets}");
            Console.WriteLine($"Reps       : {Repetitions}");
            Console.WriteLine($"Calories   : {CalculateCalories()}");
            Console.WriteLine($"Date       : {Date.ToShortDateString()}");
        }
    }

    // User Profile Class
    public class UserProfile
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        public void DisplayProfile()
        {
            Console.WriteLine("\n--- User Profile ---");
            Console.WriteLine($"User ID : {UserId}");
            Console.WriteLine($"Name    : {Name}");
            Console.WriteLine($"Age     : {Age}");
            Console.WriteLine($"Weight  : {Weight} kg");
            Console.WriteLine($"Height  : {Height} cm");
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            UserProfile user = new UserProfile();
            List<Workout> workouts = new List<Workout>();
            int choice;

            do
            {
                Console.WriteLine("\n===== FitTrack – Fitness Tracker =====");
                Console.WriteLine("1. Create User Profile");
                Console.WriteLine("2. Add Cardio Workout");
                Console.WriteLine("3. Add Strength Workout");
                Console.WriteLine("4. View All Workouts");
                Console.WriteLine("5. View User Profile");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter User ID: ");
                        user.UserId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        user.Name = Console.ReadLine();

                        Console.Write("Enter Age: ");
                        user.Age = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Weight (kg): ");
                        user.Weight = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Height (cm): ");
                        user.Height = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("User Profile Created Successfully!");
                        break;

                    case 2:
                        CardioWorkout cardio = new CardioWorkout();

                        Console.Write("Enter Workout ID: ");
                        cardio.WorkoutId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Duration (minutes): ");
                        cardio.Duration = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Distance (km): ");
                        cardio.Distance = Convert.ToDouble(Console.ReadLine());

                        cardio.Date = DateTime.Now;
                        workouts.Add(cardio);

                        Console.WriteLine("Cardio Workout Added!");
                        break;

                    case 3:
                        StrengthWorkout strength = new StrengthWorkout();

                        Console.Write("Enter Workout ID: ");
                        strength.WorkoutId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Duration (minutes): ");
                        strength.Duration = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Sets: ");
                        strength.Sets = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Repetitions: ");
                        strength.Repetitions = Convert.ToInt32(Console.ReadLine());

                        strength.Date = DateTime.Now;
                        workouts.Add(strength);

                        Console.WriteLine("Strength Workout Added!");
                        break;

                    case 4:
                        if (workouts.Count == 0)
                        {
                            Console.WriteLine("No workouts recorded yet.");
                        }
                        else
                        {
                            foreach (Workout w in workouts)
                            {
                                w.DisplayWorkout();   // Polymorphism
                            }
                        }
                        break;

                    case 5:
                        user.DisplayProfile();
                        break;

                    case 6:
                        Console.WriteLine("Thank you for using FitTrack!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

            } while (choice != 6);
        }
    }
}

