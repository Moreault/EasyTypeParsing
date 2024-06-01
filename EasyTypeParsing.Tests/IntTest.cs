namespace EasyTypeParsing.Tests;

[TestClass]
public class IntTest
{
    [TestClass]
    public class ToInt : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().BeEquivalentTo(Result<int>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNegativeInt_ReturnAsInt()
        {
            //Arrange
            var parsed = -Dummy.Create<int>();
            var value = parsed.ToString();

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().Be(Result<int>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsPositiveInt_ReturnAsInt()
        {
            //Arrange
            var parsed = Dummy.Create<int>();
            var value = parsed.ToString();

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().Be(Result<int>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanIntUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = ((long)int.MaxValue + 1).ToString();

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().BeEquivalentTo(Result<int>.Failure());
        }

        [TestMethod]
        public void WhenStringIsLesserThanIntLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = ((long)int.MinValue - 1).ToString();

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().BeEquivalentTo(Result<int>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().BeEquivalentTo(Result<int>.Failure());
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Create<int>()}.{Dummy.Create<int>()}";

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().BeEquivalentTo(Result<int>.Failure());
        }
    }

    [TestClass]
    public class ToIntOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNegativeInt_ReturnAsInt()
        {
            //Arrange
            var parsed = -Dummy.Create<int>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsPositiveInt_ReturnAsInt()
        {
            //Arrange
            var parsed = Dummy.Create<int>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanIntUpperLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = ((long)int.MaxValue + 1).ToString();
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanIntLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = ((long)int.MinValue - 1).ToString();
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Dummy.Create<int>()}.{Dummy.Create<int>()}";
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToIntOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToIntOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringIsNegativeInt_ReturnAsInt()
        {
            //Arrange
            var parsed = -Dummy.Create<int>();
            var value = parsed.ToString();

            //Act
            var result = value.ToIntOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringIsPositiveInt_ReturnAsInt()
        {
            //Arrange
            var parsed = Dummy.Create<int>();
            var value = parsed.ToString();

            //Act
            var result = value.ToIntOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringIsBiggerThanIntUpperLimit_Throw()
        {
            //Arrange
            var value = ((long)int.MaxValue + 1).ToString();

            //Act
            Action action = () => value.ToIntOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<int>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Int32)));
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringIsLesserThanIntLowerLimit_Throw()
        {
            //Arrange
            var value = ((long)int.MinValue - 1).ToString();

            //Act
            Action action = () => value.ToIntOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<int>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Int32)));
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            Action action = () => value.ToIntOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<int>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Int32)));
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Dummy.Create<int>()}.{Dummy.Create<int>()}";

            //Act
            Action action = () => value.ToIntOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<int>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Int32)));
        }
    }

    [TestClass]
    public class ToNullableInt : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToNullableInt();

            //Assert
            result.Should().BeEquivalentTo(Result<int?>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNegativeInt_ReturnAsInt()
        {
            //Arrange
            var parsed = -Dummy.Create<int>();
            var value = parsed.ToString();

            //Act
            var result = value.ToNullableInt();

            //Assert
            result.Should().Be(Result<int?>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsPositiveInt_ReturnAsInt()
        {
            //Arrange
            var parsed = Dummy.Create<int>();
            var value = parsed.ToString();

            //Act
            var result = value.ToNullableInt();

            //Assert
            result.Should().Be(Result<int?>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanIntUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = ((long)int.MaxValue + 1).ToString();

            //Act
            var result = value.ToNullableInt();

            //Assert
            result.Should().BeEquivalentTo(Result<int?>.Failure());
        }

        [TestMethod]
        public void WhenStringIsLesserThanIntLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = ((long)int.MinValue - 1).ToString();

            //Act
            var result = value.ToNullableInt();

            //Assert
            result.Should().BeEquivalentTo(Result<int?>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToNullableInt();

            //Assert
            result.Should().BeEquivalentTo(Result<int?>.Failure());
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Create<int>()}.{Dummy.Create<int>()}";

            //Act
            var result = value.ToNullableInt();

            //Assert
            result.Should().BeEquivalentTo(Result<int?>.Failure());
        }

        [TestMethod]
        public void WhenStringHasOneDigitBeforeFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Number.Between(0, 9)}.{Dummy.Create<int>()}";

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringHasTwoDigitsBeforeFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Number.Between(10, 99)}.{Dummy.Create<int>()}";

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringHasThreeDigitsBeforeFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Number.Between(100, 999)}.{Dummy.Create<int>()}";

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringHasFourDigitsBeforeFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Number.Between(1000, 9999)}.{Dummy.Create<int>()}";

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringHasFiveDigitsBeforeFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Number.Between(10000, 99999)}.{Dummy.Create<int>()}";

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringHasSixDigitsBeforeFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Number.Between(100000, 999999)}.{Dummy.Create<int>()}";

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringHasSevenDigitsBeforeFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Number.Between(1000000, 9999999)}.{Dummy.Create<int>()}";

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringHasEightDigitsBeforeFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Number.Between(10000000, 99999999)}.{Dummy.Create<int>()}";

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringHasNineDigitsBeforeFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Number.Between(100000000, 999999999)}.{Dummy.Create<int>()}";

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }
    }

    [TestClass]
    public class ToNullableIntOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmptyAndNoDefaultValueIsSpecified_ReturnDefaultValue(string value)
        {
            //Arrange

            //Act
            var result = value.ToNullableIntOrDefault();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToNullableIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNegativeInt_ReturnAsInt()
        {
            //Arrange
            var parsed = -Dummy.Create<int>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToNullableIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsPositiveInt_ReturnAsInt()
        {
            //Arrange
            var parsed = Dummy.Create<int>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToNullableIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanIntUpperLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = ((long)int.MaxValue + 1).ToString();
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToNullableIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanIntLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = ((long)int.MinValue - 1).ToString();
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToNullableIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToNullableIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Dummy.Create<int>()}.{Dummy.Create<int>()}";
            var defaultValue = Dummy.Create<int>();

            //Act
            var result = value.ToNullableIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }
}