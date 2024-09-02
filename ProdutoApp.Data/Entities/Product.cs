using ProdutoApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoApp.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int UnitaryPrice { get; set; }

 

       


        public ProductType Type { get; set; }
    }
}
