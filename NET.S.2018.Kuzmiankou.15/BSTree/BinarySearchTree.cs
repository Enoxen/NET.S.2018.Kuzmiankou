using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSTree.BSTException;

namespace BSTree
{
    public class BinarySearchTree<T>
    {
        #region Fields
        private Node root;
        private List<T> traverseContent;
        private IComparer<T> comparer;
        #endregion

        #region Constructor
        public BinarySearchTree() { }
        
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }
        #endregion

        #region Public methods
        public void Add(T element)
        {
            CheckIsNullAndThrowException(element);           
            if(root != null)
            {
                if (comparer == null)
                {
                    var compElem = CastToIComparable(element);
                    root = AddByDefault(root, compElem);
                }
                else
                {
                    root = AddByComparator(root, element);
                }
            }
            else
            {
                root = new Node
                {
                    value = element
                };
            }  
        }

        public bool Contains(T element)
        {
            CheckIsNullAndThrowException(element);
            if (comparer == null)
            {
                var comparableElement = CastToIComparable(element);
                return ContainsByDefault(root, comparableElement);
            }
            else
            {
                return ContainsByComparator(root, element);
            }
        }

        public bool Remove(T element)
        {
            if (!Contains(element)){
                return false;
            }

            if(comparer == null)
            {
                var comparableElement = CastToIComparable(element);
                root = RemoveByDefault(root, comparableElement);
            }
            else
            {
                root = RemoveByComparator(root, element);
            }

            return true;
        }
        #endregion

        #region Private methods

        private Node RemoveByDefault(Node node, IComparable<T> element)
        {

            return null;
        }

        private bool ContainsByComparator(Node node, T element)
        {
            if (node != null)
            {
                if (comparer.Compare(element, node.value) == 0)
                {
                    return true;
                }
                else if (comparer.Compare(element, node.value) < 0)
                {
                    return ContainsByComparator(node.left, element);
                }
                else
                {
                    return ContainsByComparator(node.right, element);
                }
            }
            return false;
        }

        private bool ContainsByDefault(Node node, IComparable<T> element)
        {
            if (node != null)
            {
                if (element.CompareTo(node.value) == 0)
                {
                    return true;
                }
                else if (element.CompareTo(node.value) < 0)
                {
                    return ContainsByDefault(node.left, element);
                }
                else
                {
                    return ContainsByDefault(node.right, element);
                }
            }
            return false;
        }

        private Node AddByDefault(Node node, IComparable<T> element)
        {
            if (node == null)
            {
                node = new Node();
                node.value = (T)element;
            }
            else if (element.CompareTo(node.value) < 0)
            {
                node.left = AddByDefault(node.left, element);
            }
            else
            {
                node.right = AddByDefault(node.right, element);
            }

            return node;
        }

        private Node AddByComparator(Node node, T element)
        {
            if (node == null)
            {
                node = new Node();
                node.value = element;
            }
            else if(comparer.Compare(element, node.value) < 0)
            {
                node.left = AddByComparator(node.left, element);
            }
            else
            {
                node.right = AddByComparator(node.right, element);
            }
            return node;
        }
        
        private IComparable<T> CastToIComparable(T element)
        {
            if (!(element is IComparable<T>))
            {
                throw new ComparisonException($"{nameof(element)} doesn't implement IComparable interface.");
            }
            return (IComparable<T>)element;
        }

        private void CheckIsNullAndThrowException(T element)
        {
            if (ReferenceEquals(element, null))
            {
                throw new ArgumentNullException($"{nameof(element)} is null");
            }
        }
        #endregion

        #region Node class
        private class Node
        {
            public T value;
            public Node left;
            public Node right;

            public Node(T value) : this(value, null, null) { }

            public Node(T value, Node l, Node r)
            {
                this.value = value;
                left = l;
                right = r;
            }

            public Node() { }
        }
        #endregion
    }

}
