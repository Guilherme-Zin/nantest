using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

[StandardModule]
internal sealed class _0023_003DqoopHlcx6IwZS1oNjyC_0024sh93d8t2TIthy_0024xTB0Wu1zPc_003D
{
	public static string _0023_003Dqzp5rEI738fasYxNjuOYN06LNo_O6oIXn7w2pOaSoRn4_003D;

	static _0023_003DqoopHlcx6IwZS1oNjyC_0024sh93d8t2TIthy_0024xTB0Wu1zPc_003D()
	{
		string text = _0023_003DqCAlptz5cgHMVhMqVe_spjlZbTNs8sOllXiD6KAjQyoc_003D._0023_003DqYOfO1gSKdvigXheezlRE_g_003D_003D(-473247863);
		if (2u != 0)
		{
			_0023_003Dqzp5rEI738fasYxNjuOYN06LNo_O6oIXn7w2pOaSoRn4_003D = text;
		}
	}

	public static Type _0023_003DqSj9Ia56u8bSk48pf7PjJUw_003D_003D(byte[] _0023_003DqVUz5vw9dEjFrtDslYDcV_0024w_003D_003D, Type[] _0023_003DqBf0GtOW2tCe7fgYV4f_002426g_003D_003D, Type[] _0023_003DqdUCWXzB5c5eqEBJJ882pNw_003D_003D)
	{
		Assembly assembly = Assembly.Load(_0023_003DqVUz5vw9dEjFrtDslYDcV_0024w_003D_003D);
		Assembly assembly2;
		if (7u != 0)
		{
			assembly2 = assembly;
		}
		Type[] types = assembly2.GetTypes();
		Type[] array = default(Type[]);
		if (0 == 0)
		{
			array = types;
		}
		int i = default(int);
		if (0 == 0)
		{
			i = 0;
		}
		for (; i < array.Length; i = checked(i + 1))
		{
			Type type = array[i];
			Type[] interfaces = type.GetInterfaces();
			foreach (Type value in interfaces)
			{
				if (Array.IndexOf(_0023_003DqBf0GtOW2tCe7fgYV4f_002426g_003D_003D, value) != -1)
				{
					return type;
				}
			}
			ConstructorInfo[] constructors = type.GetConstructors();
			if (constructors.Length != 1)
			{
				continue;
			}
			ParameterInfo[] parameters = constructors[0].GetParameters();
			foreach (ParameterInfo parameterInfo in parameters)
			{
				if (Array.IndexOf(_0023_003DqdUCWXzB5c5eqEBJJ882pNw_003D_003D, parameterInfo.ParameterType) != -1)
				{
					return type;
				}
			}
		}
		return null;
	}

	public static byte[] _0023_003DqxjE3jk5zkgzmCLKm7Jkopw_003D_003D(string _0023_003DqCllGCK9MT1RkysN_y9ARiQ_003D_003D)
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		MD5CryptoServiceProvider mD5CryptoServiceProvider2;
		if (7u != 0)
		{
			mD5CryptoServiceProvider2 = mD5CryptoServiceProvider;
		}
		return mD5CryptoServiceProvider2.ComputeHash(Encoding.UTF8.GetBytes(_0023_003DqCllGCK9MT1RkysN_y9ARiQ_003D_003D));
	}

	public static byte[] _0023_003DqaiMoYtU0B33f7QtOK6YeQA_003D_003D(byte[] _0023_003DqrXs2l_0024bWJlHMZLHncLNYyw_003D_003D)
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		MD5CryptoServiceProvider mD5CryptoServiceProvider2;
		if (5u != 0)
		{
			mD5CryptoServiceProvider2 = mD5CryptoServiceProvider;
		}
		return mD5CryptoServiceProvider2.ComputeHash(_0023_003DqrXs2l_0024bWJlHMZLHncLNYyw_003D_003D);
	}

	public static string _0023_003DqxTuCLVe1T1D53kUWv_D81Q_003D_003D(Stream _0023_003Dq6S7UyqMWPJxQbUJgv8SVMQ_003D_003D)
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		MD5CryptoServiceProvider mD5CryptoServiceProvider2;
		if (5u != 0)
		{
			mD5CryptoServiceProvider2 = mD5CryptoServiceProvider;
		}
		return BitConverter.ToString(mD5CryptoServiceProvider2.ComputeHash(_0023_003Dq6S7UyqMWPJxQbUJgv8SVMQ_003D_003D)).Replace(_0023_003DqCAlptz5cgHMVhMqVe_spjlZbTNs8sOllXiD6KAjQyoc_003D._0023_003DqYOfO1gSKdvigXheezlRE_g_003D_003D(-473247999), string.Empty);
	}

	public static string _0023_003DqxHRK32CScDE4yegnI4wfgA_003D_003D(Stream _0023_003DqdX6R41P4rvGy5WfI3doSEw_003D_003D, int _0023_003DqDkx3tyXyxTLfXRyKXPmtEg_003D_003D, long _0023_003Dq8UFt2xa5PC1Na9nFUGmM4g_003D_003D)
	{
		checked
		{
			byte[] array = new byte[_0023_003DqDkx3tyXyxTLfXRyKXPmtEg_003D_003D - 1 + 1];
			byte[] array2;
			if (7u != 0)
			{
				array2 = array;
			}
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			MD5CryptoServiceProvider mD5CryptoServiceProvider2;
			if (8u != 0)
			{
				mD5CryptoServiceProvider2 = mD5CryptoServiceProvider;
			}
			_0023_003DqdX6R41P4rvGy5WfI3doSEw_003D_003D.Position = 0L;
			long num = default(long);
			int num3;
			do
			{
				int num2 = (int)Math.Min(array2.Length, _0023_003Dq8UFt2xa5PC1Na9nFUGmM4g_003D_003D - num);
				int count;
				if (6u != 0)
				{
					count = num2;
				}
				num3 = _0023_003DqdX6R41P4rvGy5WfI3doSEw_003D_003D.Read(array2, 0, count);
				mD5CryptoServiceProvider2.TransformBlock(array2, 0, num3, null, 0);
				num += num3;
			}
			while (num3 != 0);
			mD5CryptoServiceProvider2.TransformFinalBlock(new byte[0], 0, 0);
			return BitConverter.ToString(mD5CryptoServiceProvider2.Hash);
		}
	}
}
