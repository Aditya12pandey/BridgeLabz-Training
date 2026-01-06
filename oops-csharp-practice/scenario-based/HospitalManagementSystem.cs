//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraning.ScenarioBased
//{
//    interface IPayable
//    {
//        double CalculateBill();
//}

//// ---------------- PATIENT BASE CLASS ----------------
//abstract class Patient
//{
//    public int PatientId { get; set; }
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public Doctor AssignedDoctor { get; set; }

//    public Patient(int id, string name, int age, Doctor doctor)
//    {
//        PatientId = id;
//        Name = name;
//        Age = age;
//        AssignedDoctor = doctor;
//    }

//    public abstract void DisplayInfo();
//}

//// ---------------- INPATIENT ----------------
//class InPatient : Patient, IPayable
//{
//    public int DaysAdmitted { get; set; }
//    public double DailyCharge { get; set; }

//    public InPatient(int id, string name, int age, Doctor doctor,
//                     int days, double charge)
//        : base(id, name, age, doctor)
//    {
//        DaysAdmitted = days;
//        DailyCharge = charge;
//    }

//    public double CalculateBill()
//    {
//        return DaysAdmitted * DailyCharge;
//    }

//    public override void DisplayInfo()
//    {
//        Console.WriteLine("\n--- InPatient Details ---");
//        Console.WriteLine($"ID: {PatientId}");
//        Console.WriteLine($"Name: {Name}");
//        Console.WriteLine($"Age: {Age}");
//        Console.WriteLine($"Doctor: {AssignedDoctor.Name}");
//        Console.WriteLine($"Days Admitted: {DaysAdmitted}");
//        Console.WriteLine($"Total Bill: ₹{CalculateBill()}");
//    }
//}

//// ---------------- OUTPATIENT ----------------
//class OutPatient : Patient, IPayable
//{
//    public double ConsultationFee { get; set; }

//    public OutPatient(int id, string name, int age, Doctor doctor,
//                      double fee)
//        : base(id, name, age, doctor)
//    {
//        ConsultationFee = fee;
//    }

//    public double CalculateBill()
//    {
//        return ConsultationFee;
//    }

//    public override void DisplayInfo()
//    {
//        Console.WriteLine("\n--- OutPatient Details ---");
//        Console.WriteLine($"ID: {PatientId}");
//        Console.WriteLine($"Name: {Name}");
//        Console.WriteLine($"Age: {Age}");
//        Console.WriteLine($"Doctor: {AssignedDoctor.Name}");
//        Console.WriteLine($"Consultation Fee: ₹{CalculateBill()}");
//    }
//}

//// ---------------- DOCTOR CLASS ----------------
//class Doctor
//{
//    public int DoctorId { get; set; }
//    public string Name { get; set; }
//    public string Specialization { get; set; }

//    public Doctor(int id, string name, string specialization)
//    {
//        DoctorId = id;
//        Name = name;
//        Specialization = specialization;
//    }
//}
//internal class HospitalManagementSystem
//    {
//        static void Main()
//        {
//            Doctor doctor = new Doctor(1, "Dr. Sharma", "Physician");
//            Patient patient = null;

//            while (true)
//            {
//                Console.WriteLine("\n===== Hospital Patient Management System =====");
//                Console.WriteLine("1. Add InPatient");
//                Console.WriteLine("2. Add OutPatient");
//                Console.WriteLine("3. Display Patient Info");
//                Console.WriteLine("4. Exit");
//                Console.Write("Choose an option: ");

//                int choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        Console.Write("Enter Patient ID: ");
//                        int ipId = Convert.ToInt32(Console.ReadLine());

//                        Console.Write("Enter Name: ");
//                        string ipName = Console.ReadLine();

//                        Console.Write("Enter Age: ");
//                        int ipAge = Convert.ToInt32(Console.ReadLine());

//                        Console.Write("Enter Days Admitted: ");
//                        int days = Convert.ToInt32(Console.ReadLine());

//                        Console.Write("Enter Daily Charge: ");
//                        double charge = Convert.ToDouble(Console.ReadLine());

//                        patient = new InPatient(ipId, ipName, ipAge, doctor, days, charge);
//                        Console.WriteLine("InPatient added successfully!");
//                        break;

//                    case 2:
//                        Console.Write("Enter Patient ID: ");
//                        int opId = Convert.ToInt32(Console.ReadLine());

//                        Console.Write("Enter Name: ");
//                        string opName = Console.ReadLine();

//                        Console.Write("Enter Age: ");
//                        int opAge = Convert.ToInt32(Console.ReadLine());

//                        Console.Write("Enter Consultation Fee: ");
//                        double fee = Convert.ToDouble(Console.ReadLine());

//                        patient = new OutPatient(opId, opName, opAge, doctor, fee);
//                        Console.WriteLine("OutPatient added successfully!");
//                        break;

//                    case 3:
//                        if (patient != null)
//                            patient.DisplayInfo(); // Polymorphism
//                        else
//                            Console.WriteLine("No patient record found!");
//                        break;

//                    case 4:
//                        Console.WriteLine("Thank you for using the system!");
//                        return;

//                    default:
//                        Console.WriteLine("Invalid choice!");
//                        break;
//                }
//            }
//        }
//    }
//}
