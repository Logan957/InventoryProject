using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InventoryProject.BL.model;

namespace InventoryProject.BL
{
    class InventoryContext : DbContext
    {
        public InventoryContext(): base("DefaultConnection") 
        { }
        public DbSet<Product> Products { get; set; }
    }
}
