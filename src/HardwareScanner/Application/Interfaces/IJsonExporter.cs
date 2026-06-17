namespace HardwareScanner.Application.Interfaces;

public interface IJsonExporter
{
    string Export<T>(T value);
}