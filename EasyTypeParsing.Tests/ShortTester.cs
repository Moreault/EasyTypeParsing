namespace EasyTypeParsing.Tests;

[TestClass]
public class ShortTester
{
    [TestClass]
    public class ToShort : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToShort();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<short>(false));
        }

        [TestMethod]
        public void WhenStringIsNegativeShort_ReturnAsShort()
        {
            //Arrange
            var parsed = (short)-Fixture.Create<short>();
            var value = parsed.ToString();

            //Act
            var result = value.ToShort();

            //Assert
            result.Should().Be(new TryGetResult<short>(parsed));
        }

        [TestMethod]
        public void WhenStringIsPositiveShort_ReturnAsShort()
        {
            //Arrange
            var parsed = Fixture.Create<short>();
            var value = parsed.ToString();

            //Act
            var result = value.ToShort();

            //Assert
            result.Should().Be(new TryGetResult<short>(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanShortUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = "32768";

            //Act
            var result = value.ToShort();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<short>(false));
        }

        [TestMethod]
        public void WhenStringIsLesserThanShortLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-32769";

            //Act
            var result = value.ToShort();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<short>(false));
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToShort();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<short>(false));
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Fixture.Create<short>()}.{Fixture.Create<short>()}";

            //Act
            var result = value.ToShort();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<short>(false));
        }
    }

    [TestClass]
    public class ToShortOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<short>();

            //Act
            var result = value.ToShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNegativeShort_ReturnAsShort()
        {
            //Arrange
            var parsed = (short)-Fixture.Create<short>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<short>();

            //Act
            var result = value.ToShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsPositiveShort_ReturnAsShort()
        {
            //Arrange
            var parsed = Fixture.Create<short>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<short>();

            //Act
            var result = value.ToShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanShortUpperLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = "32768";
            var defaultValue = Fixture.Create<short>();

            //Act
            var result = value.ToShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanShortLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = " -32769";
            var defaultValue = Fixture.Create<short>();

            //Act
            var result = value.ToShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<short>();

            //Act
            var result = value.ToShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Fixture.Create<short>()}.{Fixture.Create<short>()}";
            var defaultValue = Fixture.Create<short>();

            //Act
            var result = value.ToShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToShortOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToShortOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToShortAndStringIsNegativeShort_ReturnAsShort()
        {
            //Arrange
            var parsed = (short)-Fixture.Create<short>();
            var value = parsed.ToString();

            //Act
            var result = value.ToShortOrThrow();

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
            var result = value.ToShortOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToShortAndStringIsBiggerThanShortUpperLimit_Throw()
        {
            //Arrange
            var value = "32768";

            //Act
            Action action = () => value.ToShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<short>>().WithMessage($"Can't parse string to {nameof(Int16)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToShortAndStringIsLesserThanShortLowerLimit_Throw()
        {
            //Arrange
            var value = "-32769";

            //Act
            Action action = () => value.ToShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<short>>().WithMessage($"Can't parse string to {nameof(Int16)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToShortAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<short>>().WithMessage($"Can't parse string to {nameof(Int16)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToShortAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Fixture.Create<short>()}.{Fixture.Create<short>()}";

            //Act
            Action action = () => value.ToShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<short>>().WithMessage($"Can't parse string to {nameof(Int16)} : Its value was {value}");
        }
    }
}