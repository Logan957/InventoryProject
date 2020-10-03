using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryProject.BL;

namespace InventoryProject.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new InventoryController();
            c.AddProducts("Coca-cola", 50 , 5000);
            c.ProductsInfo();
        }
    }
}
