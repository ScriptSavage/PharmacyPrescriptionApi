using Infrastructure.Exceptions;

namespace Api.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
    {
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
           await context.Response.WriteAsync("There was a problem retrieving records!");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            await context.Response.WriteAsync("Something went wrong");
        }


    }
}