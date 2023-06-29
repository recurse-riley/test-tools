# Log Analyzer

Log Analyzer is a console application written in C# that allows you to analyze a text file for occurrences of a specific word. It reads the contents of the file and outputs the lines that contain the target word. You can continue searching for new target words or exit the program.

## Prerequisites

- .NET 6.0 SDK or runtime
- Console or terminal application to run the program

## Usage

1. Clone the repository or download the source code files.

2. Open a console or terminal and navigate to the program's directory.

3. Build the program using the following command: `dotnet build`

4. Run the program with the following command: `dotnet run -- [file path] [target word]`

Replace `[file path]` with the path to the text file you want to analyze, and `[target word]` with the word you want to search for.

Alternatively, you can run the program without command-line arguments. In this case, the program will prompt you to provide the file path and target word interactively.

1. The program will analyze the file and output the lines that contain the target word. After the analysis, you will be prompted to press 'X' to exit or any other key to search for a new word.

2. If you choose to search for a new word, you will be prompted again for the file path and target word. The program will repeat the analysis process.

3. To exit the program, press 'X' when prompted.

4. Press any key to close the console when you are finished.

## Additional Notes

- If the specified file is not found or if an error occurs while reading the file, the program will display an appropriate error message.

- The search for the target word is case-insensitive, meaning it will match regardless of the word's casing.

- The program displays the line number and the content of each line that contains the target word.

- You can search for multiple words consecutively during the program's execution.

- The program provides a way to exit the program at any time by pressing 'X'.

## License

This program is released under the MIT License. See [MIT LICENSE](https://opensource.org/license/mit/) for more information.

Feel free to modify and extend the program according to your needs.

## Contributing

Contributions to this program are closed. If you find any issues or have suggestions for improvements, please open an issue.

## Author

Jason Riley
