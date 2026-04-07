using System;

public class AppointmentMenu
{
    private readonly AppointmentUtility _utility;

    public AppointmentMenu(AppointmentUtility utility)
    {
        _utility = utility;
    }

    public void Show()
    {
        while (true)
        {
            Console.WriteLine("\n--- Appointment Menu ---");
            Console.WriteLine("1. Book Appointment");
            Console.WriteLine("2. Check Doctor Availability");
            Console.WriteLine("3. Cancel Appointment");
            Console.WriteLine("4. Reschedule Appointment");
            Console.WriteLine("5. View Daily Schedule");
            Console.WriteLine("6. Back");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: _utility.BookAppointment(); break;
                case 2: _utility.CheckDoctorAvailability(); break;
                case 3: _utility.CancelAppointment(); break;
                case 4: _utility.RescheduleAppointment(); break;
                case 5: _utility.ViewDailySchedule(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }
}
