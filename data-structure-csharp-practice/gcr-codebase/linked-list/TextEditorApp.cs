using System;

class TextState
{
    public string Content { get; set; }

    public TextState(string content)
    {
        Content = content;
    }
}

class TextNode
{
    public TextState Data;
    public TextNode Prev;
    public TextNode Next;

    public TextNode(TextState state)
    {
        Data = state;
        Prev = null;
        Next = null;
    }
}

class UndoRedoManager
{
    private TextNode head;
    private TextNode tail;
    private TextNode current;
    private int count;
    private const int MAX_HISTORY = 10;

    // Add new text state
    public void AddState(string content)
    {
        TextNode newNode = new TextNode(new TextState(content));

        // If undo was used, discard redo history
        if (current != null && current.Next != null)
        {
            current.Next.Prev = null;
            current.Next = null;
            tail = current;
        }

        if (head == null)
        {
            head = tail = current = newNode;
            count = 1;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
            current = newNode;
            count++;
        }

        // Maintain fixed history size
        if (count > MAX_HISTORY)
        {
            head = head.Next;
            head.Prev = null;
            count--;
        }

        Console.WriteLine("New text state added.");
    }

    // Undo operation
    public void Undo()
    {
        if (current == null || current.Prev == null)
        {
            Console.WriteLine("Nothing to undo.");
            return;
        }

        current = current.Prev;
        Console.WriteLine("Undo performed.");
        DisplayCurrentState();
    }

    // Redo operation
    public void Redo()
    {
        if (current == null || current.Next == null)
        {
            Console.WriteLine("Nothing to redo.");
            return;
        }

        current = current.Next;
        Console.WriteLine("Redo performed.");
        DisplayCurrentState();
    }

    // Display current text
    public void DisplayCurrentState()
    {
        if (current == null)
        {
            Console.WriteLine("No text available.");
            return;
        }

        Console.WriteLine("Current Text:");
        Console.WriteLine(current.Data.Content);
    }
}

class TextEditorApp
{
    static void Main()
    {
        UndoRedoManager editor = new UndoRedoManager();
        int choice;

        do
        {
            Console.WriteLine("\n--- Text Editor (Undo / Redo) ---");
            Console.WriteLine("1. Add New Text");
            Console.WriteLine("2. Undo");
            Console.WriteLine("3. Redo");
            Console.WriteLine("4. Display Current Text");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter text: ");
                    string text = Console.ReadLine();
                    editor.AddState(text);
                    break;

                case 2:
                    editor.Undo();
                    break;

                case 3:
                    editor.Redo();
                    break;

                case 4:
                    editor.DisplayCurrentState();
                    break;

                case 0:
                    Console.WriteLine("Exiting Text Editor...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 0);
    }
}
