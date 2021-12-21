namespace ToolBX.EasyTypeParsing;

public class StringParsingException<T> : Exception
{
    public StringParsingException(string stringValue, Exception innerException) : base($"Can't parse string to {typeof(T).Name} : Its value was {stringValue}", innerException)
    {

    }
}