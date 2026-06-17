using HardwareScanner.Application.Interfaces;
using HardwareScanner.Domain.Models;
using HardwareScanner.Infrastructure;
using System.Linq;

namespace HardwareScanner.Application.Services;

public sealed class HardwareCollector: IHardwareCollector
{
    private readonly HardwareInfoProvider _provider;

    public HardwareCollector(HardwareInfoProvider provider)
    {
        _provider = provider;
    }

    public HardwareSnapshot Collect()
    {
        var hw = _provider.Get();

        return new HardwareSnapshot
        {
            Cpu =
                hw.CpuList
                    .Select(x =>
                        new CpuInfo(
                            x.Name,
                            x.NumberOfCores,
                            x.NumberOfLogicalProcessors,
                            x.MaxClockSpeed))
                    .FirstOrDefault(),

            Memories =
                hw.MemoryList
                    .Select(x =>
                        new MemoryInfo(
                            x.Manufacturer,
                            x.Capacity
                            / 1024
                            / 1024
                            / 1024,
                            x.Speed))
                    .ToList(),

            Gpus =
                hw.VideoControllerList
                    .Select(x =>
                        new GpuInfo(
                            x.Name,
                            x.AdapterRAM
                            / 1024
                            / 1024))
                    .ToList(),

            Disks =
                hw.DriveList
                    .Select(x =>
                        new DiskInfo(
                            x.Model,
                            x.Size
                            / 1024
                            / 1024
                            / 1024,
                            x.SerialNumber))
                    .ToList(),

            Motherboard =
                hw.MotherboardList
                    .Select(x =>
                        new MotherboardInfo(
                            x.Manufacturer,
                            x.Product))
                    .FirstOrDefault()
        };
    }
}