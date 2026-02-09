using System;

public class DoctorMenu
{
    private readonly DoctorUtility _utility;

    public DoctorMenu(DoctorUtility utility)
    {
        _utility = utility;
    }

    public void Show()
    {
        while (true)
        {
            Console.WriteLine("\n--- Doctor Menu ---");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Update Doctor Speciality");
            Console.WriteLine("3. View Doctors By Speciality");
            Console.WriteLine("4. Deactivate Doctor");
            Console.WriteLine("5. Back");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: _utility.AddDoctor(); break;
                case 2: _utility.UpdateDoctorSpeciality(); break;
                case 3: _utility.ViewDoctorsBySpeciality(); break;
                case 4: _utility.DeactivateDoctor(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }
}
