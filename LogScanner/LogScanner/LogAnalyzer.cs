class LogAnalyzer : ILogAnalyzer
{
	public bool AnalyzeLogs(string[] logs, string targetWord)
	{
		bool wordFound = false;

		for (int i = 0; i < logs.Length; i++)
		{
			if (logs[i].Contains(targetWord, StringComparison.OrdinalIgnoreCase))
			{
				Console.WriteLine($"Line {i + 1}: {logs[i]}");
				wordFound = true;
			}
		}

		return wordFound;
	}
}
