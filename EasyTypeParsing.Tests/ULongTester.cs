namespace EasyTypeParsing.Tests;

[TestClass]
public class ULongTester
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
            result.Should().BeEquivalentTo(new TryGetResult<ulong>(false));
        }

        [TestMethod]
        public void WhenStringIsULong_ReturnAsULong()
        {
            //Arrange
            var parsed = Fixture.Create<ulong>();
            var value = parsed.ToString();

            //Act
            var result = value.ToULong();

            //Assert
            result.Should().Be(new TryGetResult<ulong>(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanULongUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = "18446744073709551616";

            //Act
            var result = value.ToULong();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<ulong>(false));
        }

        [TestMethod]
        public void WhenStringIsLesserThanULongLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-1";

            //Act
            var result = value.ToULong();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<ulong>(false));
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToULong();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<ulong>(false));
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Fixture.Create<ulong>()}.{Fixture.Create<ulong>()}";

            //Act
            var result = value.ToULong();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<ulong>(false));
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
            var defaultValue = Fixture.Create<ulong>();

            //Act
            var result = value.ToULongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsPositiveULong_ReturnAsULong()
        {
            //Arrange
            var parsed = Fixture.Create<ulong>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<ulong>();

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
            var defaultValue = Fixture.Create<ulong>();

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
            var defaultValue = Fixture.Create<ulong>();

            //Act
            var result = value.ToULongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<ulong>();

            //Act
            var result = value.ToULongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Fixture.Create<ulong>()}.{Fixture.Create<ulong>()}";
            var defaultValue = Fixture.Create<ulong>();

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
            var parsed = Fixture.Create<ulong>();
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
            action.Should().Throw<StringParsingException<ulong>>().WithMessage($"Can't parse string to {nameof(UInt64)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToULongAndStringIsLesserThanULongLowerLimit_Throw()
        {
            //Arrange
            var value = "-1";

            //Act
            Action action = () => value.ToULongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ulong>>().WithMessage($"Can't parse string to {nameof(UInt64)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToULongAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToULongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ulong>>().WithMessage($"Can't parse string to {nameof(UInt64)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToLongAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Fixture.Create<ulong>()}.{Fixture.Create<ulong>()}";

            //Act
            Action action = () => value.ToULongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ulong>>().WithMessage($"Can't parse string to {nameof(UInt64)} : Its value was {value}");
        }
    }
}