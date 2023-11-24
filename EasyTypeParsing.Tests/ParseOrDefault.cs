namespace EasyTypeParsing.Tests;

[TestClass]
public class ParseOrDefault : Tester
{
    [TestMethod]
    public void WhenConvertingToIntAndValueIsNegativeInt_ReturnAsInt()
    {
        //Arrange
        var parsed = -Fixture.Create<int>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<int>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsPositiveInt_ReturnAsInt()
    {
        //Arrange
        var parsed = Fixture.Create<int>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<int>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsBiggerThanIntUpperLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = ((long)int.MaxValue + 1).ToString();
        var defaultValue = Fixture.Create<int>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsLesserThanIntLowerLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = ((long)int.MinValue - 1).ToString();
        var defaultValue = Fixture.Create<int>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<int>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Fixture.Create<int>()}.{Fixture.Create<int>()}";
        var defaultValue = Fixture.Create<int>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsNegativeLong_ReturnAsLong()
    {
        //Arrange
        var parsed = -Fixture.Create<long>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<long>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsPositiveLong_ReturnAsLong()
    {
        //Arrange
        var parsed = Fixture.Create<long>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<long>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsBiggerThanLongUpperLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = "9223372036854775808";
        var defaultValue = Fixture.Create<long>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsLesserThanLongLowerLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = " -9223372036854775809";
        var defaultValue = Fixture.Create<long>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<long>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Fixture.Create<long>()}.{Fixture.Create<long>()}";
        var defaultValue = Fixture.Create<long>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsNegativeFloat_ReturnAsFloat()
    {
        //Arrange
        var parsed = -Fixture.Create<float>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Fixture.Create<float>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsPositiveFloat_ReturnAsFloat()
    {
        //Arrange
        var parsed = Fixture.Create<float>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Fixture.Create<float>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsBiggerThanFloatUpperLimit_ReturnPositiveInfinity()
    {
        //Arrange
        var value = "92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
        var defaultValue = Fixture.Create<float>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(float.PositiveInfinity);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsLesserThanFloatLowerLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = "-92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
        var defaultValue = Fixture.Create<float>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(float.NegativeInfinity);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<float>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueHasFloatingPoint_ReturnParsed()
    {
        //Arrange
        var parsed = Fixture.Create<float>() + Fixture.Create<float>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Fixture.Create<float>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsNegativeDouble_ReturnAsDouble()
    {
        //Arrange
        var parsed = -Fixture.Create<double>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Fixture.Create<double>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsPositiveDouble_ReturnAsDouble()
    {
        //Arrange
        var parsed = Fixture.Create<double>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Fixture.Create<double>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsBiggerThanDoubleUpperLimit_ReturnPositiveInfinity()
    {
        //Arrange
        var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
        var defaultValue = Fixture.Create<double>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(double.PositiveInfinity);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsLesserThanDoubleLowerLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
        var defaultValue = Fixture.Create<double>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(double.NegativeInfinity);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<double>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueHasFloatingPoint_ReturnParsed()
    {
        //Arrange
        var parsed = Fixture.Create<double>() + Fixture.Create<double>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Fixture.Create<double>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsNegativeDecimal_ReturnAsDecimal()
    {
        //Arrange
        var parsed = -Fixture.Create<decimal>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Fixture.Create<decimal>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsPositiveDecimal_ReturnAsDecimal()
    {
        //Arrange
        var parsed = Fixture.Create<decimal>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Fixture.Create<decimal>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsBiggerThanDecimalUpperLimit_ReturnPositiveInfinity()
    {
        //Arrange
        var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
        var defaultValue = Fixture.Create<decimal>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsLesserThanDecimalLowerLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
        var defaultValue = Fixture.Create<decimal>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<decimal>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueHasFloatingPoint_ReturnParsed()
    {
        //Arrange
        var parsed = Fixture.Create<decimal>() + Fixture.Create<decimal>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Fixture.Create<decimal>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsPositiveByte_ReturnAsByte()
    {
        //Arrange
        var parsed = Fixture.Create<byte>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<byte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsBiggerThanByteUpperLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = ((long)byte.MaxValue + 1).ToString();
        var defaultValue = Fixture.Create<byte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsLesserThanByteLowerLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = ((long)byte.MinValue - 1).ToString();
        var defaultValue = Fixture.Create<byte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<byte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Fixture.Create<byte>()}.{Fixture.Create<byte>()}";
        var defaultValue = Fixture.Create<byte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsNegativeSByte_ReturnAsSByte()
    {
        //Arrange
        var parsed = (sbyte)-Fixture.Create<sbyte>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<sbyte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsPositiveSByte_ReturnAsSByte()
    {
        //Arrange
        var parsed = Fixture.Create<sbyte>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<sbyte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsBiggerThanSByteUpperLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = "128";
        var defaultValue = Fixture.Create<sbyte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsLesserThanSByteLowerLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = " -129";
        var defaultValue = Fixture.Create<sbyte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<sbyte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Fixture.Create<sbyte>()}.{Fixture.Create<sbyte>()}";
        var defaultValue = Fixture.Create<sbyte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsNegativeShort_ReturnAsShort()
    {
        //Arrange
        var parsed = (short)-Fixture.Create<short>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<short>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsPositiveShort_ReturnAsShort()
    {
        //Arrange
        var parsed = Fixture.Create<short>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<short>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsBiggerThanShortUpperLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = "32768";
        var defaultValue = Fixture.Create<short>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsLesserThanShortLowerLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = " -32769";
        var defaultValue = Fixture.Create<short>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<short>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Fixture.Create<short>()}.{Fixture.Create<short>()}";
        var defaultValue = Fixture.Create<short>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToCharAndValueIsWhiteSpace_ReturnAsChar()
    {
        //Arrange
        var value = " ";
        var defaultValue = Fixture.Create<char>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(' ');
    }

    [TestMethod]
    public void WhenConvertingToCharAndValueIsNotChar_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<char>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToCharAndValueIsSingleChar_ReturnAsChar()
    {
        //Arrange
        var parsed = Fixture.Create<char>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<char>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsPositiveUInt_ReturnAsUInt()
    {
        //Arrange
        var parsed = Fixture.Create<uint>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<uint>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsBiggerThanUIntUpperLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = "4294967296";
        var defaultValue = Fixture.Create<uint>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsLesserThanUIntLowerLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = " -1";
        var defaultValue = Fixture.Create<uint>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<uint>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Fixture.Create<uint>()}.{Fixture.Create<uint>()}";
        var defaultValue = Fixture.Create<uint>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsPositiveULong_ReturnAsULong()
    {
        //Arrange
        var parsed = Fixture.Create<ulong>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<ulong>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsBiggerThanULongUpperLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = "18446744073709551616";
        var defaultValue = Fixture.Create<ulong>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsLesserThanULongLowerLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = " -1";
        var defaultValue = Fixture.Create<ulong>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<ulong>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Fixture.Create<ulong>()}.{Fixture.Create<ulong>()}";
        var defaultValue = Fixture.Create<ulong>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsPositiveUShort_ReturnAsUShort()
    {
        //Arrange
        var parsed = Fixture.Create<ushort>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<ushort>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsBiggerThanUShortUpperLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = "18446744073709551616";
        var defaultValue = Fixture.Create<ushort>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsLesserThanUShortLowerLimit_ReturnDefaultValue()
    {
        //Arrange
        var value = " -1";
        var defaultValue = Fixture.Create<ushort>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<ushort>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Fixture.Create<ushort>()}.{Fixture.Create<ushort>()}";
        var defaultValue = Fixture.Create<ushort>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }







    [TestMethod]
    public void WhenConvertingToBoolAndValueIsTrue_ReturnTrue()
    {
        //Arrange
        var value = true.ToString();
        var defaultValue = Fixture.Create<bool>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(true);
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsTrueInDifferentCaps_ReturnTrue()
    {
        //Arrange
        var value = "TrUe";
        var defaultValue = Fixture.Create<bool>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(true);
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsFalse_ReturnFalse()
    {
        //Arrange
        var value = false.ToString();
        var defaultValue = Fixture.Create<bool>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(false);
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsFalseInDifferentCaps_ReturnFalse()
    {
        //Arrange
        var value = "FaLsE";
        var defaultValue = Fixture.Create<bool>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(false);
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsNotTrueOrFalse_ReturnDefault()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<bool>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsValidDateTime_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Fixture.Create<DateTime>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsValidDateTime_CorrectlyReApplyMilliseconds()
    {
        //Arrange
        var parsed = new DateTime(2022, 3, 7, 14, 43, 26, 535);
        const string value = "03/07/2022 14:43:26.535";
        var defaultValue = Fixture.Create<DateTime>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsNotDateTime_ReturnDefault()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<DateTime>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsNotUsingSameCultureInfo_ReturnDefault()
    {
        //Arrange
        var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
        var defaultValue = Fixture.Create<DateTime>();

        //Act
        var result = value.ParseOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsUsingSameCultureInfo_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
        var defaultValue = Fixture.Create<DateTime>();

        //Act
        var result = value.ParseOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsValidDateTimeOffset_ReturnAsDateTimeOffset()
    {
        //Arrange
        var parsed = Fixture.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Fixture.Create<DateTimeOffset>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsNotDateTimeOffset_ReturnDefault()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<DateTimeOffset>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsNotUsingSameCultureInfo_ReturnDefault()
    {
        //Arrange
        var parsed = Fixture.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
        var defaultValue = Fixture.Create<DateTimeOffset>();

        //Act
        var result = value.ParseOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsUsingSameCultureInfo_ReturnAsDateTimeOffset()
    {
        //Arrange
        var parsed = Fixture.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
        var defaultValue = Fixture.Create<DateTimeOffset>();

        //Act
        var result = value.ParseOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToVersionAndValueIsCorrectlyFormattedVersion_ReturnAsVersion()
    {
        //Arrange
        var parsed = Fixture.Create<Version>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<Version>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().BeEquivalentTo(parsed);
    }

    [TestMethod]
    public void WhenConvertingToVersionAndValueIsNotVersion_ReturnDefault()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<Version>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToTimeSpanAndValueIsValidTimeSpan_ReturnAsTimeSpan()
    {
        //Arrange
        var parsed = Fixture.Create<TimeSpan>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<TimeSpan>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToTimeSpanAndValueIsNotTimeSpan_ReturnDefault()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<TimeSpan>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToGuidAndValueIsValidGuid_ReturnAsGuid()
    {
        //Arrange
        var parsed = Fixture.Create<Guid>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<Guid>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToGuidAndValueIsNotGuid_ReturnFailure()
    {
        //Arrange
        var value = "this is not a guid";
        var defaultValue = Fixture.Create<Guid>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToBigIntegerAndValueIsNumeric_ReturnAsBigInteger()
    {
        //Arrange
        var parsed = Fixture.Create<BigInteger>();
        var value = parsed.ToString();
        var defaultValue = Fixture.Create<BigInteger>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToBigIntegerAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<BigInteger>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUnsupportedType_returnDefault()
    {
        //Arrange
        var value = Fixture.Create<string>();
        var defaultValue = Fixture.Create<DummyUnsupportedType>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }
}