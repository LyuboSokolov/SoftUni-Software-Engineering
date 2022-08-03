using CarDealer.Data;
using CarDealer.Dto.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext dbContex = new CarDealerContext();

            //dbContex.Database.EnsureCreated();

            string xmlInputsuppliers = File.ReadAllText(@"../../../Datasets/suppliers.xml");

            Console.WriteLine(ImportSuppliers(dbContex,xmlInputsuppliers));

        }

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
    }
}