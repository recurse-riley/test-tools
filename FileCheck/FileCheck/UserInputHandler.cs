class UserInputHandler
{
	private readonly FileValidator _fileValidator;

	public UserInputHandler(FileValidator fileValidator)
	{
		_fileValidator = fileValidator;
	}

	public void HandleUserInput(string filePath)
	{
		bool fileExists = _fileValidator.FileExists(filePath);

		if (fileExists)
		{
			Console.WriteLine("File exists.");
		}
		else
		{
			Console.WriteLine("File doesn't exist.");
		}
	}
}
