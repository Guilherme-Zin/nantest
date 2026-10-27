using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal static class _0023_003DqCAlptz5cgHMVhMqVe_spjlZbTNs8sOllXiD6KAjQyoc_003D
{
	private enum _0023_003Dq_0024_0024mN6PzEcCRUDgYhKgmNeIw6eWBJPwpvnCRX_I31RkM_003D
	{

	}

	private sealed class _0023_003Dq0wz7Bwsxixyure6wq9VYgmUGfBSgkERnl2ztz7TBQ_U_003D
	{
		private Stream _0023_003DqeNK0ziFSODzJqk3PmwURZvt7Ny1C1vfXuqgtfAs47cQ_003D;

		private byte[] _0023_003DqIi1WSj8815rqHPj_0024YIz4tVn5QUDsClsJtAL7V4J0_KE_003D;

		public _0023_003Dq0wz7Bwsxixyure6wq9VYgmUGfBSgkERnl2ztz7TBQ_U_003D(Stream _0023_003DqeB6ZbpELKiBVnEsGWayEN419vbneXllQt1A4VNVNyEo_003D)
		{
			if (6u != 0)
			{
				_0023_003DqeNK0ziFSODzJqk3PmwURZvt7Ny1C1vfXuqgtfAs47cQ_003D = _0023_003DqeB6ZbpELKiBVnEsGWayEN419vbneXllQt1A4VNVNyEo_003D;
			}
			byte[] array = new byte[4];
			if (2u != 0)
			{
				_0023_003DqIi1WSj8815rqHPj_0024YIz4tVn5QUDsClsJtAL7V4J0_KE_003D = array;
			}
		}

		public Stream _0023_003Dq_0024hguXTq4bWL805LtYLv9RtJVkqd4d_kYeQGw87XfoVM_003D()
		{
			_ = 7;
			if (2 == 0)
			{
			}
			return _0023_003DqeNK0ziFSODzJqk3PmwURZvt7Ny1C1vfXuqgtfAs47cQ_003D;
		}

		public short _0023_003Dq5WMyBp6wewmr70Slxb5X2EFr3IgVFHOJseabeRVgvrk_003D()
		{
			_ = 4;
			if (4 == 0)
			{
			}
			_0023_003Dq3bbKu1I0ICe6gTKBwKEQ7plOaY28gLU8cMJKld7CJJ0_003D(2);
			_ = 4;
			if (3 == 0)
			{
			}
			byte num = _0023_003DqIi1WSj8815rqHPj_0024YIz4tVn5QUDsClsJtAL7V4J0_KE_003D[0];
			_ = 7;
			if (7 == 0)
			{
			}
			return (short)(num | (_0023_003DqIi1WSj8815rqHPj_0024YIz4tVn5QUDsClsJtAL7V4J0_KE_003D[1] << 8));
		}

		public int _0023_003DqCXIveonOLU_la_pInA_N2z2MIjOPMro1UDRtroCPCJY_003D()
		{
			_ = 8;
			if (7 == 0)
			{
			}
			_0023_003Dq3bbKu1I0ICe6gTKBwKEQ7plOaY28gLU8cMJKld7CJJ0_003D(4);
			_ = 2;
			if (7 == 0)
			{
			}
			byte num = _0023_003DqIi1WSj8815rqHPj_0024YIz4tVn5QUDsClsJtAL7V4J0_KE_003D[0];
			_ = 8;
			if (4 == 0)
			{
			}
			return num | (_0023_003DqIi1WSj8815rqHPj_0024YIz4tVn5QUDsClsJtAL7V4J0_KE_003D[1] << 8) | (_0023_003DqIi1WSj8815rqHPj_0024YIz4tVn5QUDsClsJtAL7V4J0_KE_003D[2] << 16) | (_0023_003DqIi1WSj8815rqHPj_0024YIz4tVn5QUDsClsJtAL7V4J0_KE_003D[3] << 24);
		}

		private void _0023_003Dq05LqJfT0QU_Ijb8zSz33ZTeJQ84kLGYxRVfyixyfxcg_003D()
		{
			throw new EndOfStreamException();
		}

		private void _0023_003Dq3bbKu1I0ICe6gTKBwKEQ7plOaY28gLU8cMJKld7CJJ0_003D(int _0023_003DqbwjDkg7O8DuwZm7ViSj40U4A8ZJZdont5F9uUts7GHE_003D)
		{
			int num;
			if (6u != 0)
			{
				num = 0;
			}
			if (6u != 0)
			{
				int num2 = 0;
			}
			if (_0023_003DqbwjDkg7O8DuwZm7ViSj40U4A8ZJZdont5F9uUts7GHE_003D == 1)
			{
				int num3 = _0023_003DqeNK0ziFSODzJqk3PmwURZvt7Ny1C1vfXuqgtfAs47cQ_003D.ReadByte();
				int num2;
				if (true)
				{
					num2 = num3;
				}
				if (num2 == -1)
				{
					_0023_003Dq05LqJfT0QU_Ijb8zSz33ZTeJQ84kLGYxRVfyixyfxcg_003D();
				}
				_0023_003DqIi1WSj8815rqHPj_0024YIz4tVn5QUDsClsJtAL7V4J0_KE_003D[0] = (byte)num2;
				return;
			}
			do
			{
				int num2 = _0023_003DqeNK0ziFSODzJqk3PmwURZvt7Ny1C1vfXuqgtfAs47cQ_003D.Read(_0023_003DqIi1WSj8815rqHPj_0024YIz4tVn5QUDsClsJtAL7V4J0_KE_003D, num, _0023_003DqbwjDkg7O8DuwZm7ViSj40U4A8ZJZdont5F9uUts7GHE_003D - num);
				if (num2 == 0)
				{
					_0023_003Dq05LqJfT0QU_Ijb8zSz33ZTeJQ84kLGYxRVfyixyfxcg_003D();
				}
				num += num2;
			}
			while (num < _0023_003DqbwjDkg7O8DuwZm7ViSj40U4A8ZJZdont5F9uUts7GHE_003D);
		}

		public void _0023_003Dq2gULwh8UNvpvktOVKLhxZJ7yeDbkgdBTa7I15PaQWEg_003D()
		{
			Stream stream = _0023_003DqeNK0ziFSODzJqk3PmwURZvt7Ny1C1vfXuqgtfAs47cQ_003D;
			Stream stream2;
			if (5u != 0)
			{
				stream2 = stream;
			}
			if (true)
			{
				_0023_003DqeNK0ziFSODzJqk3PmwURZvt7Ny1C1vfXuqgtfAs47cQ_003D = null;
			}
			stream2?.Close();
			if (2u != 0)
			{
				_0023_003DqIi1WSj8815rqHPj_0024YIz4tVn5QUDsClsJtAL7V4J0_KE_003D = null;
			}
		}

		public byte[] _0023_003Dq_Qlhvm5cgV7RhSykghF7zCuI91aHD0b3KIMQe2lqzQQ_003D(int _0023_003Dq1cBCSwasFT3h9a6Ak64HxdZWSQmlts4Fs6BTiQyEExk_003D)
		{
			if (_0023_003Dq1cBCSwasFT3h9a6Ak64HxdZWSQmlts4Fs6BTiQyEExk_003D < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			byte[] array = new byte[_0023_003Dq1cBCSwasFT3h9a6Ak64HxdZWSQmlts4Fs6BTiQyEExk_003D];
			byte[] array2;
			if (3u != 0)
			{
				array2 = array;
			}
			int num;
			if (uint.MaxValue != 0)
			{
				num = 0;
			}
			do
			{
				int num2 = _0023_003DqeNK0ziFSODzJqk3PmwURZvt7Ny1C1vfXuqgtfAs47cQ_003D.Read(array2, num, _0023_003Dq1cBCSwasFT3h9a6Ak64HxdZWSQmlts4Fs6BTiQyEExk_003D);
				int num3;
				if (2u != 0)
				{
					num3 = num2;
				}
				if (num3 == 0)
				{
					break;
				}
				num += num3;
				_0023_003Dq1cBCSwasFT3h9a6Ak64HxdZWSQmlts4Fs6BTiQyEExk_003D -= num3;
			}
			while (_0023_003Dq1cBCSwasFT3h9a6Ak64HxdZWSQmlts4Fs6BTiQyEExk_003D > 0);
			if (num != array2.Length)
			{
				byte[] array3 = new byte[num];
				Buffer.BlockCopy(array2, 0, array3, 0, num);
				array2 = array3;
			}
			return array2;
		}
	}

	[DefaultMember("Item")]
	internal sealed class _0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D
	{
		private struct _0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D
		{
			public int _0023_003Dq0zSTsnoBC3xyL4S_nj3M8Djd1_0024wAqtam_0024SS3rP1PzkQ_003D;

			public string _0023_003Dqdjmy6YXHG28Ld7JgKaiixI3Qq18UZmaYGF51h7ob1EQ_003D;
		}

		private _0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[] _0023_003DqfHqXJbgzeEKzEjyF2y94PvURYe0H_aGsdJvoKaaQ7xE_003D;

		private int _0023_003DqD_0024IHDkSGyRlSnTpPla4F9XABhKjoHM6t_0024chhO69rEw4_003D;

		public _0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D()
		{
			_0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[] array = new _0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[16];
			if (0 == 0)
			{
				_0023_003DqfHqXJbgzeEKzEjyF2y94PvURYe0H_aGsdJvoKaaQ7xE_003D = array;
			}
		}

		public _0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D(int _0023_003DqMPtAeFmgXTd4xlMOHAKpIU32MkMF5Ebzrfqk2WLP3dU_003D)
		{
			int num;
			if (3u != 0)
			{
				num = 16;
			}
			int num2 = _0023_003DqMPtAeFmgXTd4xlMOHAKpIU32MkMF5Ebzrfqk2WLP3dU_003D << 1;
			if (3u != 0)
			{
				_0023_003DqMPtAeFmgXTd4xlMOHAKpIU32MkMF5Ebzrfqk2WLP3dU_003D = num2;
			}
			while (num < _0023_003DqMPtAeFmgXTd4xlMOHAKpIU32MkMF5Ebzrfqk2WLP3dU_003D && num > 0)
			{
				int num3 = num << 1;
				if (4u != 0)
				{
					num = num3;
				}
			}
			if (num < 0)
			{
				num = 16;
			}
			_0023_003DqfHqXJbgzeEKzEjyF2y94PvURYe0H_aGsdJvoKaaQ7xE_003D = new _0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[num];
		}

		public int _0023_003Dqvd0D7V_cIW9AIIRP0Uz64Ny3wQdfZmkp1Jda2aOLQjk_003D()
		{
			_ = 4;
			if (6 == 0)
			{
			}
			return _0023_003DqD_0024IHDkSGyRlSnTpPla4F9XABhKjoHM6t_0024chhO69rEw4_003D;
		}

		private void _0023_003Dq_1DwSEcm_Y_0024Oj0IVpOivH4MD5cKhljjTraNJgq7qYM4_003D()
		{
			_0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[] array = _0023_003DqfHqXJbgzeEKzEjyF2y94PvURYe0H_aGsdJvoKaaQ7xE_003D;
			_0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[] array2;
			if (4u != 0)
			{
				array2 = array;
			}
			int num = array2.Length;
			int num2;
			if (6u != 0)
			{
				num2 = num;
			}
			int num3 = num2 * 2;
			int num4;
			if (true)
			{
				num4 = num3;
			}
			if (num4 <= 0)
			{
				return;
			}
			_0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[] array3 = new _0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[num4];
			int num5 = 0;
			for (int i = 0; i < num2; i++)
			{
				string _0023_003Dqdjmy6YXHG28Ld7JgKaiixI3Qq18UZmaYGF51h7ob1EQ_003D = array2[i]._0023_003Dqdjmy6YXHG28Ld7JgKaiixI3Qq18UZmaYGF51h7ob1EQ_003D;
				if (_0023_003Dqdjmy6YXHG28Ld7JgKaiixI3Qq18UZmaYGF51h7ob1EQ_003D == null)
				{
					continue;
				}
				int _0023_003Dq0zSTsnoBC3xyL4S_nj3M8Djd1_0024wAqtam_0024SS3rP1PzkQ_003D = array2[i]._0023_003Dq0zSTsnoBC3xyL4S_nj3M8Djd1_0024wAqtam_0024SS3rP1PzkQ_003D;
				int num6 = _0023_003Dq0zSTsnoBC3xyL4S_nj3M8Djd1_0024wAqtam_0024SS3rP1PzkQ_003D & (num4 - 1);
				while (array3[num6]._0023_003Dqdjmy6YXHG28Ld7JgKaiixI3Qq18UZmaYGF51h7ob1EQ_003D != null)
				{
					num6++;
					if (num6 >= num4)
					{
						num6 = 0;
					}
				}
				array3[num6]._0023_003Dqdjmy6YXHG28Ld7JgKaiixI3Qq18UZmaYGF51h7ob1EQ_003D = _0023_003Dqdjmy6YXHG28Ld7JgKaiixI3Qq18UZmaYGF51h7ob1EQ_003D;
				array3[num6]._0023_003Dq0zSTsnoBC3xyL4S_nj3M8Djd1_0024wAqtam_0024SS3rP1PzkQ_003D = _0023_003Dq0zSTsnoBC3xyL4S_nj3M8Djd1_0024wAqtam_0024SS3rP1PzkQ_003D;
				num5++;
			}
			_0023_003DqfHqXJbgzeEKzEjyF2y94PvURYe0H_aGsdJvoKaaQ7xE_003D = array3;
			_0023_003DqD_0024IHDkSGyRlSnTpPla4F9XABhKjoHM6t_0024chhO69rEw4_003D = num5;
		}

		public string _0023_003DqWdXaQPZeQ4mvLUcD1VH4jA_003D_003D(int _0023_003DqlANNEiAlZSJ9oJ_MIOrhq3BYK2kb4AlMco7x_rqkY0E_003D)
		{
			_0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[] array = _0023_003DqfHqXJbgzeEKzEjyF2y94PvURYe0H_aGsdJvoKaaQ7xE_003D;
			_0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[] array2;
			if (5u != 0)
			{
				array2 = array;
			}
			int num = array2.Length;
			int num2;
			if (2u != 0)
			{
				num2 = num;
			}
			int num3 = _0023_003DqlANNEiAlZSJ9oJ_MIOrhq3BYK2kb4AlMco7x_rqkY0E_003D & (num2 - 1);
			int num4;
			if (6u != 0)
			{
				num4 = num3;
			}
			string result = null;
			while (true)
			{
				if (array2[num4]._0023_003Dq0zSTsnoBC3xyL4S_nj3M8Djd1_0024wAqtam_0024SS3rP1PzkQ_003D == _0023_003DqlANNEiAlZSJ9oJ_MIOrhq3BYK2kb4AlMco7x_rqkY0E_003D)
				{
					result = array2[num4]._0023_003Dqdjmy6YXHG28Ld7JgKaiixI3Qq18UZmaYGF51h7ob1EQ_003D;
					break;
				}
				if (array2[num4]._0023_003Dqdjmy6YXHG28Ld7JgKaiixI3Qq18UZmaYGF51h7ob1EQ_003D == null)
				{
					break;
				}
				num4++;
				if (num4 >= num2)
				{
					num4 = 0;
				}
			}
			return result;
		}

		public void _0023_003DqLu6mZaw5XaWQ8BLXFAUF5g_003D_003D(int _0023_003DqHGM4ZvIIiX_5YNKMxrW3Wz6gXwyQemW4Pr6tjWOwOK8_003D, string _0023_003DqTp8yDRUFtXH18LsCHCw7fGfn07J0D1ibt3OlUbFiqag_003D)
		{
			_0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[] array = _0023_003DqfHqXJbgzeEKzEjyF2y94PvURYe0H_aGsdJvoKaaQ7xE_003D;
			_0023_003DqkaqvdCfJvpXeUeqgwrcB9l0h_0024veqdowSKGIZh2SgLgA_003D[] array2;
			if (5u != 0)
			{
				array2 = array;
			}
			int num = array2.Length;
			int num2;
			if (5u != 0)
			{
				num2 = num;
			}
			int num3 = num2 >> 1;
			int num4;
			if (true)
			{
				num4 = num3;
			}
			int num5 = _0023_003DqHGM4ZvIIiX_5YNKMxrW3Wz6gXwyQemW4Pr6tjWOwOK8_003D & (num2 - 1);
			bool flag;
			while (true)
			{
				int _0023_003Dq0zSTsnoBC3xyL4S_nj3M8Djd1_0024wAqtam_0024SS3rP1PzkQ_003D = array2[num5]._0023_003Dq0zSTsnoBC3xyL4S_nj3M8Djd1_0024wAqtam_0024SS3rP1PzkQ_003D;
				flag = array2[num5]._0023_003Dqdjmy6YXHG28Ld7JgKaiixI3Qq18UZmaYGF51h7ob1EQ_003D == null;
				if (_0023_003Dq0zSTsnoBC3xyL4S_nj3M8Djd1_0024wAqtam_0024SS3rP1PzkQ_003D == _0023_003DqHGM4ZvIIiX_5YNKMxrW3Wz6gXwyQemW4Pr6tjWOwOK8_003D || flag)
				{
					break;
				}
				num5++;
				if (num5 >= num2)
				{
					num5 = 0;
				}
			}
			array2[num5]._0023_003Dqdjmy6YXHG28Ld7JgKaiixI3Qq18UZmaYGF51h7ob1EQ_003D = _0023_003DqTp8yDRUFtXH18LsCHCw7fGfn07J0D1ibt3OlUbFiqag_003D;
			if (flag)
			{
				array2[num5]._0023_003Dq0zSTsnoBC3xyL4S_nj3M8Djd1_0024wAqtam_0024SS3rP1PzkQ_003D = _0023_003DqHGM4ZvIIiX_5YNKMxrW3Wz6gXwyQemW4Pr6tjWOwOK8_003D;
				_0023_003DqD_0024IHDkSGyRlSnTpPla4F9XABhKjoHM6t_0024chhO69rEw4_003D++;
				if (_0023_003DqD_0024IHDkSGyRlSnTpPla4F9XABhKjoHM6t_0024chhO69rEw4_003D > num4)
				{
					_0023_003Dq_1DwSEcm_Y_0024Oj0IVpOivH4MD5cKhljjTraNJgq7qYM4_003D();
				}
			}
		}
	}

	private static _0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D _0023_003Dqp3IH1fHSDkble93nqpQOiO8M6oOHR67Jpl1nqg6T2_g_003D;

	private static _0023_003Dq0wz7Bwsxixyure6wq9VYgmUGfBSgkERnl2ztz7TBQ_U_003D _0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D;

	private static byte[] _0023_003Dq9P2Nlayi1ankaYNl5MEzGAlV4f3o7T_0024_81NeUJx4xEI_003D;

	private static short _0023_003DqMsyVkT_0024mdqq5ziliLb2xTECVqLWaPiNG0vL1pnDDHkA_003D;

	private static int _0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D;

	private static byte[] _0023_003Dqo5wDTZd1Oejgt4TgAWjb1g_00249C7LLqW47uDCAjjSqPYc_003D;

	private static int _0023_003Dq2NuSwh2h_0024CFd1XWNVB1X_0024IxoU5jDeLbm0vGtNuc2EDM_003D;

	private static int _0023_003Dq1jDjr3EeO51t91DZhK5UmGr_Yga1NWIbAOPImHd3Hg8_003D;

	private static _0023_003Dq_0024_0024mN6PzEcCRUDgYhKgmNeIw6eWBJPwpvnCRX_I31RkM_003D _0023_003DqeSV4ex2YiIzDiI5Ry5IOcibEmX5qOwSeIlgfMKsU2KM_003D;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static _0023_003DqCAlptz5cgHMVhMqVe_spjlZbTNs8sOllXiD6KAjQyoc_003D()
	{
		_0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D _0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D = new _0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D(140);
		if (8u != 0)
		{
			_0023_003Dqp3IH1fHSDkble93nqpQOiO8M6oOHR67Jpl1nqg6T2_g_003D = _0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D;
		}
		int num;
		if (uint.MaxValue != 0)
		{
			num = 1;
		}
		StackTrace stackTrace = new StackTrace(num, fNeedFileInfo: false);
		StackTrace stackTrace2 = default(StackTrace);
		if (0 == 0)
		{
			stackTrace2 = stackTrace;
		}
		int num2 = num - 1;
		if (7u != 0)
		{
			num = num2;
		}
		StackFrame frame = stackTrace2.GetFrame(num);
		int num3 = ~(-(-(~(~(-(~(-(~-153656750)))))))) ^ -(~(~(-(-(~(~(-(~(-(~-314203622))))))))));
		MethodBase methodBase = frame?.GetMethod();
		if (frame != null)
		{
			num3 ^= ~(-(~(-(-(~(~(-(~(-(~-314179588))))))))));
		}
		Type type = methodBase?.DeclaringType;
		if (type == typeof(RuntimeMethodHandle))
		{
			num3 ^= 807 + num;
			_0023_003DqeSV4ex2YiIzDiI5Ry5IOcibEmX5qOwSeIlgfMKsU2KM_003D |= (_0023_003Dq_0024_0024mN6PzEcCRUDgYhKgmNeIw6eWBJPwpvnCRX_I31RkM_003D)4;
		}
		else if (type == null)
		{
			num3 ^= -(~(~(-(-(~(-(~(-(~(~-37044))))))))));
			_0023_003DqeSV4ex2YiIzDiI5Ry5IOcibEmX5qOwSeIlgfMKsU2KM_003D |= (_0023_003Dq_0024_0024mN6PzEcCRUDgYhKgmNeIw6eWBJPwpvnCRX_I31RkM_003D)1;
		}
		else if (type.Assembly != typeof(_0023_003DqCAlptz5cgHMVhMqVe_spjlZbTNs8sOllXiD6KAjQyoc_003D).Assembly)
		{
			num3 ^= 0x2B2A72E9;
			_0023_003DqeSV4ex2YiIzDiI5Ry5IOcibEmX5qOwSeIlgfMKsU2KM_003D |= (_0023_003Dq_0024_0024mN6PzEcCRUDgYhKgmNeIw6eWBJPwpvnCRX_I31RkM_003D)2;
		}
		else
		{
			num3 ^= -(~(~(-(-(~(-(~(~-24035)))))))) - num;
			_0023_003DqeSV4ex2YiIzDiI5Ry5IOcibEmX5qOwSeIlgfMKsU2KM_003D |= (_0023_003Dq_0024_0024mN6PzEcCRUDgYhKgmNeIw6eWBJPwpvnCRX_I31RkM_003D)16;
		}
		_0023_003Dq1jDjr3EeO51t91DZhK5UmGr_Yga1NWIbAOPImHd3Hg8_003D += num3;
	}

	private static void _0023_003DqyFCy1KbsxQf6A3fHJ61HKVQMFHiyvzqftFYYdmKUH7s_003D(byte[] _0023_003Dq8JcpHG5he9gELt5XS8xL2tJgNIfSDuNHEF0uNfNAU9c_003D, int _0023_003DqxJF9GsKxY10ionNscJTFtY52O7BJbOGLSu_0FXBE0GY_003D, byte[] _0023_003DqXE8an5JkMSLih_0024RtoebWuvUUbzO_HrK6omv7cR59LOg_003D)
	{
		int num;
		if (5u != 0)
		{
			num = 0;
		}
		int num2;
		if (3u != 0)
		{
			num2 = 0;
		}
		int num3;
		if (5u != 0)
		{
			num3 = 128;
		}
		int num4 = _0023_003DqXE8an5JkMSLih_0024RtoebWuvUUbzO_HrK6omv7cR59LOg_003D.Length;
		while (num < num4)
		{
			if ((num3 <<= 1) == 256)
			{
				num3 = 1;
				num2 = _0023_003Dq8JcpHG5he9gELt5XS8xL2tJgNIfSDuNHEF0uNfNAU9c_003D[_0023_003DqxJF9GsKxY10ionNscJTFtY52O7BJbOGLSu_0FXBE0GY_003D++];
			}
			if ((num2 & num3) != 0)
			{
				int num5 = (_0023_003Dq8JcpHG5he9gELt5XS8xL2tJgNIfSDuNHEF0uNfNAU9c_003D[_0023_003DqxJF9GsKxY10ionNscJTFtY52O7BJbOGLSu_0FXBE0GY_003D] >> 2) + 3;
				int num6 = ((_0023_003Dq8JcpHG5he9gELt5XS8xL2tJgNIfSDuNHEF0uNfNAU9c_003D[_0023_003DqxJF9GsKxY10ionNscJTFtY52O7BJbOGLSu_0FXBE0GY_003D] << 8) | _0023_003Dq8JcpHG5he9gELt5XS8xL2tJgNIfSDuNHEF0uNfNAU9c_003D[_0023_003DqxJF9GsKxY10ionNscJTFtY52O7BJbOGLSu_0FXBE0GY_003D + 1]) & 0x3FF;
				_0023_003DqxJF9GsKxY10ionNscJTFtY52O7BJbOGLSu_0FXBE0GY_003D += 2;
				int num7 = num - num6;
				if (num7 < 0)
				{
					break;
				}
				while (--num5 >= 0 && num < num4)
				{
					_0023_003DqXE8an5JkMSLih_0024RtoebWuvUUbzO_HrK6omv7cR59LOg_003D[num++] = _0023_003DqXE8an5JkMSLih_0024RtoebWuvUUbzO_HrK6omv7cR59LOg_003D[num7++];
				}
			}
			else
			{
				_0023_003DqXE8an5JkMSLih_0024RtoebWuvUUbzO_HrK6omv7cR59LOg_003D[num++] = _0023_003Dq8JcpHG5he9gELt5XS8xL2tJgNIfSDuNHEF0uNfNAU9c_003D[_0023_003DqxJF9GsKxY10ionNscJTFtY52O7BJbOGLSu_0FXBE0GY_003D++];
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string _0023_003DqYOfO1gSKdvigXheezlRE_g_003D_003D(int _0023_003DqORQ1CPo_0024O1wEIA87ByTXXYQQpfqgn8gYainN0s8IqeQ_003D)
	{
		_0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D _0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D = _0023_003Dqp3IH1fHSDkble93nqpQOiO8M6oOHR67Jpl1nqg6T2_g_003D;
		_0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D obj;
		if (7u != 0)
		{
			obj = _0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D;
		}
		Monitor.Enter(_0023_003DqpkpjSNuuhaIJuniLmLgBFDeoqkJuFfIeYhRKXtRTTS4_003D);
		try
		{
			string text2;
			while (true)
			{
				string text = _0023_003Dqp3IH1fHSDkble93nqpQOiO8M6oOHR67Jpl1nqg6T2_g_003D._0023_003DqWdXaQPZeQ4mvLUcD1VH4jA_003D_003D(_0023_003DqORQ1CPo_0024O1wEIA87ByTXXYQQpfqgn8gYainN0s8IqeQ_003D);
				if (7u != 0)
				{
					text2 = text;
				}
				if (text2 != null)
				{
					break;
				}
				int num5;
				if (_0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D == null)
				{
					Assembly executingAssembly = Assembly.GetExecutingAssembly();
					Assembly assembly;
					if (7u != 0)
					{
						assembly = executingAssembly;
					}
					Assembly callingAssembly = Assembly.GetCallingAssembly();
					Assembly assembly2;
					if (2u != 0)
					{
						assembly2 = callingAssembly;
					}
					int num = _0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D | 0x189282;
					if (5u != 0)
					{
						_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D = num;
					}
					Stream manifestResourceStream = assembly.GetManifestResourceStream("\u2006\u2005\u2000\u2002\u2002\u200a\u2001\u2008\u2009\u2001\u2009\u200a\u2002");
					Stream _0023_003DqeB6ZbpELKiBVnEsGWayEN419vbneXllQt1A4VNVNyEo_003D;
					if (7u != 0)
					{
						_0023_003DqeB6ZbpELKiBVnEsGWayEN419vbneXllQt1A4VNVNyEo_003D = manifestResourceStream;
					}
					int num2;
					if (5u != 0)
					{
						num2 = 1;
					}
					StackTrace stackTrace = new StackTrace(num2, fNeedFileInfo: false);
					StackTrace stackTrace2;
					if (4u != 0)
					{
						stackTrace2 = stackTrace;
					}
					int num3 = _0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D ^ (0x1946 | num2);
					if (5u != 0)
					{
						_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D = num3;
					}
					num2--;
					StackFrame frame = stackTrace2.GetFrame(num2);
					MethodBase methodBase = frame?.GetMethod();
					_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D ^= num2 + 128;
					Type type = methodBase?.DeclaringType;
					if (frame == null)
					{
						_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D ^= 219315;
					}
					bool flag = type == typeof(RuntimeMethodHandle);
					_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D ^= 160;
					if (!flag)
					{
						flag = type == null;
						if (flag)
						{
							_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D ^= 219283;
						}
					}
					if (flag == (stackTrace2 != null))
					{
						_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D ^= 32;
					}
					_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D ^= 0x1966 | (num2 + 1);
					_0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D = new _0023_003Dq0wz7Bwsxixyure6wq9VYgmUGfBSgkERnl2ztz7TBQ_U_003D(_0023_003DqeB6ZbpELKiBVnEsGWayEN419vbneXllQt1A4VNVNyEo_003D);
					short num4 = (short)(_0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D._0023_003Dq5WMyBp6wewmr70Slxb5X2EFr3IgVFHOJseabeRVgvrk_003D() ^ (short)(-(~(~(-(~(-(~(-(~-13323))))))))));
					if (num4 == 0)
					{
						_0023_003DqMsyVkT_0024mdqq5ziliLb2xTECVqLWaPiNG0vL1pnDDHkA_003D = (short)(_0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D._0023_003Dq5WMyBp6wewmr70Slxb5X2EFr3IgVFHOJseabeRVgvrk_003D() ^ (short)(-(~(~(-(-(~(-(~(~28284))))))))));
					}
					else
					{
						_0023_003Dq9P2Nlayi1ankaYNl5MEzGAlV4f3o7T_0024_81NeUJx4xEI_003D = _0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D._0023_003Dq_Qlhvm5cgV7RhSykghF7zCuI91aHD0b3KIMQe2lqzQQ_003D(num4);
					}
					assembly2 = assembly;
					AssemblyName assemblyName;
					try
					{
						assemblyName = assembly2.GetName();
					}
					catch
					{
						assemblyName = new AssemblyName(assembly2.FullName);
					}
					_0023_003Dqo5wDTZd1Oejgt4TgAWjb1g_00249C7LLqW47uDCAjjSqPYc_003D = assemblyName.GetPublicKeyToken();
					if (_0023_003Dqo5wDTZd1Oejgt4TgAWjb1g_00249C7LLqW47uDCAjjSqPYc_003D != null && _0023_003Dqo5wDTZd1Oejgt4TgAWjb1g_00249C7LLqW47uDCAjjSqPYc_003D.Length == 0)
					{
						_0023_003Dqo5wDTZd1Oejgt4TgAWjb1g_00249C7LLqW47uDCAjjSqPYc_003D = null;
					}
					num5 = _0023_003Dq1jDjr3EeO51t91DZhK5UmGr_Yga1NWIbAOPImHd3Hg8_003D;
					num5 ^= 0x755999FF;
					_0023_003Dq1jDjr3EeO51t91DZhK5UmGr_Yga1NWIbAOPImHd3Hg8_003D = 0;
					long num6 = _0023_003DqrlawuclhjGIoTrRTGGh7Wxz38p2TBmxW92H5_0024X_0024BuGY_003D._0023_003DqkhlpRv1jKxhOiBaezlR3rA_003D_003D();
					num5 ^= (int)num6;
					num5 ^= 0x24145EA9;
					num5 ^= 0x42C67D48;
					num5 = (_0023_003Dq2NuSwh2h_0024CFd1XWNVB1X_0024IxoU5jDeLbm0vGtNuc2EDM_003D = num5 ^ -(~(~(-(~(-(~(-(~60952560)))))))));
					_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D = (_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D & 0xFFFFF72) ^ 0x1A84;
					if (((uint)_0023_003DqeSV4ex2YiIzDiI5Ry5IOcibEmX5qOwSeIlgfMKsU2KM_003D & (uint)(-(~(~(-(~(-(~(-(~-19)))))))))) == 0)
					{
						_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D = 43962;
					}
				}
				else
				{
					num5 = _0023_003Dq2NuSwh2h_0024CFd1XWNVB1X_0024IxoU5jDeLbm0vGtNuc2EDM_003D;
				}
				if (_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D == 43962)
				{
					return new string(new char[3] { 'X', '0', 'X' });
				}
				int num7 = _0023_003DqORQ1CPo_0024O1wEIA87ByTXXYQQpfqgn8gYainN0s8IqeQ_003D ^ -1759012344 ^ num5;
				num7 ^= 0x30ABE507;
				_0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D._0023_003Dq_0024hguXTq4bWL805LtYLv9RtJVkqd4d_kYeQGw87XfoVM_003D().Position = num7;
				byte[] array;
				if (_0023_003Dq9P2Nlayi1ankaYNl5MEzGAlV4f3o7T_0024_81NeUJx4xEI_003D != null)
				{
					array = _0023_003Dq9P2Nlayi1ankaYNl5MEzGAlV4f3o7T_0024_81NeUJx4xEI_003D;
				}
				else
				{
					short num8 = ((_0023_003DqMsyVkT_0024mdqq5ziliLb2xTECVqLWaPiNG0vL1pnDDHkA_003D != -1) ? _0023_003DqMsyVkT_0024mdqq5ziliLb2xTECVqLWaPiNG0vL1pnDDHkA_003D : ((short)(_0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D._0023_003Dq5WMyBp6wewmr70Slxb5X2EFr3IgVFHOJseabeRVgvrk_003D() ^ 0x43CC ^ num7)));
					if (num8 == 0)
					{
						array = null;
					}
					else
					{
						array = _0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D._0023_003Dq_Qlhvm5cgV7RhSykghF7zCuI91aHD0b3KIMQe2lqzQQ_003D(num8);
						for (int i = 0; i != array.Length; i++)
						{
							array[i] ^= (byte)(_0023_003Dq2NuSwh2h_0024CFd1XWNVB1X_0024IxoU5jDeLbm0vGtNuc2EDM_003D >> ((i & 3) << 3));
						}
					}
				}
				int num9 = _0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D._0023_003DqCXIveonOLU_la_pInA_N2z2MIjOPMro1UDRtroCPCJY_003D() ^ num7 ^ -(~(-(~(~(-(-(~(~-562552601)))))))) ^ num5;
				if (num9 == -2)
				{
					byte[] array2 = _0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D._0023_003Dq_Qlhvm5cgV7RhSykghF7zCuI91aHD0b3KIMQe2lqzQQ_003D(4);
					_0023_003DqORQ1CPo_0024O1wEIA87ByTXXYQQpfqgn8gYainN0s8IqeQ_003D = 0x2187DF1A ^ num5;
					_0023_003DqORQ1CPo_0024O1wEIA87ByTXXYQQpfqgn8gYainN0s8IqeQ_003D = (array2[2] | (array2[3] << 16) | (array2[0] << 8) | (array2[1] << 24)) ^ -_0023_003DqORQ1CPo_0024O1wEIA87ByTXXYQQpfqgn8gYainN0s8IqeQ_003D;
					continue;
				}
				bool flag2 = (num9 & 0x40000000) != 0;
				bool flag3 = (num9 & 0x20000000) != 0;
				bool flag4 = (num9 & int.MinValue) != 0;
				num9 &= 0xFFFFFFF;
				byte[] array3 = _0023_003Dq0qLZUfLBNpjH9djhFA2d0OHKQutvV2QFuqNsMLaC6f0ObHBTebdQWu7_fUIWIJi2._0023_003Dq_5rHIvqFLCkr7Gvc8994bg_003D_003D(array, _0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D._0023_003Dq_Qlhvm5cgV7RhSykghF7zCuI91aHD0b3KIMQe2lqzQQ_003D(num9));
				if (_0023_003Dqo5wDTZd1Oejgt4TgAWjb1g_00249C7LLqW47uDCAjjSqPYc_003D != null != (_0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D != 1607814))
				{
					for (int j = 0; j < num9; j++)
					{
						byte b = _0023_003Dqo5wDTZd1Oejgt4TgAWjb1g_00249C7LLqW47uDCAjjSqPYc_003D[j & 7];
						b = (byte)((b << 3) | (b >> 5));
						array3[j] ^= b;
					}
				}
				int num10 = _0023_003Dq6kLIbqt9iY98msKOT93phfrf3cKYzNhjzKI_0024fiPiFmw_003D - 12;
				byte[] array4;
				int num11;
				if (!flag3)
				{
					array4 = array3;
					num11 = num9;
				}
				else
				{
					num11 = array3[2] | (array3[0] << 16) | (array3[3] << 8) | (array3[1] << 24);
					array4 = new byte[num11];
					_0023_003DqyFCy1KbsxQf6A3fHJ61HKVQMFHiyvzqftFYYdmKUH7s_003D(array3, 4, array4);
				}
				if (flag2 && num10 == 1607802)
				{
					char[] array5 = new char[num11];
					for (int k = 0; k < num11; k++)
					{
						array5[k] = (char)array4[k];
					}
					text2 = new string(array5);
				}
				else
				{
					text2 = Encoding.Unicode.GetString(array4, 0, array4.Length);
				}
				num10 += 127 + (num10 & 3) << 5;
				if (num10 != 1611930)
				{
					text2 = ((_0023_003DqORQ1CPo_0024O1wEIA87ByTXXYQQpfqgn8gYainN0s8IqeQ_003D + num9) ^ 0xE4A78 ^ (num10 & 0x50D)).ToString("X");
				}
				if (!flag4)
				{
					text2 = string.Intern(text2);
					_0023_003Dqp3IH1fHSDkble93nqpQOiO8M6oOHR67Jpl1nqg6T2_g_003D._0023_003DqLu6mZaw5XaWQ8BLXFAUF5g_003D_003D(_0023_003DqORQ1CPo_0024O1wEIA87ByTXXYQQpfqgn8gYainN0s8IqeQ_003D, text2);
					if (_0023_003Dqp3IH1fHSDkble93nqpQOiO8M6oOHR67Jpl1nqg6T2_g_003D._0023_003Dqvd0D7V_cIW9AIIRP0Uz64Ny3wQdfZmkp1Jda2aOLQjk_003D() == 140)
					{
						_0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D._0023_003Dq2gULwh8UNvpvktOVKLhxZJ7yeDbkgdBTa7I15PaQWEg_003D();
						_0023_003DqdPyH2sFCFEemX3RSNjbUBoSv1Z_0024naBkWtULSHy7dWdQ_003D = null;
						_0023_003Dq9P2Nlayi1ankaYNl5MEzGAlV4f3o7T_0024_81NeUJx4xEI_003D = (_0023_003Dqo5wDTZd1Oejgt4TgAWjb1g_00249C7LLqW47uDCAjjSqPYc_003D = null);
					}
				}
				return text2;
			}
			string result = text2;
			if (4u != 0)
			{
				return result;
			}
		}
		finally
		{
			Monitor.Exit(obj);
		}
		string result2;
		return result2;
	}
}
