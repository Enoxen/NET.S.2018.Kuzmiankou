using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSTree.BSTException;

namespace BSTree
{
    /// <summary>
    /// Generic binary search tree class.
    /// </summary>
    /// <typeparam name="T">Generic parameter.</typeparam>
    public class BinarySearchTree<T>
    {
        #region Fields
        /// <summary>
        /// Root element of a tree.
        /// </summary>
        private Node root;

        /// <summary>
        /// Contains values of traverse.
        /// </summary>
        private List<T> traverseContent;

        /// <summary>
        /// Comparer for not default comparison.
        /// </summary>
        private IComparer<T> comparer;
        #endregion

        #region Constructor
        public BinarySearchTree() { }
        
        /// <summary>
        /// COnstructor for comparer initialization.
        /// </summary>
        /// <param name="comparer">Comparer.</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Public add method.
        /// </summary>
        /// <param name="element">Element to be added.</param>
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

        /// <summary>
        /// Checks weather tree contains element.
        /// </summary>
        /// <param name="element">Element to be found.</param>
        /// <returns>True if contatins and false if it's not.</returns>
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

        /// <summary>
        /// InOreder tree traverse method.
        /// </summary>
        /// <returns>Collection of traverse content.</returns>
        public IEnumerable<T> InOrder()
        {
           
            foreach (T t in InOrder(root))
            {
                yield return t;
            }
        }

        /// <summary>
        /// PreOrder tree traverse method.
        /// </summary>
        /// <returns>Collection of traverse.</returns>
        public List<T> PreOrder()
        {
            traverseContent = new List<T>();
            PreOrder(root);
            return traverseContent;
        }
        
        /// <summary>
        /// PostOeder tree traverse method.
        /// </summary>
        /// <returns>Collection of traverse content.</returns>
        public List<T> PostOrder()
        {
            traverseContent = new List<T>();
            PostOrder(root);
            return traverseContent;
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Private InOrder implementation
        /// </summary>
        /// <param name="n">Node of a tree.</param>
        private IEnumerable<T> InOrder(Node n)
        {
            if (n != null)
            {
                foreach (T t in InOrder(n.left))
                {
                    yield return n.value;
                }

                yield return n.value;

                foreach (T t in InOrder(n.right))
                {
                    yield return n.value;
                }
            }
        }

        /// <summary>
        /// Private PostOrder implementation
        /// </summary>
        /// <param name="n">Node of a tree.</param>
        private IEnumerable<T> PostOrder(Node n)
        {
            if (n != null)
            {
                foreach (T t in PostOrder(n.left))
                {
                    yield return t;
                }


                foreach (T t in PostOrder(n.right))
                {
                    yield return t;
                }

                yield return n.value;
            }
        }

        /// <summary>
        /// Private PreOreder implementation
        /// </summary>
        /// <param name="n">Node of a tree.</param>
        private IEnumerable<T> PreOrder(Node n)
        {
            if (n != null)
            {
                yield return n.value;
                foreach (T t in PreOrder(n.left))
                {
                    yield return t;
                }

                foreach (T t in PreOrder(n.right))
                {
                    yield return t;
                }
            }
        }

        /// <summary>
        /// Checks if tree contains element using users comparer.
        /// </summary>
        /// <param name="node">Node of a tree.</param>
        /// <param name="element">Element to be found</param>
        /// <returns>True if the element is found, flase if it's not.</returns>
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

        /// <summary>
        /// Checks if tree contains element by default comparer.
        /// </summary>
        /// <param name="node">Node of a tree.</param>
        /// <param name="element">Element to be found</param>
        /// <returns>True if the element is found, flase if it's not.</returns>
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

        /// <summary>
        /// Private add method with default comparer.
        /// </summary>
        /// <param name="node">Node of a tree.</param>
        /// <param name="element">Casted to IComparable element.</param>
        /// <returns>Returns node of a tree.</returns>
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

        /// <summary>
        /// Private add method with users comparer.
        /// </summary>
        /// <param name="node">Node of a tree.</param>
        /// <param name="element">Value to de added.</param>
        /// <returns>Returns node of a tree.</returns>
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
        
        /// <summary>
        /// Checks weather element implements IComparable and casts it to IComparable.
        /// </summary>
        /// <param name="element">Element ot be casted and checked.</param>
        /// <returns>Returns IComparable copy of element.</returns>
        private IComparable<T> CastToIComparable(T element)
        {
            if (!(element is IComparable<T>))
            {
                throw new ComparisonException($"{nameof(element)} doesn't implement IComparable interface.");
            }
            return (IComparable<T>)element;
        }

        /// <summary>
        /// Checks weather element is null.
        /// </summary>
        /// <param name="element">Element to be checked.</param>
        private void CheckIsNullAndThrowException(T element)
        {
            if (ReferenceEquals(element, null))
            {
                throw new ArgumentNullException($"{nameof(element)} is null");
            }
        }
        #endregion

        #region Node class
        
        /// <summary>
        /// Inner class that represents node of a tree.
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Value that is stored in node.
            /// </summary>
            public T value;

            /// <summary>
            /// Points on the left child.
            /// </summary>
            public Node left;

            /// <summary>
            /// Points on the right child.
            /// </summary>
            public Node right;

            /// <summary>
            /// Constructor that initializes inner value.
            /// </summary>
            /// <param name="value"></param>
            public Node(T value) : this(value, null, null) { }

            /// <summary>
            /// Initializes all fields.
            /// </summary>
            /// <param name="value"></param>
            /// <param name="l"></param>
            /// <param name="r"></param>
            public Node(T value, Node l, Node r)
            {
                this.value = value;
                left = l;
                right = r;
            }

            /// <summary>
            /// Empty constructor.
            /// </summary>
            public Node() { }
        }
        #endregion
    }

}
