using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Kohl.Framework.Info
{
	public static class MachineInfo
	{
		public static string Build
		{
			get
			{
				string value;
				try
				{
					value = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion", "BuildLabEx", null);
				}
				catch
				{
					value = null;
				}
				return value;
			}
		}

		public static string BuildGuid
		{
			get
			{
				string value;
				try
				{
					value = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion", "BuildGUID", null);
				}
				catch
				{
					value = null;
				}
				return value;
			}
		}

		public static string ClientOrServer
		{
			get
			{
				string value;
				try
				{
					value = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion", "InstallationType", null);
				}
				catch
				{
					value = null;
				}
				return value;
			}
		}

		public static string CompanyName
		{
			get
			{
				string str;
				try
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = (new ManagementClass("Win32_OperatingSystem")).GetInstances().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							str = ((ManagementObject)enumerator.Current)["Organization"].ToString();
							return str;
						}
					}
					str = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion", "RegisteredOrganization", null);
				}
				catch
				{
					str = null;
				}
				return str;
			}
		}

		public static string EditionID
		{
			get
			{
				string value;
				try
				{
					value = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion", "EditionID", null);
				}
				catch
				{
					value = null;
				}
				return value;
			}
		}

		public static string ExternalIp
		{
			get
			{
				string str;
				try
				{
					string str1 = (new WebClient()).DownloadString("http://ip.kohl.bz");
					if (string.IsNullOrEmpty(str1) || str1 == "unknown")
					{
						str = null;
					}
					else
					{
						str = str1;
					}
				}
				catch
				{
					str = null;
				}
				return str;
			}
		}

		public static string HardwareID
		{
			get
			{
				string hardwareID;
				try
				{
					hardwareID = (new MachineInfo.HardwareHelper()).GetHardwareID();
				}
				catch
				{
					hardwareID = null;
				}
				return hardwareID;
			}
		}

		public static DateTime InstallDate
		{
			get
			{
				DateTime dateTime;
				try
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = (new ManagementClass("Win32_OperatingSystem")).GetInstances().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							ManagementObject current = (ManagementObject)enumerator.Current;
							dateTime = ManagementDateTimeConverter.ToDateTime(current["InstallDate"].ToString());
							return dateTime;
						}
					}
					dateTime = DateTime.MinValue;
				}
				catch
				{
					dateTime = DateTime.MinValue;
				}
				return dateTime;
			}
		}

		public static bool InternetConnection
		{
			get
			{
				bool flag;
				try
				{
					string str = (new WebClient()).DownloadString("http://services.kohl.bz/check.htm");
					if (!string.IsNullOrEmpty(str))
					{
						flag = (str != "1" ? false : true);
					}
					else
					{
						flag = false;
					}
				}
				catch
				{
					flag = false;
				}
				return flag;
			}
		}

		public static string[] IPAddresses
		{
			get
			{
				List<string> strs = new List<string>();
				NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
				for (int i = 0; i < (int)allNetworkInterfaces.Length; i++)
				{
					foreach (UnicastIPAddressInformation unicastAddress in allNetworkInterfaces[i].GetIPProperties().UnicastAddresses)
					{
						if (!(unicastAddress.Address.ToString() != "::1") || !(unicastAddress.Address.ToString() != "127.0.0.1"))
						{
							continue;
						}
						strs.Add(unicastAddress.Address.ToString());
					}
				}
				return strs.ToArray();
			}
		}

		public static bool Is64BitOperatingSystem
		{
			get
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					return true;
				}
				if (DeveloperTools.DoesWin32MethodExist("kernel32.dll", "IsWow64Process") && MachineInfo.IsWow64Process(MachineInfo.GetCurrentProcess(), out flag))
				{
					return flag;
				}
				return false;
			}
		}

		public static string MachineDomain
		{
			get
			{
				return IPGlobalProperties.GetIPGlobalProperties().DomainName;
			}
		}

		public static IDictionary MachineEnvironmentVariables
		{
			get
			{
				return Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
			}
		}

		public static string MachineName
		{
			get
			{
				string hostName = Dns.GetHostName();
				if (hostName.Contains(MachineInfo.MachineDomain))
				{
					hostName = hostName.Replace(string.Concat(".", MachineInfo.MachineDomain), "");
					hostName = hostName.Replace(string.Concat("@", MachineInfo.MachineDomain), "");
				}
				return hostName;
			}
		}

		public static IDictionary ProcessEnvironmentVariables
		{
			get
			{
				return Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
			}
		}

		public static int ProcessorCount
		{
			get
			{
				return Environment.ProcessorCount;
			}
		}

		public static string ProcessorId
		{
			get
			{
				string str;
				try
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = (new ManagementClass("Win32_Processor")).GetInstances().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							str = ((ManagementObject)enumerator.Current)["ProcessorId"].ToString();
							return str;
						}
					}
					str = null;
				}
				catch
				{
					str = null;
				}
				return str;
			}
		}

		public static string ProductId
		{
			get
			{
				string str;
				try
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = (new ManagementClass("Win32_OperatingSystem")).GetInstances().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							str = ((ManagementObject)enumerator.Current)["SerialNumber"].ToString();
							return str;
						}
					}
					str = null;
				}
				catch
				{
					str = null;
				}
				return str;
			}
		}

		public static string ProductName
		{
			get
			{
				string str;
				try
				{
					string value = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion", "ProductName", string.Empty);
					if (!string.IsNullOrEmpty(value))
					{
						string value1 = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion", "CSDVersion", string.Empty);
						if (string.IsNullOrEmpty(value1))
						{
							str = value;
						}
						else if (!value.Contains(value1))
						{
							value = string.Concat(value, " ", value1);
							str = value;
						}
						else
						{
							str = value;
						}
					}
					else
					{
						str = null;
					}
				}
				catch
				{
					str = null;
				}
				return str;
			}
		}

		public static string RegisteredOwner
		{
			get
			{
				string value;
				try
				{
					value = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion", "RegisteredOwner", null);
				}
				catch
				{
					value = null;
				}
				return value;
			}
		}

		public static IDictionary UserEnvironmentVariables
		{
			get
			{
				return Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);
			}
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern IntPtr GetCurrentProcess();

		[DllImport("kernel32.dll", CharSet=CharSet.Auto, ExactSpelling=false, SetLastError=true)]
		private static extern bool IsWow64Process(IntPtr process, out bool wow64Process);

		private class HardwareHelper
		{
			private readonly char[] _alphabet;

			public HardwareHelper()
			{
				this._alphabet = new char[36];
				for (int i = 0; i < 26; i++)
				{
					this._alphabet[i] = Convert.ToChar(i + Convert.ToInt16('A'));
				}
				for (int j = 0; j < 10; j++)
				{
					this._alphabet[j + 26] = Convert.ToChar(j + Convert.ToInt16('0'));
				}
			}

			private char bin5ToB36(string w5)
			{
				int num = Convert.ToInt16(w5, 2);
				return this._alphabet[num];
			}

			private string encodeText(string s)
			{
				char chr = Convert.ToChar(10);
				string str = s.Replace(chr.ToString(), string.Empty);
				string empty = string.Empty;
				for (int i = 0; i < str.Length; i++)
				{
					empty = string.Concat(empty, MachineInfo.HardwareHelper.intToBin((int)Convert.ToByte(str[i]), 7));
				}
				string empty1 = string.Empty;
				while (empty.Length > 0)
				{
					string str1 = MachineInfo.HardwareHelper.safeSubstring(empty, 0, 5);
					str1 = str1.PadRight(5, '0');
					empty1 = string.Concat(empty1, this.bin5ToB36(str1));
					empty = MachineInfo.HardwareHelper.safeSubstring(empty, 5, 0);
				}
				return empty1;
			}

			[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
			private static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);

			private static ulong getDiskSize()
			{
				ulong num;
				ulong num1;
				ulong num2;
				MachineInfo.HardwareHelper.GetDiskFreeSpaceEx(string.Format("{0}:\\", Environment.SystemDirectory.Substring(0, 1)), out num, out num1, out num2);
				return num1;
			}

			public string GetHardwareID()
			{
				int volumeSerial = MachineInfo.HardwareHelper.getVolumeSerial(Environment.SystemDirectory.Substring(0, 1));
				object obj = volumeSerial;
				ulong diskSize = MachineInfo.HardwareHelper.getDiskSize();
				string str = this.getHash(string.Concat(obj, diskSize.ToString())).Substring(2, 6);
				str = string.Concat(str, this.getHash(str).Substring(5, 2));
				str = MachineInfo.HardwareHelper.separateText(str, 4, "-");
				return str;
			}

			private string getHash(string s)
			{
				return this.encodeText(MachineInfo.HardwareHelper.getHashValue(s));
			}

			private static string getHashValue(string s)
			{
				if (string.IsNullOrEmpty(s))
				{
					return "5CACAD0D1C88626D74B30C1ADC2951E8";
				}
				MD5 mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
				byte[] bytes = Encoding.Default.GetBytes(s);
				string str = BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(bytes));
				return str.Replace("-", string.Empty).ToUpperInvariant();
			}

			[DllImport("Kernel32.dll", CharSet=CharSet.Auto, ExactSpelling=false, SetLastError=true)]
			private static extern bool GetVolumeInformation(string rootPathName, StringBuilder volumeNameBuffer, int volumeNameSize, out int volumeSerialNumber, out uint maximumComponentLength, out uint fileSystemFlags, StringBuilder fileSystemNameBuffer, int nFileSystemNameSize);

			private static int getVolumeSerial(string drive)
			{
				int num;
				uint num1;
				uint num2;
				StringBuilder stringBuilder = new StringBuilder(300);
				StringBuilder stringBuilder1 = new StringBuilder(300);
				MachineInfo.HardwareHelper.GetVolumeInformation(string.Format("{0}:\\", drive), stringBuilder, stringBuilder.Capacity, out num, out num1, out num2, stringBuilder1, stringBuilder1.Capacity);
				return num;
			}

			private static string intToBin(int number, int numBits)
			{
				char[] chrArray = new char[numBits];
				int num = numBits - 1;
				for (int i = 0; i < numBits; i++)
				{
					if ((number & 1 << (i & 31)) == 0)
					{
						chrArray[num] = '0';
					}
					else
					{
						chrArray[num] = '1';
					}
					num--;
				}
				return new string(chrArray);
			}

			private static string safeSubstring(string s, int start, int length)
			{
				if (length == 0)
				{
					length = s.Length - start;
				}
				if (length < 0)
				{
					length = 0;
				}
				if (start > s.Length)
				{
					return string.Empty;
				}
				if (start < 0)
				{
					start = 0;
				}
				if (start + length > s.Length)
				{
					return s.Substring(start);
				}
				return s.Substring(start, length);
			}

			private static string separateText(string s, int numChars, string separator)
			{
				string empty = string.Empty;
				int num = 0;
				for (int i = 0; i < s.Length; i++)
				{
					if (num != 0 && num % numChars == 0)
					{
						empty = string.Concat(empty, separator);
					}
					empty = string.Concat(empty, s[i]);
					num++;
				}
				return empty;
			}
		}
	}
}