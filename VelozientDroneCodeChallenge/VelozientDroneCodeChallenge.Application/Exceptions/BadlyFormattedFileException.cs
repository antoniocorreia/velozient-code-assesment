namespace VelozientDroneCodeChallenge.Application.Exceptions;

public class BadlyFormattedFileException : Exception
{
    public BadlyFormattedFileException() :base() { }
    
    public BadlyFormattedFileException(string type) : base($"No matches for {type} were found.") { }
}
