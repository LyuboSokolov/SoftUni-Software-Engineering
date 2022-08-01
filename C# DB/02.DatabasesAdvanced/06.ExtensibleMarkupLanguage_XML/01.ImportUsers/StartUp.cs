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

            //dbcontext.Database.EnsureCreated();

            string inputXml = File.ReadAllText(@"../../../Datasets/users.xml");

            Console.WriteLine(ImportUsers(dbContext, inputXml));
            
            
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]),xmlRoot);

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
    }
}