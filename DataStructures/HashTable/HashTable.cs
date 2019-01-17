using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashTable
{
    public class HashTable : IHashTable
    {
        private HashTableNode[] _array;

        private int _capacity;
        public int Size { get; private set; }
        private const double LOAD_FACTOR = 0.75;

        public HashTable(int size)
        {
            _capacity = size;
            _array = new HashTableNode[_capacity];
        }

        private void Resize()
        {
            _capacity = _capacity * 2;
            var temp = _array;
            _array = new HashTableNode[_capacity];
            temp.CopyTo(_array, 0);
        }

        private int Hash(object key)
        {
            return ((Math.Abs(key.GetHashCode()) << 5) + 13) % _capacity;
        }

        private double GetLoadfactor()
        {
            return Size / _capacity;
        }

        public object this[object key]
        {
            get
            {
                if (!Contains(key))
                {
                    throw new KeyNotFoundException();
                }
                return _array[Hash(key)].Value;
            }
            set
            {
                if (value == null)
                {
                    Remove(key);
                }
                else if (Contains(key))
                {
                    throw new DuplicateNameException();
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public void Remove(object key)
        {
            if (Contains(key))
            {
                _array[Hash(key)] = null;
                Size--;
            }
        }

        public void Add(object key, object value)
        {
            if (Contains(key))
            {
                throw new DuplicateNameException();
            }

            int index = Hash(key);

            if (GetLoadfactor() >= LOAD_FACTOR)
                Resize();

            _array[index] = new HashTableNode(key, value);
            Size++;
        }

        public bool Contains(object key)
        {
            int index = Hash(key);
            if (_array[index] == null)
            {
                return false;
            }

            return true;
        }

        public bool TryGet(object key, out object value)
        {
            int index = Hash(key);

            if (!Contains(key))
            {
                throw new KeyNotFoundException();
            }

            value = _array[index].Value;
            return true;
        }
        private class HashTableNode
        {
            public object Key { get; set; }
            public object Value { get; set; }

            public HashTableNode(object key, object value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
