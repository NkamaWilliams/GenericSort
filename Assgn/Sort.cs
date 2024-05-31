using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assgn
{
    /// <summary>
    /// Generic class for sorting elements of type T
    /// </summary>
    /// <typeparam name="T">Type of element to sort</typeparam>
    public class Sort<T> where T : IComparable<T>
    {
        /// <summary>
        /// Entry point method for sorting demonstration
        /// </summary>
        public static void Run()
        {
            //Initialize necessary variables for demonstration
            int[] arr = {1, 4, 5, 2, 0, -5 };
            string[] arr2 = { "a", "d", "c", "b", "f", "e"};
            Console.WriteLine($"{arr2.SequenceEqual<string>(new string[] {"a", "b", "c", "d", "e", "f"})}");
            Product[] products = { new Product("Pepsi", 100), new Product("Cabin", 20), new Product("Coke", 100), new Product("Meat", 1000) };
            Console.WriteLine("{0}", arr[0].CompareTo(arr[1]));
            Sort<Product>.printList(products[0..]);
            try
            {
                //Sort the array if user wants to
                Console.WriteLine("Do you want to continue? If so type 'y':");
                string ans = Console.ReadLine();
                if (ans == "y")
                {
                    Product[] sorted = Sort<Product>.MergeSort(products);
                    Sort<Product>.printList(sorted[0..]);
                }
            }
            catch
            {
                Console.WriteLine("There was an error");
            }
        }

        /// <summary>
        /// Performs merge-sort on the given array
        /// </summary>
        /// <param name="array">The array to be sorted</param>
        /// <returns>The sorted array</returns>
        public static T[] MergeSort(T[] array)
        {
            int length = array.Length;
            if (length == 1 || length == 0)
            {
                return array;
            }
            T[] arr1 = MergeSort(array[0..(length/2)]);
            T[] arr2 = MergeSort(array[(length / 2)..]);
            T[] merged = Sort<T>.Merge(arr1 , arr2);
            return merged;
        }

        /// <summary>
        /// Merges two sorted arrays
        /// </summary>
        /// <param name="arr1">The first sorted array</param>
        /// <param name="arr2">The second sorted array</param>
        /// <returns>The sorted merged array of arr1 and arr2</returns>
        public static T[] Merge(T[] arr1, T[] arr2)
        {
            T[] result = new T[arr1.Length + arr2.Length];
            int index1 = 0, index2 = 0, index = 0;
            while (index1 < arr1.Length && index2 < arr2.Length)
            {
                if (arr1[index1].CompareTo(arr2[index2]) < 0)
                {
                    result[index++] = arr1[index1];
                    index1++;
                }
                else
                {
                    result[index++] = arr2[index2];
                    index2++;
                }
            }
            if (index1 < arr1.Length)
            {
                for (int i = index1; index1 < arr1.Length; index1++)
                {
                    result[index++] = arr1[index1];
                }
            }
            else
            {
                for (int i = index2; index2 < arr2.Length; index2++)
                {
                    result[index++] = arr2[index2];
                }
            }
            return result;
        }

        /// <summary>
        /// Prints the elements of an array
        /// </summary>
        /// <param name="array">The array to be printed</param>
        public static void printList(T[] array)
        {
            Console.Write("[");
            foreach (T elem in array)
            {
                Console.Write("{0}, ", elem.ToString());
            }
            Console.Write("]\n");
        }

    }

    /// <summary>
    /// Generic class representing a VendingMachine
    /// </summary>
    /// <typeparam name="T">The type of product stored in the vending machine</typeparam>
    internal class VendingMachine<T>
    {
        /// <summary>
        /// Gets the product being stored in the machine
        /// </summary>
        /// <value>The product being stored</value>
        public T product { get; private set; }

        /// <summary>
        /// Gets the quantity of the product stored in the machine
        /// </summary>
        /// <value>The quantity of the product</value>
        public int quantity { get; private set; }

        /// <summary>
        /// Gets the name of the product being stored in the machine
        /// </summary>
        /// <value>The name of the product being stored</value>
        public string name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VendingMachine{T}"/> class
        /// </summary>
        /// <param name="product">The type of the product stored</param>
        /// <param name="name">The name of the product</param>
        public VendingMachine(T product, string name)
        {
            this.product = product;
            this.quantity = 0;
            this.name = name;
        }

        /// <summary>
        /// Displays information about the Vending Machine
        /// </summary>
        public void view()
        {
            Console.WriteLine("{0}\t\tAmount Left: {1}", this.name, this.quantity);
        }

        /// <summary>
        /// Adds items to the Vending Machine
        /// </summary>
        /// <param name="amount">The amount of items added</param>
        public void add(int amount)
        {
            this.quantity += amount;
        }

        /// <summary>
        /// Removes items from the Vending Machine
        /// </summary>
        /// <param name="amount">The amount of items to remove</param>
        /// <precondition>The amount should not be greater than the number of products the Vending Machine possseses</precondition>
        public void remove(int amount)
        {
            if (this.quantity - amount >= 0)
            {
                this.quantity -= amount;
            }
            else
            {
                Console.WriteLine("No item currently available");
            }
        }
    }

    /// <summary>
    /// The Product class represents a product
    /// </summary>
    public class Product : IComparable<Product>
    {
        /// <summary>
        /// Gets the product name
        /// </summary>
        /// <value>The product's name</value>
        public string name { get; private set; }

        /// <summary>
        /// Gets the product price
        /// </summary>
        /// <value>The product's price</value>
        public int price { get; private set; }

        /// <summary>
        /// Gets the product quantity
        /// </summary>
        /// <value>The product's quantity</value>
        public int quantity { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">The name of the product</param>
        /// <param name="price">The price of the product</param>
        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
            quantity = 1;
        }

        /// <summary>
        /// Increases the quantity of the quantity property
        /// </summary>
        /// <postcondition>The quantity property increases by 1</postcondition>
        public void incrementQuantity()
        {
            quantity += 1;
        }

        /// <summary>
        /// Decreases the quantity of the quantity property
        /// </summary>
        /// <postcondition>The quantity property decreases by 1</postcondition>
        public void decrementQuantity()
        {
            quantity -= 1;
        }

        /// <summary>
        /// Compares the name of two products
        /// </summary>
        /// <param name="other">The other product to compare</param>
        /// <returns>The integer difference between their names</returns>
        public int CompareTo(Product other)
        {
            if (other == null)
            {
                return 1;
            }

            return name.CompareTo(other.name);
        }

        /// <summary>
        /// Overrides the default ToString method for the product class
        /// </summary>
        /// <returns>THe name of the product</returns>
        public override string ToString()
        {
            return name;
        }
    }

}
