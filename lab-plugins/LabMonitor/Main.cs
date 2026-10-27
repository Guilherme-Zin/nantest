using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NanoCore;
using NanoCore.ServerPlugin;
using NanoCore.ServerPluginHost;

namespace LabPlugins.LabMonitor
{
    public sealed class Main : IServerNetwork, IServerUI
    {
        private readonly IServerNetworkHost _network;
        private readonly IServerUIHost _ui;
        private readonly IServerLoggingHost _log;
        private readonly LabMonitorWidget _widget;
        private readonly Timer _refreshTimer;

        public Main(
            IServerDataHost dataHost,
            IServerNetworkHost networkHost,
            IServerUIHost uiHost,
            IServerLoggingHost loggingHost,
            IServerDatabaseHost databaseHost,
            IServerFileTransferHost fileTransferHost,
            IServerBuildHost buildHost)
        {
            _network = networkHost;
            _ui = uiHost;
            _log = loggingHost;
            _widget = new LabMonitorWidget();

            _ui.AddWidgetEntry(new WidgetEntry
            {
                Name = "Lab Monitor",
                Locked = true,
                UserControl = _widget
            });

            _refreshTimer = new Timer { Interval = 2000 };
            _refreshTimer.Tick += delegate { RefreshStatus(); };
            _refreshTimer.Start();
            RefreshStatus();

            _log.LogServerMessage(LogColor.Information, "Lab Monitor plugin initialized.");
        }

        private void RefreshStatus()
        {
            var listeners = _network.Listeners ?? new IListener[0];
            var portList = new string[listeners.Length];
            for (var i = 0; i < listeners.Length; i++)
            {
                portList[i] = listeners[i].PortNumber.ToString();
            }
            var ports = string.Join(", ", portList);
            var clients = _network.GetClients() ?? new IClient[0];
            var pluginCount = CountLoadedPlugins();

            _widget.UpdateStatus(listeners.Length, string.IsNullOrEmpty(ports) ? "-" : ports, clients.Length, pluginCount);
        }

        private static int CountLoadedPlugins()
        {
            try
            {
                var pluginsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
                if (!Directory.Exists(pluginsDir))
                {
                    return 0;
                }

                return Directory.GetFiles(pluginsDir, "*.ncp", SearchOption.TopDirectoryOnly).Length;
            }
            catch
            {
                return -1;
            }
        }

        public void ClientStateChanged(IClient client, bool connected)
        {
            RefreshStatus();
            var endpoint = client != null && client.EndPoint != null ? client.EndPoint.ToString() : "unknown";
            _log.LogServerMessage(
                LogColor.Information,
                connected ? "Lab Monitor: client connected " + endpoint : "Lab Monitor: client disconnected " + endpoint);
        }

        public void ClientReadPacket(IClient client, string pipeName, object[] @params) { }
        public void ClientPipeCreated(IClient client, string pipeName) { }
        public void ClientPipeClosed(IClient client, string pipeName) { }
        public void ListenerStateChanged(IListener listener) { RefreshStatus(); }
        public void ListenerFailed(IListener listener) { RefreshStatus(); }
        public void ListenerAdded(IListener listener) { RefreshStatus(); }
        public void ListenerRemoved(IListener listener) { RefreshStatus(); }
        public void ThemeChanged() { }
    }
}
