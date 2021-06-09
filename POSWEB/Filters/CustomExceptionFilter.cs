using Application;
using Application.Exceptions;
using Application.Common.Interfaces;
using WebUI.DTO;
using WebUI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;
using System.Text;
namespace WebUI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly AppSetting appSetting;
        private readonly IHttpUserRequest httpUserRequest;

        public CustomExceptionFilter(IOptions<AppSetting> options, IHttpUserRequest httpUserRequest)
        {
            appSetting = options.Value;
            this.httpUserRequest = httpUserRequest;
        }

        public override void OnException(ExceptionContext context)
        {
            var code = HttpStatusCode.InternalServerError;

            string errorMessage = context.Exception.Message;
            object errorData = context.Exception;

            if (context.Exception is ValidationException)
            {
                code = HttpStatusCode.BadRequest;

                StringBuilder fluentErrorBuilder = new StringBuilder();
                foreach (var errKey in ((ValidationException)context.Exception).Failures)
                {
                    foreach (var err in errKey.Value)
                    {
                        fluentErrorBuilder.AppendLine(err);
                    }
                }
                errorMessage = fluentErrorBuilder.ToString();
                //errors = ((ValidationException)context.Exception).Failures;
                errorData = ((ValidationException)context.Exception).Failures;
            }
            else if (context.Exception is ModelStateException)
            {
                code = HttpStatusCode.BadRequest;

                //StringBuilder modelErrorBuilder = new StringBuilder();
                //foreach (var errKey in ((ModelStateException)context.Exception).ModelState.Values)
                //{
                //    foreach (var err in errKey.Errors)
                //    {
                //        modelErrorBuilder.AppendLine(err.ErrorMessage);
                //    }
                //}
                //errorMessage = modelErrorBuilder.ToString();
                errorMessage = "Permintaan tidak dapat diproses, mohon cek kembali data anda";
                errorData = ((ModelStateException)context.Exception).ModelState;
            }
            else if (context.Exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }
            else if (context.Exception is EmailOrPasswordNotMatchException)
            {
                code = HttpStatusCode.Unauthorized;
            }
            else
            {
                var exceptionNameSapce = nameof(Application.Exceptions);
                var exceptions = typeof(EmailOrPasswordNotMatchException).GetType().Assembly.GetTypes()
                    .Where(t => string.Equals(t.Namespace, exceptionNameSapce, StringComparison.Ordinal)).ToArray();

                if (exceptions.Any(t => context.Exception.GetType() == t))
                {
                    code = HttpStatusCode.BadRequest;
                }
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;

            if (appSetting.StackTrace)
            {
                context.Result = new JsonResult(new
                {
                    error = errorMessage,
                    //errorData = errorData,
                    stackTrace = context.Exception.StackTrace
                });
            }
            else
            {
                context.Result = new JsonResult(new
                {
                    error = errorMessage,
                    //errorData = errorData
                });
            }

            WriteLog(context, errorData);
        }

        private void WriteLog(ExceptionContext context, object errorData)
        {
            //Serilog.Log.Write(new LogEvent(
            //    dateTime.Now,
            //     LogEventLevel.Error,
            //     context.Exception,
            //     MessageTemplate.Empty,
            //     new List<LogEventProperty>
            //     {
            //         new LogEventProperty(CustomErrorLogger.CustomErrorProperty, new ScalarValue(true))
            //     }));

            ClientInfoDto client = new ClientInfoDto
            {
                Url = httpUserRequest.Url,
                Headers = httpUserRequest.Headers
                    .Where(x => x.Key != "Authorization")
                    .ToDictionary(x => x.Key, x => x.Value),
                IpAddress = httpUserRequest.IpAddress,
                UserId = httpUserRequest.UserId,
                IsAuthenticated = httpUserRequest.IsAuthenticated
            };

           // Serilog.Log.Error(new CustomErrorLogException(context.Exception), "Error: {Error}. Error Data: {@ErrorData} Client {@Client}", context.Exception.Message, errorData, client);
        }
    }
}