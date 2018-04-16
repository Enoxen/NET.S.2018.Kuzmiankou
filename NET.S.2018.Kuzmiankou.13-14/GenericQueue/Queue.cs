using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueue
{
    public class Queue<T> : IEnumerable<T>
    {
        #region Fields and properties

        private T[] array;

        private int head;

        private int tail;

        private int capacity = 10;

        private int version;

        private int size;

        public int Size => size;
        #endregion

        #region Constructors

        public Queue()
        {
            array = new T[capacity];
        }

        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(capacity)} is less than zero");
            }

            array = new T[capacity];
            this.capacity = capacity;
        }

        public Queue (IEnumerable<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException($"{nameof(collection)} is null");
            }

            array = new T[collection.Count()];
            capacity = array.Length;
  
            foreach(T element in collection)
            {
                Enque(element);
            }
        }

        #endregion
        #region Queue methods


        public void Enque(T element)
        {
            if (ReferenceEquals(element, null))
            {
                throw new ArgumentNullException(nameof(element));
            }
            
            if (size == capacity)
            {
                Resize(capacity * 2);
            }

            array[tail] = element;
            tail = (tail + 1) % capacity;
            size++;
            version++;
        }

        public T Dequeue()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T element = array[head];
            array[head] = default(T);
            head = (head + 1) % capacity;
            size--;
            version++;
            return element;
        }

        private void Resize(int newCapacity)
        {
            T[] newArray = new T[capacity];

            if (size > 0)
            {
                CopyOrderedToArray(newArray);
            }

            array = newArray;
            head = 0;
            tail = size == capacity ? 0 : size;
            capacity = newCapacity;
            version++;
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return array[head];
        }

        

        public bool Contains(T element)
        {
            IEqualityComparer<T> equality = EqualityComparer<T>.Default;
            foreach(var arrElem in array)
            {
                if(ReferenceEquals(arrElem, element))
                {
                    return true;
                }

                if (equality.Equals(arrElem, element))
                {
                    return true;
                }
            }

            return false;
        }

        private void CopyOrderedToArray(T[] newArray)
        {
            int current = head;
            for (int i = 0; i < size; i++)
            {
                newArray[i] = array[current];
                current = (current + 1) % capacity;
            }
        }

        public T[] ToArray()
        {
            T[] queueCopy = new T[size];

            CopyOrderedToArray(queueCopy);

            return queueCopy;

        }

        public void Clear()
        {
            Array.Clear(array, 0, array.Length);
            head = 0;
            tail = 0;
            size = 0;
            version++;
        }
        #endregion
        
        #region Enumertor methods
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Custom enumerator
        public class QueueEnumerator : IEnumerator<T>
        {
            #region Fields and properties
            private readonly Queue<T> queue;
            private int index;
            private int version;

            public T Current
            {
                get
                {
                    if(index <= -1 || index >= queue.Size)
                    {
                        throw new InvalidOperationException();
                    }

                    return queue.array[index];
                }
            }

            object IEnumerator.Current => Current;
            #endregion

            #region Constructor
            public QueueEnumerator(Queue<T> collection): this()
            {
                queue = collection;
            }

            public QueueEnumerator()
            {
            }
            #endregion


            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
        #endregion


        #region Object methods
        public override bool Equals(object obj)
        {
            var queue = obj as Queue<T>;
            return queue != null &&
                   EqualityComparer<T[]>.Default.Equals(array, queue.array) &&
                   head == queue.head &&
                   tail == queue.tail &&
                   capacity == queue.capacity &&
                   version == queue.version &&
                   size == queue.size &&
                   Size == queue.Size;
        }

        public override int GetHashCode()
        {
            var hashCode = 1555908580;
            hashCode = hashCode * -1521134295 + EqualityComparer<T[]>.Default.GetHashCode(array);
            hashCode = hashCode * -1521134295 + head.GetHashCode();
            hashCode = hashCode * -1521134295 + tail.GetHashCode();
            hashCode = hashCode * -1521134295 + capacity.GetHashCode();
            hashCode = hashCode * -1521134295 + version.GetHashCode();
            hashCode = hashCode * -1521134295 + size.GetHashCode();
            hashCode = hashCode * -1521134295 + Size.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}

