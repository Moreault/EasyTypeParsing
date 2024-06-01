namespace EasyTypeParsing.Tests;

[TestClass]
public class ByteTest
{
    [TestClass]
    public class ToByte : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringIsPositiveByte_ReturnAsByte()
        {
            //Arrange
            var parsed = Dummy.Create<byte>();
            var value = parsed.ToString();

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().Be(Result<byte>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanByteUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = ((long)byte.MaxValue + 1).ToString();

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringIsLesserThanByteLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = ((long)byte.MinValue - 1).ToString();

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Create<byte>()}.{Dummy.Create<byte>()}";

            //Act
            var result = value.ToByte();

            //Assert
            result.Should().BeEquivalentTo(Result<byte>.Failure());
        }
    }

    [TestClass]
    public class ToByteOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Dummy.Create<byte>();

            //Act
            var result = value.ToByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsPositiveByte_ReturnAsByte()
        {
            //Arrange
            var parsed = Dummy.Create<byte>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<byte>();

            //Act
            var result = value.ToByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanByteUpperLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = ((long)byte.MaxValue + 1).ToString();
            var defaultValue = Dummy.Create<byte>();

            //Act
            var result = value.ToByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanByteLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = ((long)byte.MinValue - 1).ToString();
            var defaultValue = Dummy.Create<byte>();

            //Act
            var result = value.ToByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<byte>();

            //Act
            var result = value.ToByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPointWithOneDigit_ReturnDefaultValue()
        {
            //Arrange
            var firstPart = Dummy.Number.Between<byte>(0, 9).Create();
            var value = $"{firstPart}.{Dummy.Create<byte>()}";
            var defaultValue = Dummy.Create<byte>();

            //Act
            var result = value.ToByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPointWithTwoDigits_ReturnDefaultValue()
        {
            //Arrange
            var firstPart = Dummy.Number.Between<byte>(10, 99).Create();
            var value = $"{firstPart}.{Dummy.Create<byte>()}";
            var defaultValue = Dummy.Create<byte>();

            //Act
            var result = value.ToByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPointWithThreeDigits_ReturnDefaultValue()
        {
            //Arrange
            var firstPart = Dummy.Number.Between<byte>(100, byte.MaxValue).Create();
            var value = $"{firstPart}.{Dummy.Create<byte>()}";
            var defaultValue = Dummy.Create<byte>();

            //Act
            var result = value.ToByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToByteOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToByteOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToByteAndStringIsPositiveByte_ReturnAsByte()
        {
            //Arrange
            var parsed = Dummy.Create<byte>();
            var value = parsed.ToString();

            //Act
            var result = value.ToByteOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToByteAndStringIsBiggerThanByteUpperLimit_Throw()
        {
            //Arrange
            var value = ((long)byte.MaxValue + 1).ToString();

            //Act
            Action action = () => value.ToByteOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<byte>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Byte)));
        }

        [TestMethod]
        public void WhenConvertingToByteAndStringIsLesserThanByteLowerLimit_Throw()
        {
            //Arrange
            var value = ((long)byte.MinValue - 1).ToString();

            //Act
            Action action = () => value.ToByteOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<byte>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Byte)));
        }

        [TestMethod]
        public void WhenConvertingToByteAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            Action action = () => value.ToByteOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<byte>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Byte)));
        }

        [TestMethod]
        public void WhenConvertingToByteAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Dummy.Create<byte>()}.{Dummy.Create<byte>()}";

            //Act
            Action action = () => value.ToByteOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<byte>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Byte)));
        }
    }
}