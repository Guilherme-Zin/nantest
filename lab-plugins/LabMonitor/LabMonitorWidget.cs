using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabPlugins.LabMonitor
{
    public sealed class LabMonitorWidget : UserControl
    {
        private readonly Label _title;
        private readonly Label _uptime;
        private readonly Label _listeners;
        private readonly Label _clients;
        private readonly Label _plugins;
        private readonly DateTime _started;

        public LabMonitorWidget()
        {
            _started = DateTime.Now;
            BackColor = Color.FromArgb(24, 28, 36);
            Padding = new Padding(10);
            Width = 280;
            Height = 150;

            _title = CreateLabel("Lab Monitor", new Font("Segoe UI", 10f, FontStyle.Bold), 0);
            _uptime = CreateLabel("Uptime: 0s", new Font("Segoe UI", 9f), 28);
            _listeners = CreateLabel("Listeners: -", new Font("Segoe UI", 9f), 52);
            _clients = CreateLabel("Clients: 0", new Font("Segoe UI", 9f), 76);
            _plugins = CreateLabel("Plugins: -", new Font("Segoe UI", 9f), 100);

            var timer = new Timer { Interval = 1000 };
            timer.Tick += delegate
            {
                var elapsed = DateTime.Now - _started;
                _uptime.Text = "Uptime: " + Pad2(elapsed.Hours) + ":" + Pad2(elapsed.Minutes) + ":" + Pad2(elapsed.Seconds);
            };
            timer.Start();
        }

        public void UpdateStatus(int listenerCount, string listenerPorts, int clientCount, int pluginCount)
        {
            _listeners.Text = "Listeners: " + listenerCount + " (" + listenerPorts + ")";
            _clients.Text = "Clients: " + clientCount;
            _plugins.Text = "Plugins loaded: " + pluginCount;
        }

        private Label CreateLabel(string text, Font font, int top)
        {
            var label = new Label
            {
                AutoSize = true,
                ForeColor = Color.FromArgb(230, 235, 245),
                Font = font,
                Text = text,
                Location = new Point(10, top)
            };
            Controls.Add(label);
            return label;
        }
        private static string Pad2(int value)
        {
            return value < 10 ? "0" + value : value.ToString();
        }
    }
}
