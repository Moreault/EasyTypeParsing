namespace ToolBX.EasyTypeParsing;

public class StringParsingException<T> : Exception
{
    public StringParsingException(string stringValue, Exception? innerException = null) : base(string.Format(ExceptionMessages.ParsingException, stringValue, typeof(T).GetHumanReadableName()), innerException)
    {

    }
}