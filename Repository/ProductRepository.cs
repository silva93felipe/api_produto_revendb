using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using ShopRevendb.Context;
using ShopRevendb.Model;

namespace ShopRevendb.Repository
{
    public class ProductRepository
    {
        private IDocumentSession Session {get; set;}
        private IDocumentStore Conn {get; set;}

        public async Task Add(Product product){
            Conn = RevenDbContext.GetInstance();
            Session = Conn.OpenSession();
            Session.Store(product);  

            //Session.Store(product.Category);  

            Session.SaveChanges();   
        }

        public async Task<IEnumerable<Product>> GetAll(){
            Conn = RevenDbContext.GetInstance();
            Session = Conn.OpenSession();
            return Session.Query<Product>().ToList();
        }
    }
}