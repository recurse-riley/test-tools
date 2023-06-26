using Moq;

[TestClass]
public class ProgramManagerTests
{
	private Mock<ConsoleManager> mockConsoleManager;
	private ProgramManager programManager;

	[TestInitialize]
	public void Initialize()
	{
		mockConsoleManager = new Mock<ConsoleManager>();
		programManager = new ProgramManager(mockConsoleManager.Object);
	}

	[TestMethod]
	public void Run_WhenFileExists_ShouldPrintFileExists()
	{
		// Arrange
		string filePath = "C:\\Path\\To\\ExistingFile.txt";
		mockConsoleManager.SetupSequence(c => c.ReadFilePath())
				.Returns(filePath)
				.Returns("exit"); // Provide "exit" to terminate the program
		mockConsoleManager.Setup(c => c.PrintFileExists());

		// Act
		programManager.Run();

		// Assert
		mockConsoleManager.Verify(c => c.PrintFileExists(), Times.Once);
		mockConsoleManager.Verify(c => c.PrintFileDoesNotExist(), Times.Never);
	}

	[TestMethod]
	public void Run_WhenFileDoesNotExist_ShouldPrintFileDoesNotExist()
	{
		// Arrange
		string filePath = "C:\\Path\\To\\NonExistentFile.txt";
		mockConsoleManager.SetupSequence(c => c.ReadFilePath())
				.Returns(filePath)
				.Returns("exit"); // Provide "exit" to terminate the program
		mockConsoleManager.Setup(c => c.PrintFileDoesNotExist());

		// Act
		programManager.Run();

		// Assert
		mockConsoleManager.Verify(c => c.PrintFileDoesNotExist(), Times.Once);
		mockConsoleManager.Verify(c => c.PrintFileExists(), Times.Never);
	}

	[TestMethod]
	public void Run_WhenExitCommand_ShouldTerminateProgram()
	{
		// Arrange
		mockConsoleManager.SetupSequence(c => c.ReadFilePath())
				.Returns("exit"); // Provide "exit" to terminate the program

		// Act
		programManager.Run();

		// Assert
		mockConsoleManager.Verify(c => c.PrintFileExists(), Times.Never);
		mockConsoleManager.Verify(c => c.PrintFileDoesNotExist(), Times.Never);
	}

	[TestCleanup]
	public void Cleanup()
	{
		mockConsoleManager.VerifyAll();
	}
}
