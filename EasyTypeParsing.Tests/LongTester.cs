namespace EasyTypeParsing.Tests;

[TestClass]
public class LongTester
{
    [TestClass]
    public class ToLong : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<long>(false));
        }

        [TestMethod]
        public void WhenStringIsNegativeLong_ReturnAsLong()
        {
            //Arrange
            var parsed = -Fixture.Create<long>();
            var value = parsed.ToString();

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().Be(new TryGetResult<long>(parsed));
        }

        [TestMethod]
        public void WhenStringIsPositiveLong_ReturnAsLong()
        {
            //Arrange
            var parsed = Fixture.Create<long>();
            var value = parsed.ToString();

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().Be(new TryGetResult<long>(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanLongUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = "9223372036854775808";

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<long>(false));
        }

        [TestMethod]
        public void WhenStringIsLesserThanLongLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-9223372036854775809";

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<long>(false));
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<long>(false));
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Fixture.Create<long>()}.{Fixture.Create<long>()}";

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<long>(false));
        }
    }

    [TestClass]
    public class ToLongOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNegativeLong_ReturnAsLong()
        {
            //Arrange
            var parsed = -Fixture.Create<long>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsPositiveLong_ReturnAsLong()
        {
            //Arrange
            var parsed = Fixture.Create<long>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanLongUpperLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = "9223372036854775808";
            var defaultValue = Fixture.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanLongLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = " -9223372036854775809";
            var defaultValue = Fixture.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Fixture.Create<long>()}.{Fixture.Create<long>()}";
            var defaultValue = Fixture.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToLongOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToLongOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToLongAndStringIsNegativeLong_ReturnAsLong()
        {
            //Arrange
            var parsed = -Fixture.Create<long>();
            var value = parsed.ToString();

            //Act
            var result = value.ToLongOrThrow();

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
            var result = value.ToLongOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToLongAndStringIsBiggerThanLongUpperLimit_Throw()
        {
            //Arrange
            var value = "9223372036854775808";

            //Act
            Action action = () => value.ToLongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<long>>().WithMessage($"Can't parse string to {nameof(Int64)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToLongAndStringIsLesserThanLongLowerLimit_Throw()
        {
            //Arrange
            var value = "-9223372036854775809";

            //Act
            Action action = () => value.ToLongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<long>>().WithMessage($"Can't parse string to {nameof(Int64)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToLongAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToLongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<long>>().WithMessage($"Can't parse string to {nameof(Int64)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Fixture.Create<long>()}.{Fixture.Create<long>()}";

            //Act
            Action action = () => value.ToLongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<long>>().WithMessage($"Can't parse string to {nameof(Int64)} : Its value was {value}");
        }
    }
}