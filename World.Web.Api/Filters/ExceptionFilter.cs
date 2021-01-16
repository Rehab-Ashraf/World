using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using World.Api.Models;

namespace World.Web.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            ColorizeException("Exception:");

            Console.Write($" {context.Exception}");
            Console.WriteLine();

            var result = new ObjectResult(ResponseResult.Failed())
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            context.Result = result;
        }

        private void ColorizeException(string titile)
        {
            var defaultBackColor = Console.BackgroundColor;
            var defaultForeColor = Console.ForegroundColor;

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(titile);
            Console.BackgroundColor = defaultBackColor;
            Console.ForegroundColor = defaultForeColor;
        }
    }
}
