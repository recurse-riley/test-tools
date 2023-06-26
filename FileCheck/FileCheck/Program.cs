class Program
{
	static void Main(string[] args)
	{
		var fileValidator = new FileValidator();
		var userInputHandler = new UserInputHandler(fileValidator);

		while (true)
		{
			Console.WriteLine("Enter a file path (or 'exit' to quit):");
			string? filePath = Console.ReadLine();

			if (string.IsNullOrEmpty(filePath) || filePath.ToLower() == "exit")
				break;

			userInputHandler.HandleUserInput(filePath);
		}

		Console.WriteLine("Press any key to exit...");
		Console.ReadKey();
	}
}
