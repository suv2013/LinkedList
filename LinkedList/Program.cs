namespace LinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Node
    {
        public int data;
        public Node next;
        public Node(int val)
        {
            data = val;
            next = null;
        }
    }
    class Program
    {
        public Node head;
        static void Main(string[] args)
        {
            Program sLL = new Program();
            sLL.Push(1);
            sLL.Append(2);
            sLL.Append(3);
            sLL.Append(4);
            sLL.Insert_After(sLL.head, 10);
            sLL.Append(11);
            sLL.Push(4);
            sLL.printList();
            sLL.Reverse();
            sLL.printList();
            PerformOps(sLL);
            Console.ReadKey();
        }                
        public void Push(int val)
        {
            Node new_Node = new Node(val);
            new_Node.next = head;
            head = new_Node;
        }
        public void Insert_After(Node prevNode, int val)
        {
            if (prevNode == null)
            {
                Console.WriteLine("The given previous node cannot be null");
                return;
            }
            Node new_Node = new Node(val);
            new_Node.next = prevNode.next;
            prevNode.next = new_Node;
        }
        public void Append(int val)
        {
            if (head == null)
            {
                head = new Node(val);
                return;
            }

            Node new_Node = new Node(val);
            new_Node.next = null;

            Node runningNode = head;
            while (runningNode.next != null)
            {
                runningNode = runningNode.next;
            }

            runningNode.next = new_Node;
            return;
        }
        public void Delete(int val)
        {
            if (head == null)
            {
                head = new Node(val);
                return;
            }

            Node runningNode = head;
            Node prevNode = null;
            if (runningNode != null && runningNode.data == val)
            {
                head = runningNode.next;
                return;
            }

            while (runningNode != null && runningNode.data != val)
            {
                prevNode = runningNode;
                runningNode = runningNode.next;
            }
            if (runningNode == null)
            {
                Console.WriteLine("Value Not Found.");
                return;
            }

            prevNode.next = runningNode.next;
        }
        public void printList()
        {
            Node tnode = head;
            Console.Write("Head \n | \n ");

            while (tnode != null)
            {
                Console.Write(tnode.data + " -> ");
                tnode = tnode.next;
            }
            if (tnode == null)
            {
                Console.Write("Null \n\n");
            }
        }

        private void Reverse()//iterative
        {
            Node prev = null;
            while (head != null)
            {
                Node next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }

            head = prev;
        }

        public Node reverseList(Node head)//recursive
        {
            if (head == null || head.next == null) return head;
            Node p = reverseList(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }
        public static void PerformOps(Program sLL)
        {
            Console.WriteLine("Please Enter 1 to Push in Linked List");
            Console.WriteLine("Please Enter 2 to Append in Linked List");
            Console.WriteLine("Please Enter 3 to Delete in Linked List");
            Console.WriteLine("Please Enter 0 to End the Program");
            int value = Convert.ToInt32(Console.ReadLine());

            switch (value)
            {
                case 1:
                    sLL.Push(Convert.ToInt32(Console.ReadLine()));
                    sLL.printList();
                    PerformOps(sLL);
                    break;

                case 2:
                    sLL.Append(Convert.ToInt32(Console.ReadLine()));
                    sLL.printList();
                    PerformOps(sLL);
                    break;
                case 3:
                    sLL.Delete(Convert.ToInt32(Console.ReadLine()));
                    sLL.printList();
                    PerformOps(sLL);
                    break;
                case 0:
                    sLL.printList();
                    Console.WriteLine("\nPlease visit next time.");
                    break;
                default:
                    Console.WriteLine("Invalid Input. Please visit next time.");
                    break;
            }

        }
    }
}
