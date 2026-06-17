using HardwareScanner.Application.Interfaces;
using HardwareScanner.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args).ConfigureServices(services => { services.AddHardwareScanner();}).Build();

var collector = host.Services.GetRequiredService<IHardwareCollector>();

var exporter = host.Services.GetRequiredService<IJsonExporter>();

var snapshot = collector.Collect();

Console.WriteLine(exporter.Export(snapshot));

Console.ReadLine();