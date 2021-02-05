using System;
using System.Collections.Generic;
using CollectionsAndLinq.LinqExamples;

namespace CollectionsAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //anything with angle brackets after the type name is a generic type
            //List<T> Generic List
            //Pronounced List of T
            //T is a Generic Type Parameter
            //string in this case closes the generic type
            var teachers = new List<string>() {"Jameka", "Dylan", "Nathan"};
            var e13 = new List<string>();
            e13.Add("Rob");
            e13.Add("Ryan");
            e13.Add("Bailey");
            e13.Add("Wanda");
            e13.Add("Wanda");
            e13.Add("Wanda");
            e13.Add("Hunder");

            //e13.Add(teachers[0]);
            //e13.Add(teachers[1]);
            //e13.Add(teachers[2]);

            //foreach (var student in e13)
            //{
            //    Console.WriteLine(student);
            //}

            //gets enumerator for a type
            //foreach (var student in e13)//unsupported operation exception
            //{
            //    //changes to the underlying collection do not allow for continued looping
            //    e13.Add("myself"); 
            //}

            e13.AddRange(teachers);

            if (e13.Remove("Wanda"))
            {
                Console.WriteLine("Bye Wanda");
            }
            if (e13.Remove("Wanda"))
            {
                Console.WriteLine("Bye again Wanda");
            }

            //Dictionary<TKey, TValue>
            //Arity - How many generic type parameters a collection takes in. Dictionary `2.
            //Arity (`2) Takes in 2 parameters
            //Very fast information retrieval
            //Slower information storage
            //Good for: infrequently updated but often read data
            //Good for: loading information at startup or in the background and fast retrieval on demand (caching)

            //the first parameter is the type for the keyk, the second is the type for the value
            var words = new Dictionary<string, string>
            { //collection initializer
                {"soup", "a type of food that is good." }, //key value pair
                {"cake", "a type of food that is good." }
            };

            words.Add("Arity", "How many generic type parameters a collection takes or passes in");

            words["Arity"] = "A thing Nathan made up"; //look up an item by key using the indexer

            //words.Add("Arrity", "new definition"); //argument exception
            if(!words.TryAdd("Arrity", "new definition"))
            {
                words["Arity"] = "Another definition";
            }

            words.Remove("cake"); //only need to pass the key

            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} means {word.Value}");
            }

            //destructured version of the above foreach loop
            foreach (var (word, definition) in words)
            {
                Console.WriteLine($"{word} means {definition}");
            }

            var complicatedDictionary = new Dictionary<string, List<string>>();

            complicatedDictionary.Add("Soup", new List<string>());
            complicatedDictionary["Soup"].Add("This is a definition of soup");
            complicatedDictionary.Add("Arity", new List<string> { "A definition of arity" });

            foreach (var (word, definitions) in complicatedDictionary)
            {
                Console.WriteLine(word);
                foreach (var definition in definitions)
                {
                    Console.WriteLine($"/t{definition}");
                }
            }

            //Hashset<T>
            //Really fast retrieval, no keys
            //Slow information storage
            //enforces uniqueness, but no errors
            //Good for: looping, de-duplication
            //Good for: when you only want at most one copy of a thing
                    
            var unique = new HashSet<string>(e13); //most collection constructors take in collections and convert them

            unique.Add("Ryan"); //only allows for one copy to add
            unique.Add("Ryan"); //these others will not add to "unique"
            unique.Add("Ryan");
            unique.Add("Ryan");

            unique.Remove("Ryan");

            //Queue<T>
            //FIFO - first in first out
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(8);
            queue.Enqueue(12);
            queue.Enqueue(3);
            queue.Enqueue(1);

            while (queue.Count > 0)
            {
                Console.WriteLine($"currently dequeueing : {queue.Dequeue()} ");
            }


            //Stact<T>
            //LIFO - last in first out
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(5);

            while (queue.Count > 0)
            {
                Console.WriteLine($"currently dequeueing : {stack.Pop()} ");
            }

            //var examples = new Examples();
        }
    }
}
