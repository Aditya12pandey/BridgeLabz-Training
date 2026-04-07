    public class MyLinkedList
    {
        int val;
        MyLinkedList next;
        MyLinkedList head;

        public MyLinkedList()
        {
            head = null;
        }

        public int Get(int index)
        {
            if (index < 0) return -1;

            MyLinkedList current = head;
            int i = 0;
            while (current != null)
            {
                if (index == i) return current.val;
                i++;
                current = current.next;
            }
            return -1;
        }

        public void AddAtHead(int val)
        {
            MyLinkedList newNode = new MyLinkedList();
            newNode.val = val;
            newNode.next = head;
            head = newNode;
        }

        public void AddAtTail(int val)
        {
            MyLinkedList newNode = new MyLinkedList();
            newNode.val = val;
            newNode.next = null;

            if (head == null) head = newNode;
            else
            {
                MyLinkedList current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
        }

        public void AddAtIndex(int index, int val)
        {
            MyLinkedList newNode = new MyLinkedList();
            newNode.val = val;
            MyLinkedList current = head;
            int i = 0;
            if (index == 0)
            {
                newNode.next = current;
                head = newNode;
                return;
            }
            while (current != null)
            {
                if (i == index - 1)
                {
                    newNode.next = current.next;
                    current.next = newNode;
                    return;
                }

                current = current.next;
                i++;
            }
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || head == null) return;
            if (index == 0)
            {
                head = head.next;
                return;
            }
            MyLinkedList current = head;
            int i = 0;

            while (current.next != null)
            {
                if (i == index - 1)
                {
                    current.next = current.next.next;
                    return;
                }
                current = current.next;
                i++;
            }
        }
    }