using System;
using System.Collections.Generic;

class InsurancePolicy
{
    public int PolicyNumber;
    public string HolderName;
    public string CoverageType;
    public DateTime ExpiryDate;

    public InsurancePolicy(int policyNumber, string holderName, string coverageType, DateTime expiryDate)
    {
        PolicyNumber = policyNumber;
        HolderName = holderName;
        CoverageType = coverageType;
        ExpiryDate = expiryDate;
    }

    public override string ToString()
    {
        return $"PolicyNo: {PolicyNumber}, Name: {HolderName}, Coverage: {CoverageType}, Expiry: {ExpiryDate:dd-MM-yyyy}";
    }
}

class InsurancePolicyRetrieval
{
    static void Main()
    {
        Console.Write("Enter number of policies: ");
        int n = Convert.ToInt32(Console.ReadLine());

        List<InsurancePolicy> allPolicies = new List<InsurancePolicy>();

        // For unique policies (based on PolicyNumber)
        HashSet<int> uniquePolicyNumbers = new HashSet<int>();
        List<InsurancePolicy> uniquePolicies = new List<InsurancePolicy>();

        // For duplicates
        Dictionary<int, int> policyCount = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nEnter Policy Details:");

            Console.Write("Policy Number: ");
            int policyNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Holder Name: ");
            string name = Console.ReadLine();

            Console.Write("Coverage Type (Health/Car/Life/Home): ");
            string coverage = Console.ReadLine();

            Console.Write("Expiry Date (yyyy-mm-dd): ");
            DateTime expiry = Convert.ToDateTime(Console.ReadLine());

            InsurancePolicy policy = new InsurancePolicy(policyNo, name, coverage, expiry);
            allPolicies.Add(policy);

            // Counting duplicates
            if (policyCount.ContainsKey(policyNo))
                policyCount[policyNo]++;
            else
                policyCount[policyNo] = 1;

            // Unique policies
            if (uniquePolicyNumbers.Add(policyNo))
                uniquePolicies.Add(policy);
        }

        //  All Unique Policies
        Console.WriteLine("\n All Unique Policies:");
        foreach (var p in uniquePolicies)
            Console.WriteLine(p);

        //Policies Expiring Soon (within next 30 days)
        Console.WriteLine("\n Policies Expiring Soon (Next 30 days):");
        DateTime today = DateTime.Today;
        DateTime limit = today.AddDays(30);

        bool foundSoon = false;
        foreach (var p in uniquePolicies)
        {
            if (p.ExpiryDate >= today && p.ExpiryDate <= limit)
            {
                Console.WriteLine(p);
                foundSoon = true;
            }
        }

        if (!foundSoon)
            Console.WriteLine("No policies expiring within 30 days.");

        //  Policies with Specific Coverage Type
        Console.Write("\nEnter coverage type to search: ");
        string searchCoverage = Console.ReadLine();

        Console.WriteLine($"\n Policies with Coverage Type = {searchCoverage}:");
        bool foundCoverage = false;

        foreach (var p in uniquePolicies)
        {
            if (p.CoverageType.Equals(searchCoverage, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(p);
                foundCoverage = true;
            }
        }

        if (!foundCoverage)
            Console.WriteLine("No policies found for this coverage type.");

        //  4) Duplicate Policies based on Policy Number
        Console.WriteLine("\n Duplicate Policies (Same Policy Number):");
        bool foundDuplicate = false;

        foreach (var pair in policyCount)
        {
            if (pair.Value > 1)
            {
                Console.WriteLine("Policy Number " + pair.Key + " is repeated " + pair.Value + " times");
                foundDuplicate = true;
            }
        }

        if (!foundDuplicate)
            Console.WriteLine("No duplicate policies found.");
    }
}
