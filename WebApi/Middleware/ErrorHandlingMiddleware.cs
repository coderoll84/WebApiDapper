using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Utilities.MongoDb;

namespace WebApi.Middleware
{
    [BsonCollection("Entries")]
    public class LogEntry : Document
    {
        public string Nivel { get; set; }
        public DateTime Fecha { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        public string Mensaje { get; set; }
    }


    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IMongoRepository<LogEntry> _mongoRepository;

        public ErrorHandlingMiddleware(RequestDelegate next, IMongoRepository<LogEntry> mongoRepository)
        {
            this.next = next;
            _mongoRepository = mongoRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var entry = new LogEntry { Nivel = "Error", Mensaje = ex.Message };
                await _mongoRepository.InsertOneAsync(entry);

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            /*
             if (exception is MyNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            else if (exception is MyException) code = HttpStatusCode.BadRequest;
            */
            var result = JsonConvert.SerializeObject(new { error = "Un error ocurrio" });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }


    }
}
