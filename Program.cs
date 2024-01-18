using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prefix_infix_postfix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("prefix--to--infix--press 1");

            Console.WriteLine("infix--to--postfix--press 2");

            Console.WriteLine("prefix--to--postfix--press 3");

            Console.WriteLine("infix--to--prefix--press 4");

            Console.WriteLine("postfix--to--infix--press 5");

            Console.WriteLine("postfix--to--prefix--press 6");

            int n = Convert.ToInt32(Console.ReadLine());

            switch (n)
            {
                case 1:
                    {
                        Console.WriteLine("PREFIX :");
                        Console.WriteLine(PrefixToInfix.ConvertPrefixToInfix(Console.ReadLine()));
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("INFIX :");
                        Console.WriteLine(InfixToPostfix.ConvertToPostfix(Console.ReadLine()));
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("PREFIX :");
                        string q = (InfixToPostfix.ConvertToPostfix(Console.ReadLine()));
                        Console.WriteLine(InfixToPostfix.ConvertToPostfix(q));
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("INFIX :");
                        Console.WriteLine(infixtoprefix.converttoinfix(Console.ReadLine()));
                    }
                    break;
                case 5:
                    {
                        Console.WriteLine("POSTFIX :");
                        Console.WriteLine(postfixtoinfix.convertpostfixtoinfix(Console.ReadLine()));

                    }
                    break;
                case 6:
                    {
                        Console.WriteLine("POSTFIX :");

                        string a = postfixtoinfix.convertpostfixtoinfix(Console.ReadLine());
                        string aa = a.Replace(")", "(");

                        string b = infixtoprefix.converttoinfix(aa);
                        string bb = b.Replace("(", "").Replace(")", "");
                        Console.WriteLine(bb);

                    }
                    break;


            }





            Console.ReadKey();




        }
    }
    class Stackm<T>
    {
        private static int top;
        private T[] items;


        public Stackm(int n)
        {
            items = new T[n];

            top = -1;

        }

        public void add(T item)
        {
            if (isfull())
            {
                Console.WriteLine("stack is full");

            }
            else
                items[++top] = item;
        }
        public T delete()
        {
            if (top == -1)
            {
                Console.WriteLine("stack is empty");
            }
            return items[top--];

        }

        public Boolean isfull()
        {
            if (top == items.Length - 1)
            {
                return true;
            }
            else return false;
        }
        public T peek()
        {
            if (top == -1)
            {
                Console.WriteLine("the stack is empty");
            }
            return items[top];
        }
        public int count()
        {
            return top + 1;
        }

    }
    class postfixtoinfix
    {

        public static string convertpostfixtoinfix(string postfix)
        {
            Stackm<string> st = new Stackm<string>(50);

            foreach (var item in postfix)
            {
                char h = item;
                if (h == '+' || h == '-' || h == '*' || h == '/')
                {
                    string operand1 = st.delete();
                    string operand2 = st.delete();
                    string newexpression = "(" + operand2 + h + operand1 + ")";
                    st.add(newexpression);

                }
                else
                {
                    st.add(h.ToString());
                }


            }

            return st.delete();
        }

    }
    public class PrefixToInfix
    {
        public static string ConvertPrefixToInfix(string prefix)
        {
            Stack<string> st = new Stack<string>();

            for (int i = prefix.Length - 1; i >= 0; i--)
            {
                char c = prefix[i];

                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    string operand1 = st.Pop();
                    string operand2 = st.Pop();
                    string infixExpression = "(" + operand1 + c + operand2 + ")";
                    st.Push(infixExpression);
                }
                else
                {
                    st.Push(c.ToString());
                }
            }

            return st.Pop();
        }

    }

    class InfixToPostfix
    {
        public static int Precedence(char c)
        {
            if (c == '+' || c == '-')
                return 1;
            else if (c == '*' || c == '/')
                return 2;
            else
                return 0;
        }

        public static string ConvertToPostfix(string infix)
        {
            string postfix = "";
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < infix.Length; i++)
            {
                char c = infix[i];
                if (Char.IsLetterOrDigit(c))
                {
                    postfix += c;
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix += stack.Pop();
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 && Precedence(c) <= Precedence(stack.Peek()))
                    {
                        postfix += stack.Pop();
                    }
                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
            {
                postfix += stack.Pop();
            }

            return postfix;
        }
    }
    class infixtoprefix
    {
        public static string converttoinfix(string infix)
        {
            string reverseinfix = new string(infix.Reverse().ToArray());
            string postfix = InfixToPostfix.ConvertToPostfix(reverseinfix);
            string prefix = new string(postfix.Reverse().ToArray());
            return prefix;

        }



    }

}
