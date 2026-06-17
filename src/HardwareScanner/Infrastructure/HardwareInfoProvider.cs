using Hardware.Info;

namespace HardwareScanner.Infrastructure;

public sealed class HardwareInfoProvider
{
    private readonly HardwareInfo _hardware;

    public HardwareInfoProvider(HardwareInfo hardware)
    {
        _hardware = hardware;
    }

    public HardwareInfo Get()
    {
        _hardware.RefreshAll();

        return _hardware;
    }
}