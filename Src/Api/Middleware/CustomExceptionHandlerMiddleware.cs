using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Company.Project.Application.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Company.Project.Api.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private RequestDelegate Next { get; }

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Failures);
                    break;
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = GetCustomErrorMessage(exception) });
            }

            return context.Response.WriteAsync(result);
        }


        private string GetCustomErrorMessage(Exception exception)
        {
            StringBuilder builder = new StringBuilder();

            if (exception.InnerException != null)
            {
                builder.Append(GetCustomErrorMessage(exception.InnerException));
            }
            builder.Append($"{exception.Message} --> ");

            return builder.ToString();
        }

    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
