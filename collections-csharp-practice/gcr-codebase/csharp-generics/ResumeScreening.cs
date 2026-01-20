using System;
using System.Collections.Generic;

//  Abstract class JobRole 
// Every job role must define how to calculate score
abstract class JobRole
{
    public string RoleName { get; set; }

    public JobRole(string roleName)
    {
        RoleName = roleName;
    }

    public abstract int CalculateScore(ResumeData data);
}

//   Resume Data Class 
class ResumeData
{
    public string CandidateName;
    public int YearsExperience;
    public int Projects;
    public int Certifications;
    public int CodingSkill;   // out of 10
    public int MLKnowledge;   // out of 10
}

//  Software Engineer Role 
class SoftwareEngineer : JobRole
{
    public SoftwareEngineer() : base("Software Engineer") { }

    public override int CalculateScore(ResumeData data)
    {
        int score = 0;

        score += data.YearsExperience * 10;  // experience important
        score += data.Projects * 5;
        score += data.CodingSkill * 8;

        return score;
    }
}

//  Data Scientist Role 
class DataScientist : JobRole
{
    public DataScientist() : base("Data Scientist") { }

    public override int CalculateScore(ResumeData data)
    {
        int score = 0;

        score += data.YearsExperience * 8;
        score += data.Projects * 6;
        score += data.Certifications * 7;
        score += data.MLKnowledge * 10;

        return score;
    }
}

//   Generic Resume<T> class 
class Resume<T> where T : JobRole, new()
{
    public ResumeData Data;

    public Resume(ResumeData data)
    {
        Data = data;
    }

    // Generic Method to process resume
    public void ScreenResume()
    {
        T role = new T(); // role object created automatically

        Console.WriteLine($" Candidate: {Data.CandidateName}");
        Console.WriteLine($" Applying for: {role.RoleName}");

        int score = role.CalculateScore(Data);

        Console.WriteLine($" Score: {score}");

        if (score >= 60)
            Console.WriteLine(" RESULT: SELECTED ");
        else
            Console.WriteLine(" RESULT: REJECTED");
    }
}

//   Main Program 
class ResumeScreening
{
    static void Main()
    {
        Console.WriteLine("=== AI-Driven Resume Screening System ===");

        // Creating candidate resumes
        ResumeData r1 = new ResumeData()
        {
            CandidateName = "Aditya",
            YearsExperience = 2,
            Projects = 5,
            Certifications = 1,
            CodingSkill = 8,
            MLKnowledge = 4
        };

        ResumeData r2 = new ResumeData()
        {
            CandidateName = "Neha",
            YearsExperience = 1,
            Projects = 3,
            Certifications = 2,
            CodingSkill = 5,
            MLKnowledge = 9
        };

        // Screening Pipeline using List<T>
        Console.WriteLine("\n--- Screening Pipeline Started ---");

        List<Action> screeningPipeline = new List<Action>();

        screeningPipeline.Add(() =>
        {
            Resume<SoftwareEngineer> resume1 = new Resume<SoftwareEngineer>(r1);
            resume1.ScreenResume();
        });

        screeningPipeline.Add(() =>
        {
            Resume<DataScientist> resume2 = new Resume<DataScientist>(r2);
            resume2.ScreenResume();
        });

        // Run pipeline
        foreach (var task in screeningPipeline)
        {
            task();
        }

        Console.WriteLine("\n Screening Pipeline Completed");
    }
}
