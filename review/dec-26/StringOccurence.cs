    class StringOccurence
    {
        public static void  Main()
        {
            Console.WriteLine("Enter a string: ");
            string word = Console.ReadLine();
            string lower = word.ToLower();
            int[] arr = new int[26];

            foreach (char c in word)
            {
                if (c >= 'a' && c <= 'z')
                {
                    arr[c - 'a']++; // Map 'a'-'z' to 0-25
                }
            }

            Console.WriteLine("\nLetter Frequencies:");
            for (int i = 0; i < 26; i++)
            {
                if (arr[i] > 0)
                {
                    Console.WriteLine($"{(char)(i + 'a')} : {arr[i]}");
                }
            }
      
        }
    }
