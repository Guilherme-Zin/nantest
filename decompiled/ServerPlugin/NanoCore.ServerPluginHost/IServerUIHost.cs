using System.Drawing;
using System.Windows.Forms;

namespace NanoCore.ServerPluginHost;

public interface IServerUIHost
{
	Icon ApplicationIcon { get; }

	/// <summary>
	///  Gets the current theme settings.
	///  </summary>
	/// <value>Theme settings.</value>
	/// <returns></returns>
	IServerReadOnlyNameObjectCollection ThemeSettings { get; }

	void Activate();

	/// <summary>
	///  Invokes the specified method on the UI thread.
	///  </summary>
	/// <param name="target">A <see cref="T:NanoCore.ServerInvokeDelegate" /> to be invoked.</param>
	/// <param name="state">A state object to be passed to the specified method.</param>
	void Invoke(ServerInvokeDelegate target, object state);

	void ApplyTheme(Control control);

	/// <summary>
	///  Shows a toast notification.
	///  </summary>
	/// <param name="client">The client that this notification belongs to or null for a server notification.</param>
	/// <param name="title">The title of the notification.</param>
	/// <param name="message">The message to be shown on the notification.</param>
	/// <param name="icon">The icon to be shown on the notification.</param>
	/// <param name="duration">The duration in milliseconds to show the notification.</param>
	/// <param name="state">A state object to be passed to the action callback.</param>
	/// <param name="actions">An array of actions the notification supports.</param>
	void ShowToastNotification(IClient client, string title, string message, string icon, int duration, object state, NotificationAction[] actions);

	void AddContextEntry(ContextEntry contextEntry);

	/// <summary>
	///  Adds a tab entry.
	///  </summary>
	/// <param name="tabEntry">The tab entry to be added.</param>
	void AddTabEntry(TabEntry tabEntry);

	void FocusTab(string categoryName, string name);

	/// <summary>
	///  Adds a widget entry.
	///  </summary>
	/// <param name="widgetEntry">The widget entry to be added.</param>
	void AddWidgetEntry(WidgetEntry widgetEntry);

	void FocusClient(IClient client);

	/// <summary>
	///  Adds a client column entry.
	///  </summary>
	/// <param name="columnEntry">The column entry to be added.</param>
	void AddClientColumnEntry(ColumnEntry columnEntry);

	void SetClientColumnValue(IClient client, string columnName, string imageName, string text);

	/// <summary>
	///  Adds a server setting entry.
	///  </summary>
	/// <param name="settingEntry">The setting entry to be added.</param>
	void AddServerSettingEntry(SettingEntry settingEntry);

	void AddBuilderSettingEntry(SettingEntry settingEntry);

	/// <summary>
	///  Adds a hint to the hint widget.
	///  </summary>
	/// <param name="hint">The hint to be added.</param>
	void AddHint(string hint);
}
