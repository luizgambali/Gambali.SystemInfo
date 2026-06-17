using HardwareScanner.Domain.Models;

namespace HardwareScanner.Application.Interfaces;

public interface IHardwareCollector
{
    HardwareSnapshot Collect();
}