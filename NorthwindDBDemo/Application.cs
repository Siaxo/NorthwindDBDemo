using Microsoft.EntityFrameworkCore;
using NorthwindDBDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDBDemo
{
    public class Application
    {
        private readonly string _connectionString;

        public Application(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Run()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>();
            options.UseSqlServer(_connectionString);
            using (var context = new NorthwindContext(options.Options))
            {
                while (true)
                {
                    Console.WriteLine("1. Create new user");
                    Console.WriteLine("2. List all users");
                    Console.WriteLine("0. Exit");

                    int sel = Convert.ToInt32(Console.ReadLine());

                    if (sel == 1)
                    {
                        var customer = new Customer();
                        Console.WriteLine("Customer ID: ");
                        customer.CustomerId = Console.ReadLine();
                        Console.WriteLine("Companyname: ");
                        customer.CompanyName = Console.ReadLine();
                        Console.WriteLine("Contact person: ");
                        customer.ContactName = Console.ReadLine();
                        Console.WriteLine("Title of person: ");
                        customer.ContactTitle = Console.ReadLine();
                        Console.WriteLine("City: ");
                        customer.City = Console.ReadLine();
                        Console.WriteLine("Country: ");
                        customer.Country = Console.ReadLine();

                        context.Customers.Add(customer);
                        context.SaveChanges();
                    }
                    if (sel == 2)
                    {
                        foreach (var customer in context.Customers)
                        {
                            Console.WriteLine(customer.CompanyName);
                        }
                    }
                    if (sel == 0)
                    {
                        break;
                    }
                }
                
            }
        }
    }
}
