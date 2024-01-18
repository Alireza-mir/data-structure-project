using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generalized_List
{
    class Program
    {
        static void Main(string[] args)
        {
           

            node h = new node(false, 10, null);
            node f = new node(false, 12, h);
            node t = new node(true, f, null);
            node q = new node(false, 13, t);
            node p = new node(false, 12, q);


            node H = new node(false, 10, null);
            node F = new node(false, 12, H);
            node T = new node(true, F, null);
            node Q = new node(false, 13, T);
            node P = new node(false, 12, Q);

            node s = new node(false, 8, null);
            node n = new node(true,s,null);
            node m = new node(false, 6, n);
            
            //GeneralizedList.ADD(p, m);

            GeneralizedList.GENlistPrint(p);
            Console.WriteLine("");
            GeneralizedList.GENlistPrint(P);

            Console.WriteLine("");
            Console.Write("sum of the generalizedlist is :");
            Console.Write(GeneralizedList.Sumgen(p));
            Console.WriteLine("");
            Console.Write("Depth of the generalizedlist is :");
            Console.Write(GeneralizedList.depth(p));
            Console.WriteLine("");
            if(GeneralizedList.Equal(p,P)==1)
                Console.WriteLine("Equal");
            else
                Console.WriteLine("not Equal");

            Console.ReadLine();

        }
    }
    class node
    {

        public bool tag;
        public int data;
        public node Slink;
        public node link;


        public node(bool t, node Dl, node L)
        {
            tag = t;
            Slink = Dl;
            link = L;
            data = 0;
        }
        public node(bool t, int dat, node L)
        {
            tag = t;
            data = dat;
            link = L;
            Slink = null;

        }









    }

    class GeneralizedList
    {

        public static void ADD(node p,node d)
        {
            node f = p;
            p = p.link;
            while (p != null)
            {
                p = p.link;
                f = f.link;
            }
            f.link = d;
            
        }



        public static void GENlistPrint(node p)
        {

            Console.Write("<");
            while (p != null)
            {
                Console.Write(",");
                if (p.tag == false)
                { Console.Write(p.data); }
                else
                    GENlistPrint(p.Slink);
                p = p.link;
            }
            Console.Write(">");
        }
        public static int Sumgen(node p)
        {
            int s = 0;
            while (p != null)
            {
                if (p.tag == false)
                    s += p.data;
                else
                    s += Sumgen(p.Slink);
                p = p.link;
            }
            return s;
        }
        public static int depth(node p)
        {
            if (p == null)
                return 0;
            node s = p;
            int m = 1;
            while (s != null)
            {
                if (s.tag)
                {
                    int n = depth(p.Slink);
                    if (m < n)
                        m = n;
                }
                s = s.link;
            }
            return m + 1;
        }

        public static int Equal(node p, node q)
        {
            int a=0;
            if (p == null && q == null)
                return 1;
            if (p != null && q != null && p.tag == q.tag)
            {
                if (p.tag == false)
                    if (p.data == q.data)
                        a=1;
                    else
                        a=0;
 
                else
                   a=Equal(p.Slink,q.Slink);

                     if(a==1)
                         return Equal(p.link,q.link);

            }

            return a;


        }






    }

}
