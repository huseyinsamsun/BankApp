using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Extensions;

public static class HttpResponseExtensions
{
    public static void WriteJson<T>(this HttpResponse response, T obj)
    {
        response.ContentType = "application/json";
        JsonSerializer.Serialize(response.Body, obj);
    }
} 