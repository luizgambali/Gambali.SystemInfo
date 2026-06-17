using System.Text.Json;
using HardwareScanner.Application.Interfaces;

namespace HardwareScanner.Application.Services;

public sealed class JsonExporter : IJsonExporter
{
    public string Export<T>(T value)
    {
        return JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true} );
    }
}