using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse? _response;
    public HttpResponse Response 
    {
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }

    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        var details = new BusinessProblemDetails(businessException.Message);
        return WriteJsonResponse(details);
    }

    protected override Task HandleException(ValidationException validationException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        var details = new ValidationProblemDetails(validationException.Errors);
        return WriteJsonResponse(details);
    }

    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        var details = new InternalServerErrorProblemDetails(exception.Message);
        return WriteJsonResponse(details);
    }

    private Task WriteJsonResponse<T>(T details)
    {
        Response.ContentType = "application/json";
        return JsonSerializer.SerializeAsync(Response.Body, details);
    }
} 