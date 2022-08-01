using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            string inputXmlUsers = File.ReadAllText(@"../../../Datasets/users.xml");
            string inputXml = File.ReadAllText(@"../../../Datasets/products.xml");

            Console.WriteLine(ImportUsers(dbContext, inputXmlUsers));
            Console.WriteLine(ImportProducts(dbContext, inputXml));



        }

        //Problem 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), xmlRoot);

            ImportUserDto[] dtos = (ImportUserDto[])serializer.Deserialize(new StringReader(inputXml));

            List<User> users = new List<User>();

            foreach (var user in dtos)
            {
                User newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = int.Parse(user.Age)
                };
                users.Add(newUser);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), xmlRoot);

            ImportProductDto[] dtos = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Product> dbProducts = new List<Product>();

            foreach (var item in dtos)
            {
                Product product = new Product()
                {
                    Name = item.Name,
                    Price = item.Price,
                    SellerId = item.SellerId,
                    BuyerId = item.BuyerId

                };
                dbProducts.Add(product);
            }
            context.Products.AddRange(dbProducts);
            context.SaveChanges();


            return $"Successfully imported {dbProducts.Count}";
        }
    }
}