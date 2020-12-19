using System;

namespace trees
{
    public class Tree<T>
    {
        public TreeNode<T> Root { get; }

        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.Root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (var child in children)
            {
                this.Root.AddChild(child.Root);
            }
        }

        public void TraverseDFS()
        {
            this.PrintDFS(this.Root, string.Empty);
        }

        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            if (this.Root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);

            for (int i = 0; i < root.ChildrenCount; i++)
            {
                var child = root.GetChild(i);
                PrintDFS(child, spaces + "   ");
            }
        }
    }
}