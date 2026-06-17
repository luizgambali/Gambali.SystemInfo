using Hardware.Info;
using HardwareScanner.Application.Interfaces;
using HardwareScanner.Application.Services;
using HardwareScanner.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareScanner.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHardwareScanner(this IServiceCollection services)
    {
        services.AddSingleton<HardwareInfo>();

        services.AddSingleton<HardwareInfoProvider>();

        services.AddSingleton<IHardwareCollector,HardwareCollector>();

        services.AddSingleton<IJsonExporter,JsonExporter>();

        return services;
    }
}