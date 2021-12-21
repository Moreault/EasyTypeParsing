namespace EasyTypeParsing.Tests;

[TestClass]
public class Parse : Tester
{
    [TestMethod]
    public void WhenConvertingToIntAndValueIsNegativeInt_ReturnAsInt()
    {
        //Arrange
        var parsed = -Fixture.Create<int>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().Be(new TryGetResult<int>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsPositiveInt_ReturnAsInt()
    {
        //Arrange
        var parsed = Fixture.Create<int>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().Be(new TryGetResult<int>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsBiggerThanIntUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = ((long)int.MaxValue + 1).ToString();

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<int>(false));
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsLesserThanIntLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = ((long)int.MinValue - 1).ToString();

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<int>(false));
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<int>(false));
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Fixture.Create<int>()}.{Fixture.Create<int>()}";

        //Act
        var result = value.Parse<int>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<int>(false));
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsNegativeLong_ReturnAsLong()
    {
        //Arrange
        var parsed = -Fixture.Create<long>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().Be(new TryGetResult<long>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsPositiveLong_ReturnAsLong()
    {
        //Arrange
        var parsed = Fixture.Create<long>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().Be(new TryGetResult<long>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsBiggerThanLongUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "9223372036854775808";

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<long>(false));
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsLesserThanLongLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-9223372036854775809";

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<long>(false));
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<long>(false));
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Fixture.Create<long>()}.{Fixture.Create<long>()}";

        //Act
        var result = value.Parse<long>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<long>(false));
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsNegativeFloat_ReturnAsFloat()
    {
        //Arrange
        var parsed = -Fixture.Create<float>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<float>();

        //Assert
        result.Should().Be(new TryGetResult<float>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsPositiveFloat_ReturnAsFloat()
    {
        //Arrange
        var parsed = Fixture.Create<float>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<float>();

        //Assert
        result.Should().Be(new TryGetResult<float>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsBiggerThanFloatUpperLimit_ReturnPositiveInfinity()
    {
        //Arrange
        var value = "92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.Parse<float>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<float>(float.PositiveInfinity));
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsLesserThanFloatLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.Parse<float>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<float>(float.NegativeInfinity));
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<float>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<float>(false));
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueHasFloatingPoint_ReturnAsFloat()
    {
        //Arrange
        var parsed = Fixture.Create<float>() + Fixture.Create<float>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<float>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<float>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsNegativeDouble_ReturnAsDouble()
    {
        //Arrange
        var parsed = -Fixture.Create<double>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<double>();

        //Assert
        result.Should().Be(new TryGetResult<double>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsPositiveDouble_ReturnAsDouble()
    {
        //Arrange
        var parsed = Fixture.Create<double>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<double>();

        //Assert
        result.Should().Be(new TryGetResult<double>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsBiggerThanDoubleUpperLimit_ReturnPositiveInfinity()
    {
        //Arrange
        var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.Parse<double>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<double>(double.PositiveInfinity));
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsLesserThanDoubleLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.Parse<double>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<double>(double.NegativeInfinity));
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<double>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<double>(false));
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueHasFloatingPoint_ReturnAsDouble()
    {
        //Arrange
        var parsed = Fixture.Create<double>() + Fixture.Create<double>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<double>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<double>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsNegativeDecimal_ReturnAsDecimal()
    {
        //Arrange
        var parsed = -Fixture.Create<decimal>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<decimal>();

        //Assert
        result.Should().Be(new TryGetResult<decimal>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsPositiveDecimal_ReturnAsDecimal()
    {
        //Arrange
        var parsed = Fixture.Create<decimal>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<decimal>();

        //Assert
        result.Should().Be(new TryGetResult<decimal>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsBiggerThanDecimalUpperLimit_ReturnPositiveInfinity()
    {
        //Arrange
        var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.Parse<decimal>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<decimal>(false));
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsLesserThanDecimalLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

        //Act
        var result = value.Parse<decimal>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<decimal>(false));
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<decimal>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<decimal>(false));
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueHasFloatingPoint_ReturnAsDecimal()
    {
        //Arrange
        var parsed = Fixture.Create<decimal>() + Fixture.Create<decimal>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<decimal>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<decimal>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsPositiveByte_ReturnAsByte()
    {
        //Arrange
        var parsed = Fixture.Create<byte>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<byte>();

        //Assert
        result.Should().Be(new TryGetResult<byte>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsBiggerThanByteUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = ((long)byte.MaxValue + 1).ToString();

        //Act
        var result = value.Parse<byte>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<byte>(false));
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsLesserThanByteLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = ((long)byte.MinValue - 1).ToString();

        //Act
        var result = value.Parse<byte>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<byte>(false));
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<byte>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<byte>(false));
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Fixture.Create<byte>()}.{Fixture.Create<byte>()}";

        //Act
        var result = value.Parse<byte>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<byte>(false));
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsNegativeSByte_ReturnAsSByte()
    {
        //Arrange
        var parsed = (sbyte)-Fixture.Create<sbyte>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().Be(new TryGetResult<sbyte>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsPositiveSByte_ReturnAsSByte()
    {
        //Arrange
        var parsed = Fixture.Create<sbyte>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().Be(new TryGetResult<sbyte>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsBiggerThanSByteUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "-129";

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<sbyte>(false));
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsLesserThanSByteLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "128";

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<sbyte>(false));
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<sbyte>(false));
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Fixture.Create<sbyte>()}.{Fixture.Create<sbyte>()}";

        //Act
        var result = value.Parse<sbyte>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<sbyte>(false));
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsNegativeShort_ReturnAsShort()
    {
        //Arrange
        var parsed = (short)-Fixture.Create<short>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().Be(new TryGetResult<short>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsPositiveShort_ReturnAsShort()
    {
        //Arrange
        var parsed = Fixture.Create<short>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().Be(new TryGetResult<short>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsBiggerThanShortUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "32768";

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<short>(false));
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsLesserThanShortLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-32769";

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<short>(false));
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<short>(false));
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Fixture.Create<short>()}.{Fixture.Create<short>()}";

        //Act
        var result = value.Parse<short>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<short>(false));
    }

    [TestMethod]
    public void WhenConvertingToCharAndValueIsWhiteSpace_ReturnAsChar()
    {
        //Arrange
        var value = " ";

        //Act
        var result = value.Parse<char>();

        //Assert
        result.Should().Be(new TryGetResult<char>(true, ' '));
    }

    [TestMethod]
    public void WhenConvertingToCharAndValueIsNotChar_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<char>();

        //Assert
        result.Should().BeEquivalentTo(TryGetResult<char>.Failure);
    }

    [TestMethod]
    public void WhenConvertingToCharAndValueIsSingleChar_ReturnAsChar()
    {
        //Arrange
        var parsed = Fixture.Create<char>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<char>();

        //Assert
        result.Should().Be(new TryGetResult<char>(true, parsed));
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsUInt_ReturnAsUInt()
    {
        //Arrange
        var parsed = Fixture.Create<uint>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<uint>();

        //Assert
        result.Should().Be(new TryGetResult<uint>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsBiggerThanUintUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "4294967296";

        //Act
        var result = value.Parse<uint>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<uint>(false));
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsLesserThanUIntLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-1";

        //Act
        var result = value.Parse<uint>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<uint>(false));
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<uint>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<uint>(false));
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Fixture.Create<uint>()}.{Fixture.Create<uint>()}";

        //Act
        var result = value.Parse<uint>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<uint>(false));
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsULong_ReturnAsULong()
    {
        //Arrange
        var parsed = Fixture.Create<ulong>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<ulong>();

        //Assert
        result.Should().Be(new TryGetResult<ulong>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsBiggerThanULongUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "18446744073709551616";

        //Act
        var result = value.Parse<ulong>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<ulong>(false));
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsLesserThanULongLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-1";

        //Act
        var result = value.Parse<ulong>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<ulong>(false));
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<ulong>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<ulong>(false));
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Fixture.Create<ulong>()}.{Fixture.Create<ulong>()}";

        //Act
        var result = value.Parse<ulong>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<ulong>(false));
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsUShort_ReturnAsUShort()
    {
        //Arrange
        var parsed = Fixture.Create<ushort>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<ushort>();

        //Assert
        result.Should().Be(new TryGetResult<ushort>(parsed));
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsBiggerThanUShortUpperLimit_ReturnFailure()
    {
        //Arrange
        var value = "18446744073709551616";

        //Act
        var result = value.Parse<ushort>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<ushort>(false));
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsLesserThanUShortLowerLimit_ReturnFailure()
    {
        //Arrange
        var value = "-1";

        //Act
        var result = value.Parse<ushort>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<ushort>(false));
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<ushort>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<ushort>(false));
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueHasFloatingPoint_ReturnFailure()
    {
        //Arrange
        var value = $"{Fixture.Create<ushort>()}.{Fixture.Create<ushort>()}";

        //Act
        var result = value.Parse<ushort>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<ushort>(false));
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsTrue_ReturnTrue()
    {
        //Arrange
        var value = true.ToString();

        //Act
        var result = value.Parse<bool>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<bool>(true, true));
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsTrueInDifferentCaps_ReturnTrue()
    {
        //Arrange
        var value = "TrUe";

        //Act
        var result = value.Parse<bool>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<bool>(true, true));
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsFalse_ReturnFalse()
    {
        //Arrange
        var value = false.ToString();

        //Act
        var result = value.Parse<bool>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<bool>(true, false));
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsFalseInDifferentCaps_ReturnFalse()
    {
        //Arrange
        var value = "FaLsE";

        //Act
        var result = value.Parse<bool>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<bool>(true, false));
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsNotTrueOrFalse_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<bool>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<bool>(false));
    }
    
    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsValidDateTime_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<DateTime>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<DateTime>(true, parsed));
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
        result.Should().BeEquivalentTo(new TryGetResult<DateTime>(true, parsed));
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsNotDateTime_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<DateTime>();

        //Assert
        result.Should().BeEquivalentTo(TryGetResult<DateTime>.Failure);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsNotUsingSameCultureInfo_ReturnFailure()
    {
        //Arrange
        var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.Parse<DateTime>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        result.Should().BeEquivalentTo(TryGetResult<DateTime>.Failure);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsUsingSameCultureInfo_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.Parse<DateTime>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<DateTime>(true, parsed));
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsValidDateTimeOffset_ReturnAsDateTimeOffset()
    {
        //Arrange
        var parsed = Fixture.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.Parse<DateTimeOffset>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<DateTimeOffset>(true, parsed));
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsNotDateTimeOffset_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<DateTimeOffset>();

        //Assert
        result.Should().BeEquivalentTo(TryGetResult<DateTimeOffset>.Failure);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsNotUsingSameCultureInfo_ReturnFailure()
    {
        //Arrange
        var parsed = Fixture.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.Parse<DateTimeOffset>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        result.Should().BeEquivalentTo(TryGetResult<DateTimeOffset>.Failure);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsUsingSameCultureInfo_ReturnAsDateTimeOffset()
    {
        //Arrange
        var parsed = Fixture.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.Parse<DateTimeOffset>(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<DateTimeOffset>(true, parsed));
    }

    [TestMethod]
    public void WhenConvertingToVersionAndValueIsCorrectlyFormattedVersion_ReturnAsVersion()
    {
        //Arrange
        var parsed = Fixture.Create<Version>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<Version>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<Version>(true, parsed));
    }

    [TestMethod]
    public void WhenConvertingToVersionAndValueIsNotVersion_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<Version>();

        //Assert
        result.Should().BeEquivalentTo(TryGetResult<Version>.Failure);
    }
    
    [TestMethod]
    public void WhenConvertingToTimeSpanAndValueIsValidTimeSpan_ReturnAsTimeSpan()
    {
        //Arrange
        var parsed = Fixture.Create<TimeSpan>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<TimeSpan>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<TimeSpan>(true, parsed));
    }

    [TestMethod]
    public void WhenConvertingToTimeSpanAndValueIsNotTimeSpan_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<TimeSpan>();

        //Assert
        result.Should().BeEquivalentTo(TryGetResult<TimeSpan>.Failure);
    }
    
    [TestMethod]
    public void WhenConvertingToGuidAndValueIsGuid_ReturnAsGuid()
    {
        //Arrange
        var parsed = Fixture.Create<Guid>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<Guid>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<Guid>(true, parsed));
    }

    [TestMethod]
    public void WhenConvertingToGuidAndValueIsNotGuid_ReturnFailure()
    {
        //Arrange
        var value = "this is not a guid";

        //Act
        var result = value.Parse<Guid>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<Guid>(false));
    }
    
    [TestMethod]
    public void WhenConvertingToBigIntegerAndValueIsNumeric_ReturnAsBigInteger()
    {
        //Arrange
        var parsed = Fixture.Create<BigInteger>();
        var value = parsed.ToString();

        //Act
        var result = value.Parse<BigInteger>();

        //Assert
        result.Should().BeEquivalentTo(new TryGetResult<BigInteger>(true, parsed));
    }

    [TestMethod]
    public void WhenConvertingToBigIntegerAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<BigInteger>();

        //Assert
        result.Should().BeEquivalentTo(TryGetResult<BigInteger>.Failure);
    }

    [TestMethod]
    public void WhenConvertingToUnsupportedType_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();

        //Act
        var result = value.Parse<DummyUnsupportedType>();

        //Assert
        result.Should().BeEquivalentTo(TryGetResult<DummyUnsupportedType>.Failure);
    }
}