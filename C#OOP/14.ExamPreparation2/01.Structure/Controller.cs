using Bakery.Core.Contracts;
using Bakery.Drinks;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bakery
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            try
            {
                Type currType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name.StartsWith(type));
                if (currType == null)
                {
                    throw new ArgumentNullException();
                }
                IDrink drink = (IDrink)Activator.CreateInstance(currType, new object[] { name, portion, brand });

                drinks.Add(drink);
                return $"Added {name} ({brand}) to the drink menu";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
          
        }

        public string AddFood(string type, string name, decimal price)
        {
            try
            {
                Type currType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(n => n.Name.StartsWith(type));
                if (currType == null)
                {
                    throw new ArgumentNullException();
                }
                IBakedFood bakedFood = (IBakedFood)Activator.CreateInstance(currType, new object[] { name, price });

                bakedFoods.Add(bakedFood);
                return $"Added {name} ({type}) to the menu";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            try
            {
                Type currType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name.StartsWith(type));
                if (currType == null)
                {
                    throw new ArgumentNullException();
                }
                ITable table = (ITable)Activator.CreateInstance(currType, new object[] { tableNumber, capacity });

                tables.Add(table);
                return $"Added table number {tableNumber} in the bakery";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in tables)
            {
                if (!table.IsReserved)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }
            return sb.ToString();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(p => p.TableNumber == tableNumber);

            if (table == null)
            {
                throw new ArgumentNullException();
            }
            string result = $"Table: {tableNumber}" + Environment.NewLine;
            result += $"Bill: {table.GetBill():f2}";
            totalIncome += table.GetBill();
            table.Clear();
            return result;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(p => p.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            IDrink drink = null;

            foreach (var currDrink in drinks)
            {
                if (currDrink.Name == drinkName && currDrink.Brand == drinkBrand)
                {
                    drink = currDrink;
                    break;
                }
            }
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(p => p.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            IBakedFood bakedFood = bakedFoods.FirstOrDefault(p => p.Name == foodName);

            if (bakedFood == null)
            {
                return $"No {foodName} in the menu";
            }
            table.OrderFood(bakedFood);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            foreach (var table in tables)
            {
                if (!table.IsReserved && table.Capacity >= numberOfPeople)
                {
                    table.Reserve(numberOfPeople);
                    return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";

                }
            }
            return $"No available table for {numberOfPeople} people";
        }
    }
}
