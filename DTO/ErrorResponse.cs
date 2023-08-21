using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRevendb.DTO
{
    public class ErrorResponse
    {
        public ErrorResponse(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; set; }
    }
}