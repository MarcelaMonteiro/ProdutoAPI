using Microsoft.EntityFrameworkCore;
using ProdutoApp.Data.Contexts;
using ProdutoApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoApp.Data.Repositories
{
    public class ProductRepository
    {
        public void Save(Product product)
        {
            
            using (var dataContext = new DataContext())
            {
                
                dataContext.Add(product);
                dataContext.SaveChanges();
            }
        }
        
        public void Update(Product product)
        {

            using (var dataContext = new DataContext())
            {
                dataContext.Update(product);
                dataContext.SaveChanges();
            }

        }

        public void Delete(Product product)
        {
            using (var dataContext = new DataContext())
            {

                dataContext.Remove(product);
                dataContext.SaveChanges();

            }
        }

        
       

       
        public Product? GetById(Guid id)
        {
            //abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Product>()         
                    .Where(p => p.Id == id) 
                    .FirstOrDefault(); 


            }
        }



        public List<Product> GetAll()
        {
            // Abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Product>() 
                    .ToList(); 
            }
        }
        }
}
