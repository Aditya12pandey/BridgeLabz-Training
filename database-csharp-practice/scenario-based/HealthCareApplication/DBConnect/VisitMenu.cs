using System;
public class VisitMenu
{
    private readonly VisitUtility _utility;
    public VisitMenu(VisitUtility utility)
    {
        _utility = utility;
    }
    public void Show()
    {
        while (true)
        {
            Console.WriteLine("--- Visit & Medical Records Menu ---");
            Console.WriteLine("1. Record Patient Visit");
            Console.WriteLine("2. View Patient Medical History");
            Console.WriteLine("3. Add Prescriptions");
            Console.WriteLine("4. Back");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: _utility.RecordPatientVisit(); break;
                case 2: _utility.ViewPatientMedicalHistory(); break;
                case 3: _utility.AddPrescriptions(); break;
                case 4: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }
}
