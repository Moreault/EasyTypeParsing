namespace ToolBX.EasyTypeParsing;

public static class StringParsing
{
    public static T ParseOrThrow<T>(this string value, ParsingOptions? options = null) where T : IComparable, IComparable<T>, IEquatable<T>
    {
        var type = typeof(T);
        if (type == typeof(int))
            return (T)(object)value.ToIntOrThrow(options);
        if (type == typeof(long))
            return (T)(object)value.ToLongOrThrow(options);
        if (type == typeof(float))
            return (T)(object)value.ToFloatOrThrow(options);
        if (type == typeof(double))
            return (T)(object)value.ToDoubleOrThrow(options);
        if (type == typeof(decimal))
            return (T)(object)value.ToDecimalOrThrow(options);
        if (type == typeof(byte))
            return (T)(object)value.ToByteOrThrow(options);
        if (type == typeof(sbyte))
            return (T)(object)value.ToSByteOrThrow(options);
        if (type == typeof(short))
            return (T)(object)value.ToShortOrThrow(options);
        if (type == typeof(char))
            return (T)(object)value.ToCharOrThrow();
        if (type == typeof(uint))
            return (T)(object)value.ToUIntOrThrow(options);
        if (type == typeof(ulong))
            return (T)(object)value.ToULongOrThrow(options);
        if (type == typeof(ushort))
            return (T)(object)value.ToUShortOrThrow(options);
        if (type == typeof(bool))
            return (T)(object)value.ToBoolOrThrow();
        if (type == typeof(DateTime))
            return (T)(object)value.ToDateTimeOrThrow(options);
        if (type == typeof(DateTimeOffset))
            return (T)(object)value.ToDateTimeOffsetOrThrow(options);
        if (type == typeof(Version))
            return (T)(object)value.ToVersionOrThrow();
        if (type == typeof(TimeSpan))
            return (T)(object)value.ToTimeSpanOrThrow(options);
        if (type == typeof(Guid))
            return (T)(object)value.ToGuidOrThrow();
        if (type == typeof(BigInteger))
            return (T)(object)value.ToBigIntegerOrThrow(options);

        throw new NotSupportedException($"Can't parse string to {typeof(T).Name} : {typeof(T).Name} is not supported.");
    }

    public static T? ParseOrDefault<T>(this string value, T? defaultValue = default, ParsingOptions? options = null) where T : IComparable, IComparable<T>, IEquatable<T>
    {
        var type = typeof(T);
        if (type == typeof(int))
            return (T)(object)value.ToIntOrDefault((int)(object)defaultValue!, options);
        if (type == typeof(long))
            return (T)(object)value.ToLongOrDefault((long)(object)defaultValue!, options);
        if (type == typeof(float))
            return (T)(object)value.ToFloatOrDefault((float)(object)defaultValue!, options);
        if (type == typeof(double))
            return (T)(object)value.ToDoubleOrDefault((double)(object)defaultValue!, options);
        if (type == typeof(decimal))
            return (T)(object)value.ToDecimalOrDefault((decimal)(object)defaultValue!, options);
        if (type == typeof(byte))
            return (T)(object)value.ToByteOrDefault((byte)(object)defaultValue!, options);
        if (type == typeof(sbyte))
            return (T)(object)value.ToSByteOrDefault((sbyte)(object)defaultValue!, options);
        if (type == typeof(short))
            return (T)(object)value.ToShortOrDefault((short)(object)defaultValue!, options);
        if (type == typeof(char))
            return (T)(object)value.ToCharOrDefault((char)(object)defaultValue!);
        if (type == typeof(uint))
            return (T)(object)value.ToUIntOrDefault((uint)(object)defaultValue!, options);
        if (type == typeof(ulong))
            return (T)(object)value.ToULongOrDefault((ulong)(object)defaultValue!, options);
        if (type == typeof(ushort))
            return (T)(object)value.ToUShortOrDefault((ushort)(object)defaultValue!, options);
        if (type == typeof(bool))
            return (T)(object)value.ToBoolOrDefault((bool)(object)defaultValue!);
        if (type == typeof(DateTime))
            return (T)(object)value.ToDateTimeOrDefault((DateTime)(object)defaultValue!, options);
        if (type == typeof(DateTimeOffset))
            return (T)(object)value.ToDateTimeOffsetOrDefault((DateTimeOffset)(object)defaultValue!, options);
        if (type == typeof(Version))
        {
            var parsed = value.ToVersionOrDefault((Version)(object)defaultValue!);
            return parsed == null ? defaultValue : (T)(object)parsed;
        }
        if (type == typeof(TimeSpan))
            return (T)(object)value.ToTimeSpanOrDefault((TimeSpan)(object)defaultValue!, options);
        if (type == typeof(Guid))
            return (T)(object)value.ToGuidOrDefault((Guid)(object)defaultValue!);
        if (type == typeof(BigInteger))
            return (T)(object)value.ToBigIntegerOrDefault((BigInteger)(object)defaultValue!, options);

        return defaultValue;
    }

    public static Result<T> Parse<T>(this string value, ParsingOptions? options = null) where T : IComparable, IComparable<T>, IEquatable<T>
    {
        var type = typeof(T);
        if (type == typeof(int))
            return (Result<T>)(object)value.ToInt(options);
        if (type == typeof(long))
            return (Result<T>)(object)value.ToLong(options);
        if (type == typeof(float))
            return (Result<T>)(object)value.ToFloat(options);
        if (type == typeof(double))
            return (Result<T>)(object)value.ToDouble(options);
        if (type == typeof(decimal))
            return (Result<T>)(object)value.ToDecimal(options);
        if (type == typeof(byte))
            return (Result<T>)(object)value.ToByte(options);
        if (type == typeof(sbyte))
            return (Result<T>)(object)value.ToSByte(options);
        if (type == typeof(short))
            return (Result<T>)(object)value.ToShort(options);
        if (type == typeof(char))
            return (Result<T>)(object)value.ToChar();
        if (type == typeof(uint))
            return (Result<T>)(object)value.ToUInt(options);
        if (type == typeof(ulong))
            return (Result<T>)(object)value.ToULong(options);
        if (type == typeof(ushort))
            return (Result<T>)(object)value.ToUShort(options);
        if (type == typeof(bool))
            return (Result<T>)(object)value.ToBool();
        if (type == typeof(DateTime))
            return (Result<T>)(object)value.ToDateTime(options);
        if (type == typeof(DateTimeOffset))
            return (Result<T>)(object)value.ToDateTimeOffset(options);
        if (type == typeof(Version))
            return (Result<T>)(object)value.ToVersion();
        if (type == typeof(TimeSpan))
            return (Result<T>)(object)value.ToTimeSpan(options);
        if (type == typeof(Guid))
            return (Result<T>)(object)value.ToGuid();
        if (type == typeof(BigInteger))
            return (Result<T>)(object)value.ToBigInteger(options);

        return Result<T>.Failure();
    }

    public static Result<int> ToInt(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = int.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<int>.Success(parsedValue) : Result<int>.Failure();
    }

    public static int ToIntOrDefault(this string value, int defaultValue = default, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var result = value.ToInt(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static int ToIntOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return int.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<int>(value, e);
        }
    }

    public static Result<int?> ToNullableInt(this string value, ParsingOptions? options = null)
    {
        var result = value.ToInt(options);
        return result.IsSuccess ? Result<int?>.Success(result.Value) : Result<int?>.Failure();
    }

    public static int? ToNullableIntOrDefault(this string value, int? defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToInt(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static Result<T> ToEnum<T>(this string value) where T : struct, Enum
    {
        var isSuccess = Enum.TryParse(value, true, out T parsedValue);
        return isSuccess ? Result<T>.Success(parsedValue) : Result<T>.Failure();
    }

    public static T ToEnumOrDefault<T>(this string value, T defaultValue = default) where T : struct, Enum
    {
        var result = value.ToEnum<T>();
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static Result<T?> ToNullableEnum<T>(this string value) where T : struct, Enum
    {
        var result = value.ToEnum<T>();
        return result.IsSuccess ? Result<T?>.Success(result.Value) : Result<T?>.Failure();
    }

    public static T? ToNullableEnumOrDefault<T>(this string value, T? defaultValue = default) where T : struct, Enum
    {
        var result = value.ToEnum<T>();
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static Result<byte> ToByte(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = byte.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<byte>.Success(parsedValue) : Result<byte>.Failure();
    }

    public static byte ToByteOrDefault(this string value, byte defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToByte(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static byte ToByteOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return byte.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<byte>(value, e);
        }
    }

    public static Result<Guid> ToGuid(this string value)
    {
        var isSuccess = Guid.TryParse(value, out var parsedValue);
        return isSuccess ? Result<Guid>.Success(parsedValue) : Result<Guid>.Failure();
    }

    public static Guid ToGuidOrDefault(this string value, Guid defaultValue = default)
    {
        var result = value.ToGuid();
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static Guid ToGuidOrThrow(this string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        try
        {
            return Guid.Parse(value);
        }
        catch (Exception e)
        {
            throw new StringParsingException<Guid>(value, e);
        }
    }

    public static Result<char> ToChar(this string value)
    {
        var isSuccess = char.TryParse(value, out var parsedValue);
        return isSuccess ? Result<char>.Success(parsedValue) : Result<char>.Failure();
    }

    public static char ToCharOrDefault(this string value, char defaultValue = default)
    {
        var result = value.ToChar();
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static char ToCharOrThrow(this string value)
    {
        if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
        try
        {
            return char.Parse(value);
        }
        catch (Exception e)
        {
            throw new StringParsingException<char>(value, e);
        }
    }

    public static Result<long> ToLong(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = long.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<long>.Success(parsedValue) : Result<long>.Failure();
    }

    public static long ToLongOrDefault(this string value, long defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToLong(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static long ToLongOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return long.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<long>(value, e);
        }
    }

    public static Result<sbyte> ToSByte(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = sbyte.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<sbyte>.Success(parsedValue) : Result<sbyte>.Failure();
    }

    public static sbyte ToSByteOrDefault(this string value, sbyte defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToSByte(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static sbyte ToSByteOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return sbyte.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<sbyte>(value, e);
        }
    }

    public static Result<short> ToShort(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = short.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<short>.Success(parsedValue) : Result<short>.Failure();
    }

    public static short ToShortOrDefault(this string value, short defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToShort(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static short ToShortOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return short.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<short>(value, e);
        }
    }

    public static Result<uint> ToUInt(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = uint.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<uint>.Success(parsedValue) : Result<uint>.Failure();
    }

    public static uint ToUIntOrDefault(this string value, uint defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToUInt(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static uint ToUIntOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return uint.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<uint>(value, e);
        }
    }

    public static Result<ulong> ToULong(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = ulong.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<ulong>.Success(parsedValue) : Result<ulong>.Failure();
    }

    public static ulong ToULongOrDefault(this string value, ulong defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToULong(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static ulong ToULongOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return ulong.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<ulong>(value, e);
        }
    }

    public static Result<ushort> ToUShort(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = ushort.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<ushort>.Success(parsedValue) : Result<ushort>.Failure();
    }

    public static ushort ToUShortOrDefault(this string value, ushort defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToUShort(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static ushort ToUShortOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return ushort.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<ushort>(value, e);
        }
    }

    public static Result<float> ToFloat(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = float.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<float>.Success(parsedValue) : Result<float>.Failure();
    }

    public static float ToFloatOrDefault(this string value, float defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToFloat(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static float ToFloatOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return float.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<float>(value, e);
        }
    }

    public static Result<double> ToDouble(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = double.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<double>.Success(parsedValue) : Result<double>.Failure();
    }

    public static double ToDoubleOrDefault(this string value, double defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToDouble(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static double ToDoubleOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return double.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<double>(value, e);
        }
    }

    public static Result<bool> ToBool(this string value)
    {
        var isSuccess = bool.TryParse(value, out var parsedValue);
        return isSuccess ? Result<bool>.Success(parsedValue) : Result<bool>.Failure();
    }

    public static bool ToBoolOrDefault(this string value, bool defaultValue = default)
    {
        var result = value.ToBool();
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static bool ToBoolOrThrow(this string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        try
        {
            return bool.Parse(value);
        }
        catch (Exception e)
        {
            throw new StringParsingException<bool>(value, e);
        }
    }

    public static Result<decimal> ToDecimal(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = decimal.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<decimal>.Success(parsedValue) : Result<decimal>.Failure();
    }

    public static decimal ToDecimalOrDefault(this string value, decimal defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToDecimal(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static decimal ToDecimalOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return decimal.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<decimal>(value, e);
        }
    }

    public static Result<DateTime> ToDateTime(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = DateTime.TryParse(value, options.FormatProvider, options.DateStyles, out var parsedValue);
        return isSuccess ? Result<DateTime>.Success(parsedValue) : Result<DateTime>.Failure();
    }

    public static DateTime ToDateTimeOrDefault(this string value, DateTime defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToDateTime(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static DateTime ToDateTimeOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return DateTime.Parse(value, options.FormatProvider, options.DateStyles);
        }
        catch (Exception e)
        {
            throw new StringParsingException<DateTime>(value, e);
        }
    }

    public static Result<TimeSpan> ToTimeSpan(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = TimeSpan.TryParse(value, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<TimeSpan>.Success(parsedValue) : Result<TimeSpan>.Failure();
    }

    public static TimeSpan ToTimeSpanOrDefault(this string value, TimeSpan defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToTimeSpan(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static TimeSpan ToTimeSpanOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return TimeSpan.Parse(value, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<TimeSpan>(value, e);
        }
    }

    public static Result<DateTimeOffset> ToDateTimeOffset(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = DateTimeOffset.TryParse(value, options.FormatProvider, options.DateStyles, out var parsedValue);
        return isSuccess ? Result<DateTimeOffset>.Success(parsedValue) : Result<DateTimeOffset>.Failure();
    }

    public static DateTimeOffset ToDateTimeOffsetOrDefault(this string value, DateTimeOffset defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToDateTimeOffset(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static DateTimeOffset ToDateTimeOffsetOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return DateTimeOffset.Parse(value, options.FormatProvider, options.DateStyles);
        }
        catch (Exception e)
        {
            throw new StringParsingException<DateTimeOffset>(value, e);
        }
    }

    public static Result<Version> ToVersion(this string value)
    {
        var isSuccess = Version.TryParse(value, out var parsedValue);
        return isSuccess ? Result<Version>.Success(parsedValue!) : Result<Version>.Failure();
    }

    public static Version? ToVersionOrDefault(this string value, Version? defaultValue = default)
    {
        var result = value.ToVersion();
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static Version ToVersionOrThrow(this string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        try
        {
            return Version.Parse(value);
        }
        catch (Exception e)
        {
            throw new StringParsingException<Version>(value, e);
        }
    }

    public static Result<IPAddress> ToIpAddress(this string value)
    {
        var isSuccess = IPAddress.TryParse(value, out var parsedValue);
        return isSuccess ? Result<IPAddress>.Success(parsedValue!) : Result<IPAddress>.Failure();
    }

    public static IPAddress? ToIpAddressOrDefault(this string value, IPAddress? defaultValue = default)
    {
        var result = value.ToIpAddress();
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static IPAddress ToIpAddressOrThrow(this string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        try
        {
            return IPAddress.Parse(value);
        }
        catch (Exception e)
        {
            throw new StringParsingException<IPAddress>(value, e);
        }
    }

    public static Result<BigInteger> ToBigInteger(this string value, ParsingOptions? options = null)
    {
        options ??= new ParsingOptions();
        var isSuccess = BigInteger.TryParse(value, options.NumberStyles, options.FormatProvider, out var parsedValue);
        return isSuccess ? Result<BigInteger>.Success(parsedValue) : Result<BigInteger>.Failure();
    }

    public static BigInteger ToBigIntegerOrDefault(this string value, BigInteger defaultValue = default, ParsingOptions? options = null)
    {
        var result = value.ToBigInteger(options);
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static BigInteger ToBigIntegerOrThrow(this string value, ParsingOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        options ??= new ParsingOptions();
        try
        {
            return BigInteger.Parse(value, options.NumberStyles, options.FormatProvider);
        }
        catch (Exception e)
        {
            throw new StringParsingException<BigInteger>(value, e);
        }
    }
}