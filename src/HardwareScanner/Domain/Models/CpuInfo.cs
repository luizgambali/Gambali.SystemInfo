namespace HardwareScanner.Domain.Models;

public sealed record CpuInfo(string Name, uint Cores, uint Threads, uint ClockMHz);