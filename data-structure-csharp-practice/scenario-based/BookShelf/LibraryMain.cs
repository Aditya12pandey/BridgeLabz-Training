using System;

public class LibraryMain
{
    public static void Main(string[] args)
    {
        ILibraryService service = new LibraryService();
        service.StartMenu();
    }
}
