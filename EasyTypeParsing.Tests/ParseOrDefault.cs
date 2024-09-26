namespace EasyTypeParsing.Tests;

[TestClass]
public class ParseOrDefault : Tester
{
    [TestMethod]
    public void WhenConvertingToIntAndValueIsNegativeInt_ReturnAsInt()
    {
        //Arrange
        var parsed = -Dummy.Create<int>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<int>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsPositiveInt_ReturnAsInt()
    {
        //Arrange
        var parsed = Dummy.Create<int>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<int>();

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
        var defaultValue = Dummy.Create<int>();

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
        var defaultValue = Dummy.Create<int>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<int>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToIntAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Dummy.Create<int>()}.{Dummy.Create<int>()}";
        var defaultValue = Dummy.Create<int>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsNegativeLong_ReturnAsLong()
    {
        //Arrange
        var parsed = -Dummy.Create<long>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<long>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsPositiveLong_ReturnAsLong()
    {
        //Arrange
        var parsed = Dummy.Create<long>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<long>();

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
        var defaultValue = Dummy.Create<long>();

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
        var defaultValue = Dummy.Create<long>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<long>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToLongAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Dummy.Create<long>()}.{Dummy.Create<long>()}";
        var defaultValue = Dummy.Create<long>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsNegativeFloat_ReturnAsFloat()
    {
        //Arrange
        var parsed = -Dummy.Create<float>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<float>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsPositiveFloat_ReturnAsFloat()
    {
        //Arrange
        var parsed = Dummy.Create<float>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<float>();

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
        var defaultValue = Dummy.Create<float>();

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
        var defaultValue = Dummy.Create<float>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(float.NegativeInfinity);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<float>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToFloatAndValueHasFloatingPoint_ReturnParsed()
    {
        //Arrange
        var parsed = Dummy.Create<float>() + Dummy.Create<float>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<float>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsNegativeDouble_ReturnAsDouble()
    {
        //Arrange
        var parsed = -Dummy.Create<double>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<double>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsPositiveDouble_ReturnAsDouble()
    {
        //Arrange
        var parsed = Dummy.Create<double>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<double>();

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
        var defaultValue = Dummy.Create<double>();

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
        var defaultValue = Dummy.Create<double>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(double.NegativeInfinity);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<double>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDoubleAndValueHasFloatingPoint_ReturnParsed()
    {
        //Arrange
        var parsed = Dummy.Create<double>() + Dummy.Create<double>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<double>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsNegativeDecimal_ReturnAsDecimal()
    {
        //Arrange
        var parsed = -Dummy.Create<decimal>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<decimal>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsPositiveDecimal_ReturnAsDecimal()
    {
        //Arrange
        var parsed = Dummy.Create<decimal>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<decimal>();

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
        var defaultValue = Dummy.Create<decimal>();

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
        var defaultValue = Dummy.Create<decimal>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<decimal>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDecimalAndValueHasFloatingPoint_ReturnParsed()
    {
        //Arrange
        var parsed = Dummy.Create<decimal>() + Dummy.Create<decimal>() / 100;
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<decimal>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsPositiveByte_ReturnAsByte()
    {
        //Arrange
        var parsed = Dummy.Create<byte>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<byte>();

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
        var defaultValue = Dummy.Create<byte>();

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
        var defaultValue = Dummy.Create<byte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<byte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToByteAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Dummy.Create<byte>()}.{Dummy.Create<byte>()}";
        var defaultValue = Dummy.Create<byte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsNegativeSByte_ReturnAsSByte()
    {
        //Arrange
        var parsed = (sbyte)-Dummy.Create<sbyte>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<sbyte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsPositiveSByte_ReturnAsSByte()
    {
        //Arrange
        var parsed = Dummy.Create<sbyte>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<sbyte>();

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
        var defaultValue = Dummy.Create<sbyte>();

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
        var defaultValue = Dummy.Create<sbyte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<sbyte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToSByteAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Dummy.Create<sbyte>()}.{Dummy.Create<sbyte>()}";
        var defaultValue = Dummy.Create<sbyte>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsNegativeShort_ReturnAsShort()
    {
        //Arrange
        var parsed = (short)-Dummy.Create<short>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<short>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsPositiveShort_ReturnAsShort()
    {
        //Arrange
        var parsed = Dummy.Create<short>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<short>();

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
        var defaultValue = Dummy.Create<short>();

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
        var defaultValue = Dummy.Create<short>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<short>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToShortAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Dummy.Create<short>()}.{Dummy.Create<short>()}";
        var defaultValue = Dummy.Create<short>();

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
        var defaultValue = Dummy.Create<char>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(' ');
    }

    [TestMethod]
    public void WhenConvertingToCharAndValueIsNotChar_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<char>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToCharAndValueIsSingleChar_ReturnAsChar()
    {
        //Arrange
        var parsed = Dummy.Create<char>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<char>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsPositiveUInt_ReturnAsUInt()
    {
        //Arrange
        var parsed = Dummy.Create<uint>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<uint>();

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
        var defaultValue = Dummy.Create<uint>();

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
        var defaultValue = Dummy.Create<uint>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<uint>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUIntAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Dummy.Create<uint>()}.{Dummy.Create<uint>()}";
        var defaultValue = Dummy.Create<uint>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsPositiveULong_ReturnAsULong()
    {
        //Arrange
        var parsed = Dummy.Create<ulong>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<ulong>();

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
        var defaultValue = Dummy.Create<ulong>();

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
        var defaultValue = Dummy.Create<ulong>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<ulong>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToULongAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Dummy.Create<ulong>()}.{Dummy.Create<ulong>()}";
        var defaultValue = Dummy.Create<ulong>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsPositiveUShort_ReturnAsUShort()
    {
        //Arrange
        var parsed = Dummy.Create<ushort>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<ushort>();

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
        var defaultValue = Dummy.Create<ushort>();

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
        var defaultValue = Dummy.Create<ushort>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueIsNotNumeric_ReturnDefaultValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<ushort>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUShortAndValueHasFloatingPoint_ReturnDefaultValue()
    {
        //Arrange
        var value = $"{Dummy.Create<ushort>()}.{Dummy.Create<ushort>()}";
        var defaultValue = Dummy.Create<ushort>();

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
        var defaultValue = Dummy.Create<bool>();

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
        var defaultValue = Dummy.Create<bool>();

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
        var defaultValue = Dummy.Create<bool>();

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
        var defaultValue = Dummy.Create<bool>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(false);
    }

    [TestMethod]
    public void WhenConvertingToBoolAndValueIsNotTrueOrFalse_ReturnDefault()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<bool>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsValidDateTime_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<DateTime>();

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
        var defaultValue = Dummy.Create<DateTime>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsNotDateTime_ReturnDefault()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<DateTime>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsNotUsingSameCultureInfo_ReturnDefault()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
        var defaultValue = Dummy.Create<DateTime>();

        //Act
        var result = value.ParseOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeAndValueIsUsingSameCultureInfo_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
        var defaultValue = Dummy.Create<DateTime>();

        //Act
        var result = value.ParseOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsValidDateTimeOffset_ReturnAsDateTimeOffset()
    {
        //Arrange
        var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<DateTimeOffset>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsNotDateTimeOffset_ReturnDefault()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<DateTimeOffset>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsNotUsingSameCultureInfo_ReturnDefault()
    {
        //Arrange
        var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
        var defaultValue = Dummy.Create<DateTimeOffset>();

        //Act
        var result = value.ParseOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToDateTimeOffsetAndValueIsUsingSameCultureInfo_ReturnAsDateTimeOffset()
    {
        //Arrange
        var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
        var defaultValue = Dummy.Create<DateTimeOffset>();

        //Act
        var result = value.ParseOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToVersionAndValueIsCorrectlyFormattedVersion_ReturnAsVersion()
    {
        //Arrange
        var parsed = Dummy.Create<Version>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<Version>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().BeEquivalentTo(parsed);
    }

    [TestMethod]
    public void WhenConvertingToVersionAndValueIsNotVersion_ReturnDefault()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<Version>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToTimeSpanAndValueIsValidTimeSpan_ReturnAsTimeSpan()
    {
        //Arrange
        var parsed = Dummy.Create<TimeSpan>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<TimeSpan>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToTimeSpanAndValueIsNotTimeSpan_ReturnDefault()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<TimeSpan>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToGuidAndValueIsValidGuid_ReturnAsGuid()
    {
        //Arrange
        var parsed = Dummy.Create<Guid>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<Guid>();

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
        var defaultValue = Dummy.Create<Guid>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToBigIntegerAndValueIsNumeric_ReturnAsBigInteger()
    {
        //Arrange
        var parsed = Dummy.Create<BigInteger>();
        var value = parsed.ToString();
        var defaultValue = Dummy.Create<BigInteger>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void WhenConvertingToBigIntegerAndValueIsNotNumeric_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<BigInteger>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void WhenConvertingToUnsupportedType_returnDefault()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<DummyUnsupportedType>();

        //Act
        var result = value.ParseOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }
}