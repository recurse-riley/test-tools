using System;
using DriveInfo;

class Program
{
	static void Main()
	{
		Console.WriteLine("Enter the machine name:");
		string machineName = Console.ReadLine();

		Console.WriteLine("Enter your username:");
		string username = Console.ReadLine();

		Console.WriteLine("Enter your password:");
		string password = Console.ReadLine();

		DiskSpaceMonitor monitor = new DiskSpaceMonitor(machineName, username, password);
		monitor.DisplayDiskSpaceInfo();
	}
}