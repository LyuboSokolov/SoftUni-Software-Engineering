using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
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
            var suppliersAsJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            Console.WriteLine(ImportSuppliers(dbcontex,suppliersAsJson));

        }

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
    }
}