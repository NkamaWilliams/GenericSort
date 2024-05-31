// See https://aka.ms/new-console-template for more information
using System;

namespace Assgn
{
    public class Vend
    {
        public static void Main(string[] args)
        {
            Sort<int>.Run();
        }

        public static void Run()
        {
            Product a = new Product("Liams", 22);

            VendingMachine machine = new VendingMachine();
            machine.addProduct(a.name, a.price);
            machine.addProduct("Cabin", 50);
            machine.addProduct("Cabin");
            machine.addProduct("Cabin");
            machine.addProduct("Cabin");
            machine.addProduct("Cabin");
            machine.view();
            Console.WriteLine("Input the name of the product you want to buy:");
            string choice = Console.ReadLine();
            try
            {
                machine.dispense(choice);
                machine.view();
            }
            catch
            {
                Console.WriteLine("Invalid product name or price!");
            }
        }
    }

    /// <summary>
    /// The VendingMachine class represents a VendingMachine
    /// </summary>
    class VendingMachine
    {
        /// <summary>
        /// A list of all available <see cref="Product"/>s
        /// </summary>
        /// <value>The list of products</value>
        private List<Product> products;

        /// <summary>
        /// Initializes a new instance of <see cref="VendingMachine"/> and creates an empty list of products
        /// </summary>
        public VendingMachine()
        {
            products = new List<Product>();
        }

        /// <summary>
        /// Shows all products along with their names, prices and quantity left
        /// </summary>
        public void view()
        {
            int counter = 1;
            foreach (Product product in products)
            {
                Console.WriteLine("{0}. {1} ${2}\t\t{3}", counter, product.name, product.price, product.quantity);
                counter++;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Adds a product to the vending machine
        /// </summary>
        /// <param name="productName">The name of the product being added</param>
        /// <param name="price">The price of the product being added</param>
        /// <postcondition>The products list is updated</postcondition>
        public void addProduct(string productName, int price)
        {
            int index = products.FindIndex(product => product.name == productName);
            if (index != -1)
            {
                products[index].incrementQuantity();
            }
            else if (price >= 0)
            {
                products.Add(new Product(productName, price));
            }
            else
            {
                Console.WriteLine("Invalid price given");
            }
        }

        /// <summary>
        /// Adds a product to the vending machine
        /// </summary>
        /// <param name="productName">The name of the product being added</param>
        /// <postcondition>The products list is updated</postcondition>
        public void addProduct(string productName)
        {
            int index = products.FindIndex(product => product.name == productName);
            if (index != -1)
            {
                products[index].incrementQuantity();
            }
            else
            {
                products.Add(new Product(productName, 10));
            }
        }

        /// <summary>
        /// Dispenses a product from the machine
        /// </summary>
        /// <param name="productName">The name of the product to be dispensed</param>
        /// <returns>The product</returns>
        /// <precondition>The product name must be valid</precondition>
        public Product dispense(string productName)
        {
            int index = products.FindIndex(product => product.name == productName);
            if (index == -1)
            {
                Console.WriteLine("We do not have such a product");
                return new Product("", 0);
            }
            if (products[index].quantity < 1)
            {
                Console.WriteLine("Sorry, we've run out of {0}. Try again later!", products[index].name);
                return new Product("", 0);
            }
            Console.WriteLine("{0} costs {1}. Please input payment:", products[index].name, products[index].price);
            int amount = Convert.ToInt32(Console.ReadLine());
            bool success = pay(amount, products[index].price);

            if (success)
            {
                Console.WriteLine("Payment Successful!\n");
                products[index].decrementQuantity();
                return products[index];
            }
            else
            {
                Console.WriteLine("Insufficient amount!");
                return new Product("", 0);
            }
        }

        /// <summary>
        /// Pays for a product
        /// </summary>
        /// <param name="amount">The amount being payed</param>
        /// <param name="price">The amount to be paid</param>
        /// <returns>True or False depending on the status of the transaction</returns>
        public bool pay(int amount, int price)
        {
            return amount >= price;
        }
    }
}