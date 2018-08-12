using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Logging;
using Solution.CrossCutting.Utils;

namespace Solution.CrossCutting.AspNetCore.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly IHostingEnvironment _environment;
        private readonly ILogger _logger;
        private readonly RequestDelegate _request;

        public ExceptionMiddleware(IHostingEnvironment environment, RequestDelegate request)
        {
            _environment = environment;
            _logger = DependencyInjector.GetService<ILogger>();
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context).ConfigureAwait(false);
            }
            catch (DomainException exception)
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(exception.Message).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (_environment.IsDevelopment())
                {
                    throw;
                }

                _logger.Error(exception);
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Text.Plain;
                await context.Response.WriteAsync(string.Empty).ConfigureAwait(false);
            }
        }
    }
}
