internal static class _0023_003Dq0qLZUfLBNpjH9djhFA2d0OHKQutvV2QFuqNsMLaC6f0ObHBTebdQWu7_fUIWIJi2
{
	public static byte[] _0023_003Dq_5rHIvqFLCkr7Gvc8994bg_003D_003D(byte[] _0023_003DqSyTgOkMdXb9oYWK1z09ShNbhEFIvZSNv79LWOlnu1xA_003D, byte[] _0023_003DqmkainDDMr8I3FiIVFIO_Z8MDdvHE22uNZfP36RAVpQo_003D)
	{
		byte num = _0023_003DqSyTgOkMdXb9oYWK1z09ShNbhEFIvZSNv79LWOlnu1xA_003D[1];
		byte b;
		if (3u != 0)
		{
			b = num;
		}
		int num2 = _0023_003DqmkainDDMr8I3FiIVFIO_Z8MDdvHE22uNZfP36RAVpQo_003D.Length;
		int num3;
		if (uint.MaxValue != 0)
		{
			num3 = num2;
		}
		byte num4 = (byte)((num3 + 11) ^ (b + 7));
		byte b2;
		if (uint.MaxValue != 0)
		{
			b2 = num4;
		}
		uint num5 = (uint)((_0023_003DqSyTgOkMdXb9oYWK1z09ShNbhEFIvZSNv79LWOlnu1xA_003D[0] | (_0023_003DqSyTgOkMdXb9oYWK1z09ShNbhEFIvZSNv79LWOlnu1xA_003D[2] << 8)) + (b2 << 3));
		ushort num6 = 0;
		for (int i = 0; i < num3; i++)
		{
			if ((i & 1) == 0)
			{
				num5 = num5 * 214013 + 2531011;
				num6 = (ushort)(num5 >> 16);
			}
			byte b3 = (byte)num6;
			num6 >>= 8;
			byte b4 = _0023_003DqmkainDDMr8I3FiIVFIO_Z8MDdvHE22uNZfP36RAVpQo_003D[i];
			_0023_003DqmkainDDMr8I3FiIVFIO_Z8MDdvHE22uNZfP36RAVpQo_003D[i] = (byte)(b4 ^ b ^ (b2 + 3) ^ b3);
			b2 = b4;
		}
		return _0023_003DqmkainDDMr8I3FiIVFIO_Z8MDdvHE22uNZfP36RAVpQo_003D;
	}
}
