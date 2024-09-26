namespace EasyTypeParsing.Tests;

[TestClass]
public class ULongTest
{
    [TestClass]
    public class ToULong : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToULong();

            //Assert
            result.Should().BeEquivalentTo(Result<ulong>.Failure());
        }

        [TestMethod]
        public void WhenStringIsULong_ReturnAsULong()
        {
            //Arrange
            var parsed = Dummy.Create<ulong>();
            var value = parsed.ToString();

            //Act
            var result = value.ToULong();

            //Assert
            result.Should().Be(Result<ulong>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanULongUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = "18446744073709551616";

            //Act
            var result = value.ToULong();

            //Assert
            result.Should().BeEquivalentTo(Result<ulong>.Failure());
        }

        [TestMethod]
        public void WhenStringIsLesserThanULongLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-1";

            //Act
            var result = value.ToULong();

            //Assert
            result.Should().BeEquivalentTo(Result<ulong>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToULong();

            //Assert
            result.Should().BeEquivalentTo(Result<ulong>.Failure());
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Create<ulong>()}.{Dummy.Create<ulong>()}";

            //Act
            var result = value.ToULong();

            //Assert
            result.Should().BeEquivalentTo(Result<ulong>.Failure());
        }
    }

    [TestClass]
    public class ToULongOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Dummy.Create<ulong>();

            //Act
            var result = value.ToULongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsPositiveULong_ReturnAsULong()
        {
            //Arrange
            var parsed = Dummy.Create<ulong>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<ulong>();

            //Act
            var result = value.ToULongOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanULongUpperLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = "18446744073709551616";
            var defaultValue = Dummy.Create<ulong>();

            //Act
            var result = value.ToULongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanULongLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = " -1";
            var defaultValue = Dummy.Create<ulong>();

            //Act
            var result = value.ToULongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<ulong>();

            //Act
            var result = value.ToULongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Dummy.Create<ulong>()}.{Dummy.Create<ulong>()}";
            var defaultValue = Dummy.Create<ulong>();

            //Act
            var result = value.ToULongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToULongOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToULongOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToULongAndStringIsPositiveULong_ReturnAsULong()
        {
            //Arrange
            var parsed = Dummy.Create<ulong>();
            var value = parsed.ToString();

            //Act
            var result = value.ToULongOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToULongAndStringIsBiggerThanULongUpperLimit_Throw()
        {
            //Arrange
            var value = "18446744073709551616";

            //Act
            Action action = () => value.ToULongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ulong>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt64)));
        }

        [TestMethod]
        public void WhenConvertingToULongAndStringIsLesserThanULongLowerLimit_Throw()
        {
            //Arrange
            var value = "-1";

            //Act
            Action action = () => value.ToULongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ulong>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt64)));
        }

        [TestMethod]
        public void WhenConvertingToULongAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            Action action = () => value.ToULongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ulong>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt64)));
        }

        [TestMethod]
        public void WhenConvertingToLongAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Dummy.Create<ulong>()}.{Dummy.Create<ulong>()}";

            //Act
            Action action = () => value.ToULongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ulong>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt64)));
        }
    }
}