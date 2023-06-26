class FileValidator
{
	public bool FileExists(string filePath)
	{
		return File.Exists(filePath);
	}
}
