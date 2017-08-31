using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSort
{
    public class Tree
    {
        public Tree Left { get; set; }
        public Tree Right { get; set; }
        public int Value { get; set; }

        public Tree(int value)
        {
            Left = null;
            Right = null;
            Value = value;
        }

        public static Tree AddToTree(Tree root, int value)
        {
            if (root == null)
            {
                root = new Tree(value);
                return root;
            }
            else if (root.Value < value)
                root.Left = AddToTree(root.Left, value);
            else
                root.Right = AddToTree(root.Right, value);

            return root;
        }
        public static int TreeToArray(Tree root, ref int[] array, int pos)
        {
            //1-2 Ascending
            //2-1 Descendingly

            //1
            if (root.Right != null)
                pos = TreeToArray(root.Right, ref array, pos);

            array[pos++] = root.Value;

            //2
            if (root.Left != null)
                pos = TreeToArray(root.Left, ref array, pos);

            return pos;
        }

        public static void Sort(ref int[] array)
        {
            Tree root = null;
            for (int i = 0; i < array.Length; i++)
                root = AddToTree(root, array[i]);

            TreeToArray(root, ref array, 0);
        }
    }
}
