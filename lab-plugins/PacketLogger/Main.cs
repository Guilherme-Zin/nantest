using System;
using System.IO;
using System.Text;
using NanoCore;
using NanoCore.ServerPlugin;
using NanoCore.ServerPluginHost;

namespace LabPlugins.PacketLogger
{
    public sealed class Main : IServerNetwork
    {
        private readonly IServerLoggingHost _log;
        private readonly string _logFile;
        private readonly object _sync = new object();

        public Main(
            IServerDataHost dataHost,
            IServerNetworkHost networkHost,
            IServerUIHost uiHost,
            IServerLoggingHost loggingHost,
            IServerDatabaseHost databaseHost,
            IServerFileTransferHost fileTransferHost,
            IServerBuildHost buildHost)
        {
            _log = loggingHost;

            var labDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LabAnalysis");
            Directory.CreateDirectory(labDir);
            _logFile = Path.Combine(labDir, "packets.log");

            WriteHeader();
            _log.LogServerMessage(LogColor.Information, "Packet Logger writing to " + _logFile);
        }

        public void ClientReadPacket(IClient client, string pipeName, object[] @params)
        {
            var clientId = client != null ? client.Id.ToString() : "null";
            var endpoint = client != null && client.EndPoint != null ? client.EndPoint.ToString() : "unknown";
            var summary = SummarizeParams(@params);

            AppendLine(string.Format(
                "[{0:yyyy-MM-dd HH:mm:ss.fff}] IN  client={1} endpoint={2} pipe={3} params={4}",
                DateTime.Now,
                clientId,
                endpoint,
                pipeName ?? "(null)",
                summary));
        }

        public void ClientStateChanged(IClient client, bool connected)
        {
            var clientId = client != null ? client.Id.ToString() : "null";
            var endpoint = client != null && client.EndPoint != null ? client.EndPoint.ToString() : "unknown";
            AppendLine(string.Format(
                "[{0:yyyy-MM-dd HH:mm:ss.fff}] STATE client={1} endpoint={2} connected={3}",
                DateTime.Now,
                clientId,
                endpoint,
                connected));
        }

        public void ClientPipeCreated(IClient client, string pipeName)
        {
            AppendLine(string.Format("[{0:yyyy-MM-dd HH:mm:ss.fff}] PIPE+ {1}", DateTime.Now, pipeName));
        }

        public void ClientPipeClosed(IClient client, string pipeName)
        {
            AppendLine(string.Format("[{0:yyyy-MM-dd HH:mm:ss.fff}] PIPE- {1}", DateTime.Now, pipeName));
        }

        public void ListenerStateChanged(IListener listener) { }
        public void ListenerFailed(IListener listener) { }
        public void ListenerAdded(IListener listener) { }
        public void ListenerRemoved(IListener listener) { }

        private void WriteHeader()
        {
            AppendLine("# NanoCore Packet Logger - educational lab use only");
            AppendLine("# Started: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendLine("# Format: timestamp direction client endpoint pipe params");
            AppendLine(string.Empty);
        }

        private void AppendLine(string line)
        {
            lock (_sync)
            {
                File.AppendAllText(_logFile, line + Environment.NewLine, Encoding.UTF8);
            }
        }

        private static string SummarizeParams(object[] values)
        {
            if (values == null || values.Length == 0)
            {
                return "[]";
            }

            var parts = new string[values.Length];
            for (var i = 0; i < values.Length; i++)
            {
                var value = values[i];
                if (value == null)
                {
                    parts[i] = "null";
                    continue;
                }

                if (value is byte[])
                {
                    parts[i] = "byte[" + ((byte[])value).Length + "]";
                }
                else
                {
                    var text = value.ToString();
                    if (text.Length > 80)
                    {
                        text = text.Substring(0, 80) + "...";
                    }
                    parts[i] = text;
                }
            }

            return "[" + string.Join(", ", parts) + "]";
        }
    }
}
