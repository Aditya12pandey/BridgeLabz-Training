using System;

class SpecialityMenu
{
    private readonly ISpecialityUtility _utility;

    public SpecialityMenu(ISpecialityUtility utility)
    {
        _utility = utility;
    }

    public void Show()
    {
        while (true)
        {
            Console.WriteLine(" Speciality Management ");
            Console.WriteLine("1. Add Speciality");
            Console.WriteLine("2. Update Speciality");
            Console.WriteLine("3. View Specialities");
            Console.WriteLine("4. Delete Speciality");
            Console.WriteLine("5. Back");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: _utility.AddSpeciality(); break;
                case 2: _utility.UpdateSpeciality(); break;
                case 3: _utility.ViewSpecialities(); break;
                case 4: _utility.DeleteSpeciality(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }
}
