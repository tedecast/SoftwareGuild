using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
			//PrintAllProducts();
			//PrintAllCustomers();
			//Exercise1();
			//Exercise2();
			//Exercise3();
			//Exercise4();
			//Exercise5();
			//Exercise6();
			//Exercise7();
			//Exercise8();
			//Exercise9();
			Exercise10();
			//Exercise11();
			//Exercise12();
			//Exercise13();
			//Exercise14();
			//Exercise15();
			//Exercise16();
			//Exercise17();
			//Exercise18();
			//Exercise19();
			//Exercise20();
			//Exercise20();
			//Exercise21();
			//Exercise22();
			//Exercise23();
			//Exercise24();
			//Exercise25();
			//Exercise26();
			//Exercise27();
			//Exercise28();
			//Exercise29();
			//Exercise30();
			//Exercise31();

			Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
			var products = DataLoader.LoadProducts().Where(p => p.UnitsInStock == 0);
			PrintProductInformation(products);
		}

		/// <summary>
		/// Print all products that are in stock and cost more than 3.00 per unit.
		/// </summary>
		static void Exercise2()
        {
			var products = DataLoader.LoadProducts().Where(c => c.UnitsInStock > 0 && c.UnitPrice > 3M);
			PrintProductInformation(products);
		}

		/// <summary>
		/// Print all customer and their order information for the Washington (WA) region.
		/// </summary>
		static void Exercise3()
        {
			var WACustomers = DataLoader.LoadCustomers().Where(c => c.Region == "WA");
			PrintCustomerInformation(WACustomers);
		}

		/// <summary>
		/// Create and print an anonymous type with just the ProductName
		/// </summary>
		static void Exercise4()
        {
			var products = DataLoader.LoadProducts();
			var JustNames = from product in products

							select new
							{
								name = product.ProductName
							};

			foreach (var name in JustNames)
			{
				Console.WriteLine(name.name);
			}
		}

		/// <summary>
		/// Create and print an anonymous type of all product information but increase the unit price by 25%
		/// </summary>
		static void Exercise5()
        {
			var products = DataLoader.LoadProducts();
			decimal multiplier = 1.25M;
			var ProductsMultiplied = from product in products

									 select new
									 {
										 product.ProductID,
										 product.ProductName,
										 product.Category,
										 product.UnitsInStock,
										 price = product.UnitPrice * multiplier
									 };
			string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
			Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
			Console.WriteLine("==============================================================================");

			foreach (var product in ProductsMultiplied)
			{
				Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
					product.price, product.UnitsInStock);

			}
		}

		/// <summary>
		/// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
		/// </summary>
		static void Exercise6()
        {
			var products = DataLoader.LoadProducts();
			var ProductsMultiplied = from product in products

									 select new
									 {
										 UpperName = product.ProductName.ToUpper(),
										 UpperCategory = product.Category.ToUpper()
									 };
			string line = "{0,-35} {1,-15}";
			Console.WriteLine(line, "Product Name", "Category");
			Console.WriteLine("==============================================================================");

			foreach (var product in ProductsMultiplied)
			{
				Console.WriteLine(line, product.UpperName, product.UpperCategory);

			}
		}

		/// <summary>
		/// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
		/// be set to true if the Units in Stock is less than 3
		/// 
		/// Hint: use a ternary expression
		/// </summary>
		static void Exercise7()
        {
			var products = DataLoader.LoadProducts();
			var ProductsReOrder = from product in products

								  select new
								  {
									  product.ProductID,
									  product.ProductName,
									  product.Category,
									  product.UnitsInStock,
									  product.UnitPrice,
									  ReOrder = product.UnitsInStock < 3 ? true : false
								  };

			string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5, 6:c}";
			Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "ReOrder");
			Console.WriteLine("==============================================================================");

			foreach (var product in ProductsReOrder)
			{

				Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
				product.UnitPrice, product.UnitsInStock, product.ReOrder);
			}
		}

		/// <summary>
		/// Create and print an anonymous type of all Product information with an extra decimal called 
		/// StockValue which should be the product of unit price and units in stock
		/// </summary>
		static void Exercise8()
        {
			var products = DataLoader.LoadProducts();
			var ProductsReOrder = from product in products

								  select new
								  {
									  product.ProductID,
									  product.ProductName,
									  product.Category,
									  product.UnitsInStock,
									  product.UnitPrice,
									  StockMultiplied = product.UnitsInStock * product.UnitPrice
								  };

			string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5, 6:c}";
			Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Total Value");
			Console.WriteLine("==============================================================================");

			foreach (var product in ProductsReOrder)
			{

				Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
				product.UnitPrice, product.UnitsInStock, product.StockMultiplied);
			}

		}

		/// <summary>
		/// Print only the even numbers in NumbersA
		/// </summary>
		static void Exercise9()
        {
			IEnumerable<int> onlyEvens = DataLoader.NumbersA.Where(number => number % 2 == 0);

			foreach (int i in onlyEvens)
				Console.WriteLine(i);
		}

		/// <summary>
		/// Print only customers that have an order whos total is less than $500
		/// </summary>
		static void Exercise10()
        {
			var customers = DataLoader.LoadCustomers();
			var fivehundred = customers.Where(customer => customer.Orders.Any(order => order.Total < 500M));
			PrintCustomerInformation(fivehundred);
			
			/*var customers = DataLoader.LoadCustomers();
			foreach (var customer in customers)
			{
				decimal total = 0M;
				foreach (var order in customer.Orders)
				{
					total += order.Total;
				}

				if (total < 500M)
				{
					Console.WriteLine(customer.CustomerID);
				}
			}*/
		}

		/// <summary>
		/// Print only the first 3 odd numbers from NumbersC
		/// </summary>
		static void Exercise11()
        {
			IEnumerable<int> onlyOdds= DataLoader.NumbersC.Where(number => number % 2 == 1).Take(3);

			foreach(var number in onlyOdds)
				Console.WriteLine(number);
		}

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
			IEnumerable<int> NotFirstThree = DataLoader.NumbersB.Skip(3);

			foreach (int number in NotFirstThree)
				Console.WriteLine(number);
		}

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
			IEnumerable<Customer> customers = DataLoader.LoadCustomers();

			var RecentWA = from customer in customers
 						   where customer.Region == "WA"
						   
						   select new
							{
							customer.CompanyName,
							MostRecentOrder = customer.Orders.OrderByDescending(order => order.OrderDate).First()

						   };

			string format = "{0,-35}\t{1:MM-dd-yyyy} {2,6} {3,10:c}";
			Console.WriteLine(format, "Company Name", "Order Date", "Order ID", "Order Total");
			foreach (var customer in RecentWA)
			{
				Console.WriteLine(format, customer.CompanyName, customer.MostRecentOrder.OrderDate, customer.MostRecentOrder.OrderID, customer.MostRecentOrder.Total);
			}

		}

		/// <summary>
		/// Print all the numbers in NumbersC until a number is >= 6
		/// </summary>
		static void Exercise14()
        {
			IEnumerable<int> UntilSix = DataLoader.NumbersC.TakeWhile(n => n <= 6);

			foreach (var n in UntilSix)
			{
				Console.WriteLine(n);
			}
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
			IEnumerable<int> Divide3 = DataLoader.NumbersC.SkipWhile(n => n % 3 != 0).Skip(1);

			foreach (var n in Divide3)
			{
				Console.WriteLine(n);
			}
		}

		/// <summary>
		/// Print the products alphabetically by name
		/// </summary>

		static void Exercise16()
        {
			IEnumerable<Product> allProducts = DataLoader.LoadProducts();

			var alphabeticalOrder = allProducts.OrderBy(product => product.ProductName);
			foreach (var product in alphabeticalOrder)
			{
				Console.WriteLine(product.ProductName);
			}
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
			var descendingUnits = DataLoader.LoadProducts().OrderByDescending(p => p.UnitsInStock);

			PrintProductInformation(descendingUnits);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
			var organized = DataLoader.LoadProducts().OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
			PrintProductInformation(organized);

		}

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
			var reverse = DataLoader.NumbersB.Reverse();
			foreach (var number in reverse)
			{
				Console.WriteLine(number);
			}
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
			var category = DataLoader.LoadProducts().GroupBy(p => p.Category);

			foreach (var c in category)
			{
				Console.WriteLine(c.Key);
				foreach (var p in c)
				{
					if (c.Key == p.Category)
						Console.WriteLine(p.ProductName);
				}
			}
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
			var allCustomers = DataLoader.LoadCustomers();

			foreach (var customer in allCustomers)
			{
				Console.WriteLine(customer.CompanyName);
				var orderDates = customer.Orders.GroupBy(o => o.OrderDate.Year);

				foreach (var year in orderDates)
				{
					Console.WriteLine(year.Key);
					foreach (var month in year)
					{
						Console.WriteLine("\t" + month.OrderDate.Month + " - " + month.Total);
					}
					
				}

				Console.WriteLine();
			}
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
			var categories = DataLoader.LoadProducts().GroupBy(c => c.Category);

			foreach (var c in categories)
			{
				Console.WriteLine(c.Key);

			}
		}

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
			var Find798 = DataLoader.LoadProducts().Find(p => p.ProductID == 789);

			if (Find798 != null)
				Console.WriteLine("Products 789 exists");
			else
				Console.WriteLine("Product 789 doesn't exist");
			
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
			var OutofStock = DataLoader.LoadProducts().GroupBy(p => p.Category);

			foreach (var item in OutofStock)
			{
				foreach (var data in item)
				{
					if (data.UnitsInStock == 0)
					{
						Console.WriteLine(item.Key);
						break;
					}

				}
			}
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
			var AllinStock = DataLoader.LoadProducts().GroupBy(p => p.Category);

			foreach (var item in AllinStock)
			{
				bool isAllinStock = true;

				foreach (var data in item)
				{

					if (data.UnitsInStock == 0)
					{
						isAllinStock = false;
						break;
					}

				}

				if (isAllinStock)
					Console.WriteLine(item.Key);
			}
		}

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
			var odds = DataLoader.NumbersA.Where(n => n % 2 != 0);
			Console.WriteLine(odds.Count());
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
			var customerandorder = DataLoader.LoadCustomers().Select(c => new
															   {
																   c.CustomerID,
																   OrderCount = c.Orders.Length
															   });
			Console.WriteLine("Customer ID      Order Count");
			foreach (var customer in customerandorder)
				Console.WriteLine(customer.CustomerID  + "              " + customer.OrderCount);
		}

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
			var allProducts = DataLoader.LoadProducts().GroupBy(p => p.Category);
			string format = "{0,-10} \t{1}";

			foreach (var category in allProducts)
			{
				Console.WriteLine(format, category.Key, category.Count());
			}
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
			var allProductCategories = DataLoader.LoadProducts().GroupBy(c => c.Category);
			string format = "{0,-10} \t{1}";

			foreach (var category in allProductCategories)
			{
				int total = 0;
				foreach (var item in category)
				{
					total += item.UnitsInStock;
				}

				Console.WriteLine(format, category.Key, total);
			}
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
			var allProductCategories = DataLoader.LoadProducts().GroupBy(c => c.Category);
			string format = "{0, -8} \t{1}";

			foreach (var category in allProductCategories)
			{
				var lowest = category.OrderBy(p => p.UnitPrice).First();

				Console.WriteLine(format, category.Key, lowest.ProductName);

			}
		}

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
			var SortedCategories = DataLoader.LoadProducts().GroupBy(p => p.Category);
			string format = "{0, -8} \t{1}";
			foreach (var category in SortedCategories.OrderByDescending(category => category.Average(p => p.UnitPrice)).Take(3))
			{
				Console.WriteLine(format, category.Key, category.Average(p => p.UnitPrice).ToString("$0.00"));
			}
        }
    }
}
