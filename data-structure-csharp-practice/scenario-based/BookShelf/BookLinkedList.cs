using System;

public class BookLinkedList
{
    private class Node
    {
        public Book Data;
        public Node Next;

        public Node(Book book)
        {
            Data = book;
            Next = null;
        }
    }

    private Node head;

    public BookLinkedList()
    {
        head = null;
    }

    public bool AddBook(Book book)
    {
        // Avoid Duplicate Book ID in same genre
        if (SearchById(book.BookId) != null)
            return false;

        Node newNode = new Node(book);

        if (head == null)
        {
            head = newNode;
            return true;
        }

        Node temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
        return true;
    }

    public Book SearchById(int id)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.BookId == id)
                return temp.Data;

            temp = temp.Next;
        }
        return null;
    }

    public bool DeleteBook(int id)
    {
        if (head == null)
            return false;

        if (head.Data.BookId == id)
        {
            head = head.Next;
            return true;
        }

        Node prev = head;
        Node curr = head.Next;

        while (curr != null)
        {
            if (curr.Data.BookId == id)
            {
                prev.Next = curr.Next;
                return true;
            }

            prev = curr;
            curr = curr.Next;
        }

        return false;
    }

    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No books found!");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            temp.Data.Display();
            temp = temp.Next;
        }
    }
}
