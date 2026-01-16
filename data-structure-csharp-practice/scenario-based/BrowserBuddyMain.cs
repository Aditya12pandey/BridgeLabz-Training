//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraning.ScenarioBased
//{
//    class HistoryNode
//    {
//        public string Url;
//        public HistoryNode Prev;
//        public HistoryNode Next;

//        public HistoryNode(string url)
//        {
//            Url = url;
//            Prev = null;
//            Next = null;
//        }
//    }

//    //  Custom Doubly Linked List (Browser History) 
//    class BrowserHistory
//    {
//        private HistoryNode head;
//        private HistoryNode tail;
//        private HistoryNode current;

//        public BrowserHistory()
//        {
//            head = null;
//            tail = null;
//            current = null;
//        }

//        // Visit a new URL
//        public void Visit(string url)
//        {
//            HistoryNode newNode = new HistoryNode(url);

//            // If first visit
//            if (head == null)
//            {
//                head = tail = current = newNode;
//                return;
//            }

//            // If current is not at tail, remove forward history
//            if (current != tail)
//            {
//                HistoryNode temp = current.Next;
//                while (temp != null)
//                {
//                    HistoryNode nextTemp = temp.Next;
//                    temp.Prev = null;
//                    temp.Next = null;
//                    temp = nextTemp;
//                }

//                current.Next = null;
//                tail = current;
//            }

//            // Attach new node
//            tail.Next = newNode;
//            newNode.Prev = tail;
//            tail = newNode;
//            current = newNode;
//        }

//        // Go Back
//        public bool Back()
//        {
//            if (current != null && current.Prev != null)
//            {
//                current = current.Prev;
//                return true;
//            }
//            return false;
//        }

//        // Go Forward
//        public bool Forward()
//        {
//            if (current != null && current.Next != null)
//            {
//                current = current.Next;
//                return true;
//            }
//            return false;
//        }

//        // Get current page
//        public string GetCurrentPage()
//        {
//            if (current == null)
//                return "No Page Open";
//            return current.Url;
//        }

//        // Print Full History
//        public void ShowHistory()
//        {
//            if (head == null)
//            {
//                Console.WriteLine("History is empty.");
//                return;
//            }

//            HistoryNode temp = head;
//            Console.WriteLine("\n Tab History ");

//            while (temp != null)
//            {
//                if (temp == current)
//                    Console.WriteLine(" " + temp.Url + " (Current)");
//                else
//                    Console.WriteLine("   " + temp.Url);

//                temp = temp.Next;
//            }
//        }
//    }

//    //  Tab Class 
//    class Tab
//    {
//        public int TabId { get; set; }
//        public BrowserHistory History { get; set; }

//        public Tab(int tabId)
//        {
//            TabId = tabId;
//            History = new BrowserHistory();
//        }
//    }

//    //  Stack Node for Closed Tabs 
//    class StackNode
//    {
//        public Tab Data;
//        public StackNode Next;

//        public StackNode(Tab tab)
//        {
//            Data = tab;
//            Next = null;
//        }
//    }

//    //  Custom Stack for Closed Tabs 
//    class ClosedTabStack
//    {
//        private StackNode top;

//        public ClosedTabStack()
//        {
//            top = null;
//        }

//        public void Push(Tab tab)
//        {
//            StackNode newNode = new StackNode(tab);
//            newNode.Next = top;
//            top = newNode;
//        }

//        public Tab Pop()
//        {
//            if (top == null)
//                return null;

//            Tab removed = top.Data;
//            top = top.Next;
//            return removed;
//        }

//        public bool IsEmpty()
//        {
//            return top == null;
//        }

//        public void ShowClosedTabs()
//        {
//            if (top == null)
//            {
//                Console.WriteLine("No closed tabs available to restore.");
//                return;
//            }

//            Console.WriteLine("\n Closed Tabs (Top Bottom) ");
//            StackNode temp = top;
//            while (temp != null)
//            {
//                Console.WriteLine("Tab ID: " + temp.Data.TabId);
//                temp = temp.Next;
//            }
//        }
//    }
//    internal class BrowserBuddyMain
//    {
//        static void Main(string[] args)
//        {
//            Tab currentTab = null;
//            ClosedTabStack closedTabs = new ClosedTabStack();
//            int tabCounter = 1;

//            bool exit = false;

//            while (!exit)
//            {
//                Console.WriteLine("   BrowserBuddy - Tab Manager");
//                Console.WriteLine("1. Open New Tab");
//                Console.WriteLine("2. Visit URL in Current Tab");
//                Console.WriteLine("3. Back");
//                Console.WriteLine("4. Forward");
//                Console.WriteLine("5. Show Current Page");
//                Console.WriteLine("6. Show Tab History");
//                Console.WriteLine("7. Close Current Tab");
//                Console.WriteLine("8. Restore Recently Closed Tab");
//                Console.WriteLine("9. Show Closed Tabs Stack");
//                Console.WriteLine("0. Exit");
//                Console.Write("Enter Choice: ");

//                string input = Console.ReadLine();

//                switch (input)
//                {
//                    case "1":
//                        currentTab = new Tab(tabCounter++);
//                        Console.WriteLine("New Tab Opened ✅ Tab ID: " + currentTab.TabId);
//                        break;

//                    case "2":
//                        if (currentTab == null)
//                        {
//                            Console.WriteLine("No tab open. Open a tab first!");
//                            break;
//                        }

//                        Console.Write("Enter URL to Visit: ");
//                        string url = Console.ReadLine();

//                        if (string.IsNullOrWhiteSpace(url))
//                        {
//                            Console.WriteLine("Invalid URL!");
//                            break;
//                        }

//                        currentTab.History.Visit(url);
//                        Console.WriteLine("Visited: " + url);
//                        break;

//                    case "3":
//                        if (currentTab == null)
//                        {
//                            Console.WriteLine("No tab open!");
//                            break;
//                        }

//                        if (currentTab.History.Back())
//                            Console.WriteLine("Moved Back ✅ Current: " + currentTab.History.GetCurrentPage());
//                        else
//                            Console.WriteLine("Cannot go back ❌");
//                        break;

//                    case "4":
//                        if (currentTab == null)
//                        {
//                            Console.WriteLine("No tab open!");
//                            break;
//                        }

//                        if (currentTab.History.Forward())
//                            Console.WriteLine("Moved Forward  Current: " + currentTab.History.GetCurrentPage());
//                        else
//                            Console.WriteLine("Cannot go forward ");
//                        break;

//                    case "5":
//                        if (currentTab == null)
//                            Console.WriteLine("No tab open!");
//                        else
//                            Console.WriteLine("Current Page: " + currentTab.History.GetCurrentPage());
//                        break;

//                    case "6":
//                        if (currentTab == null)
//                            Console.WriteLine("No tab open!");
//                        else
//                            currentTab.History.ShowHistory();
//                        break;

//                    case "7":
//                        if (currentTab == null)
//                        {
//                            Console.WriteLine("No tab to close!");
//                            break;
//                        }

//                        closedTabs.Push(currentTab);
//                        Console.WriteLine("Tab Closed  Tab ID: " + currentTab.TabId);
//                        currentTab = null;
//                        break;

//                    case "8":
//                        if (closedTabs.IsEmpty())
//                        {
//                            Console.WriteLine("No closed tab to restore!");
//                            break;
//                        }

//                        currentTab = closedTabs.Pop();
//                        Console.WriteLine("Tab Restored Tab ID: " + currentTab.TabId);
//                        Console.WriteLine("Current Page: " + currentTab.History.GetCurrentPage());
//                        break;

//                    case "9":
//                        closedTabs.ShowClosedTabs();
//                        break;

//                    case "0":
//                        exit = true;
//                        Console.WriteLine("Exiting BrowserBuddy ");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid Choice  Try Again.");
//                        break;
//                }
//            }
//        }
//    }
//}
