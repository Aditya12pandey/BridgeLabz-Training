//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraning.ScenarioBased
//{
//    class CinemaTimeManager 
//    {
//        private string[] MovieTitle;
//        private string[] MovieTime;
//        private int Count;

//        public CinemaTimeManager( int Capacity)
//        {
//            MovieTitle = new string[Capacity];
//            MovieTime = new string[Capacity];
//            this.Count = 0;
//        }
//        public void AddMovie(string title, string time)
//        {
//            if (Count >= MovieTitle.Length)
//            {
//                Console.WriteLine("Cinema is at full capacity!");
//            }
//            MovieTitle[Count] = title;
//            MovieTime[Count] = time;
//            Count++;

//            Console.WriteLine("Movie Added Successfully");
//        }
//        public void SearchMovie(string Keyword)
//        {
//            bool found = false;
//            Console.WriteLine("Search Results:");
//            for (int i = 0; i < Count; i++)
//            {
//                if (MovieTitle[i].ToLower().Contains(Keyword.ToLower()))
//                {
//                    Console.WriteLine($"Title: {MovieTitle[i]}, Time: {MovieTime[i]}");
//                    found = true;
//                }
//            }
//            if (!found)
//            {
//                Console.WriteLine("Movie Not Found");
//            }
//        }
//        public void DisplayAllMovie() 
//        {
//            if (Count == 0)
//            {
//                Console.WriteLine("No Movies Availabel ");
//            }
//            else
//            {
//                for(int i = 0; i < Count; i++)
//                {
//                    string formatted = string.Format("({0}) Movie: {1,-20} | Showtime: {2}", i, MovieTitle[i], MovieTime[i]);
//                    Console.WriteLine(formatted);
//                }
//            }
//        }
//    }
//    internal class CinemaTime
//    {
//        public static void Main(string[] args)
//        {
//            Console.WriteLine("Enter no. of Movie to Enter ");
//            int Capacity = int.Parse(Console.ReadLine());

//            CinemaTimeManager manager = new CinemaTimeManager(Capacity);

//            while (true)
//            {
//                Console.WriteLine(" CinemaTime - Movie Manager");
//                Console.WriteLine("1. Add Movie");
//                Console.WriteLine("2. Display All Movies");
//                Console.WriteLine("3. Search Movie");
//                Console.WriteLine("4. Exit");
//                Console.Write("Enter your choice: ");

//                int choice = int.Parse(Console.ReadLine());

//                switch(choice)
//                {
//                    case 1:

//                        for(int i=0; i< Capacity; i++)
//                        {
//                            Console.Write("Enter Movie Title: ");
//                            string title = Console.ReadLine();

//                            Console.Write("Enter Showtime (HH:MM): ");
//                            string time = Console.ReadLine();

//                            manager.AddMovie(title, time);
//                        }
//                         break;
//                    case 2:
//                        manager.DisplayAllMovie();

//                        break;
//                    case 3:
//                        Console.WriteLine("enter the title to search");
//                        string keyword = Console.ReadLine();
//                        manager.SearchMovie(keyword);

//                        break;
//                    case 4:
//                        Console.WriteLine("thankyou!");
//                        return;
                        
//                    default:
//                        Console.WriteLine(" Invalid choice Please select 1-4.");

//                        break;
//                }
               
                
//            }

//        }
//    }
//}
