using System;

//  INTERFACE 
interface IApprovable
{
    bool ApproveLoan();
    double CalculateEMI();
}

//  APPLICANT 
class Applicant
{
    public string Name { get; private set; }
    private int CreditScore;          // Encapsulated
    public double Income { get; private set; }
    public double LoanAmount { get; private set; }

    public Applicant(string name, int creditScore, double income, double loanAmount)
    {
        Name = name;
        CreditScore = creditScore;
        Income = income;
        LoanAmount = loanAmount;
    }

    public int GetCreditScore()
    {
        return CreditScore;
    }
}

//  BASE LOAN 
abstract class LoanApplication : IApprovable
{
    protected Applicant applicant;
    protected int Term;                 // months
    protected double InterestRate;       // annual %

    private bool approved;               // restricted access

    protected LoanApplication(Applicant applicant, int term, double interestRate)
    {
        this.applicant = applicant;
        Term = term;
        InterestRate = interestRate;
    }

    // Encapsulated approval logic
    public virtual bool ApproveLoan()
    {
        approved =
            applicant.GetCreditScore() >= 650 &&
            applicant.Income >= (applicant.LoanAmount / Term) * 2;

        return approved;
    }

    // EMI Formula
    public virtual double CalculateEMI()
    {
        double P = applicant.LoanAmount;
        double R = (InterestRate / 12) / 100;
        int N = Term;

        return (P * R * Math.Pow(1 + R, N)) /
               (Math.Pow(1 + R, N) - 1);
    }

    public void DisplayResult()
    {
        Console.WriteLine("\nApplicant Name : " + applicant.Name);
        Console.WriteLine("Loan Amount    : ₹" + applicant.LoanAmount);
        Console.WriteLine("Loan Term      : " + Term + " months");
        Console.WriteLine("Interest Rate  : " + InterestRate + "%");

        if (ApproveLoan())
        {
            Console.WriteLine("Loan Status    : APPROVED");
            Console.WriteLine($"Monthly EMI    : ₹{CalculateEMI():0.00}");
        }
        else
        {
            Console.WriteLine("Loan Status    : REJECTED");
        }
    }
}

//  HOME LOAN 
class HomeLoan : LoanApplication
{
    public HomeLoan(Applicant applicant, int term)
        : base(applicant, term, 8.5) { }

    // Polymorphism
    public override double CalculateEMI()
    {
        return base.CalculateEMI() * 0.98; // benefit
    }
}

//  AUTO LOAN 
class AutoLoan : LoanApplication
{
    public AutoLoan(Applicant applicant, int term)
        : base(applicant, term, 10.5) { }
}

//  PERSONAL LOAN 
class PersonalLoan : LoanApplication
{
    public PersonalLoan(Applicant applicant, int term)
        : base(applicant, term, 13.5) { }

    // Stricter approval rule
    public override bool ApproveLoan()
    {
        return
            applicant.GetCreditScore() >= 700 &&
            applicant.Income >= (applicant.LoanAmount / Term) * 3;
    }
}

//  MAIN PROGRAM 
class LoanBuddyApp
{
    static void Main()
    {
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine(" LoanBuddy – Loan Approval Automation");
            Console.WriteLine("1. Apply for Loan");
            Console.WriteLine("2. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                // Applicant Input
                Console.Write("\nEnter Applicant Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Credit Score: ");
                int creditScore = int.Parse(Console.ReadLine());

                Console.Write("Enter Monthly Income: ");
                double income = double.Parse(Console.ReadLine());

                Console.Write("Enter Loan Amount: ");
                double loanAmount = double.Parse(Console.ReadLine());

                Applicant applicant =
                    new Applicant(name, creditScore, income, loanAmount);

                // Loan Type Selection
                Console.WriteLine("\nSelect Loan Type:");
                Console.WriteLine("1. Home Loan");
                Console.WriteLine("2. Auto Loan");
                Console.WriteLine("3. Personal Loan");
                Console.Write("Enter choice: ");
                int loanType = int.Parse(Console.ReadLine());

                Console.Write("Enter Loan Term (months): ");
                int term = int.Parse(Console.ReadLine());

                LoanApplication loan = null;

                switch (loanType)
                {
                    case 1:
                        loan = new HomeLoan(applicant, term);
                        break;
                    case 2:
                        loan = new AutoLoan(applicant, term);
                        break;
                    case 3:
                        loan = new PersonalLoan(applicant, term);
                        break;
                    default:
                        Console.WriteLine(" Invalid loan type");
                        break;
                }

                if (loan != null)
                    loan.DisplayResult();

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

        } while (choice != 2);

        Console.WriteLine("\nThank you for using LoanBuddy!");
    }
}
