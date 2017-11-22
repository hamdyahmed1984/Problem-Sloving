using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Arrays
{
    /*
     * 7.12 Hash Table: Design and implement a hash table which uses chaining (linked lists) to handle collisions.
     */
    class HashTable<K, V>
    {
        private class HashTableNode<K, V>
        {
            public K Key { get; set; }
            public V Value { get; set; }
            public HashTableNode<K, V> Next;

            public HashTableNode(K k, V v)
            {
                Key = k;
                Value = v;
            }
        }

        List<HashTableNode<K, V>> items;
        private int _capacity;
        private int _size;

        public HashTable(int capacity)
        {
            _capacity = capacity;
            // Create list of HashTableNode at a particular size. Fill list with null values, as it's the only way to make the array the desired size.
            items = new List<HashTableNode<K, V>>();
            for (int i = 0; i < capacity; i++)
                items.Add(null);
        }

        /// <summary>
        /// Add key, value pair in the hast table or update if already exists
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {
            //get node for the current key
            HashTableNode<K, V> node = GetNodeForKey(key);
            if(node != null)//key already exists, upddate and return
            {
                node.Value = value;
                return;
            }
            //key doesn't exists in hash table, create new node and add it
            int index = GetIndexForKey(key);
            node = new HashTableNode<K, V>(key, value);
            node.Next = items[index];//set the new created node next pointer to the head of the linked list in items[index], may be a node or null if no nodes added to this index.
            items[index] = node;//set the head of items[index] to the new created node.

            _size++;//increment count of items

            //Optional: double capacity of the hashtable if the loa factor goes beyond a predefined threshold, we set it here to 0.7
            DoubleHashTable();
        }
        

        public V Remove(K key)
        {
            HashTableNode<K, V> node = GetNodeForKey(key);//Get node for the key
            HashTableNode<K, V> prev = null;//keep tracking of the prev node to use for removal of the found node
            while(node != null)
            {
                if (node.Key.Equals(key))//Node with key found
                    break;
                prev = node;
                node = node.Next;
            }
            if (node == null) return default(V);//Node with key not found

            _size--;//decrement size of items

            int index = GetIndexForKey(key);//Get index of the key
            if (prev != null)//Node found and has a prev node
                prev.Next = node.Next;//set next of prev node to the next of the found node, i.e remove the node reference
            else//Node with key found as the head of items[index], i.e it has no prev node
                items[index] = node.Next;
            return node.Value;
        }
        public V Get(K key)
        {
            HashTableNode<K, V> node = GetNodeForKey(key);
            if (node == null) return default(V);
            return node.Value;
            //return node == null ? null : node.Value;
        }
        /// <summary>
        /// The Hash function
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetIndexForKey(K key)
        {
            return key.GetHashCode() % _capacity;
        }
        private HashTableNode<K, V> GetNodeForKey(K key)
        {
            int index = GetIndexForKey(key);
            HashTableNode<K, V> node = items[index];
            while(node != null)
            {
                if (node.Key.Equals(key))
                    return node;
                node = node.Next;
            }
            return null;
        }

        private void DoubleHashTable()
        {
            if ((float)_size / (float)_capacity >= 0.7)
            {
                List<HashTableNode<K, V>> tmp = items.ToList();
                items = new List<HashTableNode<K, V>>();
                _size = 0;
                _capacity = _capacity * 2;
                // Create list of HashTableNode at a particular size. Fill list with null values, as it's the only way to make the array the desired size.
                for (int i = 0; i < _capacity; i++)
                    items.Add(null);
                foreach(HashTableNode<K, V> head in tmp)
                {
                    HashTableNode<K, V> tmpNode = head;//This is a temp node as we cannot assign the head variable because it is the foreach variable
                    while (tmpNode != null)
                    {
                        Add(tmpNode.Key, tmpNode.Value);
                        tmpNode = head.Next;
                    }
                }
            }
        }
    }
}
