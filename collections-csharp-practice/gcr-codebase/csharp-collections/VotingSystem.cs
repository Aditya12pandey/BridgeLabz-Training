using System;
using System.Collections.Generic;

class VotingSystem
{
    static void Main()
    {
        // Dictionary -> store votes
        Dictionary<string, int> votes = new Dictionary<string, int>();

        //  LinkedHashMap equivalent -> maintain order of votes
        List<string> voteOrder = new List<string>();

        Console.Write("Enter number of voters: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("\nEnter candidate name to vote: ");
            string candidate = Console.ReadLine();

            voteOrder.Add(candidate);

            if (votes.ContainsKey(candidate))
                votes[candidate]++;
            else
                votes[candidate] = 1;
        }

        //  Display votes stored in Dictionary
        Console.WriteLine("\n Vote Count (Dictionary):");
        foreach (var item in votes)
        {
            Console.WriteLine(item.Key + " => " + item.Value);
        }

        //  Display results in Sorted Order (SortedDictionary)
        SortedDictionary<string, int> sortedVotes = new SortedDictionary<string, int>(votes);

        Console.WriteLine("\n Results in Sorted Order (SortedDictionary):");
        foreach (var item in sortedVotes)
        {
            Console.WriteLine(item.Key + " => " + item.Value);
        }

        //  Display vote order (LinkedHashMap concept)
        Console.WriteLine("\n Vote Order (LinkedHashMap style):");
        for (int i = 0; i < voteOrder.Count; i++)
        {
            Console.WriteLine("Vote " + (i + 1) + " => " + voteOrder[i]);
        }
    }
}
