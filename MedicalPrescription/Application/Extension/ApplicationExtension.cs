using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extension;

public static class ApplicationExtension
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IPatientService, PatientService>();
    }
}