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
    public class CategoryRepository
    {
         private IDocumentSession Session {get; set;}
        private IDocumentStore Conn {get; set;}

        public async Task Add(Category cat){
            Conn = RevenDbContext.GetInstance();
            Session = Conn.OpenSession();
            Session.Store(cat);  
            Session.SaveChanges();   
        }

        public async Task<IEnumerable<Category>> GetAll(){
            Conn = RevenDbContext.GetInstance();
            Session = Conn.OpenSession();
            return Session.Query<Category>().ToList();
        }
    }
}