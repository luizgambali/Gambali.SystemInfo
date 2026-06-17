namespace HardwareScanner.Domain.Models;

public sealed record DiskInfo(string Model, ulong SizeGb, string Serial);