using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client.Documents;

namespace ShopRevendb.Context
{
    public class RevenDbContext
    {
        private readonly string URL_BASE  =  "http://localhost:8080";
        private readonly string DATABASE  =  "Shop";

        private static RevenDbContext revenDbContext;
        public  static IDocumentStore  Store {get; set;}
        private  RevenDbContext()
        { 
            Store = new DocumentStore
            {
                Urls = new[]                        
                {                                   
                   URL_BASE
                },
                Database = DATABASE,
                Conventions = { }
            };

            Store.Initialize();
        }

        public static IDocumentStore  GetInstance(){
            revenDbContext ??= new RevenDbContext();
            return Store;
        }
    }
}