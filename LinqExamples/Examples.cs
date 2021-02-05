using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionsAndLinq.LinqExamples
{
    class Examples
    {
        public void Run()
        {

            //new list of whole numbers
            var numbers = new List<int> { 12, 15, 400, 1, 3208, 19, 12, 400, 300, 3209 };
            var badNumbers = new List<int> { 666, 13, 19 };

            //Where is like Array.filter, returns a new collection of IEnumerable<T>
            //filtering data
            var bigNumbers = numbers.Where(number => number > 27);

            //Select is like Array.map, returns a new collection of IEnumerable<T>
            //transforming data
            var biggerNumbers = numbers.Select(number => number + 27);

            //the "max" item in a collection
            var biggestNumber = numbers.Max();

            //the first item of a collection
            var firstNumber = numbers.First();

            //first matching item
            var firstMatchingNumber = numbers.First(number => number > 12);

            //contains but cooler, is there a value contained... is there a specific value contained within the collection
            var hasReallyBigNumbers = numbers.Any(number => number > 1000000);

            //Complex/Referenc Types and Linq
            var animals = new List<Animal>
            {//collection initializer
                new Animal{Type = "Giraffe", HeightInInches = 204, WeightInPounds = 1800}, //object initializer
                new Animal{Type = "Tiger", HeightInInches = 40, WeightInPounds = 500},//<-- must include comma
                new Animal{Type = "Frog", HeightInInches = 3, WeightInPounds = 0},
                new Animal{Type = "Gorilla", HeightInInches = 63, WeightInPounds = 3500}
            };

            //filter data
            var animalsThatStartWithG = animals.Where(animal => animal.Type.StartsWith("G")).ToList();

            //transform data
            var animalDescriptions = animals
                .Select(animal => $@"A {animal.Type} is {animal.HeightInInches} inches tall and {animal.WeightInPounds}lbs heavy.");

            foreach (var description in animalDescriptions)
            {
                Console.WriteLine(description);
            }

            //group a collection by a given key (based on a function)
            var groupAnimals = animals.GroupBy(animal => animal.Type.First());

            foreach (var animalGroup in groupAnimals)
            {
                Console.WriteLine($"Animals that start with {animalGroup.Key}");

                foreach (var animal in animalGroup)
                {
                    Console.WriteLine(animal.Type);
                }
            }
                                                                //Key                   //Value
            var groupAnimalNames = animals.GroupBy(animal => animal.Type.First(), animal => animal.Type);

            var filteredAndTransformedAnimals = animals
                .Where(animal => animal.HeightInInches > 20)
                .Select(animal => animal.Type);

            var firstThreeNumbersAndTheSixth = numbers.Take(3).Concat(numbers.Skip(5).Take(1));

            //removes a set of numbers from a collection held within another collection
            var onlyGoodNumbers = numbers.Except(badNumbers);

            //no duplicates
            var uniqueNumbers = numbers.Distinct();

        }
    }
}
