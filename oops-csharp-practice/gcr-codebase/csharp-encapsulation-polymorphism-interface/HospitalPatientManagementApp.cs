using System;
using System.Collections.Generic;

namespace HospitalPatientManagement
{
    // Interface for Medical Records
    interface IMedicalRecord
    {
        void AddRecord(string record);
        void ViewRecords();
    }

    // Abstract Patient class
    abstract class Patient
    {
        // Encapsulated fields
        private int patientId;
        private string name;
        private int age;

        // Sensitive medical data (restricted access)
        private string diagnosis;
        private List<string> medicalHistory = new List<string>();

        // Properties
        public int PatientId
        {
            get { return patientId; }
            private set { patientId = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        // Constructor
        public Patient(int id, string name, int age)
        {
            patientId = id;
            this.name = name;
            this.age = age;
        }

        // Abstract method
        public abstract double CalculateBill();

        // Concrete method
        public void GetPatientDetails()
        {
            Console.WriteLine("Patient ID   : " + PatientId);
            Console.WriteLine("Name         : " + Name);
            Console.WriteLine("Age          : " + Age);
            Console.WriteLine("Bill Amount  : " + CalculateBill());
            Console.WriteLine("----------------------------------");
        }

        // Protected medical data methods
        protected void SetDiagnosis(string diagnosisInfo)
        {
            diagnosis = diagnosisInfo;
        }

        protected void AddToMedicalHistory(string record)
        {
            medicalHistory.Add(record);
        }

        protected void DisplayMedicalHistory()
        {
            Console.WriteLine("Diagnosis : " + diagnosis);
            Console.WriteLine("Medical History:");
            foreach (string record in medicalHistory)
            {
                Console.WriteLine("- " + record);
            }
        }
    }

    // In-Patient class
    class InPatient : Patient, IMedicalRecord
    {
        private int numberOfDays;
        private double dailyCharge;

        public InPatient(int id, string name, int age, int days, double chargePerDay)
            : base(id, name, age)
        {
            numberOfDays = days;
            dailyCharge = chargePerDay;
        }

        public override double CalculateBill()
        {
            return numberOfDays * dailyCharge + 5000; // extra hospital charges
        }

        public void AddRecord(string record)
        {
            SetDiagnosis("Admitted Patient");
            AddToMedicalHistory(record);
        }

        public void ViewRecords()
        {
            DisplayMedicalHistory();
        }
    }

    // Out-Patient class
    class OutPatient : Patient, IMedicalRecord
    {
        private double consultationFee;

        public OutPatient(int id, string name, int age, double consultationFee)
            : base(id, name, age)
        {
            this.consultationFee = consultationFee;
        }

        public override double CalculateBill()
        {
            return consultationFee;
        }

        public void AddRecord(string record)
        {
            SetDiagnosis("Consultation Patient");
            AddToMedicalHistory(record);
        }

        public void ViewRecords()
        {
            DisplayMedicalHistory();
        }
    }

    // Main Application Class
    class HospitalPatientManagementApp
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>
            {
                new InPatient(1, "Rahul", 45, 5, 2000),
                new OutPatient(2, "Anita", 30, 800)
            };

            // Add medical records
            ((IMedicalRecord)patients[0]).AddRecord("Surgery performed");
            ((IMedicalRecord)patients[1]).AddRecord("Routine check-up");

            // Polymorphism demonstration
            foreach (Patient patient in patients)
            {
                patient.GetPatientDetails();
            }

            Console.ReadLine();
        }
    }
}
