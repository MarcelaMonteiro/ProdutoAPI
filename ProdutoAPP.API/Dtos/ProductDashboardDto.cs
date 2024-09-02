using ProdutoApp.Data.Enums;

namespace ProdutoApp.API.Dtos
{
    public class ProductDashboardDto
    {
        public ProductType Type { get; set; }
        public int Quantity { get; set; } 
        public decimal AverageUnitaryPrice { get; set; } 
    }
}
