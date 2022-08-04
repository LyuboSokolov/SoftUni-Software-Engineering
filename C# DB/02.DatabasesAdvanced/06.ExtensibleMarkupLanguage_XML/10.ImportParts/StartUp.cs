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
            string xmlInputParts = File.ReadAllText(@"../../../Datasets/parts.xml");

            //Console.WriteLine(ImportSuppliers(dbContex,xmlInputSuppliers));
            Console.WriteLine(ImportParts(dbContex, xmlInputParts));

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

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), xmlRoot);

            ImportPartDto[] importPartDtos = (ImportPartDto[]) xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Part> dbParts = new List<Part>();

            foreach (var part in importPartDtos)
            {
                if (context.Suppliers.FirstOrDefault(x=> x.Id == part.SupplierId) == null)
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
    }
}