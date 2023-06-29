class Program
{
	private static readonly IFileReader fileReader = new FileReader();
	private static readonly ILogAnalyzer logAnalyzer = new LogAnalyzer();

	static void Main(string[] args)
	{
		string filePath;
		string targetWord;
		bool exitRequested = false;

		do
		{
			if (args.Length < 2)
			{
				Console.WriteLine("Please provide the file path:");
				filePath = Console.ReadLine()!;

				Console.WriteLine("Please provide the target word:");
				targetWord = Console.ReadLine()!;
			}
			else
			{
				filePath = args[0];
				targetWord = args[1];
			}

			try
			{
				string[] logs = fileReader.ReadAllLines(filePath);

				bool wordFound = logAnalyzer.AnalyzeLogs(logs, targetWord);

				if (!wordFound)
				{
					Console.WriteLine("The target word was not found in the logs.");
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("File not found.");
			}
			catch (IOException)
			{
				Console.WriteLine("An error occurred while reading the file.");
			}

			Console.WriteLine("Press 'X' to exit or any other key to search for a new target word.");

			ConsoleKeyInfo keyInfo = Console.ReadKey();
			Console.WriteLine();

			if (keyInfo.Key == ConsoleKey.X)
			{
				exitRequested = true;
			}

		} while (!exitRequested);

		Console.WriteLine("Exiting the program. Press any key to close the console.");
		Console.ReadKey();
	}
}
