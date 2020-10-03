using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InventoryProject.BL.model;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace InventoryProject.BL
{
    public class InventoryController
    {
        public void AddProducts( string name , int price , int number)
        {
            bool AddChecker = false;

            using (InventoryContext db = new InventoryContext())
            {           
                var products = db.Products.ToList();
                foreach (var n in products) 
                {
                    if (name == n.Name)
                    {
                        AddChecker = true;
                        Console.WriteLine("Продукт с данным именем уже существует ");
                        break;
                    }
                }
                if (AddChecker == false)
                {
                    db.Products.Add(new Product { Name = name, Price = price, Number = number });
                    db.SaveChanges();
                }

            }
        }
        public void DeleteProducts(string name)
        {
            bool DeleteChecker = false;
            using (InventoryContext db = new InventoryContext())
            {
                var products = db.Products.ToList();
                foreach (var n in products)
                {
                    if (name == n.Name)
                    {
                        DeleteChecker = true;
                        db.Products.Remove(n);
                        db.SaveChanges();
                        Console.WriteLine("Продукт успешно удален ");
                        break;
                    }
                    
                }
                if (DeleteChecker == false) Console.WriteLine("Данный продукт не найден");

            }
        }
        public void ProductsInfo()
        {
            using (InventoryContext db = new InventoryContext())
            {
                var products = db.Products.ToList();
                foreach (var p in products)
                    Console.WriteLine("{0} - {1} - {2} - {3}", p.Id, p.Name, p.Price, p.Number);
            }
        }
        public void SummInfo ()
        {
            using (InventoryContext db = new InventoryContext())
            {
                var products = db.Products.Select(p => new
                {
                    Summ = p.Price * p.Number
                });
                var Summ = products.Sum(p => p.Summ);
                Console.WriteLine(Summ);
                foreach (var p in products) 
                {
                    Console.WriteLine(p);
                }

            }
        }
    }
}

