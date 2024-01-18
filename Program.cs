using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarytreeNode A = new BinarytreeNode(18);
            BinarytreeNode B = new BinarytreeNode(16);
            BinarytreeNode C = new BinarytreeNode(4);
            BinarytreeNode D = new BinarytreeNode(6, C, null);
            BinarytreeNode E = new BinarytreeNode(17, B, A);
            BinarytreeNode F = new BinarytreeNode(15, D, E);


            //BinarytreeNode.ADDNode(F,1);
            //BinarytreeNode.DeleteNode(F, 17);
            Console.Write("tree is :");
            BinarytreeNode.printtree(F);
            Console.WriteLine("");
            Console.WriteLine("number of levels =" + BinarytreeNode.numberoflevels(F));
            Console.WriteLine("Sum of tree node =" + BinarytreeNode.SumofNode(F));
            Console.WriteLine("number of nodes in tree =" + BinarytreeNode.countNode(F));
            Console.WriteLine("number of leaves in the tree is :" + BinarytreeNode.countLeaves(F));
            Console.Write("preorder :");
            BinarytreeNode.preorder(F);
            Console.Write("    inorder :");
            BinarytreeNode.inorder(F);
            Console.Write("     postorder :");
            BinarytreeNode.postorder(F);

            Console.ReadKey();






        }
    }
    class BinarytreeNode
    {
        public int data;
        public BinarytreeNode Left;
        public BinarytreeNode Right;

        public BinarytreeNode(int D)
        {
            data = D;
            Left = null;
            Right = null;
        }

        public BinarytreeNode(int D, BinarytreeNode L, BinarytreeNode R)
        {
            data = D;
            Left = L;
            Right = R;
        }

        public static BinarytreeNode ADDNode(BinarytreeNode R, int Dataa)
        {
            if (R == null)
            {
                return new BinarytreeNode(Dataa);
            }
            if (Dataa < R.data)
            {
                R.Left = ADDNode(R.Left, Dataa);
            }
            else if (Dataa > R.data)
            {
                R.Right = ADDNode(R.Right, Dataa);
            }

            return R;
        }

        public static BinarytreeNode minnode(BinarytreeNode R)
        {
            BinarytreeNode min = R;

            while (min.Left != null)
            {
                min = min.Left;
            }
            return min;
        }
        public static BinarytreeNode DeleteNode(BinarytreeNode R, int key)
        {
            if (R == null)
                return null;
            if (key < R.data)
                R.Left = DeleteNode(R.Left, key);
            else if (key > R.data)
                R.Right = DeleteNode(R.Right, key);
            else
            {
                if (R.Left == null)
                {
                    BinarytreeNode temp = R.Right;
                    R = null;
                    return temp;
                }
                else if (R.Right == null)
                {
                    BinarytreeNode temp = R.Left;
                    R = null;
                    return temp;
                }

                BinarytreeNode tempe = BinarytreeNode.minnode(R.Right);
                R.data = tempe.data;
                R.Right = DeleteNode(R.Right, tempe.data);

            }
            return R;

        }



        public static int numberoflevels(BinarytreeNode R)
        {
            if (R == null)
            {
                return 0;

            }

            int leftH = numberoflevels(R.Left);
            int rightH = numberoflevels(R.Right);
            return 1 + Math.Max(leftH, rightH);
        }

        public static int countNode(BinarytreeNode r)
        {
            if (r == null)
            {
                return (0);

            }
            else return (1 + countNode(r.Left) + countNode(r.Right));

        }
        public static int countLeaves(BinarytreeNode R)
        {
            if (R == null)
            {
                return 0;
            }
            if (R.Left == null && R.Right == null)
            {
                return 1;
            }
            return countLeaves(R.Left) + countLeaves(R.Right);

        }

        public static void preorder(BinarytreeNode R)
        {
            if (R == null)
                return;
            Console.Write(R.data + ",");
            preorder(R.Left);
            preorder(R.Right);
        }
        public static void inorder(BinarytreeNode R)
        {
            if (R == null)
                return;
            inorder(R.Left);
            Console.Write(R.data + ",");
            inorder(R.Right);
        }
        public static void postorder(BinarytreeNode R)
        {
            if (R == null)
                return;
            postorder(R.Left);
            postorder(R.Right);
            Console.Write(R.data + ",");

        }
        public static int SumofNode(BinarytreeNode R)
        {
            if (R == null) return 0;
            return SumofNode(R.Left) + SumofNode(R.Right) + R.data;

        }
        public static void printtree(BinarytreeNode R)
        {


            if (R != null)
            {
                printtree(R.Left);
                Console.Write(R.data + " ");
                printtree(R.Right);

            }
        }







    }

}
