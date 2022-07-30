using System;
using System.Collections.Generic;
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
            var dbcontex = new CarDealerContext();
            //dbcontex.Database.EnsureCreated();

            // var suppliersAsJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            var partsAsJson = File.ReadAllText(@"../../../Datasets/parts.json");

            //Console.WriteLine(ImportSuppliers(dbcontex, suppliersAsJson));
            Console.WriteLine(ImportParts(dbcontex, partsAsJson));

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

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var partsInput = JsonConvert.DeserializeObject<PartInputDto[]>(inputJson);

            List<Part> dbParts = new List<Part>();

            foreach (var part in partsInput)
            {
                if ( context.Suppliers.FirstOrDefault(x=> x.Id == part.SupplierId) == null)
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
    }
}