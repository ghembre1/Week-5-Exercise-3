using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Exercise_3
{
    internal class Program
    {
        class Product // establishes the prduct class
        {
            public string ProductID { get; set; } // sets ProductID property
            public string ProductName { get; set; } // sets ProductName property
            public double Price { get; set; } // sets Price property

            public Product(string productId, string productName, double price)
            {
                // sets the properties as variables
                ProductID = productId;
                ProductName = productName;
                Price = price;
            }
        }

        class ShoppingCart // sets up the shoppingcart class
        {
            private List<Product> products; // establishes product list

            public ShoppingCart()
            {
                products = new List<Product>(); // makes product a new list
            }

            public void AddProduct(Product product) // method for AddProduct
            {
                products.Add(product);
                Console.WriteLine($"Added {product.ProductName} to the cart."); // prompts user what they added to the cart
            }

            public void RemoveProduct(string productId) // method for RemoveProduct
            {
                Product productToRemove = products.Find(product => product.ProductID == productId);
                if (productToRemove != null)
                {
                    products.Remove(productToRemove);
                    Console.WriteLine($"Removed {productToRemove.ProductName} from the cart."); // prompts users what they removed from the cart
                }
            }
            public double CalculateTotalPrice() // method for CalculateTotalPrice
            {
                double totalPrice = 0;
                foreach (var product in products) // starts loop for all products in the list
                {
                    totalPrice += product.Price; // adds the price of each item together
                }
                return totalPrice; // returns the final totalprice from all the items
            }
        }
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart(); // creates a new ShoppingCart

            while (true)
            {
                // Prompts users the options they can choose
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. Calculate Total Price");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: "); // prompts user to choose and option
                string choice = Console.ReadLine(); // takes users input

                if (choice == "1") // option 1 is to add product
                {
                    Console.Write("Enter Product ID: "); // prompts user to input ID
                    string productId = Console.ReadLine(); // takes users input
                    Console.Write("Enter Product Name: "); // prompts user to input the product
                    string productName = Console.ReadLine(); // takes users input
                    Console.Write("Enter Price: "); // prompts user to input the price of the product
                    double price = Convert.ToDouble(Console.ReadLine()); // takes users input

                    Product product = new Product(productId, productName, price); // creates a new product
                    cart.AddProduct(product);
                }
                else if (choice == "2") // option 2 is to remove a product
                {
                    Console.Write("Enter Product ID to remove: "); // prompts user to input the ID
                    string productId = Console.ReadLine(); // takes users input
                    cart.RemoveProduct(productId); // removes product from list
                }
                else if (choice == "3") // option 3 is to calculate the total price of their inputed products
                {
                    double totalPrice = cart.CalculateTotalPrice(); // takes the method and calculates the total price for all items user inputed
                    Console.WriteLine($"Total Price: ${totalPrice:F2}"); // prompts user the total price for their items
                }
                else if (choice == "4") // option 4 closes the program when the user is ready
                {
                    Console.WriteLine("Exiting the program."); // prompts user that they are exiting the program
                    break; // breaks loop
                }
            }
            Console.ReadKey();
        }
    }
}
