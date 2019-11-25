using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OBS.API.Exception;

namespace OBS.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, IHostingEnvironment env)
        {
            _next = next;
            _env = env;
        }
        
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {

                await HandleExceptionAsync(httpContext, ex, _env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, System.Exception exception, IHostingEnvironment _env)
        {
            var code = HttpStatusCode.InternalServerError;

            // 500 if unexpected

            var error = new ApiError();
            error.StatusCode = (int)code;
            if (_env.IsDevelopment())
            {
                error.Message = exception.StackTrace;
                error.Details = exception.Message;
            }
            else
            {
                error.Message = "A server error occurred!";
                error.Details = exception.Message;
            }


            if (exception is ApiException)
            {
                error.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                code = HttpStatusCode.UnprocessableEntity;
            }
            else if (exception is UnauthorizedAccessException)
            {
                error.StatusCode = 401;
                error.Message = "Unauthorized Access!";
                error.Details = exception.Message;
                code = HttpStatusCode.Unauthorized;
            }

            var result = JsonConvert.SerializeObject(error);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}