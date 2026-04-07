using System;

public class Book
{
    public int BookId;
    public string Title;
    public string Author;
    public string Genre;
    public bool IsBorrowed;

    public Book(int id, string title, string author, string genre)
    {
        BookId = id;
        Title = title;
        Author = author;
        Genre = genre;
        IsBorrowed = false;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {BookId} | Title: {Title} | Author: {Author} | Genre: {Genre} | Borrowed: {(IsBorrowed ? "YES" : "NO")}");
    }
}
