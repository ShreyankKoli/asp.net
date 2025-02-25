using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class Generic
    {
        public static void Run()
        {
            Console.WriteLine("Generic Collections Demo");

            // 1. List<T> Example
            Console.WriteLine("Generic Collections Demo");

            // 1. List<T> Example
            List<string> carBrands = new List<string>() { "Toyota", "BMW", "Tesla" };

            Console.WriteLine("List<T> Properties and Methods:");
            Console.WriteLine("Capacity: " + carBrands.Capacity);
            Console.WriteLine("Count: " + carBrands.Count);

            carBrands.Add("Ford"); // Adds an item
            Console.WriteLine("After Add: Count = " + carBrands.Count);

            carBrands.Insert(1, "Honda"); // Inserts at index 1
            Console.WriteLine("After Insert: ");
            carBrands.ForEach(Console.WriteLine);

            carBrands.Remove("Tesla"); // Removes a specific item
            Console.WriteLine("After Remove: ");
            carBrands.ForEach(Console.WriteLine);

            carBrands.RemoveAt(0); // Removes by index
            Console.WriteLine("After RemoveAt(0): ");
            carBrands.ForEach(Console.WriteLine);

            bool containsBMW = carBrands.Contains("BMW");
            Console.WriteLine("Contains 'BMW': " + containsBMW);

            carBrands.Sort(); // Sorts the list
            Console.WriteLine("After Sort: ");
            carBrands.ForEach(Console.WriteLine);

            carBrands.Reverse(); // Reverses the list
            Console.WriteLine("After Reverse: ");
            carBrands.ForEach(Console.WriteLine);

            string foundItem = carBrands.Find(x => x.Contains("Ford")); // Finds an item
            Console.WriteLine("Found Item: " + foundItem);

            List<string> clonedList = new List<string>(carBrands); // Clones the list
            Console.WriteLine("Cloned List: ");
            clonedList.ForEach(Console.WriteLine);

            carBrands.Clear(); // Clears all items
            Console.WriteLine("After Clear: Count = " + carBrands.Count);

            // Adding an array to a list
            string[] cities = { "Mumbai", "Pune", "Nashik" };
            var popularCities = new List<string>(cities);

            var favCities = new List<string>();
            favCities.AddRange(popularCities);

            Console.WriteLine("Favorite Cities: ");
            favCities.ForEach(Console.WriteLine);

            // Additional List<T> Methods
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            numbers.InsertRange(2, new List<int> { 6, 7 }); // Inserts multiple items at index
            Console.WriteLine("After InsertRange: ");
            numbers.ForEach(Console.WriteLine);

            numbers.RemoveRange(2, 2); // Removes range of elements
            Console.WriteLine("After RemoveRange: ");
            numbers.ForEach(Console.WriteLine);

            int firstNumber = numbers.First(); // Gets first element
            Console.WriteLine("First element: " + firstNumber);

            int lastNumber = numbers.Last(); // Gets last element
            Console.WriteLine("Last element: " + lastNumber);

            numbers.TrimExcess(); // Trims excess capacity
            Console.WriteLine("After TrimExcess, Capacity: " + numbers.Capacity);

            List<int> ints = new List<int>();
            ints.Add(1);
            ints.Add(2);
            ints.Add(3);

            Console.WriteLine("List<T> Items:");
            foreach (var brand in carBrands.Where(carBrands => carBrands.Contains("BMW")))
            {
                Console.WriteLine("Car Brand: "+brand);
            }

            ICollection<string> carCollection = carBrands;

            carCollection.Add(new string("Ford"));

            foreach(string s in carCollection)
            {
                Console.WriteLine("Icollection: "+ s);
            }

            ICollection<string> mtcollection = new List<string>() { "Luffy","Zoro","Ace" };
            int itemCount = mtcollection.Count;
            Console.WriteLine("Count: "+itemCount);

            IEnumerable<int> numbers = Enumerable.Range(1, 10);
            foreach (int number in numbers)
            {
                Console.WriteLine("IEnumerable example: " + number);
            }

            //adding an array in a list
            string[] cities = new string[3] { "Mumbai", "Pune", "Nashik" };

            var popularCities = new List<string>();

            popularCities.AddRange(cities);

            var favCities = new List<string>();

            favCities.AddRange(popularCities);

            foreach (var item in favCities)
            {
                Console.WriteLine("String List: " + item);
            }

            //accessing a list
            List<int> newNumbers = new List<int> { 1,2,3,4,5,6,7,8,9};
            Console.WriteLine(newNumbers[0]); 
            Console.WriteLine(newNumbers[1]); 
            Console.WriteLine(newNumbers[2]); 
            Console.WriteLine(newNumbers[3]);

            for (int i = 0; i < newNumbers.Count; i++)
                Console.WriteLine("Accessing a list: "+newNumbers[i]);


            List<string> name = new List<string>();
            name.Add("Luffy");

            int idx = name.IndexOf("Luffy");
            if (idx > 0)
            {
                Console.WriteLine($"Item index in List is: {idx}");
            }
            else
            {
                Console.WriteLine("Item not found");
            }

            // List of string
            List<string> authors = new List<string>(5);
            authors.Add("Mahesh Chand");
            authors.Add("Chris Love");
            authors.Add("Allen O'neill");
            authors.Add("Naveen Sharma");
            authors.Add("Mahesh Chand");
            authors.Add("Monica Rathbun");
            authors.Add("David McCarter");
            Console.WriteLine("Original List items");
       
            foreach (string a in authors)
                Console.WriteLine(a);

            // Reverse list items
            authors.Reverse();
            Console.WriteLine();
            Console.WriteLine("Sorted List items");

            // Print reversed items
            foreach (string a in authors)
                Console.WriteLine(a);

            // Copy items from one list to another list
            List<string> listOne = new();
            listOne.Add("One");
            listOne.Add("Two");
            listOne.Add("Three");
            listOne.Add("Four");
            listOne.Add("Five");

            
            List<string> listTwo = new();
            listTwo.Add("A");
            listTwo.Add("B");
            listTwo.Add("C");
            
            listOne.AddRange(listTwo);

            foreach (string item in listOne)
                Console.WriteLine(item);

            List<string> newData = new List<string>();
            newData.Add("Luffy");
            newData.Add("Zoro");
            newData.Add("Sanji");

            foreach (string item in newData.Where(newData => newData.Contains("Luffy")))
            {
                Console.WriteLine("New Data: "+item);
            }


            // 2. Dictionary<TKey, TValue> Example
            Dictionary<int, string> employees = new Dictionary<int, string>();
            employees.Add(101, "Luffy");
            employees.Add(102, "Ace");
            employees.Add(103, "Zoro");

            Console.WriteLine("Dictionary<TKey, TValue> Items:");
            foreach (var kvp in employees)
            {
                Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
            }

            // 3. Stack<T> Example
            Stack<string> stack = new Stack<string>();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");

            Console.WriteLine("Stack Items (LIFO):");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            // 4. Queue<T> Example
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine("Queue Items (FIFO):");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            // 5. HashSet<T> Example
            HashSet<int> uniqueNumbers = new HashSet<int>();
            uniqueNumbers.Add(10);
            uniqueNumbers.Add(20);
            uniqueNumbers.Add(30);
            uniqueNumbers.Add(20); // Duplicate won't be added

            Console.WriteLine("\nHashSet<T> Items (Unique Elements Only):");
            foreach (var number in uniqueNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
