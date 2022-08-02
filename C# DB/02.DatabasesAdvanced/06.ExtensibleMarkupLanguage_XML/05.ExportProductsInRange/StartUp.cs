using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //string inputXmlUsers = File.ReadAllText(@"../../../Datasets/users.xml");
            //string inputXml = File.ReadAllText(@"../../../Datasets/products.xml");
            //string inputXmlCategories = File.ReadAllText(@"../../../Datasets/categories.xml");
            //string inputXmlCategoryProducts = File.ReadAllText(@"../../../Datasets/categories-products.xml");

            //Console.WriteLine(ImportUsers(dbContext, inputXmlUsers));
            //Console.WriteLine(ImportProducts(dbContext, inputXml));
            //Console.WriteLine(ImportCategories(dbContext, inputXmlCategories));
            //Console.WriteLine(ImportCategoryProducts(dbContext, inputXmlCategoryProducts));

            Console.WriteLine(GetProductsInRange(dbContext));

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

        //Problem 02. Import Products
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

        //Problem 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), xmlRoot);
            ImportCategoryDto[] dtos = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));
            List<Category> dbCategories = new List<Category>();

            foreach (var item in dtos)
            {
                if (string.IsNullOrWhiteSpace(item.Name))
                {
                    continue;
                }
                Category category = new Category()
                {
                    Name = item.Name
                };
                dbCategories.Add(category);
            }

            context.Categories.AddRange(dbCategories);
            context.SaveChanges();

            return $"Successfully imported {dbCategories.Count}";
        }

        //Problem 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("CategoryProducts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), xmlRoot);

            ImportCategoryProductDto[] dtos =
                (ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var cp in dtos)
            {
                if (context.Categories.FirstOrDefault(x => x.Id == cp.CategoryId) == null ||
                    context.Products.FirstOrDefault(x => x.Id == cp.ProductId) == null)
                {
                    continue;
                }

                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                };
                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductInRangeDto[] productsInRange = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ExportProductInRangeDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = $"{x.Buyer.FirstName} {x.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            var serializer = new XmlSerializer(typeof(ExportProductInRangeDto[]),xmlRoot);

            StringBuilder sb = new StringBuilder();

            using (StringWriter st = new StringWriter(sb))
            {
                serializer.Serialize(st, productsInRange,xmlSerializerNamespaces);
                
            }
            return sb.ToString().TrimEnd();
        }
    }
}