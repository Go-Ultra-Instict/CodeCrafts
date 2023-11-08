
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CodeCrafts.Domain.Exceptions;

namespace CodeCrafts.WebAPI.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly Dictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>()
            {
                {typeof( NotImplementedException),  HandleNotImplimentedException},
                {typeof( NotFoundCustomException),    HandleNotFoundCustomException}
            };
        }

        public override void OnException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }
        }


        private static void HandleNotImplimentedException(ExceptionContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                var details = new
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Bad Request",
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                    Detail = context.Exception.Message
                };
                context.Result = new Microsoft.AspNetCore.Mvc.ObjectResult(details)
                {
                    StatusCode = (int)HttpStatusCode.NotFound,

                };
                context.ExceptionHandled = true;
            }
        }

        private static void HandleNotFoundCustomException(ExceptionContext context)
        {
            if (context.Exception is NotFoundCustomException)
            {
                var details = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Not Found",
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                    Detail = context.Exception.Message
                };
                context.Result = new Microsoft.AspNetCore.Mvc.ObjectResult(details)
                {
                    StatusCode = (int)HttpStatusCode.NotFound,

                };
                context.ExceptionHandled = true;
            }
        }

       
    }
}
