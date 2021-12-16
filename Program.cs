using System;

namespace ข้อ9Final
{
    class Node
    {
        public string Message;

        public Node(string messagevalue)
        {
            Message = messagevalue;
        }
    }

    class QuestionNode : Node
    {
        public Node Left;
        public Node Right;

        public QuestionNode(string messagevalue) : base(messagevalue) { }

    }
    class Skill : Node
    {
        public Skill(string messagevalue) : base(messagevalue) { }
    }
    class Program
    {
        static void AddNode(ref Node node)
        {
            Console.WriteLine("Input skill name");
            string answer = Console.ReadLine();
            if (answer != "?")
            {
                Console.WriteLine("Add dependency for {0} (Y/N):", answer);
                string message = Console.ReadLine();
                node = new QuestionNode(message);
                AddNode(ref (node as QuestionNode).Left);
                AddNode(ref (node as QuestionNode).Right);

            }

            else
            {
                string message = Console.ReadLine();
                node = new Skill(message);
            }
        }

        static void Main(string[] args)
        {
            Node root = null;
            AddNode(ref root);

            Node ptr = root;
            while (true)
            {
                Console.WriteLine(ptr.Message);
                if (ptr is QuestionNode)
                {
                    char answer = char.Parse(Console.ReadLine());
                    if (answer == 'y')
                    {
                        ptr = (ptr as QuestionNode).Left;
                    }
                    else
                    {
                        ptr = (ptr as QuestionNode).Right;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
