namespace HardwareScanner.Domain.Models;

public sealed record MemoryInfo(string Manufacturer, ulong CapacityGb, uint SpeedMHz);