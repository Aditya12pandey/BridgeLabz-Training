using System;

class ProcessRecord
{
    public int ProcessId { get; set; }
    public int BurstTime { get; set; }
    public int RemainingTime { get; set; }
    public int Priority { get; set; }

    public ProcessRecord(int pid, int burst, int priority)
    {
        ProcessId = pid;
        BurstTime = burst;
        RemainingTime = burst;
        Priority = priority;
    }

    public void Display()
    {
        Console.WriteLine($"PID: {ProcessId}, Remaining Time: {RemainingTime}, Priority: {Priority}");
    }
}

class ProcessNode
{
    public ProcessRecord Data;
    public ProcessNode Next;

    public ProcessNode(ProcessRecord process)
    {
        Data = process;
        Next = null;
    }
}

class RoundRobinScheduler
{
    private ProcessNode head;
    private int totalProcesses;

    // Add process at end
    public void AddProcess(ProcessRecord process)
    {
        ProcessNode newNode = new ProcessNode(process);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
        }
        else
        {
            ProcessNode temp = head;
            while (temp.Next != head)
                temp = temp.Next;

            temp.Next = newNode;
            newNode.Next = head;
        }

        totalProcesses++;
        Console.WriteLine("Process added successfully.");
    }

    // Remove process by ID
    private void RemoveProcess(int pid)
    {
        if (head == null)
            return;

        ProcessNode curr = head;
        ProcessNode prev = null;

        do
        {
            if (curr.Data.ProcessId == pid)
            {
                if (prev != null)
                    prev.Next = curr.Next;
                else
                {
                    ProcessNode last = head;
                    while (last.Next != head)
                        last = last.Next;

                    head = head.Next;
                    last.Next = head;
                }
                totalProcesses--;
                return;
            }

            prev = curr;
            curr = curr.Next;

        } while (curr != head);
    }

    // Display processes after each round
    public void DisplayProcesses()
    {
        if (head == null)
        {
            Console.WriteLine("No processes in queue.");
            return;
        }

        ProcessNode temp = head;
        do
        {
            temp.Data.Display();
            temp = temp.Next;
        } while (temp != head);
    }

    // Round Robin Scheduling Simulation
    public void ExecuteRoundRobin(int timeQuantum)
    {
        if (head == null)
        {
            Console.WriteLine("No processes to schedule.");
            return;
        }

        int currentTime = 0;
        double totalWaitingTime = 0;
        double totalTurnaroundTime = 0;

        ProcessNode temp = head;

        while (totalProcesses > 0)
        {
            if (temp.Data.RemainingTime > 0)
            {
                int execTime = Math.Min(timeQuantum, temp.Data.RemainingTime);
                temp.Data.RemainingTime -= execTime;
                currentTime += execTime;

                Console.WriteLine($"\nProcess {temp.Data.ProcessId} executed for {execTime} units");

                if (temp.Data.RemainingTime == 0)
                {
                    int turnaroundTime = currentTime;
                    int waitingTime = turnaroundTime - temp.Data.BurstTime;

                    totalWaitingTime += waitingTime;
                    totalTurnaroundTime += turnaroundTime;

                    Console.WriteLine($"Process {temp.Data.ProcessId} completed.");
                    RemoveProcess(temp.Data.ProcessId);
                }

                DisplayProcesses();
            }

            temp = temp.Next;
        }

        Console.WriteLine("\n--- Scheduling Complete ---");
        Console.WriteLine($"Average Waiting Time: {totalWaitingTime / (totalWaitingTime + totalTurnaroundTime - totalWaitingTime):F2}");
        Console.WriteLine($"Average Turnaround Time: {totalTurnaroundTime / (totalWaitingTime + totalTurnaroundTime - totalWaitingTime):F2}");
    }
}

class RoundRobinApp
{
    static void Main()
    {
        RoundRobinScheduler scheduler = new RoundRobinScheduler();
        int choice;

        do
        {
            Console.WriteLine("\n--- Round Robin CPU Scheduling ---");
            Console.WriteLine("1. Add Process");
            Console.WriteLine("2. Execute Round Robin Scheduling");
            Console.WriteLine("3. Display Processes");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Process ID: ");
                    int pid = int.Parse(Console.ReadLine());
                    Console.Write("Burst Time: ");
                    int burst = int.Parse(Console.ReadLine());
                    Console.Write("Priority: ");
                    int priority = int.Parse(Console.ReadLine());

                    scheduler.AddProcess(new ProcessRecord(pid, burst, priority));
                    break;

                case 2:
                    Console.Write("Enter Time Quantum: ");
                    int tq = int.Parse(Console.ReadLine());
                    scheduler.ExecuteRoundRobin(tq);
                    break;

                case 3:
                    scheduler.DisplayProcesses();
                    break;

                case 0:
                    Console.WriteLine("Exiting Scheduler...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 0);
    }
}
