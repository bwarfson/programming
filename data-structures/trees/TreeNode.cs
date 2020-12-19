using System;
using System.Collections.Generic;

namespace trees
{
    public class TreeNode<T>
    {
        public T Value { get; set; }

        public List<TreeNode<T>> Children { get; set; }

        public bool HasParent { get; set; }

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value");
            }

            this.Value = value;
            this.Children = new List<TreeNode<T>>();
        }

        public int ChildrenCount => this.Children.Count;

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value");
            }

            if (child.HasParent)
            {
                throw new ArgumentException("The node already has a parent");
            }

            child.HasParent = true;
            this.Children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.Children[index];
        }
    }
}