using System;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

[StandardModule]
internal sealed class _0023_003DqW5BkZP_00247vb5brlBnyDVNVl5O5_0024YE5A0F_0024mprGt4ci9M_003D
{
	public static _0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D _0023_003DqXv0DbmKLxUCzyRWXnW2_UA_003D_003D()
	{
		FileStream fileStream;
		if (6u != 0)
		{
			fileStream = null;
		}
		BinaryReader binaryReader;
		if (3u != 0)
		{
			binaryReader = null;
		}
		_0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D result;
		try
		{
			FileStream fileStream2 = new FileStream(_0023_003DqCAlptz5cgHMVhMqVe_spjlZbTNs8sOllXiD6KAjQyoc_003D._0023_003DqYOfO1gSKdvigXheezlRE_g_003D_003D(-473248821), FileMode.Open, FileAccess.Read);
			if (3u != 0)
			{
				fileStream = fileStream2;
			}
			binaryReader = new BinaryReader(fileStream);
			_0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D _0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D2 = new _0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D();
			_0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D2._0023_003DqB9CMU0gny6NIqZ41_00240z6ZQ_003D_003D = binaryReader.ReadString();
			_0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D2._0023_003DqmVnTYmeE3VaH0_y2FbkByA_003D_003D = binaryReader.ReadBytes(binaryReader.ReadInt32());
			binaryReader.Close();
			result = _0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			_0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D _0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D3 = new _0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D();
			_0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D3._0023_003DqB9CMU0gny6NIqZ41_00240z6ZQ_003D_003D = string.Empty;
			_0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D3._0023_003DqmVnTYmeE3VaH0_y2FbkByA_003D_003D = new byte[0];
			result = _0023_003DqV_0024_pNMY6gwHOi7Zqo_0024tIMw_003D_003D3;
			ProjectData.ClearProjectError();
		}
		finally
		{
			fileStream?.Close();
			binaryReader?.Close();
		}
		return result;
	}

	public static void _0023_003DqznepTnwiaBVLoCbcdH70vA_003D_003D(string _0023_003Dq3ghOpmedwGXRQlklQkxnkw_003D_003D, byte[] _0023_003DqYErgrDqp9Gt_dDxFVZq0hQ_003D_003D)
	{
		FileStream fileStream = new FileStream(_0023_003DqCAlptz5cgHMVhMqVe_spjlZbTNs8sOllXiD6KAjQyoc_003D._0023_003DqYOfO1gSKdvigXheezlRE_g_003D_003D(-473248821), FileMode.Create, FileAccess.Write);
		FileStream output;
		if (8u != 0)
		{
			output = fileStream;
		}
		BinaryWriter binaryWriter = new BinaryWriter(output);
		BinaryWriter binaryWriter2;
		if (8u != 0)
		{
			binaryWriter2 = binaryWriter;
		}
		binaryWriter2.Write(_0023_003Dq3ghOpmedwGXRQlklQkxnkw_003D_003D);
		binaryWriter2.Write(_0023_003DqYErgrDqp9Gt_dDxFVZq0hQ_003D_003D.Length);
		binaryWriter2.Write(_0023_003DqYErgrDqp9Gt_dDxFVZq0hQ_003D_003D);
		binaryWriter2.Close();
	}
}
