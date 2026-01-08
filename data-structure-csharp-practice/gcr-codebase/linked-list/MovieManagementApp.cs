using System;

class MovieRecord
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int ReleaseYear { get; set; }
    public double Rating { get; set; }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}, Director: {Director}, Year: {ReleaseYear}, Rating: {Rating}");
    }
}

class MovieNode
{
    public MovieRecord Data;
    public MovieNode Prev;
    public MovieNode Next;

    public MovieNode(MovieRecord movie)
    {
        Data = movie;
        Prev = null;
        Next = null;
    }
}

class MovieDoublyLinkedList
{
    private MovieNode head;
    private MovieNode tail;

    // Add at Beginning
    public void AddAtBeginning(MovieRecord movie)
    {
        MovieNode newNode = new MovieNode(movie);

        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }

        Console.WriteLine("Movie added at beginning.");
    }

    // Add at End
    public void AddAtEnd(MovieRecord movie)
    {
        MovieNode newNode = new MovieNode(movie);

        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }

        Console.WriteLine("Movie added at end.");
    }

    // Add at Specific Position
    public void AddAtPosition(MovieRecord movie, int position)
    {
        if (position <= 1)
        {
            AddAtBeginning(movie);
            return;
        }

        MovieNode temp = head;
        for (int i = 1; i < position - 1 && temp != null; i++)
            temp = temp.Next;

        if (temp == null || temp.Next == null)
        {
            AddAtEnd(movie);
            return;
        }

        MovieNode newNode = new MovieNode(movie);
        newNode.Next = temp.Next;
        newNode.Prev = temp;
        temp.Next.Prev = newNode;
        temp.Next = newNode;

        Console.WriteLine("Movie added at position.");
    }

    // Remove by Movie Title
    public void RemoveByTitle(string title)
    {
        MovieNode temp = head;

        while (temp != null && temp.Data.Title != title)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Movie not found.");
            return;
        }

        if (temp == head)
            head = temp.Next;

        if (temp == tail)
            tail = temp.Prev;

        if (temp.Prev != null)
            temp.Prev.Next = temp.Next;

        if (temp.Next != null)
            temp.Next.Prev = temp.Prev;

        Console.WriteLine("Movie removed successfully.");
    }

    // Search by Director
    public void SearchByDirector(string director)
    {
        MovieNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Data.Director.Equals(director, StringComparison.OrdinalIgnoreCase))
            {
                temp.Data.Display();
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("No movies found for this director.");
    }

    // Search by Rating
    public void SearchByRating(double rating)
    {
        MovieNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Data.Rating >= rating)
            {
                temp.Data.Display();
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("No movies found with this rating.");
    }

    // Update Rating by Title
    public void UpdateRating(string title, double newRating)
    {
        MovieNode temp = head;

        while (temp != null)
        {
            if (temp.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                temp.Data.Rating = newRating;
                Console.WriteLine("Movie rating updated.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Movie not found.");
    }

    // Display Forward
    public void DisplayForward()
    {
        if (head == null)
        {
            Console.WriteLine("No movies available.");
            return;
        }

        MovieNode temp = head;
        while (temp != null)
        {
            temp.Data.Display();
            temp = temp.Next;
        }
    }

    // Display Reverse
    public void DisplayReverse()
    {
        if (tail == null)
        {
            Console.WriteLine("No movies available.");
            return;
        }

        MovieNode temp = tail;
        while (temp != null)
        {
            temp.Data.Display();
            temp = temp.Prev;
        }
    }
}

class MovieManagementApp
{
    static void Main()
    {
        MovieDoublyLinkedList movieList = new MovieDoublyLinkedList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Movie Management System ---");
            Console.WriteLine("1. Add Movie at Beginning");
            Console.WriteLine("2. Add Movie at End");
            Console.WriteLine("3. Add Movie at Position");
            Console.WriteLine("4. Remove Movie by Title");
            Console.WriteLine("5. Search Movie by Director");
            Console.WriteLine("6. Search Movie by Rating");
            Console.WriteLine("7. Update Movie Rating");
            Console.WriteLine("8. Display Movies (Forward)");
            Console.WriteLine("9. Display Movies (Reverse)");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                case 2:
                case 3:
                    MovieRecord movie = new MovieRecord();

                    Console.Write("Title: ");
                    movie.Title = Console.ReadLine();
                    Console.Write("Director: ");
                    movie.Director = Console.ReadLine();
                    Console.Write("Release Year: ");
                    movie.ReleaseYear = int.Parse(Console.ReadLine());
                    Console.Write("Rating: ");
                    movie.Rating = double.Parse(Console.ReadLine());

                    if (choice == 1)
                        movieList.AddAtBeginning(movie);
                    else if (choice == 2)
                        movieList.AddAtEnd(movie);
                    else
                    {
                        Console.Write("Position: ");
                        int pos = int.Parse(Console.ReadLine());
                        movieList.AddAtPosition(movie, pos);
                    }
                    break;

                case 4:
                    Console.Write("Enter Movie Title to remove: ");
                    movieList.RemoveByTitle(Console.ReadLine());
                    break;

                case 5:
                    Console.Write("Enter Director name: ");
                    movieList.SearchByDirector(Console.ReadLine());
                    break;

                case 6:
                    Console.Write("Enter minimum Rating: ");
                    movieList.SearchByRating(double.Parse(Console.ReadLine()));
                    break;

                case 7:
                    Console.Write("Enter Movie Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter New Rating: ");
                    double rating = double.Parse(Console.ReadLine());
                    movieList.UpdateRating(title, rating);
                    break;

                case 8:
                    movieList.DisplayForward();
                    break;

                case 9:
                    movieList.DisplayReverse();
                    break;

                case 0:
                    Console.WriteLine("Exiting Movie Management System...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 0);
    }
}
