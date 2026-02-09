using System;

public class PatientMenu
{
    private readonly PatientUtility _utility;

    public PatientMenu(PatientUtility utility)
    {
        _utility = utility;
    }

    public void Show()
    {
        while (true)
        {
            Console.WriteLine("\n--- Patient Menu ---");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. Update Patient");
            Console.WriteLine("3. Search Patient");
            Console.WriteLine("4. View Patient Visit History");
            Console.WriteLine("5. Back");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: _utility.RegisterPatient(); break;
                case 2: _utility.UpdatePatient(); break;
                case 3: _utility.SearchPatient(); break;
                case 4: _utility.ViewPatientHistory(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }
}
