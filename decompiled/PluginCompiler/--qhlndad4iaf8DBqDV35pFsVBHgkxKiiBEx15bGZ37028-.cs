using System;
using Microsoft.VisualBasic.CompilerServices;
using NanoCore.ServerPlugin;
using NanoCore.ServerPluginHost;

[StandardModule]
internal sealed class _0023_003Dqhlndad4iaf8DBqDV35pFsVBHgkxKiiBEx15bGZ37028_003D
{
	public static Type[] _0023_003DqrKWeRnvE2krEFaSOwaqh3E_0024w9hiI1RlYAu3yvqapxG4_003D;

	public static Type[] _0023_003DqCkl8viGY0VhBIIw2ujclbBgx0qXlabmagR3HK_NCwa0_003D;

	static _0023_003Dqhlndad4iaf8DBqDV35pFsVBHgkxKiiBEx15bGZ37028_003D()
	{
		Type[] array = new Type[5];
		Type[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		array2[0] = typeof(IServerData);
		array2[1] = typeof(IServerNetwork);
		array2[2] = typeof(IServerBuild);
		array2[3] = typeof(IServerApp);
		array2[4] = typeof(IServerFileTransfer);
		Type[] array3 = array2;
		if (uint.MaxValue != 0)
		{
			_0023_003DqrKWeRnvE2krEFaSOwaqh3E_0024w9hiI1RlYAu3yvqapxG4_003D = array3;
		}
		Type[] array4 = new Type[7];
		if (uint.MaxValue != 0)
		{
			array2 = array4;
		}
		array2[0] = typeof(IServerDataHost);
		array2[1] = typeof(IServerNetworkHost);
		array2[2] = typeof(IServerUIHost);
		array2[3] = typeof(IServerLoggingHost);
		array2[4] = typeof(IServerDatabaseHost);
		array2[5] = typeof(IServerFileTransferHost);
		array2[6] = typeof(IServerBuildHost);
		_0023_003DqCkl8viGY0VhBIIw2ujclbBgx0qXlabmagR3HK_NCwa0_003D = array2;
	}
}
