using System;

namespace PowerfulWindSlickedBackHair.Tools
{
	// Token: 0x0200001F RID: 31
	public struct Mathf
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x000087E8 File Offset: 0x000069E8
		public static float Sin(float f)
		{
			return (float)Math.Sin((double)f);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00008804 File Offset: 0x00006A04
		public static float Cos(float f)
		{
			return (float)Math.Cos((double)f);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00008820 File Offset: 0x00006A20
		public static float Tan(float f)
		{
			return (float)Math.Tan((double)f);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000883C File Offset: 0x00006A3C
		public static float Asin(float f)
		{
			return (float)Math.Asin((double)f);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00008858 File Offset: 0x00006A58
		public static float Acos(float f)
		{
			return (float)Math.Acos((double)f);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00008874 File Offset: 0x00006A74
		public static float Atan(float f)
		{
			return (float)Math.Atan((double)f);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00008890 File Offset: 0x00006A90
		public static float Atan2(float y, float x)
		{
			return (float)Math.Atan2((double)y, (double)x);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000088AC File Offset: 0x00006AAC
		public static float Sqrt(float f)
		{
			return (float)Math.Sqrt((double)f);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000088C8 File Offset: 0x00006AC8
		public static float Abs(float f)
		{
			return Math.Abs(f);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000088E0 File Offset: 0x00006AE0
		public static int Abs(int value)
		{
			return Math.Abs(value);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000088F8 File Offset: 0x00006AF8
		public static float Min(float a, float b)
		{
			return (a < b) ? a : b;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00008914 File Offset: 0x00006B14
		public static float Min(params float[] values)
		{
			int num = values.Length;
			bool flag = num == 0;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				float num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					bool flag2 = values[i] < num2;
					if (flag2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000896C File Offset: 0x00006B6C
		public static int Min(int a, int b)
		{
			return (a < b) ? a : b;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00008988 File Offset: 0x00006B88
		public static int Min(params int[] values)
		{
			int num = values.Length;
			bool flag = num == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					bool flag2 = values[i] < num2;
					if (flag2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000089DC File Offset: 0x00006BDC
		public static float Max(float a, float b)
		{
			return (a > b) ? a : b;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000089F8 File Offset: 0x00006BF8
		public static float Max(params float[] values)
		{
			int num = values.Length;
			bool flag = num == 0;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				float num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					bool flag2 = values[i] > num2;
					if (flag2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00008A50 File Offset: 0x00006C50
		public static int Max(int a, int b)
		{
			return (a > b) ? a : b;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00008A6C File Offset: 0x00006C6C
		public static int Max(params int[] values)
		{
			int num = values.Length;
			bool flag = num == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					bool flag2 = values[i] > num2;
					if (flag2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00008AC0 File Offset: 0x00006CC0
		public static float Pow(float f, float p)
		{
			return (float)Math.Pow((double)f, (double)p);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00008ADC File Offset: 0x00006CDC
		public static float Exp(float power)
		{
			return (float)Math.Exp((double)power);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00008AF8 File Offset: 0x00006CF8
		public static float Log(float f, float p)
		{
			return (float)Math.Log((double)f, (double)p);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00008B14 File Offset: 0x00006D14
		public static float Log(float f)
		{
			return (float)Math.Log((double)f);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00008B30 File Offset: 0x00006D30
		public static float Log10(float f)
		{
			return (float)Math.Log10((double)f);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00008B4C File Offset: 0x00006D4C
		public static float Ceil(float f)
		{
			return (float)Math.Ceiling((double)f);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00008B68 File Offset: 0x00006D68
		public static float Floor(float f)
		{
			return (float)Math.Floor((double)f);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00008B84 File Offset: 0x00006D84
		public static float Round(float f)
		{
			return (float)Math.Round((double)f);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00008BA0 File Offset: 0x00006DA0
		public static int CeilToInt(float f)
		{
			return (int)Math.Ceiling((double)f);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00008BBC File Offset: 0x00006DBC
		public static int FloorToInt(float f)
		{
			return (int)Math.Floor((double)f);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00008BD8 File Offset: 0x00006DD8
		public static int RoundToInt(float f)
		{
			return (int)Math.Round((double)f);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00008BF4 File Offset: 0x00006DF4
		public static float Sign(float f)
		{
			return (f >= 0f) ? 1f : -1f;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00008C1C File Offset: 0x00006E1C
		public static float Clamp(float value, float min, float max)
		{
			bool flag = value < min;
			if (flag)
			{
				value = min;
			}
			else
			{
				bool flag2 = value > max;
				if (flag2)
				{
					value = max;
				}
			}
			return value;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00008C48 File Offset: 0x00006E48
		public static int Clamp(int value, int min, int max)
		{
			bool flag = value < min;
			if (flag)
			{
				value = min;
			}
			else
			{
				bool flag2 = value > max;
				if (flag2)
				{
					value = max;
				}
			}
			return value;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00008C74 File Offset: 0x00006E74
		public static float Clamp01(float value)
		{
			bool flag = value < 0f;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				bool flag2 = value > 1f;
				if (flag2)
				{
					result = 1f;
				}
				else
				{
					result = value;
				}
			}
			return result;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00008CB0 File Offset: 0x00006EB0
		public static float Lerp(float a, float b, float t)
		{
			return a + (b - a) * Mathf.Clamp01(t);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00008CD0 File Offset: 0x00006ED0
		public static float LerpUnclamped(float a, float b, float t)
		{
			return a + (b - a) * t;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00008CEC File Offset: 0x00006EEC
		public static float LerpAngle(float a, float b, float t)
		{
			float num = Mathf.Repeat(b - a, 360f);
			bool flag = num > 180f;
			if (flag)
			{
				num -= 360f;
			}
			return a + num * Mathf.Clamp01(t);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00008D2C File Offset: 0x00006F2C
		public static float MoveTowards(float current, float target, float maxDelta)
		{
			bool flag = Mathf.Abs(target - current) <= maxDelta;
			float result;
			if (flag)
			{
				result = target;
			}
			else
			{
				result = current + Mathf.Sign(target - current) * maxDelta;
			}
			return result;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00008D60 File Offset: 0x00006F60
		public static float MoveTowardsAngle(float current, float target, float maxDelta)
		{
			float num = Mathf.DeltaAngle(current, target);
			bool flag = -maxDelta < num && num < maxDelta;
			float result;
			if (flag)
			{
				result = target;
			}
			else
			{
				target = current + num;
				result = Mathf.MoveTowards(current, target, maxDelta);
			}
			return result;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00008D9C File Offset: 0x00006F9C
		public static float SmoothStep(float from, float to, float t)
		{
			t = Mathf.Clamp01(t);
			t = -2f * t * t * t + 3f * t * t;
			return to * t + from * (1f - t);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00008DDC File Offset: 0x00006FDC
		public static float Gamma(float value, float absmax, float gamma)
		{
			bool flag = value < 0f;
			float num = Mathf.Abs(value);
			bool flag2 = num > absmax;
			float result;
			if (flag2)
			{
				result = (flag ? (-num) : num);
			}
			else
			{
				float num2 = Mathf.Pow(num / absmax, gamma) * absmax;
				result = (flag ? (-num2) : num2);
			}
			return result;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00008E28 File Offset: 0x00007028
		public static float Repeat(float t, float length)
		{
			return Mathf.Clamp(t - Mathf.Floor(t / length) * length, 0f, length);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00008E54 File Offset: 0x00007054
		public static float PingPong(float t, float length)
		{
			t = Mathf.Repeat(t, length * 2f);
			return length - Mathf.Abs(t - length);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00008E80 File Offset: 0x00007080
		public static float InverseLerp(float a, float b, float value)
		{
			bool flag = a != b;
			float result;
			if (flag)
			{
				result = Mathf.Clamp01((value - a) / (b - a));
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00008EB4 File Offset: 0x000070B4
		public static float DeltaAngle(float current, float target)
		{
			float num = Mathf.Repeat(target - current, 360f);
			bool flag = num > 180f;
			if (flag)
			{
				num -= 360f;
			}
			return num;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00008EEC File Offset: 0x000070EC
		internal static long RandomToLong(Random r)
		{
			byte[] array = new byte[8];
			r.NextBytes(array);
			return (long)(BitConverter.ToUInt64(array, 0) & 9223372036854775807UL);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00008F20 File Offset: 0x00007120
		internal static float ClampToFloat(double value)
		{
			bool flag = double.IsPositiveInfinity(value);
			float result;
			if (flag)
			{
				result = float.PositiveInfinity;
			}
			else
			{
				bool flag2 = double.IsNegativeInfinity(value);
				if (flag2)
				{
					result = float.NegativeInfinity;
				}
				else
				{
					bool flag3 = value < -3.4028234663852886E+38;
					if (flag3)
					{
						result = float.MinValue;
					}
					else
					{
						bool flag4 = value > 3.4028234663852886E+38;
						if (flag4)
						{
							result = float.MaxValue;
						}
						else
						{
							result = (float)value;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00008F8C File Offset: 0x0000718C
		internal static int ClampToInt(long value)
		{
			bool flag = value < -2147483648L;
			int result;
			if (flag)
			{
				result = int.MinValue;
			}
			else
			{
				bool flag2 = value > 2147483647L;
				if (flag2)
				{
					result = int.MaxValue;
				}
				else
				{
					result = (int)value;
				}
			}
			return result;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00008FCC File Offset: 0x000071CC
		internal static float RoundToMultipleOf(float value, float roundingValue)
		{
			bool flag = roundingValue == 0f;
			float result;
			if (flag)
			{
				result = value;
			}
			else
			{
				result = Mathf.Round(value / roundingValue) * roundingValue;
			}
			return result;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00008FF8 File Offset: 0x000071F8
		internal static float GetClosestPowerOfTen(float positiveNumber)
		{
			bool flag = positiveNumber <= 0f;
			float result;
			if (flag)
			{
				result = 1f;
			}
			else
			{
				result = Mathf.Pow(10f, (float)Mathf.RoundToInt(Mathf.Log10(positiveNumber)));
			}
			return result;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00009038 File Offset: 0x00007238
		internal static int GetNumberOfDecimalsForMinimumDifference(float minDifference)
		{
			return Mathf.Clamp(-Mathf.FloorToInt(Mathf.Log10(Mathf.Abs(minDifference))), 0, 15);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00009064 File Offset: 0x00007264
		internal static int GetNumberOfDecimalsForMinimumDifference(double minDifference)
		{
			return (int)Math.Max(0.0, -Math.Floor(Math.Log10(Math.Abs(minDifference))));
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00009098 File Offset: 0x00007298
		internal static float RoundBasedOnMinimumDifference(float valueToRound, float minDifference)
		{
			bool flag = minDifference == 0f;
			float result;
			if (flag)
			{
				result = Mathf.DiscardLeastSignificantDecimal(valueToRound);
			}
			else
			{
				result = (float)Math.Round((double)valueToRound, Mathf.GetNumberOfDecimalsForMinimumDifference(minDifference), MidpointRounding.AwayFromZero);
			}
			return result;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000090D0 File Offset: 0x000072D0
		internal static double RoundBasedOnMinimumDifference(double valueToRound, double minDifference)
		{
			bool flag = minDifference == 0.0;
			double result;
			if (flag)
			{
				result = Mathf.DiscardLeastSignificantDecimal(valueToRound);
			}
			else
			{
				result = Math.Round(valueToRound, Mathf.GetNumberOfDecimalsForMinimumDifference(minDifference), MidpointRounding.AwayFromZero);
			}
			return result;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00009108 File Offset: 0x00007308
		internal static float DiscardLeastSignificantDecimal(float v)
		{
			int digits = Mathf.Clamp((int)(5f - Mathf.Log10(Mathf.Abs(v))), 0, 15);
			return (float)Math.Round((double)v, digits, MidpointRounding.AwayFromZero);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00009140 File Offset: 0x00007340
		internal static double DiscardLeastSignificantDecimal(double v)
		{
			int digits = Math.Max(0, (int)(5.0 - Math.Log10(Math.Abs(v))));
			double result;
			try
			{
				result = Math.Round(v, digits);
			}
			catch (ArgumentOutOfRangeException)
			{
				result = 0.0;
			}
			return result;
		}

		// Token: 0x0400008D RID: 141
		public const float PI = 3.1415927f;

		// Token: 0x0400008E RID: 142
		public const float Infinity = float.PositiveInfinity;

		// Token: 0x0400008F RID: 143
		public const float NegativeInfinity = float.NegativeInfinity;

		// Token: 0x04000090 RID: 144
		public const float Deg2Rad = 0.017453292f;

		// Token: 0x04000091 RID: 145
		public const float Rad2Deg = 57.29578f;

		// Token: 0x04000092 RID: 146
		internal const int kMaxDecimals = 15;
	}
}
