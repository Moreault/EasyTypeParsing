namespace EasyTypeParsing.Tests.Utilities;

internal static class DateTimeExtensions
{
    public static DateTime TrimMilliseconds(this DateTime dt)
    {
        return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0, dt.Kind);
    }

    public static DateTimeOffset TrimMilliseconds(this DateTimeOffset dt)
    {
        return new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, new TimeSpan());
    }
}