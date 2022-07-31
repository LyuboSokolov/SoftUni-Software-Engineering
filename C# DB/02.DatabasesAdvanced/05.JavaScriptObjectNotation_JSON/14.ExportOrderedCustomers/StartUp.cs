using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbcontext = new CarDealerContext();
            //dbcontext.Database.EnsureDeleted();
            //dbcontext.Database.EnsureCreated();

            //var suppliersAsJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //var partsAsJson = File.ReadAllText(@"../../../Datasets/parts.json");
            //var carsAsJson = File.ReadAllText(@"../../../Datasets/cars.json");
            //var customersAsJson = File.ReadAllText(@"../../../Datasets/customers.json");
            //var salesAsJson = File.ReadAllText(@"../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(dbcontext, suppliersAsJson));
            //Console.WriteLine(ImportParts(dbcontext, partsAsJson));
            //Console.WriteLine(ImportCars(dbcontext, carsAsJson));
            //Console.WriteLine(ImportCustomers(dbcontext, customersAsJson));
            //Console.WriteLine(ImportSales(dbcontext, salesAsJson));

            Console.WriteLine(GetOrderedCustomers(dbcontext));

        }

        //Problem 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersInput = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            List<Supplier> dbSuppliers = new List<Supplier>();

            foreach (var supplier in suppliersInput)
            {
                var dbSupplier = new Supplier()
                {
                    Name = supplier.Name,
                    IsImporter = supplier.IsImporter
                };
                dbSuppliers.Add(dbSupplier);
            }

            context.Suppliers.AddRange(dbSuppliers);
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}.";
        }

        //Problem 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var partsInput = JsonConvert.DeserializeObject<PartInputDto[]>(inputJson);

            List<Part> dbParts = new List<Part>();

            foreach (var part in partsInput)
            {
                if (context.Suppliers.FirstOrDefault(x => x.Id == part.SupplierId) == null)
                {
                    continue;
                }
                var dbPart = new Part()
                {
                    Name = part.Name,
                    Price = part.Price,
                    Quantity = part.Quantity,
                    SupplierId = part.SupplierId
                };

                dbParts.Add(dbPart);
            }

            context.Parts.AddRange(dbParts);
            context.SaveChanges();


            return $"Successfully imported {context.Parts.Count()}."; ;
        }

        //Problem 11.
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsInput = JsonConvert.DeserializeObject<CarInputDto[]>(inputJson);

            List<Car> dbCars = new List<Car>();
            List<PartCar> dbPartsCars = new List<PartCar>();

            foreach (var car in carsInput)
            {

                var dbCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,

                };


                foreach (var partId in car.PartsId.Distinct())
                {
                    PartCar newPart = new PartCar()
                    {

                        PartId = partId,
                        Car = dbCar
                    };
                    dbPartsCars.Add(newPart);
                }

                dbCars.Add(dbCar);
            }
        
            context.Cars.AddRange(dbCars);
            context.PartCars.AddRange(dbPartsCars);
            context.SaveChanges();


            return $"Successfully imported {context.Cars.Count()}.";
        }
        //Problem 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var inputCustomers = JsonConvert.DeserializeObject<CustomerInputDto[]>(inputJson);
            List<Customer> dbCustomers = new List<Customer>();

            foreach (var customer in inputCustomers)
            {
                var dbCustomer = new Customer()
                {
                    Name = customer.Name,
                    BirthDate = customer.BirthDate,
                    IsYoungDriver = customer.IsYoungDriver
                };
                dbCustomers.Add(dbCustomer);
            }
            context.Customers.AddRange(dbCustomers);
            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}.";
        }

        //Problem 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var inputSales = JsonConvert.DeserializeObject<SaleInputDto[]>(inputJson);
            List<Sale> dbSales = new List<Sale>();

            foreach (var sale in inputSales)
            {
                var newSale = new Sale()
                {
                    CarId = sale.CarId,
                    CustomerId = sale.CustomerId,
                    Discount = sale.Discount
                };
                dbSales.Add(newSale);
            }
            context.Sales.AddRange(dbSales);
            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}.";
        }


        public static string GetOrderedCustomers(CarDealerContext context)
        {
            List<CustomerOutputDto> results = new List<CustomerOutputDto>();

            var customers = context.Customers
                 .OrderBy(x => x.BirthDate)
                 .ThenBy(x => x.IsYoungDriver)
                 .Select(x => new
                 {
                     Name = x.Name,
                     BirthDate = x.BirthDate.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                     IsYoungDriver = x.IsYoungDriver
                 })
                 .ToList();

            foreach (var customer in customers)
            {
                var result = new CustomerOutputDto()
                {
                    Name = customer.Name,
                    BirthDate = customer.BirthDate,
                    IsYoungDriver = customer.IsYoungDriver
                };
                results.Add(result);
            }
            var customersAsJson = JsonConvert.SerializeObject(results,Formatting.Indented);

            return customersAsJson;
        }

    }
}