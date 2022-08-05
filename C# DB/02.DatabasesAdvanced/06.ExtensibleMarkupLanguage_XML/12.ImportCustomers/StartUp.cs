using CarDealer.Data;
using CarDealer.Dto.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext dbContex = new CarDealerContext();

            //dbContex.Database.EnsureCreated();

            //string xmlInputSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            //string xmlInputParts = File.ReadAllText(@"../../../Datasets/parts.xml");
            // string xmlInputCars = File.ReadAllText(@"../../../Datasets/cars.xml");
            string xmlInputCustomers = File.ReadAllText(@"../../../Datasets/customers.xml");

            //Console.WriteLine(ImportSuppliers(dbContex,xmlInputSuppliers));
            // Console.WriteLine(ImportParts(dbContex, xmlInputParts));
            //Console.WriteLine(ImportCars(dbContex, xmlInputCars));
            Console.WriteLine(ImportCustomers(dbContex, xmlInputCustomers));

        }
        //Problem 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            ImportSupplierDto[] suppliers = (ImportSupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Supplier> dbSuppliers = new List<Supplier>();

            foreach (var supp in suppliers)
            {
                Supplier sp = new Supplier()
                {
                    Name = supp.Name,
                    IsImporter = bool.Parse(supp.IsImporter)
                };
                dbSuppliers.Add(sp);
            }

            context.Suppliers.AddRange(dbSuppliers);
            context.SaveChanges();

            return $"Successfully imported {dbSuppliers.Count}";
        }

        //Problem 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), xmlRoot);

            ImportPartDto[] importPartDtos = (ImportPartDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Part> dbParts = new List<Part>();

            foreach (var part in importPartDtos)
            {
                if (context.Suppliers.FirstOrDefault(x => x.Id == part.SupplierId) == null)
                {
                    continue;
                }

                Part newPart = new Part()
                {
                    Name = part.Name,
                    Price = part.Price,
                    Quantity = part.Quantity,
                    SupplierId = part.SupplierId
                };
                dbParts.Add(newPart);
            }
            context.Parts.AddRange(dbParts);
            context.SaveChanges();

            return $"Successfully imported {dbParts.Count}";
        }

        //Problem 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), xmlRoot);

            ImportCarDto[] carDtos = (ImportCarDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Car> dbCars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                List<PartCar> currPartCar = new List<PartCar>();

                foreach (var part in carDto.Parts.Select(x => x.Id).Distinct())
                {
                    if (context.Parts.FirstOrDefault(x => x.Id == part) == null)
                    {
                        continue;
                    }
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = part
                    };
                    currPartCar.Add(partCar);
                }
                car.PartCars = currPartCar;
                dbCars.Add(car);
            }

            context.Cars.AddRange(dbCars);
            context.SaveChanges();

            return $"Successfully imported {dbCars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), xmlRoot);

            ImportCustomerDto[] customersDtos =
                (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Customer> dbCustomers = new List<Customer>();

            foreach (var customerDto in customersDtos)
            {
                Customer customer = new Customer()
                {
                    Name = customerDto.Name,
                    BirthDate = customerDto.BirthDate,
                    IsYoungDriver = customerDto.IsYoungDriver
                };

                dbCustomers.Add(customer);
            }
            context.Customers.AddRange(dbCustomers);
            context.SaveChanges();

            return $"Successfully imported {dbCustomers.Count}";
        }
    }
}