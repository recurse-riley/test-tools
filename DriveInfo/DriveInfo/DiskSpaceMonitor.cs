using System;
using System.Linq;
using System.Management;

namespace DriveInfo
{
	public class DiskSpaceMonitor : IDiskSpaceMonitor
	{
		private readonly string _machineName;
		private readonly string _username;
		private readonly string _password;

		public DiskSpaceMonitor(string machineName, string username, string password)
		{
			_machineName = machineName;
			_username = username;
			_password = password;
		}

		public void DisplayDiskSpaceInfo()
		{
			ConnectionOptions options = new ConnectionOptions
			{
				Username = _username,
				Password = _password
			};

			ManagementScope scope = new ManagementScope($"\\\\{_machineName}\\root\\cimv2", options);
			scope.Connect();

			ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_LogicalDisk");
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

			foreach (ManagementObject disk in searcher.Get().Cast<ManagementObject>())
			{
				double freeSpaceGB = Convert.ToDouble(disk["FreeSpace"]) / 1024 / 1024 / 1024;
				double totalSizeGB = Convert.ToDouble(disk["Size"]) / 1024 / 1024 / 1024;

				Console.WriteLine($"Drive: {disk["Name"]}");
				Console.WriteLine($"Free Space: {freeSpaceGB:F2} GB");
				Console.WriteLine($"Total Size: {totalSizeGB:F2} GB");
				Console.WriteLine();
			}
		}
	}
}