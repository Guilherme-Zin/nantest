using System;
using System.Net;

public sealed class _0023_003DqhXlfiAZ1OnKkAzykx4TS_Q_003D_003D : WebClient
{
	private HttpWebRequest _0023_003Dq1ICMrNL78PE_00247zBkBZXQSA_003D_003D;

	public CookieContainer _0023_003DqsBq1nKB_0024jxRZja3J_fSbYA_003D_003D;

	public _0023_003DqhXlfiAZ1OnKkAzykx4TS_Q_003D_003D()
	{
		CookieContainer cookieContainer = new CookieContainer();
		if (4u != 0)
		{
			_0023_003DqsBq1nKB_0024jxRZja3J_fSbYA_003D_003D = cookieContainer;
		}
	}

	protected override WebRequest GetWebRequest(Uri _0023_003DqOzmAMN044G6SXwZmOFVBYw_003D_003D)
	{
		HttpWebRequest obj = (HttpWebRequest)base.GetWebRequest(_0023_003DqOzmAMN044G6SXwZmOFVBYw_003D_003D);
		if (4u != 0)
		{
			_0023_003Dq1ICMrNL78PE_00247zBkBZXQSA_003D_003D = obj;
		}
		_0023_003Dq1ICMrNL78PE_00247zBkBZXQSA_003D_003D.Timeout = 15000;
		_0023_003Dq1ICMrNL78PE_00247zBkBZXQSA_003D_003D.ReadWriteTimeout = 15000;
		_0023_003Dq1ICMrNL78PE_00247zBkBZXQSA_003D_003D.KeepAlive = false;
		_0023_003Dq1ICMrNL78PE_00247zBkBZXQSA_003D_003D.AllowAutoRedirect = true;
		_0023_003Dq1ICMrNL78PE_00247zBkBZXQSA_003D_003D.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
		_0023_003Dq1ICMrNL78PE_00247zBkBZXQSA_003D_003D.CookieContainer = _0023_003DqsBq1nKB_0024jxRZja3J_fSbYA_003D_003D;
		_0023_003Dq1ICMrNL78PE_00247zBkBZXQSA_003D_003D.Proxy = null;
		return _0023_003Dq1ICMrNL78PE_00247zBkBZXQSA_003D_003D;
	}

	public void _000E_200A_200B_2008_2007_2009_2004_2009_2005_2006_2006()
	{
		CookieContainer cookieContainer = new CookieContainer();
		if (8u != 0)
		{
			_0023_003DqsBq1nKB_0024jxRZja3J_fSbYA_003D_003D = cookieContainer;
		}
	}
}
