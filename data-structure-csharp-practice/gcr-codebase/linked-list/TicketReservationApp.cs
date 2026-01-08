using System;

class TicketRecord
{
    public int TicketId { get; set; }
    public string CustomerName { get; set; }
    public string MovieName { get; set; }
    public string SeatNumber { get; set; }
    public DateTime BookingTime { get; set; }

    public void Display()
    {
        Console.WriteLine($"TicketID: {TicketId}, Customer: {CustomerName}, Movie: {MovieName}, Seat: {SeatNumber}, Time: {BookingTime}");
    }
}

class TicketNode
{
    public TicketRecord Data;
    public TicketNode Next;

    public TicketNode(TicketRecord ticket)
    {
        Data = ticket;
        Next = null;
    }
}

class TicketCircularList
{
    private TicketNode head;

    // Add ticket at end
    public void AddTicket(TicketRecord ticket)
    {
        TicketNode newNode = new TicketNode(ticket);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
        }
        else
        {
            TicketNode temp = head;
            while (temp.Next != head)
                temp = temp.Next;

            temp.Next = newNode;
            newNode.Next = head;
        }

        Console.WriteLine("Ticket booked successfully.");
    }

    // Remove ticket by ID
    public void RemoveTicket(int ticketId)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode curr = head;
        TicketNode prev = null;

        do
        {
            if (curr.Data.TicketId == ticketId)
            {
                if (prev != null)
                    prev.Next = curr.Next;
                else
                {
                    TicketNode last = head;
                    while (last.Next != head)
                        last = last.Next;

                    head = head.Next;
                    last.Next = head;
                }

                Console.WriteLine("Ticket cancelled successfully.");
                return;
            }

            prev = curr;
            curr = curr.Next;

        } while (curr != head);

        Console.WriteLine("Ticket not found.");
    }

    // Display all tickets
    public void DisplayTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = head;
        do
        {
            temp.Data.Display();
            temp = temp.Next;
        } while (temp != head);
    }

    // Search by Customer Name
    public void SearchByCustomer(string name)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = head;
        bool found = false;

        do
        {
            if (temp.Data.CustomerName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                temp.Data.Display();
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No tickets found for this customer.");
    }

    // Search by Movie Name
    public void SearchByMovie(string movie)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = head;
        bool found = false;

        do
        {
            if (temp.Data.MovieName.Equals(movie, StringComparison.OrdinalIgnoreCase))
            {
                temp.Data.Display();
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No tickets found for this movie.");
    }

    // Count tickets
    public void CountTickets()
    {
        if (head == null)
        {
            Console.WriteLine("Total Tickets: 0");
            return;
        }

        int count = 0;
        TicketNode temp = head;

        do
        {
            count++;
            temp = temp.Next;
        } while (temp != head);

        Console.WriteLine($"Total Tickets Booked: {count}");
    }
}

class TicketReservationApp
{
    static void Main()
    {
        TicketCircularList ticketList = new TicketCircularList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Online Ticket Reservation System ---");
            Console.WriteLine("1. Book Ticket");
            Console.WriteLine("2. Cancel Ticket");
            Console.WriteLine("3. Display Tickets");
            Console.WriteLine("4. Search Ticket by Customer Name");
            Console.WriteLine("5. Search Ticket by Movie Name");
            Console.WriteLine("6. Count Total Tickets");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    TicketRecord ticket = new TicketRecord();
                    Console.Write("Ticket ID: ");
                    ticket.TicketId = int.Parse(Console.ReadLine());
                    Console.Write("Customer Name: ");
                    ticket.CustomerName = Console.ReadLine();
                    Console.Write("Movie Name: ");
                    ticket.MovieName = Console.ReadLine();
                    Console.Write("Seat Number: ");
                    ticket.SeatNumber = Console.ReadLine();
                    ticket.BookingTime = DateTime.Now;

                    ticketList.AddTicket(ticket);
                    break;

                case 2:
                    Console.Write("Enter Ticket ID to cancel: ");
                    ticketList.RemoveTicket(int.Parse(Console.ReadLine()));
                    break;

                case 3:
                    ticketList.DisplayTickets();
                    break;

                case 4:
                    Console.Write("Customer Name: ");
                    ticketList.SearchByCustomer(Console.ReadLine());
                    break;

                case 5:
                    Console.Write("Movie Name: ");
                    ticketList.SearchByMovie(Console.ReadLine());
                    break;

                case 6:
                    ticketList.CountTickets();
                    break;

                case 0:
                    Console.WriteLine("Exiting Ticket Reservation System...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 0);
    }
}
