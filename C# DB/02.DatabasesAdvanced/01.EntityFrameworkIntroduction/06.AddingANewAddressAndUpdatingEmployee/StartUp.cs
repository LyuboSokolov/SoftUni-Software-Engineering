using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            Console.WriteLine(AddNewAddressToEmployee(db));
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            context.Addresses.Add(new Address { AddressText = "Vitoshka 15", TownId = 4 });
            context.SaveChanges();
            var newAddress = context.Addresses.First(x => x.AddressText == "Vitoshka 15");
            var employee = context.Employees.First(x => x.LastName == "Nakov");
            employee.Address = newAddress;
            context.SaveChanges();

            StringBuilder sb = new StringBuilder();
            int count = 0;

            foreach (var address in context.Addresses.OrderByDescending(x => x.AddressId))
            {
                count++;
                sb.AppendLine(address.AddressText);
                if (count == 10)
                {
                    break;
                }
            }

            return sb.ToString();
        }

    }



}
