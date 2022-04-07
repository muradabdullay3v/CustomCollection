using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollection
{
    internal class CustomList<T>: IEnumerator, IEnumerable
    {
        private T[] arr;
        public int Capacity { get; set; }

        int position = -1;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length) {
                    return arr[index]; 
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                {
                    arr[index] = value;
                }
            }
        }
        public CustomList()
        {
            arr = new T[0];
        }

        public CustomList(int capacity)
        {
            Capacity = capacity;
            arr = new T[Capacity];
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public void Add(T item)
        {
            if (Capacity != 0)
            {
                if (arr[^1] != null) {
                    Array.Resize(ref arr, arr.Length + Capacity);
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != null)
                    {
                        continue;
                    }
                    else
                    {
                        arr[i] = item;
                        break;
                    }
                }
            }
            else
            {
                Array.Resize(ref arr, arr.Length + 1);
                arr[^1] = item;
            }
            
        }

        public void Clear()
        {
            arr = new T[arr.Length];
        }

        public bool MoveNext()
        {
            position++;
            return (position < arr.Length);
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current
        {
            get { return arr[position]; }
        }

        public bool Contains(T item)
        {
            foreach (var i in arr)
            {
                if (i.ToString() == item.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public void Sort()
        {
            Array.Sort(arr);
        }

        public void Remove(int index)
        {
            T[] arr1 = new T[arr.Length - 1];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }
                arr1[j] = arr[i];
                j++;
            }
            arr = arr1;
        }

        public void Remove(T item)
        {
            T[] arr1 = new T[arr.Length - 1];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (item.ToString() == arr[i].ToString())
                {
                    continue;
                }
                arr1[j] = arr[i];
                j++;
            }
            arr = arr1;
        }

    }
}
