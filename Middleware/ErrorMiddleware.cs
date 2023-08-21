using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopRevendb.DTO;

namespace ShopRevendb.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExepection(context, ex);
            }
        }

        private Task HandleExepection(HttpContext context, Exception ex)
        {
            var erro = new ErrorResponse("Servidor não respondendo..");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(erro);
            context.Response.ContentType = "application/json"; 
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}