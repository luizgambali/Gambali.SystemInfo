namespace HardwareScanner.Domain.Models;

public sealed class HardwareSnapshot
{
    public CpuInfo? Cpu { get; init; }
    public List<MemoryInfo> Memories { get; init; } = [];
    public List<GpuInfo> Gpus { get; init; } = [];
    public List<DiskInfo> Disks { get; init; } = [];
    public MotherboardInfo? Motherboard { get; init; }
}