using System;

namespace Data_Structures_Algorithms.Data_Structures
{
    //Trie is a type of search tree used for storing and searching a specific key from a set.
    //Using Trie, search complexities can be brought to optimal limit(key length). 
    //Is a based data structure that is used for storing some collection of strings and performing efficient search operations on them.
    //The word Trie is derived from reTRIEval, which means finding something or obtaining it.
    public class SearchWordWithTrie
    {
        public void Test()
        {
            Trie trie = new Trie();
            string[] arr = { "and", "ant", "do", "dad" };

            foreach (string s in arr) { trie.Insert(s); }

            // One by one search strings
            string[] searchKeys = { "do", "gee", "bat" };
            foreach (string s in searchKeys)
            {
                if (trie.Search(s))
                    Console.Write("true ");
                else
                    Console.Write("false ");
            }
            Console.WriteLine();

            // One by one search for prefixes
            string[] prefixKeys = { "ge", "ba", "do", "de" };
            foreach (string s in prefixKeys)
            {
                if (trie.isPrefix(s))
                    Console.Write("true ");
                else
                    Console.Write("false ");
            }
        }
    }

    public class TrieNode
    {
        static readonly int ALPHABET_SIZE = 26;

        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

        // isEndOfWord is true if the node represents
        // end of a word

        public bool isLeaf;

        public TrieNode()
        {
            isLeaf = false;
            for (int i = 0; i < ALPHABET_SIZE; i++)
                children[i] = null;
        }
    }
    public class Trie
    {
        private TrieNode root;

        public Trie() { root = new TrieNode(); }

        public void Insert(string key)
        {
            TrieNode curr = root;
            foreach (char c in key)
            {
                if (curr.children[c - 'a'] == null)
                {
                    curr.children[c - 'a'] = new TrieNode();
                }
                curr = curr.children[c - 'a'];
            }
            curr.isLeaf = true;
        }

        public bool Search(string word)
        {
            TrieNode cur = root;
            foreach (char c in word)
            {
                int i = c - 'a';
                if (cur.children[i] == null)
                {
                    return false;
                }
                cur = cur.children[i];
            }
            return cur.isLeaf;
        }

        public bool isPrefix(string prefix)
        {
            TrieNode cur = root;
            foreach (char c in prefix)
            {
                int i = c - 'a';
                if (cur.children[i] == null)
                {
                    return false;
                }
                cur = cur.children[i];
            }
            return true;
        }
    }
}

//Insertion O(n) Here n is the length of the string inserted
//Searching O(n) Here n is the length of the string searched
//Prefix Searching O(n) Here n is the length of the string searched

