using Microsoft.AspNetCore.Mvc;
using ProdutoApp.Data.Repositories;
using ProdutoApp.API.Dtos;
using AutoMapper;
using ProdutoApp.Data.Entities;
namespace ProdutoApp.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMapper _mapper;
    public ProductsController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Post(ProductRequestDto request)
    {
        try
        {
            //copiar os campos da classe dto para a entidade
            var product = _mapper.Map<Product>(request);
            //gerando o Id para a tarefa (gravação no banco de dados)
            product.Id = Guid.NewGuid();

            //gravar a tarefa no banco de dados
            var productRepository = new ProductRepository();
            productRepository.Save(product);

            //HTTP 201 (CREATED)
            return StatusCode(201, new { mensagem = "Produto inserido com sucesso" });

        }
        catch (Exception e)
        {
            //retornar erro...
            return StatusCode(500, new { mensagem = "Falha ao cadastrar tarefa:" + e.Message });
        }
    }







    [HttpGet]
    public IActionResult Get()
    {
        var productRepository = new ProductRepository();

        var result = _mapper.Map<List<ProductResponseDto>>(productRepository.GetAll());

        return Ok(result);



    }


    [HttpGet ("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            var productRepository = new ProductRepository();
            var product = productRepository.GetById(id);

            if (product == null)
                return StatusCode(204);
            var response = _mapper.Map<ProductResponseDto>(product);

            return StatusCode(200, response);

        }
        catch (Exception e)
        {
            return StatusCode(500, new { mensagem = e.Message });
        }
    }

      

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, ProductRequestDto request)
    {
        try
        {
            var productRepository = new ProductRepository();
            var product = productRepository.GetById(id);

            if (product == null)
                return StatusCode(404, new { mensagem = "Produto não encontrada para edição. Verifique o ID informado." });

                _mapper.Map(request, product);

               

            productRepository.Update(product);

            return StatusCode(200, new { mensagem = "Produto atualizado com sucesso." });
        }
        catch (Exception e)
        {
            return StatusCode(500, new { mensagem = "Falha ao atualizar o produto:" + e.Message });
        }
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            var productRepository = new ProductRepository();
            var product = productRepository.GetById(id);

            if (product == null)
                return StatusCode(404, new { mensagem = "Produto não encontrado para exclusão. Verifique o ID informado." });

            productRepository.Delete(product);

            return StatusCode(200, new { mensagem = "Produto excluído com sucesso." });


        }
        catch (Exception e)
        {
            return StatusCode(500, new { mensagem = "Falha ao excluir produto: " + e.Message });
        }
    }

    [HttpGet("dashboard")]
    public IActionResult GetDashboard()
    {
        try
        {
            var productRepository = new ProductRepository();
            var products = productRepository.GetAll();

            var dashboardData = products
                .GroupBy(p => p.Type) 
                .Select(g => new ProductDashboardDto
                {
                    Type = g.Key,
                    Quantity = g.Count(), 
                    AverageUnitaryPrice = (decimal)g.Average(p => (double)p.UnitaryPrice) 
                })
                .ToList();

            // Converte a resposta para um formato que pode ser manipulado corretamente
            var response = dashboardData.Select(dto => new
            {
                Type = dto.Type.ToString(), // Converte enum para string
                dto.Quantity,
                dto.AverageUnitaryPrice
            }).ToList();

            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { mensagem = "Falha ao obter o resumo do dashboard: " + e.Message });
        }
    }
}





