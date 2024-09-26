namespace EasyTypeParsing.Tests;

[TestClass]
public class ParseTest : Tester
{
    [TestMethod]
    public void WhenConvertingToIntAndValueIsNegativeInt_ReturnAsInt()
    {
        //Arrange
        var parsed = -Dummy.Create<int>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().Be(Result<int>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsPositiveInt_ReturnAsInt()
    {
        //Arrange
        var parsed = Dummy.Create<int>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().Be(Result<int>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsBiggerThanIntUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = ((long)int.MaxValue + 1).ToString();

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().BeEquivalentTo(Result<int>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsLesserThanIntLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = ((long)int.MinValue - 1).ToString();

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().BeEquivalentTo(Result<int>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().BeEquivalentTo(Result<int>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Dummy.Create<int>()}.{Dummy.Create<int>()}";

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().BeEquivalentTo(Result<int>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsNegativeLong_ReturnAsLong()
    {
        //Arrange
        var parsed = -Dummy.Create<long>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().Be(Result<long>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsPositiveLong_ReturnAsLong()
    {
        //Arrange
        var parsed = Dummy.Create<long>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().Be(Result<long>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsBiggerThanLongUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "9223372036854775808";

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().BeEquivalentTo(Result<long>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsLesserThanLongLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-9223372036854775809";

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().BeEquivalentTo(Result<long>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().BeEquivalentTo(Result<long>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Dummy.Create<long>()}.{Dummy.Create<long>()}";

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().BeEquivalentTo(Result<long>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsNegativeFloat_ReturnAsFloat()
    {
        //Arrange
        var parsed = -Dummy.Create<float>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<float>();

        //Assert
        result.Should().Be(Result<float>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsPositiveFloat_ReturnAsFloat()
    {
        //Arrange
        var parsed = Dummy.Create<float>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<float>();

        //Assert
        result.Should().Be(Result<float>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsLesserThanFloatLowerLimit_ReturnSuccessWithNegativeInfinity()
    {
        //Arrange
        var value = "-92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.Parse<float>();

        //Assert
        result.Should().BeEquivalentTo(Result<float>.Success(float.NegativeInfinity));
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<float>();

        //Assert
        result.Should().BeEquivalentTo(Result<float>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueHasFloatingPoint_ReturnAsFloat()
    {
        //Arrange
        var parsed = Dummy.Create<float>() + Dummy.Create<float>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<float>();

        //Assert
        result.Should().BeEquivalentTo(Result<float>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsNegativeDouble_ReturnAsDouble()
    {
        //Arrange
        var parsed = -Dummy.Create<double>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<double>();

        //Assert
        result.Should().Be(Result<double>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsPositiveDouble_ReturnAsDouble()
    {
        //Arrange
        var parsed = Dummy.Create<double>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<double>();

        //Assert
        result.Should().Be(Result<double>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsLesserThanDoubleLowerLimit_ReturnSuccessWithNegativeInfinity()
    {
        //Arrange
        var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.Parse<double>();

        //Assert
        result.Should().BeEquivalentTo(Result<double>.Success(double.NegativeInfinity));
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<double>();

        //Assert
        result.Should().BeEquivalentTo(Result<double>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueHasFloatingPoint_ReturnAsDouble()
    {
        //Arrange
        var parsed = Dummy.Create<double>() + Dummy.Create<double>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<double>();

        //Assert
        result.Should().BeEquivalentTo(Result<double>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsNegativeDecimal_ReturnAsDecimal()
    {
        //Arrange
        var parsed = -Dummy.Create<decimal>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<decimal>();

        //Assert
        result.Should().Be(Result<decimal>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsPositiveDecimal_ReturnAsDecimal()
    {
        //Arrange
        var parsed = Dummy.Create<decimal>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<decimal>();

        //Assert
        result.Should().Be(Result<decimal>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsLesserThanDecimalLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.Parse<decimal>();

        //Assert
        result.Should().BeEquivalentTo(Result<decimal>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<decimal>();

        //Assert
        result.Should().BeEquivalentTo(Result<decimal>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueHasFloatingPoint_ReturnAsDecimal()
    {
        //Arrange
        var parsed = Dummy.Create<decimal>() + Dummy.Create<decimal>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<decimal>();

        //Assert
        result.Should().BeEquivalentTo(Result<decimal>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsPositiveByte_ReturnAsByte()
    {
        //Arrange
        var parsed = Dummy.Create<byte>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<byte>();

        //Assert
        result.Should().Be(Result<byte>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsBiggerThanByteUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = ((long)byte.MaxValue + 1).ToString();

        //Act
        var result = value.Parse<byte>();

        //Assert
        result.Should().BeEquivalentTo(Result<byte>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsLesserThanByteLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = ((long)byte.MinValue - 1).ToString();

        //Act
        var result = value.Parse<byte>();

        //Assert
        result.Should().BeEquivalentTo(Result<byte>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<byte>();

        //Assert
        result.Should().BeEquivalentTo(Result<byte>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Dummy.Create<byte>()}.{Dummy.Create<byte>()}";

        //Act
        var result = value.Parse<byte>();

        //Assert
        result.Should().BeEquivalentTo(Result<byte>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsNegativeSByte_ReturnAsSByte()
    {
        //Arrange
        var parsed = (sbyte)-Dummy.Create<sbyte>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().Be(Result<sbyte>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsPositiveSByte_ReturnAsSByte()
    {
        //Arrange
        var parsed = Dummy.Create<sbyte>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().Be(Result<sbyte>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsBiggerThanSByteUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "-129";

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().BeEquivalentTo(Result<sbyte>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsLesserThanSByteLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "128";

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().BeEquivalentTo(Result<sbyte>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().BeEquivalentTo(Result<sbyte>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Dummy.Create<sbyte>()}.{Dummy.Create<sbyte>()}";

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().BeEquivalentTo(Result<sbyte>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsNegativeShort_ReturnAsShort()
    {
        //Arrange
        var parsed = (short)-Dummy.Create<short>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().Be(Result<short>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsPositiveShort_ReturnAsShort()
    {
        //Arrange
        var parsed = Dummy.Create<short>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().Be(Result<short>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsBiggerThanShortUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "32768";

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().BeEquivalentTo(Result<short>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsLesserThanShortLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-32769";

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().BeEquivalentTo(Result<short>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().BeEquivalentTo(Result<short>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Dummy.Create<short>()}.{Dummy.Create<short>()}";

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().BeEquivalentTo(Result<short>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToCharAndValueIsWhiteSpace_ReturnAsChar()
    {
        //Arrange
        var value = " ";

        //Act
        var result = value.Parse<char>();

        //Assert
        result.Should().Be(Result<char>.Success(' '));
    }

    [TestMethod]
    public void WhenConvertingToCharAndValueIsNotChar_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<char>();

        //Assert
        result.Should().BeEquivalentTo(Result<char>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToCharAndValueIsSingleChar_ReturnAsChar()
    {
        //Arrange
        var parsed = Dummy.Create<char>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<char>();

        //Assert
        result.Should().Be(Result<char>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsUInt_ReturnAsUInt()
    {
        //Arrange
        var parsed = Dummy.Create<uint>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<uint>();

        //Assert
        result.Should().Be(Result<uint>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsBiggerThanUintUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "4294967296";

        //Act
        var result = value.Parse<uint>();

        //Assert
        result.Should().BeEquivalentTo(Result<uint>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsLesserThanUIntLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-1";

        //Act
        var result = value.Parse<uint>();

        //Assert
        result.Should().BeEquivalentTo(Result<uint>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<uint>();

        //Assert
        result.Should().BeEquivalentTo(Result<uint>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Dummy.Create<uint>()}.{Dummy.Create<uint>()}";

        //Act
        var result = value.Parse<uint>();

        //Assert
        result.Should().BeEquivalentTo(Result<uint>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsULong_ReturnAsULong()
    {
        //Arrange
        var parsed = Dummy.Create<ulong>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<ulong>();

        //Assert
        result.Should().Be(Result<ulong>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsBiggerThanULongUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "18446744073709551616";

        //Act
        var result = value.Parse<ulong>();

        //Assert
        result.Should().BeEquivalentTo(Result<ulong>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsLesserThanULongLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-1";

        //Act
        var result = value.Parse<ulong>();

        //Assert
        result.Should().BeEquivalentTo(Result<ulong>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<ulong>();

        //Assert
        result.Should().BeEquivalentTo(Result<ulong>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Dummy.Create<ulong>()}.{Dummy.Create<ulong>()}";

        //Act
        var result = value.Parse<ulong>();

        //Assert
        result.Should().BeEquivalentTo(Result<ulong>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsUShort_ReturnAsUShort()
    {
        //Arrange
        var parsed = Dummy.Create<ushort>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<ushort>();

        //Assert
        result.Should().Be(Result<ushort>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsBiggerThanUShortUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "18446744073709551616";

        //Act
        var result = value.Parse<ushort>();

        //Assert
        result.Should().BeEquivalentTo(Result<ushort>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsLesserThanUShortLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-1";

        //Act
        var result = value.Parse<ushort>();

        //Assert
        result.Should().BeEquivalentTo(Result<ushort>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<ushort>();

        //Assert
        result.Should().BeEquivalentTo(Result<ushort>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Dummy.Create<ushort>()}.{Dummy.Create<ushort>()}";

        //Act
        var result = value.Parse<ushort>();

        //Assert
        result.Should().BeEquivalentTo(Result<ushort>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsTrue_ReturnTrue()
    {
        //Arrange
        var value = true.ToString();

        //Act
        var result = value.Parse<bool>();

        //Assert
        result.Should().BeEquivalentTo(Result<bool>.Success(true));
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsTrueInDifferentCaps_ReturnTrue()
    {
        //Arrange
        var value = "TrUe";

        //Act
        var result = value.Parse<bool>();

        //Assert
        result.Should().BeEquivalentTo(Result<bool>.Success(true));
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsFalse_ReturnFalse()
    {
        //Arrange
        var value = false.ToString();

        //Act
        var result = value.Parse<bool>();

        //Assert
        result.Should().BeEquivalentTo(Result<bool>.Success(false));
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsFalseInDifferentCaps_ReturnFalse()
    {
        //Arrange
        var value = "FaLsE";

        //Act
        var result = value.Parse<bool>();

        //Assert
        result.Should().BeEquivalentTo(Result<bool>.Success(false));
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsNotTrueOrFalse_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<bool>();

        //Assert
        result.Should().BeEquivalentTo(Result<bool>.Failure());
    }
    
    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsValidDateTime_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<DateTime>();

        //Assert
        result.Should().BeEquivalentTo(Result<DateTime>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsValidDateTime_CorrectlyReApplyMilliseconds()
    {
        //Arrange
        var parsed = new DateTime(2022, 3, 7, 14, 43, 26, 535);
        const string value = "03/07/2022 14:43:26.535";

        //Act
        var result = value.Parse<DateTime>();

        //Assert
        result.Should().BeEquivalentTo(Result<DateTime>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsNotDateTime_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<DateTime>();

        //Assert
        result.Should().BeEquivalentTo(Result<DateTime>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsNotUsingSameCultureInfo_ReturnFailure()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.Parse<DateTime>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        result.Should().BeEquivalentTo(Result<DateTime>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsUsingSameCultureInfo_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.Parse<DateTime>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().BeEquivalentTo(Result<DateTime>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsValidDateTimeOffset_ReturnAsDateTimeOffset()
    {
        //Arrange
        var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<DateTimeOffset>();

        //Assert
        result.Should().BeEquivalentTo(Result<DateTimeOffset>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsNotDateTimeOffset_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<DateTimeOffset>();

        //Assert
        result.Should().BeEquivalentTo(Result<DateTimeOffset>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsNotUsingSameCultureInfo_ReturnFailure()
    {
        //Arrange
        var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.Parse<DateTimeOffset>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        result.Should().BeEquivalentTo(Result<DateTimeOffset>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsUsingSameCultureInfo_ReturnAsDateTimeOffset()
    {
        //Arrange
        var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.Parse<DateTimeOffset>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().BeEquivalentTo(Result<DateTimeOffset>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToVersionAndValueIsCorrectlyFormattedVersion_ReturnAsVersion()
    {
        //Arrange
        var parsed = Dummy.Create<Version>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<Version>();

        //Assert
        result.Should().BeEquivalentTo(Result<Version>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToVersionAndValueIsNotVersion_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<Version>();

        //Assert
        result.Should().BeEquivalentTo(Result<Version>.Failure());
    }
    
    [TestMethod]
    public void WhenConvertingToTimeSpanAndValueIsValidTimeSpan_ReturnAsTimeSpan()
    {
        //Arrange
        var parsed = Dummy.Create<TimeSpan>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<TimeSpan>();

        //Assert
        result.Should().BeEquivalentTo(Result<TimeSpan>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToTimeSpanAndValueIsNotTimeSpan_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<TimeSpan>();

        //Assert
        result.Should().BeEquivalentTo(Result<TimeSpan>.Failure());
    }
    
    [TestMethod]
    public void WhenConvertingToGuidAndValueIsGuid_ReturnAsGuid()
    {
        //Arrange
        var parsed = Dummy.Create<Guid>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<Guid>();

        //Assert
        result.Should().BeEquivalentTo(Result<Guid>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToGuidAndValueIsNotGuid_ReturnFailure()
    {
        //Arrange
        var value = "this is not a guid";

        //Act
        var result = value.Parse<Guid>();

        //Assert
        result.Should().BeEquivalentTo(Result<Guid>.Failure());
    }
    
    [TestMethod]
    public void WhenConvertingToBigIntegerAndValueIsNumeric_ReturnAsBigInteger()
    {
        //Arrange
        var parsed = Dummy.Create<BigInteger>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<BigInteger>();

        //Assert
        result.Should().BeEquivalentTo(Result<BigInteger>.Success(parsed));
    }

    [TestMethod]
    public void WhenConvertingToBigIntegerAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<BigInteger>();

        //Assert
        result.Should().BeEquivalentTo(Result<BigInteger>.Failure());
    }

    [TestMethod]
    public void WhenConvertingToUnsupportedType_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.Parse<DummyUnsupportedType>();

        //Assert
        result.Should().BeEquivalentTo(Result<DummyUnsupportedType>.Failure());
    }
}