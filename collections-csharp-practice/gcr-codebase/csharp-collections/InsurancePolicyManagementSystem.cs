using System;
using System.Collections.Generic;

class InsurancePolicy
{
    public int PolicyId;
    public string HolderName;
    public DateTime ExpiryDate;

    public InsurancePolicy(int policyId, string holderName, DateTime expiryDate)
    {
        PolicyId = policyId;
        HolderName = holderName;
        ExpiryDate = expiryDate;
    }

    public override string ToString()
    {
        return $"PolicyId: {PolicyId}, Holder: {HolderName}, Expiry: {ExpiryDate:dd-MM-yyyy}";
    }

    // HashSet will check uniqueness using PolicyId
    public override bool Equals(object obj)
    {
        InsurancePolicy other = obj as InsurancePolicy;
        if (other == null) return false;
        return this.PolicyId == other.PolicyId;
    }

    public override int GetHashCode()
    {
        return PolicyId.GetHashCode();
    }
}

// SortedSet needs a comparer (sort by expiry date)
class ExpiryDateComparer : IComparer<InsurancePolicy>
{
    public int Compare(InsurancePolicy x, InsurancePolicy y)
    {
        if (x == null || y == null) return 0;

        int result = x.ExpiryDate.CompareTo(y.ExpiryDate);

        // If expiry date is same, compare PolicyId to avoid duplicate removal
        if (result == 0)
            result = x.PolicyId.CompareTo(y.PolicyId);

        return result;
    }
}

class InsurancePolicyManagementSystem
{
    static void Main()
    {
        // 1) HashSet (unique + fast lookup)
        HashSet<InsurancePolicy> hashSet = new HashSet<InsurancePolicy>();

        // 2) LinkedHashSet (C# alternative)
        // we use: List to maintain order + HashSet for uniqueness
        List<InsurancePolicy> insertionOrderList = new List<InsurancePolicy>();
        HashSet<InsurancePolicy> insertionOrderSet = new HashSet<InsurancePolicy>();

        // 3) SortedSet (sorted by expiry date)
        SortedSet<InsurancePolicy> sortedSet = new SortedSet<InsurancePolicy>(new ExpiryDateComparer());

        Console.Write("Enter number of policies: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nEnter Policy Details:");

            Console.Write("Policy Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Holder Name: ");
            string name = Console.ReadLine();

            Console.Write("Expiry Date (yyyy-mm-dd): ");
            DateTime expiry = Convert.ToDateTime(Console.ReadLine());

            InsurancePolicy policy = new InsurancePolicy(id, name, expiry);

            // Add to HashSet
            hashSet.Add(policy);

            // Add to LinkedHashSet (List + Set logic)
            if (insertionOrderSet.Add(policy))
                insertionOrderList.Add(policy);

            // Add to SortedSet
            sortedSet.Add(policy);
        }

        Console.WriteLine("\n Policies in HashSet (Unique, Unordered):");
        foreach (var p in hashSet)
            Console.WriteLine(p);

        Console.WriteLine("\n Policies in LinkedHashSet style (Insertion Order):");
        foreach (var p in insertionOrderList)
            Console.WriteLine(p);

        Console.WriteLine("\n Policies in SortedSet (Sorted by Expiry Date):");
        foreach (var p in sortedSet)
            Console.WriteLine(p);

        // Quick Lookup Example
        Console.Write("\nEnter PolicyId to search (HashSet lookup): ");
        int searchId = Convert.ToInt32(Console.ReadLine());

        InsurancePolicy temp = new InsurancePolicy(searchId, "", DateTime.Now);

        if (hashSet.Contains(temp))
            Console.WriteLine(" Policy Found!");
        else
            Console.WriteLine(" Policy Not Found!");
    }
}
