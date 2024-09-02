using ProdutoApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProdutoApp.API.Dtos
{
    public class ProductRequestDto
    {
       
    

        [MaxLength(300, ErrorMessage = "Informe o nome do produto com no máximo {1} caracteres.")]
        [MinLength(6, ErrorMessage = "Informe o nome do produto com pelo menos {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public int? UnitaryPrice { get; set; }

        [Required(ErrorMessage = "Por favor, informe o tipo do produto.")]
        public ProductType Type {  get; set; }
      
    }
}
