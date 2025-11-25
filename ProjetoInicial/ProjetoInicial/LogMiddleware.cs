using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ProjetoInicial
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            Console.WriteLine("Iniciando a aplicação");
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var username = httpContext.Request.Query.FirstOrDefault().Value;
               
            //valida se o nome do usuario é Admin.
            if (username.Count() > 0)
            {
                if (username.Equals("admin"))
                {
                    await _next(httpContext);
                    return;
                }
            
            }

            httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            await httpContext.Response.WriteAsync("Usuário não autorizado.");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
