using System;

class Patient
{
    // static members
    public static string HospitalName = "City Care Hospital";
    private static int totalPatients = 0;

    // readonly field
    public readonly int PatientID;

    // instance variables
    public string Name;
    public int Age;
    public string Ailment;

    // constructor using this
    public Patient(string name, int age, string ailment, int patientId)
    {
        this.Name = name;
        this.Age = age;
        this.Ailment = ailment;
        this.PatientID = patientId;
        totalPatients++;
    }

    // static method
    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients Admitted: " + totalPatients);
    }

    public void DisplayPatient()
    {
        Console.WriteLine("\nHospital  : " + HospitalName);
        Console.WriteLine("PatientID : " + PatientID);
        Console.WriteLine("Name      : " + Name);
        Console.WriteLine("Age       : " + Age);
        Console.WriteLine("Ailment   : " + Ailment);
    }
}

class HospitalApp
{
    public static void Main()
    {
        Patient p1 = new Patient("Ravi", 45, "Fever", 501);
        Patient p2 = new Patient("Neha", 30, "Migraine", 502);

        if (p1 is Patient)
            p1.DisplayPatient();

        if (p2 is Patient)
            p2.DisplayPatient();

        Patient.GetTotalPatients();
    }
}
