namespace ToolBX.EasyTypeParsing;

public record ParsingOptions
{
    public IFormatProvider FormatProvider { get; init; } = CultureInfo.InvariantCulture;
    public NumberStyles NumberStyles { get; init; } = NumberStyles.Any;
    public DateTimeStyles DateStyles { get; init; } = DateTimeStyles.None;
}