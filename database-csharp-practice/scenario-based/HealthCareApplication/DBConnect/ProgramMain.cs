using System;

class ProgramMain
{
    static void Main()
    {
        IConnection connection = new HealthClinicConnection();

        PatientUtility patientUtility = new PatientUtility(connection);
        PatientMenu patientMenu = new PatientMenu(patientUtility);

        DoctorUtility doctorUtility = new DoctorUtility(connection);
        DoctorMenu doctorMenu = new DoctorMenu(doctorUtility);

        AppointmentUtility appointmentUtility = new AppointmentUtility(connection);
        AppointmentMenu appointmentMenu = new AppointmentMenu(appointmentUtility);

        VisitUtility visitUtility = new VisitUtility(connection);
        VisitMenu visitMenu = new VisitMenu(visitUtility);

        BillingUtility billingUtility = new BillingUtility(connection);
        BillingMenu billingMenu = new BillingMenu(billingUtility);

        SpecialityUtility specialityUtility = new SpecialityUtility(connection);
        SpecialityMenu specialityMenu = new SpecialityMenu(specialityUtility);


        while (true)
        {
            Console.WriteLine("------ Hospital Management System -----");
            Console.WriteLine("1. Patient Management");
            Console.WriteLine("2. Doctor Management");
            Console.WriteLine("3. Appointment Management");
            Console.WriteLine("4. Visit & Medical Records");
            Console.WriteLine("5. Billing & Payments");
            Console.WriteLine("6. Speciality Management");
            Console.WriteLine("7. Exit");

            Console.Write("Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: patientMenu.Show(); break;
                case 2: doctorMenu.Show(); break;
                case 3: appointmentMenu.Show(); break;
                case 4: visitMenu.Show(); break;
                case 5: billingMenu.Show(); break;
                case 6: specialityMenu.Show(); break;
                case 7: return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
