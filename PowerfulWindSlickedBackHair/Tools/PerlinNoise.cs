using System;

namespace PowerfulWindSlickedBackHair.Tools
{
	// Token: 0x02000020 RID: 32
	public static class PerlinNoise
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x00009198 File Offset: 0x00007398
		public static float Noise(float x, float y, float z)
		{
			int num = Mathf.FloorToInt(x) & 255;
			int num2 = Mathf.FloorToInt(y) & 255;
			int num3 = Mathf.FloorToInt(z) & 255;
			x -= Mathf.Floor(x);
			y -= Mathf.Floor(y);
			z -= Mathf.Floor(z);
			float t = PerlinNoise.Fade(x);
			float t2 = PerlinNoise.Fade(y);
			float t3 = PerlinNoise.Fade(z);
			int num4 = PerlinNoise.perm[num] + num2 & 255;
			int num5 = PerlinNoise.perm[num + 1] + num2 & 255;
			int num6 = PerlinNoise.perm[num4] + num3 & 255;
			int num7 = PerlinNoise.perm[num5] + num3 & 255;
			int num8 = PerlinNoise.perm[num4 + 1] + num3 & 255;
			int num9 = PerlinNoise.perm[num5 + 1] + num3 & 255;
			int hash = PerlinNoise.perm[num6];
			int hash2 = PerlinNoise.perm[num7];
			int hash3 = PerlinNoise.perm[num8];
			int hash4 = PerlinNoise.perm[num9];
			int hash5 = PerlinNoise.perm[num6 + 1];
			int hash6 = PerlinNoise.perm[num7 + 1];
			int hash7 = PerlinNoise.perm[num8 + 1];
			int hash8 = PerlinNoise.perm[num9 + 1];
			float a = PerlinNoise.Lerp(PerlinNoise.Grad(hash, x, y, z), PerlinNoise.Grad(hash2, x - 1f, y, z), t);
			float b = PerlinNoise.Lerp(PerlinNoise.Grad(hash3, x, y - 1f, z), PerlinNoise.Grad(hash4, x - 1f, y - 1f, z), t);
			float a2 = PerlinNoise.Lerp(a, b, t2);
			a = PerlinNoise.Lerp(PerlinNoise.Grad(hash5, x, y, z - 1f), PerlinNoise.Grad(hash6, x - 1f, y, z - 1f), t);
			b = PerlinNoise.Lerp(PerlinNoise.Grad(hash7, x, y - 1f, z - 1f), PerlinNoise.Grad(hash8, x - 1f, y - 1f, z - 1f), t);
			float b2 = PerlinNoise.Lerp(a, b, t2);
			return (PerlinNoise.Lerp(a2, b2, t3) + 1f) / 2f;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000093BC File Offset: 0x000075BC
		private static float Fade(float t)
		{
			return t * t * t * (t * (t * 6f - 15f) + 10f);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000093EC File Offset: 0x000075EC
		private static float grad(int hash, float x, float y, float z)
		{
			int num = hash & 15;
			float num2 = (num < 8) ? x : y;
			float num3 = (num < 4) ? y : ((num == 12 || num == 14) ? x : z);
			return (((num & 1) == 0) ? num2 : (-num2)) + (((num & 2) == 0) ? num3 : (-num3));
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00009438 File Offset: 0x00007638
		public static float Grad(int hash, float x, float y, float z)
		{
			float result;
			switch (hash & 15)
			{
			case 0:
				result = x + y;
				break;
			case 1:
				result = -x + y;
				break;
			case 2:
				result = x - y;
				break;
			case 3:
				result = -x - y;
				break;
			case 4:
				result = x + z;
				break;
			case 5:
				result = -x + z;
				break;
			case 6:
				result = x - z;
				break;
			case 7:
				result = -x - z;
				break;
			case 8:
				result = y + z;
				break;
			case 9:
				result = -y + z;
				break;
			case 10:
				result = y - z;
				break;
			case 11:
				result = -y - z;
				break;
			case 12:
				result = y + x;
				break;
			case 13:
				result = -y + z;
				break;
			case 14:
				result = y - x;
				break;
			case 15:
				result = -y - z;
				break;
			default:
				result = 0f;
				break;
			}
			return result;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00009508 File Offset: 0x00007708
		private static float Lerp(float a, float b, float t)
		{
			return a + t * (b - a);
		}

		// Token: 0x04000093 RID: 147
		private static readonly int[] perm = new int[]
		{
			151,
			160,
			137,
			91,
			90,
			15,
			131,
			13,
			201,
			95,
			96,
			53,
			194,
			233,
			7,
			225,
			140,
			36,
			103,
			30,
			69,
			142,
			8,
			99,
			37,
			240,
			21,
			10,
			23,
			190,
			6,
			148,
			247,
			120,
			234,
			75,
			0,
			26,
			197,
			62,
			94,
			252,
			219,
			203,
			117,
			35,
			11,
			32,
			57,
			177,
			33,
			88,
			237,
			149,
			56,
			87,
			174,
			20,
			125,
			136,
			171,
			168,
			68,
			175,
			74,
			165,
			71,
			134,
			139,
			48,
			27,
			166,
			77,
			146,
			158,
			231,
			83,
			111,
			229,
			122,
			60,
			211,
			133,
			230,
			220,
			105,
			92,
			41,
			55,
			46,
			245,
			40,
			244,
			102,
			143,
			54,
			65,
			25,
			63,
			161,
			1,
			216,
			80,
			73,
			209,
			76,
			132,
			187,
			208,
			89,
			18,
			169,
			200,
			196,
			135,
			130,
			116,
			188,
			159,
			86,
			164,
			100,
			109,
			198,
			173,
			186,
			3,
			64,
			52,
			217,
			226,
			250,
			124,
			123,
			5,
			202,
			38,
			147,
			118,
			126,
			255,
			82,
			85,
			212,
			207,
			206,
			59,
			227,
			47,
			16,
			58,
			17,
			182,
			189,
			28,
			42,
			223,
			183,
			170,
			213,
			119,
			248,
			152,
			2,
			44,
			154,
			163,
			70,
			221,
			153,
			101,
			155,
			167,
			43,
			172,
			9,
			129,
			22,
			39,
			253,
			19,
			98,
			108,
			110,
			79,
			113,
			224,
			232,
			178,
			185,
			112,
			104,
			218,
			246,
			97,
			228,
			251,
			34,
			242,
			193,
			238,
			210,
			144,
			12,
			191,
			179,
			162,
			241,
			81,
			51,
			145,
			235,
			249,
			14,
			239,
			107,
			49,
			192,
			214,
			31,
			181,
			199,
			106,
			157,
			184,
			84,
			204,
			176,
			115,
			121,
			50,
			45,
			127,
			4,
			150,
			254,
			138,
			236,
			205,
			93,
			222,
			114,
			67,
			29,
			24,
			72,
			243,
			141,
			128,
			195,
			78,
			66,
			215,
			61,
			156,
			180,
			151
		};
	}
}
