using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace withOpentelem.Api.Filters
{
    public class HttpResponseExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpResponseExceptionFilter> _logger;

        public HttpResponseExceptionFilter(ILogger<HttpResponseExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException exception)
            {
                IEnumerable<ValidationFailure> attemptedValue = exception.Errors.Where(o => (o.PropertyName == "Files" || o.PropertyName == ""));

                if (attemptedValue.Count() > 0 )
                {
                    context.Result = new ObjectResult(exception.Errors.Select(o => new { o.ErrorMessage, o.PropertyName }))
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                    };
                }
                else
                {
                    context.Result = new ObjectResult(exception.Errors.Select(o => new { o.AttemptedValue, o.ErrorMessage, o.PropertyName }))
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                    };
                }
                context.ExceptionHandled = true;
            } else
            {
                var other_exception = context.Exception;
                context.Result = new ObjectResult(other_exception.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
                context.ExceptionHandled = true;
            }
            _logger.LogError($"Error: " +
                            $"Message:{context.Exception.Message} " +
                            $"StackTrace: {context.Exception.StackTrace} ");
        }
    }
}
