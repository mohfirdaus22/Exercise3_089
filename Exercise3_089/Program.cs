using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_089Exercise_Linked_List_A
{
    class Node
    {
      //creates Nodes for the circular nexted list
      public int rollNumber;
      public string name;
      public Node next;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
           LAST = null;
        }

        public void addNote()
        {
            int rollNum;
            string nm
            Console.Write("\nEnter the roll number of the student : ");
            rollNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student : ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNum;
            newnode.name = nm;
            
            if (LAST == null || rollNum <=LAST.rollNumber)
            {
                if((LAST !=null) && (rollNum == LAST.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                newnode.next = LAST;
                LAST = newnode;
                return;
            }
        }

        public bool Search(int rollNo, ref Node previous, ref Node current 
        //Searches for the specified node
        {
            for(previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);//return true if the node is found
            }
            if (rollNo == LAST.rollNumber)//if the node is present at the end
                return true;
            else 
                return (false);//returns false if the node is not found
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        public void traverse()//Traverse all the nodes of the list
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecords in the list are: \n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + " " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
                Console.WriteLine("The first records in the list is:\n\n" + LAST.next.rollNumber + " " + LAST.next.name);
        }
        static void Main(string[] args )
        {
            CircularList obj = new CircularList();  
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("\n1. View all the records in the list");
                    Console.WriteLine("\n2. Search for a record in the list");
                    Console.WriteLine("\n3. Display the first record in the list");
                    Console.WriteLine("\n4. Exit");
                    Console.Write("\nEnter your choice ( 1-4 ): ");
                    char ch = Convert.ToChar(Console.ReadKey());    
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty()==true)
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number" + curr.rollNumber);
                                    Console.WriteLine("\nName:" + curr.name);
                                }

                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid Option");
                                break;
                            }

                    }

                }
                catch (Exception e )
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }

}
