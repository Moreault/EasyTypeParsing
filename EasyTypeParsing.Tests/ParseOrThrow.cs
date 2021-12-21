namespace EasyTypeParsing.Tests;

[TestClass]
public class ParseOrThrow : Tester
{
    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void WhenValueIsNullOrWhiteSpace_Throw(string value)
    {
        //Arrange

        //Act
        Action action = () => value.ParseOrThrow<int>();

        //Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void WhenConvertingToIntAndStringIsNegativeInt_ReturnAsInt()
    {
        //Arrange
        var parsed = -Fixture.Create<int>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<int>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToIntAndStringIsPositiveInt_ReturnAsInt()
    {
        //Arrange
        var parsed = Fixture.Create<int>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<int>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToIntAndStringIsBiggerThanIntUpperLimit_Throw()
    {
        //Arrange
        var value = ((long)int.MaxValue + 1).ToString();

        //Act
        Action action = () => value.ParseOrThrow<int>();

        //Assert
        action.Should().Throw<StringParsingException<int>>().WithMessage($"Can't parse string to {nameof(Int32)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToIntAndStringIsLesserThanIntLowerLimit_Throw()
    {
        //Arrange
        var value = ((long)int.MinValue - 1).ToString();

        //Act
        Action action = () => value.ParseOrThrow<int>();

        //Assert
        action.Should().Throw<StringParsingException<int>>().WithMessage($"Can't parse string to {nameof(Int32)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToIntAndStringIsNotNumeric_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<int>();

        //Assert
        action.Should().Throw<StringParsingException<int>>().WithMessage($"Can't parse string to {nameof(Int32)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToIntAndStringHasFloatingPoint_Throw()
    {
        //Arrange
        var value = $"{Fixture.Create<int>()}.{Fixture.Create<int>()}";

        //Act
        Action action = () => value.ParseOrThrow<int>();

        //Assert
        action.Should().Throw<StringParsingException<int>>().WithMessage($"Can't parse string to {nameof(Int32)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToLongAndStringIsNegativeLong_ReturnAsLong()
    {
        //Arrange
        var parsed = -Fixture.Create<long>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<long>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToLongAndStringIsPositiveLong_ReturnAsLong()
    {
        //Arrange
        var parsed = Fixture.Create<long>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<long>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToLongAndStringIsNotNumeric_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<long>();

        //Assert
        action.Should().Throw<StringParsingException<long>>().WithMessage($"Can't parse string to {nameof(Int64)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToLongAndStringHasFloatingPoLong_Throw()
    {
        //Arrange
        var value = $"{Fixture.Create<long>()}.{Fixture.Create<long>()}";

        //Act
        Action action = () => value.ParseOrThrow<long>();

        //Assert
        action.Should().Throw<StringParsingException<long>>().WithMessage($"Can't parse string to {nameof(Int64)} : Its value was {value}");
    }


    [TestMethod]
    public void WhenConvertingToFloatAndStringIsNegativeFloat_ReturnAsFloat()
    {
        //Arrange
        var parsed = -Fixture.Create<float>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ParseOrThrow<float>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndStringIsPositiveFloat_ReturnAsFloat()
    {
        //Arrange
        var parsed = Fixture.Create<float>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ParseOrThrow<float>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndStringIsBiggerThanFloatUpperLimit_ReturnPositiveInfinity()
    {
        //Arrange
        var value = "92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.ParseOrThrow<float>();

        //Assert
        result.Should().Be(float.PositiveInfinity);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndStringIsLesserThanFloatLowerLimit_ReturnNegativeInfinity()
    {
        //Arrange
        var value = "-92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.ParseOrThrow<float>();

        //Assert
        result.Should().Be(float.NegativeInfinity);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndStringIsNotNumeric_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<float>();

        //Assert
        action.Should().Throw<StringParsingException<float>>().WithMessage($"Can't parse string to {nameof(Single)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToFloatAndStringHasFloatingPoint_ReturnParsed()
    {
        //Arrange
        var parsed = Fixture.Create<float>() + Fixture.Create<float>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ParseOrThrow<float>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndStringIsNegativeDouble_ReturnAsDouble()
    {
        //Arrange
        var parsed = -Fixture.Create<double>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ParseOrThrow<double>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndStringIsPositiveDouble_ReturnAsDouble()
    {
        //Arrange
        var parsed = Fixture.Create<double>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ParseOrThrow<double>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndStringIsBiggerThanDoubleUpperLimit_ReturnPositiveInfinity()
    {
        //Arrange
        var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.ParseOrThrow<double>();

        //Assert
        result.Should().Be(double.PositiveInfinity);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndStringIsLesserThanDoubleLowerLimit_ReturnNegativeInfinity()
    {
        //Arrange
        var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.ParseOrThrow<double>();

        //Assert
        result.Should().Be(double.NegativeInfinity);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndStringIsNotNumeric_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<double>();

        //Assert
        action.Should().Throw<StringParsingException<double>>().WithMessage($"Can't parse string to {nameof(Double)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndStringHasFloatingPoint_ReturnParsed()
    {
        //Arrange
        var parsed = Fixture.Create<double>() + Fixture.Create<double>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ParseOrThrow<double>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndStringIsNegativeDecimal_ReturnAsDecimal()
    {
        //Arrange
        var parsed = -Fixture.Create<decimal>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ParseOrThrow<decimal>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndStringIsPositiveDecimal_ReturnAsDecimal()
    {
        //Arrange
        var parsed = Fixture.Create<decimal>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ParseOrThrow<decimal>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndStringIsBiggerThanDecimalUpperLimit_ReturnPositiveInfinity()
    {
        //Arrange
        var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        Action action = () => value.ParseOrThrow<decimal>();

        //Assert
        action.Should().Throw<StringParsingException<decimal>>().WithMessage($"Can't parse string to {nameof(Decimal)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndStringIsLesserThanDecimalLowerLimit_ReturnNegativeInfinity()
    {
        //Arrange
        var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        Action action = () => value.ParseOrThrow<decimal>();

        //Assert
        action.Should().Throw<StringParsingException<decimal>>().WithMessage($"Can't parse string to {nameof(Decimal)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndStringIsNotNumeric_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<decimal>();

        //Assert
        action.Should().Throw<StringParsingException<decimal>>().WithMessage($"Can't parse string to {nameof(Decimal)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndStringHasFloatingPoint_ReturnParsed()
    {
        //Arrange
        var parsed = Fixture.Create<decimal>() + Fixture.Create<decimal>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ParseOrThrow<decimal>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToByteAndStringIsPositiveByte_ReturnAsByte()
    {
        //Arrange
        var parsed = Fixture.Create<byte>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<byte>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToByteAndStringIsBiggerThanByteUpperLimit_Throw()
    {
        //Arrange
        var value = ((long)byte.MaxValue + 1).ToString();

        //Act
        Action action = () => value.ParseOrThrow<byte>();

        //Assert
        action.Should().Throw<StringParsingException<byte>>().WithMessage($"Can't parse string to {nameof(Byte)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToByteAndStringIsLesserThanByteLowerLimit_Throw()
    {
        //Arrange
        var value = ((long)byte.MinValue - 1).ToString();

        //Act
        Action action = () => value.ParseOrThrow<byte>();

        //Assert
        action.Should().Throw<StringParsingException<byte>>().WithMessage($"Can't parse string to {nameof(Byte)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToByteAndStringIsNotNumeric_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<byte>();

        //Assert
        action.Should().Throw<StringParsingException<byte>>().WithMessage($"Can't parse string to {nameof(Byte)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToByteAndStringHasFloatingPoint_Throw()
    {
        //Arrange
        var value = $"{Fixture.Create<byte>()}.{Fixture.Create<byte>()}";

        //Act
        Action action = () => value.ParseOrThrow<byte>();

        //Assert
        action.Should().Throw<StringParsingException<byte>>().WithMessage($"Can't parse string to {nameof(Byte)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToSByteAndStringIsNegativeSByte_ReturnAsSByte()
    {
        //Arrange
        var parsed = (sbyte)-Fixture.Create<sbyte>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<sbyte>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndStringIsPositiveSByte_ReturnAsSByte()
    {
        //Arrange
        var parsed = Fixture.Create<sbyte>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<sbyte>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndStringIsBiggerThanSByteUpperLimit_Throw()
    {
        //Arrange
        var value = "128";

        //Act
        Action action = () => value.ParseOrThrow<sbyte>();

        //Assert
        action.Should().Throw<StringParsingException<sbyte>>().WithMessage($"Can't parse string to {nameof(SByte)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToSByteAndStringIsLesserThanSByteLowerLimit_Throw()
    {
        //Arrange
        var value = "-129";

        //Act
        Action action = () => value.ParseOrThrow<sbyte>();

        //Assert
        action.Should().Throw<StringParsingException<sbyte>>().WithMessage($"Can't parse string to {nameof(SByte)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToSByteAndStringIsNotNumeric_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<sbyte>();

        //Assert
        action.Should().Throw<StringParsingException<sbyte>>().WithMessage($"Can't parse string to {nameof(SByte)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToSByteAndStringHasFloatingPoint_Throw()
    {
        //Arrange
        var value = $"{Fixture.Create<sbyte>()}.{Fixture.Create<sbyte>()}";

        //Act
        Action action = () => value.ParseOrThrow<sbyte>();

        //Assert
        action.Should().Throw<StringParsingException<sbyte>>().WithMessage($"Can't parse string to {nameof(SByte)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToShortAndStringIsNegativeShort_ReturnAsShort()
    {
        //Arrange
        var parsed = (short)-Fixture.Create<short>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<short>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToShortAndStringIsPositiveShort_ReturnAsShort()
    {
        //Arrange
        var parsed = Fixture.Create<short>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<short>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToShortAndStringIsBiggerThanShortUpperLimit_Throw()
    {
        //Arrange
        var value = "32768";

        //Act
        Action action = () => value.ParseOrThrow<short>();

        //Assert
        action.Should().Throw<StringParsingException<short>>().WithMessage($"Can't parse string to {nameof(Int16)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToShortAndStringIsLesserThanShortLowerLimit_Throw()
    {
        //Arrange
        var value = "-32769";

        //Act
        Action action = () => value.ParseOrThrow<short>();

        //Assert
        action.Should().Throw<StringParsingException<short>>().WithMessage($"Can't parse string to {nameof(Int16)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToShortAndStringIsNotNumeric_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<short>();

        //Assert
        action.Should().Throw<StringParsingException<short>>().WithMessage($"Can't parse string to {nameof(Int16)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToShortAndStringHasFloatingPoint_Throw()
    {
        //Arrange
        var value = $"{Fixture.Create<short>()}.{Fixture.Create<short>()}";

        //Act
        Action action = () => value.ParseOrThrow<short>();

        //Assert
        action.Should().Throw<StringParsingException<short>>().WithMessage($"Can't parse string to {nameof(Int16)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenValueIsWhiteSpace_ReturnAsChar()
    {
        //Arrange
        var value = " ";

        //Act
        var result = value.ParseOrThrow<char>();

        //Assert
        result.Should().Be(' ');
    }

    [TestMethod]
    public void WhenValueIsNotChar_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var action = () => value.ParseOrThrow<char>();

        //Assert
        action.Should().Throw<StringParsingException<char>>().WithMessage($"Can't parse string to {nameof(Char)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenValueIsSingleChar_ReturnAsChar()
    {
        //Arrange
        var parsed = Fixture.Create<char>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<char>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToUIntAndStringIsPositiveUInt_ReturnAsUInt()
    {
        //Arrange
        var parsed = Fixture.Create<uint>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<uint>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToUIntAndStringIsBiggerThanUIntUpperLimit_Throw()
    {
        //Arrange
        var value = "4294967296";

        //Act
        Action action = () => value.ParseOrThrow<uint>();

        //Assert
        action.Should().Throw<StringParsingException<uint>>().WithMessage($"Can't parse string to {nameof(UInt32)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToUIntAndStringIsLesserThanUIntLowerLimit_Throw()
    {
        //Arrange
        var value = "-1";

        //Act
        Action action = () => value.ParseOrThrow<uint>();

        //Assert
        action.Should().Throw<StringParsingException<uint>>().WithMessage($"Can't parse string to {nameof(UInt32)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToUIntAndStringIsNotNumeric_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<uint>();

        //Assert
        action.Should().Throw<StringParsingException<uint>>().WithMessage($"Can't parse string to {nameof(UInt32)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToUIntAndStringHasFloatingPoint_Throw()
    {
        //Arrange
        var value = $"{Fixture.Create<uint>()}.{Fixture.Create<uint>()}";

        //Act
        Action action = () => value.ParseOrThrow<uint>();

        //Assert
        action.Should().Throw<StringParsingException<uint>>().WithMessage($"Can't parse string to {nameof(UInt32)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToULongAndStringIsPositiveULong_ReturnAsULong()
    {
        //Arrange
        var parsed = Fixture.Create<ulong>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<ulong>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToULongAndStringIsBiggerThanULongUpperLimit_Throw()
    {
        //Arrange
        var value = "18446744073709551616";

        //Act
        Action action = () => value.ParseOrThrow<ulong>();

        //Assert
        action.Should().Throw<StringParsingException<ulong>>().WithMessage($"Can't parse string to {nameof(UInt64)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToULongAndStringIsLesserThanULongLowerLimit_Throw()
    {
        //Arrange
        var value = "-1";

        //Act
        Action action = () => value.ParseOrThrow<ulong>();

        //Assert
        action.Should().Throw<StringParsingException<ulong>>().WithMessage($"Can't parse string to {nameof(UInt64)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToULongAndStringIsNotNumeric_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<ulong>();

        //Assert
        action.Should().Throw<StringParsingException<ulong>>().WithMessage($"Can't parse string to {nameof(UInt64)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToLongAndStringHasFloatingPoint_Throw()
    {
        //Arrange
        var value = $"{Fixture.Create<ulong>()}.{Fixture.Create<ulong>()}";

        //Act
        Action action = () => value.ParseOrThrow<ulong>();

        //Assert
        action.Should().Throw<StringParsingException<ulong>>().WithMessage($"Can't parse string to {nameof(UInt64)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToUShortAndStringIsPositiveUShort_ReturnAsUShort()
    {
        //Arrange
        var parsed = Fixture.Create<ushort>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<ushort>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToUShortAndStringIsBiggerThanUShortUpperLimit_Throw()
    {
        //Arrange
        var value = "18446744073709551616";

        //Act
        Action action = () => value.ParseOrThrow<ushort>();

        //Assert
        action.Should().Throw<StringParsingException<ushort>>().WithMessage($"Can't parse string to {nameof(UInt16)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToUShortAndStringIsLesserThanUShortLowerLimit_Throw()
    {
        //Arrange
        var value = "-1";

        //Act
        Action action = () => value.ParseOrThrow<ushort>();

        //Assert
        action.Should().Throw<StringParsingException<ushort>>().WithMessage($"Can't parse string to {nameof(UInt16)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToUShortAndStringIsNotNumeric_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<ushort>();

        //Assert
        action.Should().Throw<StringParsingException<ushort>>().WithMessage($"Can't parse string to {nameof(UInt16)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingToUShortAndStringHasFloatingPoint_Throw()
    {
        //Arrange
        var value = $"{Fixture.Create<ushort>()}.{Fixture.Create<ushort>()}";

        //Act
        Action action = () => value.ParseOrThrow<ushort>();

        //Assert
        action.Should().Throw<StringParsingException<ushort>>().WithMessage($"Can't parse string to {nameof(UInt16)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenValueIsTrue_ReturnTrue()
    {
        //Arrange
        var value = true.ToString();

        //Act
        var result = value.ParseOrThrow<bool>();

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void WhenValueIsTrueInDifferentCaps_ReturnTrue()
    {
        //Arrange
        var value = "TrUe";

        //Act
        var result = value.ParseOrThrow<bool>();

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void WhenValueIsFalse_ReturnFalse()
    {
        //Arrange
        var value = false.ToString();

        //Act
        var result = value.ParseOrThrow<bool>();

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void WhenValueIsFalseInDifferentCaps_ReturnFalse()
    {
        //Arrange
        var value = "FaLsE";

        //Act
        var result = value.ParseOrThrow<bool>();

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void WhenValueIsNotTrueOrFalse_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<bool>();

        //Assert
        action.Should().Throw<StringParsingException<bool>>().WithMessage($"Can't parse string to {nameof(Boolean)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenValueIsValidDateTime_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ParseOrThrow<DateTime>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenValueIsValidDateTime_CorrectlyReApplyMilliseconds()
    {
        //Arrange
        var parsed = new DateTime(2022, 3, 7, 14, 43, 26, 535);
        const string value = "03/07/2022 14:43:26.535";

        //Act
        var result = value.ParseOrThrow<DateTime>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenValueIsNotDateTime_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<DateTime>();

        //Assert
        action.Should().Throw<StringParsingException<DateTime>>().WithMessage($"Can't parse string to {nameof(DateTime)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenValueIsNotUsingSameCultureInfo_Throw()
    {
        //Arrange
        var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        Action action = () => value.ParseOrThrow<DateTime>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        action.Should().Throw<StringParsingException<DateTime>>().WithMessage($"Can't parse string to {nameof(DateTime)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenValueIsUsingSameCultureInfo_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.ParseOrThrow<DateTime>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenValueIsValidDateTimeOffset_ReturnAsDateTimeOffset()
    {
        //Arrange
        var parsed = Fixture.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ParseOrThrow<DateTimeOffset>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenValueIsNotDateTimeOffset_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<DateTimeOffset>();

        //Assert
        action.Should().Throw<StringParsingException<DateTimeOffset>>().WithMessage($"Can't parse string to {nameof(DateTimeOffset)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenConvertingDateTimeOffsetAndValueIsNotUsingSameCultureInfo_Throw()
    {
        //Arrange
        var parsed = Fixture.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        Action action = () => value.ParseOrThrow<DateTimeOffset>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        action.Should().Throw<StringParsingException<DateTimeOffset>>().WithMessage($"Can't parse string to {nameof(DateTimeOffset)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenValueIsUsingSameCultureInfo_ReturnAsDateTimeOffset()
    {
        //Arrange
        var parsed = Fixture.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.ParseOrThrow<DateTimeOffset>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenIsCorrectlyFormattedVersion_ReturnAsVersion()
    {
        //Arrange
        var parsed = Fixture.Create<Version>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<Version>();

        //Assert
        result.Should().BeEquivalentTo(parsed);
    }

    [TestMethod]
    public void WhenValueIsNotVersion_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<Version>();

        //Assert
        action.Should().Throw<StringParsingException<Version>>().WithMessage($"Can't parse string to {nameof(Version)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenValueIsValidTimeSpan_ReturnAsTimeSpan()
    {
        //Arrange
        var parsed = Fixture.Create<TimeSpan>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<TimeSpan>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenValueIsNotTimeSpan_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<TimeSpan>();

        //Assert
        action.Should().Throw<StringParsingException<TimeSpan>>().WithMessage($"Can't parse string to {nameof(TimeSpan)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenValueIsGuid_ReturnAsGuid()
    {
        //Arrange
        var parsed = Fixture.Create<Guid>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<Guid>();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenValueIsNotGuid_Throw()
    {
        //Arrange
        var value = "this is not a guid";

        //Act
        var action = () => value.ParseOrThrow<Guid>();

        //Assert
        action.Should().Throw<StringParsingException<Guid>>().WithMessage($"Can't parse string to {nameof(Guid)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenValueIsNumeric_ReturnAsBigInteger()
    {
        //Arrange
        var parsed = Fixture.Create<BigInteger>();
        var value = parsed.ToString();

        //Act
        var result = value.ParseOrThrow<BigInteger>();

        //Assert
        result.Should().BeEquivalentTo(parsed);
    }

    [TestMethod]
    public void WhenValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<BigInteger>();

        //Assert
        action.Should().Throw<StringParsingException<BigInteger>>().WithMessage($"Can't parse string to {nameof(BigInteger)} : Its value was {value}");
    }

    [TestMethod]
    public void WhenIsUnsupportedType_Throw()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        Action action = () => value.ParseOrThrow<DummyUnsupportedType>();

        //Assert
        action.Should().Throw<NotSupportedException>().WithMessage($"Can't parse string to {nameof(DummyUnsupportedType)} : {nameof(DummyUnsupportedType)} is not supported.");
    }
}