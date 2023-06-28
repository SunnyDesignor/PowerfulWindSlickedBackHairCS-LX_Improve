using System;
using System.Diagnostics;

namespace PowerfulWindSlickedBackHair.Tools
{
	// Token: 0x0200001E RID: 30
	public class CmdHelper
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x00008600 File Offset: 0x00006800
		public static string ExeCommand(string commandText)
		{
			return CmdHelper.ExeCommand(new string[]
			{
				commandText
			});
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00008624 File Offset: 0x00006824
		public static string ExeCommand(string[] commandTexts)
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			string result = null;
			try
			{
				process.Start();
				foreach (string value in commandTexts)
				{
					process.StandardInput.WriteLine(value);
				}
				process.StandardInput.WriteLine("exit");
				result = process.StandardOutput.ReadToEnd();
				process.WaitForExit();
				process.Close();
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00008710 File Offset: 0x00006910
		public static bool StartApp(string appName)
		{
			return CmdHelper.StartApp(appName, ProcessWindowStyle.Hidden);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000872C File Offset: 0x0000692C
		public static bool StartApp(string appName, ProcessWindowStyle style)
		{
			return CmdHelper.StartApp(appName, null, style);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00008748 File Offset: 0x00006948
		public static bool StartApp(string appName, string arguments)
		{
			return CmdHelper.StartApp(appName, arguments, ProcessWindowStyle.Hidden);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00008764 File Offset: 0x00006964
		public static bool StartApp(string appName, string arguments, ProcessWindowStyle style)
		{
			bool result = false;
			Process process = new Process();
			process.StartInfo.FileName = appName;
			process.StartInfo.WindowStyle = style;
			process.StartInfo.Arguments = arguments;
			try
			{
				process.Start();
				process.WaitForExit();
				process.Close();
				result = true;
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000087D8 File Offset: 0x000069D8
		public static void Rar(string s, string d)
		{
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000087DB File Offset: 0x000069DB
		public static void UnRar(string s, string d)
		{
		}
	}
}
