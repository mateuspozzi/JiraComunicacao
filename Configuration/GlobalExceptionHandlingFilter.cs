using Elmah.Io.Client.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JiraComunicacao.Configuration
{
    public class GlobalExceptionHandlingFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionHandlingFilter> _logger;
        private readonly IWebHostEnvironment _hostingEnviroment;

        public GlobalExceptionHandlingFilter(ILogger<GlobalExceptionHandlingFilter> logger,
                                             IWebHostEnvironment hostingEnviroment)
        {
            _logger = logger;
            _hostingEnviroment = hostingEnviroment;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(1, context.Exception, context.Exception.Message);

            context.ExceptionHandled = true;
        }

        private static List<Item> Form(HttpContext httpContext)
        {
            try
            {
                return httpContext.Request?.Form?.Keys.Select(k => new Item(k, httpContext.Request.Form[k])).ToList();
            }
            catch (InvalidOperationException)
            {
            }

            return null;
        }
    }
}
