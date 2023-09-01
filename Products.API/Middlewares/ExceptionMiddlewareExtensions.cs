using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Products.Common.Dtos;
using Products.Common.Exceptions;

namespace Products.API.Middlewares
{
  public static class ExceptionMiddlewareExtensions
  {
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
      app.UseExceptionHandler(appError =>
      {
        appError.Run(async context =>
        {
          var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
          context.Response.StatusCode = GetErrorCode(contextFeature?.Error);
          context.Response.ContentType = "application/json";

          var errorDto = new ErrorResponseDto
          {
            StatusCode = context.Response.StatusCode
          };
          var json = JsonConvert.SerializeObject(errorDto,
            new JsonSerializerSettings
            {
              ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
              Formatting = Formatting.Indented
            });
          await context.Response.WriteAsync(json);
        });
      });
    }

    private static int GetErrorCode(Exception? exception)
    {
      return exception switch
      {
        // TODO: handle all the possible codes returned by the app
        RecordNotFoundException _ => (int)HttpStatusCode.NotFound,
        _ => (int)HttpStatusCode.InternalServerError
      };
    }
  }
}
