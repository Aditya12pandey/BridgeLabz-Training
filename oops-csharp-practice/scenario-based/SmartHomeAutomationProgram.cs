using System;
using System.Collections.Generic;

namespace SmartHomeAutomation
{
    // INTERFACE
    interface IControllable
    {
        void TurnOn();
        void TurnOff();
    }

    abstract class Appliance : IControllable
    {
        public string Name { get; protected set; }
        public bool IsOn { get; protected set; }

        public Appliance(string name)
        {
            Name = name;
            IsOn = false;
        }

        public abstract void TurnOn();

        public virtual void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} is turned OFF.");
        }

        public void ShowStatus()
        {
            Console.WriteLine($"{Name} Status: {(IsOn ? "ON" : "OFF")}");
        }
    }

    // LIGHT CLASS
    class Light : Appliance
    {
        public Light() : base("Light") { }

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("Light is turned ON with soft brightness.");
        }
    }

    // FAN CLASS
    class Fan : Appliance
    {
        public Fan() : base("Fan") { }

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("Fan is spinning at medium speed.");
        }
    }

    // AC CLASS
    class AC : Appliance
    {
        public AC() : base("AC") { }

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("AC is turned ON. Cooling at 22°C.");
        }
    }

    // MAIN PROGRAM
    class SmartHomeAutomationProgram
    {
        static void Main()
        {
            List<Appliance> appliances = new List<Appliance>
            {
                new Light(),
                new Fan(),
                new AC()
            };

            int choice;
            do
            {
                Console.WriteLine("\n SMART HOME AUTOMATION ");
                Console.WriteLine("1. Turn ON Appliance");
                Console.WriteLine("2. Turn OFF Appliance");
                Console.WriteLine("3. Show Appliance Status");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ControlAppliance(appliances, true);
                        break;

                    case 2:
                        ControlAppliance(appliances, false);
                        break;

                    case 3:
                        foreach (var app in appliances)
                            app.ShowStatus();
                        break;

                    case 4:
                        Console.WriteLine("Exiting Smart Home System...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            } while (choice != 4);
        }

        static void ControlAppliance(List<Appliance> appliances, bool turnOn)
        {
            Console.WriteLine("\nSelect Appliance:");
            for (int i = 0; i < appliances.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {appliances[i].Name}");
            }

            Console.Write("Enter option: ");
            int option = int.Parse(Console.ReadLine()) - 1;

            if (option >= 0 && option < appliances.Count)
            {
                if (turnOn)
                    appliances[option].TurnOn();   // POLYMORPHISM
                else
                    appliances[option].TurnOff();
            }
            else
            {
                Console.WriteLine("Invalid appliance selection!");
            }
        }
    }
}
