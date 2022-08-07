using CarDealer.Data;
using CarDealer.Dto.Export;
using CarDealer.Dto.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext dbContex = new CarDealerContext();

            //dbContex.Database.EnsureDeleted();
            //dbContex.Database.EnsureCreated();

            //string xmlInputSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            //string xmlInputParts = File.ReadAllText(@"../../../Datasets/parts.xml");
            //string xmlInputCars = File.ReadAllText(@"../../../Datasets/cars.xml");
            //string xmlInputCustomers = File.ReadAllText(@"../../../Datasets/customers.xml");
            //string xmlInputSales = File.ReadAllText(@"../../../Datasets/sales.xml");

            //Console.WriteLine(ImportSuppliers(dbContex, xmlInputSuppliers));
            //Console.WriteLine(ImportParts(dbContex, xmlInputParts));
            //Console.WriteLine(ImportCars(dbContex, xmlInputCars));
            //Console.WriteLine(ImportCustomers(dbContex, xmlInputCustomers));
            //Console.WriteLine(ImportSales(dbContex, xmlInputSales));

            Console.WriteLine(GetSalesWithAppliedDiscount(dbContex));

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

        //Problem 12. Import Customers
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

        //Problem 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), xmlRoot);

            ImportSaleDto[] salesDto = (ImportSaleDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Sale> dbSales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                if (context.Cars.FirstOrDefault(x => x.Id == saleDto.CarId) == null)
                {
                    continue;
                }

                Sale sale = new Sale()
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                };
                dbSales.Add(sale);
            }

            context.Sales.AddRange(dbSales);
            context.SaveChanges();

            return $"Successfully imported {dbSales.Count}";
        }

        //Problem 14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarDto[] carsToProcess = context.Cars
                 .Where(x => x.TravelledDistance > 2000000)
                 .OrderBy(x => x.Make)
                 .ThenBy(x => x.Model)
                 .Select(x => new ExportCarDto()
                 {
                     Make = x.Make,
                     Model = x.Model,
                     TravelledDistance = x.TravelledDistance
                 })
                 .Take(10)
                 .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), carsToProcess, namespaces);

            return sb.ToString().TrimEnd(); ;
        }

        //Problem 15. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportCarBmwDto[] carsBmw = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new ExportCarBmwDto()
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarBmwDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), carsBmw, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSupplierDto[] suppliersToProcess = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new ExportLocalSupplierDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSupplierDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), suppliersToProcess, namespaces);

            return sb.ToString().TrimEnd();

        }

        //Problem 17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            List<ExportCarWithPartsDto> exportCars = new List<ExportCarWithPartsDto>();

            var exportCarsToProcess = context.Cars
                .Select(x => new
                {
                    x.Make,
                    x.Model,
                    x.TravelledDistance,
                    Parts = x.PartCars.Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price
                    })

                   .OrderByDescending(p => p.Price)
                   .ToList()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToList();

            foreach (var carToProcess in exportCarsToProcess)
            {
                ExportCarWithPartsDto car = new ExportCarWithPartsDto()
                {
                    Make = carToProcess.Make,
                    Model = carToProcess.Model,
                    TravelledDistance = carToProcess.TravelledDistance
                };

                List<ExportPartDto> currParts = new List<ExportPartDto>();

                foreach (var part in carToProcess.Parts)
                {
                    ExportPartDto p = new ExportPartDto()
                    {
                        Name = part.Name,
                        Price = part.Price
                    };
                    currParts.Add(p);
                }
                car.Parts = currParts.ToArray();
                exportCars.Add(car);
            }
            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarWithPartsDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), exportCars.ToArray(), namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            ExportCustomerDto[] customersToProcess = context.Customers
                .Where(x => x.Sales.Count >= 1)
                .Select(x => new ExportCustomerDto()
                {
                    FullName = x.Name,
                    BoughtCar = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(pc => pc.Car.PartCars.Sum(p => p.Part.Price))

                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomerDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), customersToProcess, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleDto[] exportCarSaleDtos =
                          context.Sales
               .Select(x => new ExportSaleDto()
               {
                   Car = new ExportCarSaleDto()
                   {
                       Make = x.Car.Make,
                       Model = x.Car.Model,
                       TravelledDistance = x.Car.TravelledDistance.ToString(),
                   },
                   CustomerName = x.Customer.Name,
                   Discount = x.Discount.ToString(),
                   Price = x.Car.PartCars.Sum(x => x.Part.Price).ToString(),
                   //PriceWithDiscount =
                   // $"{(x.Car.PartCars.Sum(x => x.Part.Price) * (1 - ((x.Discount) / 100))).ToString("f2",CultureInfo.InvariantCulture)}"
                   PriceWithDiscount =
                   ((x.Car.PartCars.Sum(p => p.Part.Price) - (x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100))).ToString()


               })

            .ToArray();

            //.Select(x => new ExportSaleDto()
            //{

            //    Car = new ExportCarSaleDto()
            //    {
            //        Make = x.Car.Make,
            //        Model = x.Car.Model,
            //        TravelledDistance = x.Car.TravelledDistance.ToString()
            //    },
            //    CustomerName = x.Customer.Name,
            //    Discount = x.Discount.ToString(),
            //    Price = x.Car.PartCars.Sum(p => p.Part.Price).ToString(),
            //    PriceWithDiscount = ((x.Car.PartCars.Sum(p => p.Part.Price) - (x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100))).ToString()
            //})
            //.ToArray();


            XmlRootAttribute xmlRoot = new XmlRootAttribute("sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSaleDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), exportCarSaleDtos, namespaces);

            return sb.ToString().Trim();
        }
    }
}