using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace My;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
internal sealed class MySettings : ApplicationSettingsBase
{
	private static MySettings defaultInstance;

	private static bool addedHandler;

	private static object addedHandlerLockObject;

	public static MySettings Default
	{
		get
		{
			if (!addedHandler)
			{
				object obj = addedHandlerLockObject;
				object obj2;
				if (7u != 0)
				{
					obj2 = obj;
				}
				ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
				Monitor.Enter(obj2);
				try
				{
					if (!addedHandler)
					{
						_0023_003Dq7JG_0024Oia5OWnwA2wTbLwgSQ_003D_003D._0023_003DqqDN6Qto5xqdizxtGfPf5uPiwPELBmVEC8tl_bz_0024QJnY_003D().Shutdown += [EditorBrowsable(EditorBrowsableState.Advanced)] [DebuggerNonUserCode] (object sender, EventArgs e) =>
						{
							if (_0023_003Dq7JG_0024Oia5OWnwA2wTbLwgSQ_003D_003D._0023_003DqqDN6Qto5xqdizxtGfPf5uPiwPELBmVEC8tl_bz_0024QJnY_003D().SaveMySettingsOnExit)
							{
								_0023_003DqX6QZ9VFdzdcAly8oOVUmBrv9ZJAGySp82somfPjborE_003D._0023_003DqcveCmq34KRcxMB6d2AeTcQ_003D_003D().Save();
							}
						};
						if (2u != 0)
						{
							addedHandler = true;
						}
					}
				}
				finally
				{
					Monitor.Exit(obj2);
				}
			}
			return defaultInstance;
		}
	}

	static MySettings()
	{
		MySettings obj = (MySettings)SettingsBase.Synchronized(new MySettings());
		if (0 == 0)
		{
			defaultInstance = obj;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(new object());
		if (8u != 0)
		{
			addedHandlerLockObject = objectValue;
		}
	}

	public MySettings()
	{
		_ = 2;
		if (6 == 0)
		{
		}
		base._002Ector();
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DebuggerNonUserCode]
	private static void AutoSaveSettings(object sender, EventArgs e)
	{
		if (_0023_003Dq7JG_0024Oia5OWnwA2wTbLwgSQ_003D_003D._0023_003DqqDN6Qto5xqdizxtGfPf5uPiwPELBmVEC8tl_bz_0024QJnY_003D().SaveMySettingsOnExit)
		{
			_0023_003DqX6QZ9VFdzdcAly8oOVUmBrv9ZJAGySp82somfPjborE_003D._0023_003DqcveCmq34KRcxMB6d2AeTcQ_003D_003D().Save();
		}
	}
}
