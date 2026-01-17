using System;

public class CustomHashMap
{
    private class Entry
    {
        public string GenreKey;
        public BookLinkedList Books;
        public Entry Next;

        public Entry(string genre)
        {
            GenreKey = genre;
            Books = new BookLinkedList();
            Next = null;
        }
    }

    private Entry[] buckets;
    private int size;

    public CustomHashMap(int size)
    {
        this.size = size;
        buckets = new Entry[size];
    }

    private int GetHash(string key)
    {
        int hash = 0;
        for (int i = 0; i < key.Length; i++)
            hash += key[i];

        return hash % size;
    }

    public BookLinkedList GetOrCreateGenreList(string genre)
    {
        int index = GetHash(genre);
        Entry temp = buckets[index];

        while (temp != null)
        {
            if (temp.GenreKey.Equals(genre, StringComparison.OrdinalIgnoreCase))
                return temp.Books;

            temp = temp.Next;
        }

        Entry newEntry = new Entry(genre);
        newEntry.Next = buckets[index];
        buckets[index] = newEntry;

        return newEntry.Books;
    }

    public BookLinkedList GetGenreList(string genre)
    {
        int index = GetHash(genre);
        Entry temp = buckets[index];

        while (temp != null)
        {
            if (temp.GenreKey.Equals(genre, StringComparison.OrdinalIgnoreCase))
                return temp.Books;

            temp = temp.Next;
        }

        return null;
    }

    public void DisplayAllGenres()
    {
        bool any = false;

        for (int i = 0; i < size; i++)
        {
            Entry temp = buckets[i];

            while (temp != null)
            {
                any = true;
                Console.WriteLine("\nGenre: " + temp.GenreKey);
                temp.Books.DisplayAll();
                temp = temp.Next;
            }
        }

        if (!any)
            Console.WriteLine("Library is empty!");
    }
}
