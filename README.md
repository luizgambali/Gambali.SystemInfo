# HardwareScanner

> **Este projeto foi gerado com auxílio de Inteligência Artificial (GitHub Copilot).** O código foi revisado e tem fins exclusivamente didáticos.

Projeto demonstrativo em **C# / .NET 9**

---

## Sobre o Projeto

O objetivo é ilustrar, de maneira didática, como coletar dados de hardware (CPU, memória RAM, GPU, discos e placa-mãe) utilizando C# e exportar essas informações estruturadas em JSON, utilizando boas práticas de arquitetura como injeção de dependência e separação de responsabilidades.

---

## Tecnologias Utilizadas

| Tecnologia | Versão |
|---|---|
| .NET | 9.0 |
| [Hardware.Info](https://github.com/Jinjinov/Hardware.Info) | 110.0.0.1 |
| Microsoft.Extensions.DependencyInjection | 10.0.9 |
| Microsoft.Extensions.Hosting | 10.0.9 |
| System.Text.Json | nativo do .NET |

---

## Arquitetura

O projeto segue uma estrutura em camadas inspirada na **Clean Architecture**:

```
HardwareScanner/
Domain/
   Models/             # Modelos de dados (CpuInfo, DiskInfo, etc.)
Application/
   Interfaces/         # Contratos (IHardwareCollector, IJsonExporter)
   Services/           # Implementações (HardwareCollector, JsonExporter)
Infrastructure/
   HardwareInfoProvider.cs  # Acesso à biblioteca Hardware.Info
Extensions/
   ServiceCollectionExtensions.cs  # Registro de dependências
Program.cs              # Ponto de entrada
```

---

## Dados Coletados

O snapshot de hardware é composto pelas seguintes informações:

### CPU
| Campo | Descrição |
|---|---|
| `Name` | Nome do processador |
| `Cores` | Número de núcleos físicos |
| `Threads` | Número de threads lógicos |
| `ClockMHz` | Frequência máxima (MHz) |

### Memória RAM (por módulo)
| Campo | Descrição |
|---|---|
| `Manufacturer` | Fabricante |
| `CapacityGb` | Capacidade em GB |
| `SpeedMHz` | Velocidade (MHz) |

### GPU (por placa)
| Campo | Descrição |
|---|---|
| `Name` | Nome da placa de vídeo |
| `MemoryMb` | Memória de vídeo em MB |

### Disco (por dispositivo)
| Campo | Descrição |
|---|---|
| `Model` | Modelo do disco |
| `SizeGb` | Capacidade em GB |
| `Serial` | Número de série |

### Placa-mãe
| Campo | Descrição |
|---|---|
| `Manufacturer` | Fabricante |
| `Product` | Modelo |

---

## Exemplo de Saída JSON

```json
{
  "Cpu": {
    "Name": "Intel(R) Core(TM) i7-10700 CPU @ 2.90GHz",
    "Cores": 8,
    "Threads": 16,
    "ClockMHz": 2904
  },
  "Memories": [
    {
      "Manufacturer": "Kingston",
      "CapacityGb": 16,
      "SpeedMHz": 2667
    },
    {
      "Manufacturer": "Kingston",
      "CapacityGb": 16,
      "SpeedMHz": 2667
    }
  ],
  "Gpus": [
    {
      "Name": "NVIDIA GeForce RTX 3060",
      "MemoryMb": 12288
    }
  ],
  "Disks": [
    {
      "Model": "Samsung SSD 870 EVO 500GB",
      "SizeGb": 465,
      "Serial": "S4EWNG0M123456"
    },
    {
      "Model": "WDC WD10EZEX-08WN4A0",
      "SizeGb": 931,
      "Serial": "WD-WCC6Y3HD1234"
    }
  ],
  "Motherboard": {
    "Manufacturer": "ASUSTeK COMPUTER INC.",
    "Product": "PRIME B460M-A"
  }
}
```

---

## Como Executar

### Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) instalado

### Passos

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/Gambali.SystemInfo.git

# Acesse o diretório do projeto
cd Gambali.SystemInfo/src/HardwareScanner

# Restaure as dependências
dotnet restore

# Execute o projeto
dotnet run
```

O JSON com as informações do hardware da sua máquina será exibido no console.

---

## Como Funciona

1. **`Program.cs`** configura o host com injeção de dependência via `AddHardwareScanner()`.
2. **`HardwareInfoProvider`** encapsula a biblioteca `Hardware.Info` e aciona `RefreshAll()` para ler os dados do sistema operacional.
3. **`HardwareCollector`** mapeia os dados brutos para os modelos do domínio (`CpuInfo`, `MemoryInfo`, `GpuInfo`, `DiskInfo`, `MotherboardInfo`), agrupados no `HardwareSnapshot`.
4. **`JsonExporter`** serializa o snapshot usando `System.Text.Json` com formatação indentada (`WriteIndented = true`).
5. O JSON final é impresso no console.

---

## Estrutura de Arquivos

```
Gambali.SystemInfo/
src/
   HardwareScanner/
       Application/
          Interfaces/
             IHardwareCollector.cs
             IJsonExporter.cs
          Services/
              HardwareCollector.cs
              JsonExporter.cs
       Domain/
          Models/
              CpuInfo.cs
              DiskInfo.cs
              GpuInfo.cs
              HardwareSnapshot.cs
              MemoryInfo.cs
              MotherboardInfo.cs
       Extensions/
          ServiceCollectionExtensions.cs
       Infrastructure/
          HardwareInfoProvider.cs
       HardwareScanner.csproj
       Program.cs
 README.md
```

---

## Licença

Este projeto está licenciado sob a **MIT License**.

```
MIT License

Copyright (c) 2025 Gambali

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
