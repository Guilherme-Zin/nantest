# NanoCore Lab - Documentacao SQLite
# Gerado para analise educacional em ambiente isolado.

## Bancos disponiveis

| Arquivo | Uso provavel |
|---|---|
| `Databases/core.sqlite` | Configuracoes e estado interno do servidor |
| `Databases/main.sqlite` | Dados principais de clientes/sessoes |
| `Databases/network.sqlite` | Historico de rede, hosts, conexoes |
| `Databases/geolocation.sqlite` | Cache de geolocalizacao por IP |

## Como inspecionar

### Opcao 1 - Script dotnet (recomendado)

```powershell
cd lab-tools
.\inspect-sqlite.ps1
```

### Opcao 2 - DB Browser for SQLite

Abra cada `.sqlite` com DB Browser for SQLite (ferramenta grafica gratuita).

## Exportacao forense

```powershell
.\export-ioc.ps1
```

Gera `LabAnalysis/ioc-export.json` com:
- portas em escuta detectadas no log
- plugins carregados
- erros recentes
- amostra de eventos do servidor

## Packet Logger

Quando o plugin `PacketLogger.ncp` estiver ativo, os pacotes sao gravados em:

```
LabAnalysis/packets.log
```

Formato:
```
[timestamp] IN client=<guid> endpoint=<ip:port> pipe=<nome> params=[...]
```

## Tema Lab

Arquivo: `Resources/Themes/Lab.xml`

Para ativar: no NanoCore, va em Settings > Appearance > Theme > Lab (apos reiniciar o servidor).

## Plugins desabilitados

Estes plugins foram movidos para `Plugins/_disabled/` por formato obsoleto:
- AIO.ncp
- NanoBlack.ncp
- VisibleMode1.1.ncp
