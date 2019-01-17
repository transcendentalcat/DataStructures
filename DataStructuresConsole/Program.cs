using DataStructures.LinkedList;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.HashTable;

namespace DataStructuresConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********Create new list*************");
            var list = new LinkedList<string>(){"item1", "item2", "item3" };
            foreach (var element in list)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine("\n****Added item4****");
            list.Add("item4");
            foreach (var element in list)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine("\n****Added item0 to the begining****");
            list.AddAt("item0", 0);
            foreach (var element in list)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine("\n****Removed first item0 ****");
            list.RemoveAt(0);
            foreach (var element in list)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine("\n****Removed item2 ****");

            list.Remove("item2");
            foreach (var element in list)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine("\n****Element and their position****");
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine($"{list.ElementAt(i)} at {i} position ");
            }

            Console.WriteLine("*********Create new hash table*************");

            var hashtable = new HashTable(5);
            hashtable.Add("1", "testString1");
            hashtable.Add("2", "testString2");
            hashtable.Add("3", "testString3");

            for (int i = 0; i < hashtable.Size; i++)
            {
                Console.WriteLine(hashtable[i]);
            }

            Console.WriteLine($"Hashtable contains '2' key - {hashtable.Contains("2")}");
            Console.WriteLine($"Hashtable contains '4' key - {hashtable.Contains("4")}");

            object value;
            var result = hashtable.TryGet("1", out value);
            Console.WriteLine($"Hashtable contains '1' key - {hashtable.Contains("4")} with {value} value");

            Console.ReadKey();
        }
    }
}
