using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbcontext = new ProductShopContext();

            //dbcontext.Database.EnsureDeleted();
            //dbcontext.Database.EnsureCreated();

            //var usersJsonAsString = File.ReadAllText("../../../Datasets/users.json");
            // var producJsonAsString = File.ReadAllText("../../../Datasets/products.json");
            //var categoryJsonAsString = File.ReadAllText("../../../Datasets/categories.json");
            // var categoryProductJsonAsString = File.ReadAllText("../../../Datasets/categories-products.json");

            Console.WriteLine(GetSoldProducts(dbcontext));


        }

        //Problem Query 2. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<UserInputDto> users = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            IMapper mapper = new Mapper(mapperConfiguration);

            var mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }

        //Problem Query 3. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<ProductInputDto> products = JsonConvert
                                                    .DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            IMapper mapper = new Mapper(mapperConfiguration);

            var mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        //Problem Query 4. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryInputDto> categories = JsonConvert
                                .DeserializeObject<IEnumerable<CategoryInputDto>>(inputJson)
                                .Where(x => x.Name != null);

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            IMapper mapper = new Mapper(mapperConfiguration);
            var categoriesObj = mapper.Map<IEnumerable<Category>>(categories);

            context.Categories.AddRange(categoriesObj);
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }
        // Problem Query 5. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryProduct> categoriesProducts = JsonConvert
                .DeserializeObject<IEnumerable<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        //Problem Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {

            var productsInRange = context.Products.Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    x.Name,
                    x.Price,
                    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToList();

            DefaultContractResolver defaultContract = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = defaultContract
            };

            var productJson = JsonConvert.SerializeObject(productsInRange, jsonSettings);
            return productJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProduct = context.Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    SoldProducts = x.ProductsSold
                                        .Where(x => x.Seller != null)
                                        .Select(p => new
                                        {
                                            Name = p.Name,
                                            Price = p.Price,
                                            BuyerFirstName = p.Buyer.FirstName,
                                            BuyerLastName = p.Buyer.LastName
                                        })
                                        .ToList()

                })

                .ToList();

            DefaultContractResolver defaultContract = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = defaultContract
            };


            var result = JsonConvert.SerializeObject(soldProduct, jsonSettings);

            return result;
        }
    }
}
