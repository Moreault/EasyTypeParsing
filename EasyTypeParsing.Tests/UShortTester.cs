namespace EasyTypeParsing.Tests;

[TestClass]
public class UShortTester
{
    [TestClass]
    public class ToUShort : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<ushort>(false));
        }

        [TestMethod]
        public void WhenStringIsUShort_ReturnAsUShort()
        {
            //Arrange
            var parsed = Fixture.Create<ushort>();
            var value = parsed.ToString();

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().Be(new TryGetResult<ushort>(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanUShortUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = "18446744073709551616";

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<ushort>(false));
        }

        [TestMethod]
        public void WhenStringIsLesserThanUShortLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-1";

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<ushort>(false));
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<ushort>(false));
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Fixture.Create<ushort>()}.{Fixture.Create<ushort>()}";

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<ushort>(false));
        }
    }

    [TestClass]
    public class ToUShortOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsPositiveUShort_ReturnAsUShort()
        {
            //Arrange
            var parsed = Fixture.Create<ushort>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanUShortUpperLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = "18446744073709551616";
            var defaultValue = Fixture.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanUShortLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = " -1";
            var defaultValue = Fixture.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Fixture.Create<ushort>()}.{Fixture.Create<ushort>()}";
            var defaultValue = Fixture.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToUShortOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToUShortOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToUShortAndStringIsPositiveUShort_ReturnAsUShort()
        {
            //Arrange
            var parsed = Fixture.Create<ushort>();
            var value = parsed.ToString();

            //Act
            var result = value.ToUShortOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToUShortAndStringIsBiggerThanUShortUpperLimit_Throw()
        {
            //Arrange
            var value = "18446744073709551616";

            //Act
            Action action = () => value.ToUShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ushort>>().WithMessage($"Can't parse string to {nameof(UInt16)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToUShortAndStringIsLesserThanUShortLowerLimit_Throw()
        {
            //Arrange
            var value = "-1";

            //Act
            Action action = () => value.ToUShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ushort>>().WithMessage($"Can't parse string to {nameof(UInt16)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToUShortAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToUShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ushort>>().WithMessage($"Can't parse string to {nameof(UInt16)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToUShortAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Fixture.Create<ushort>()}.{Fixture.Create<ushort>()}";

            //Act
            Action action = () => value.ToUShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ushort>>().WithMessage($"Can't parse string to {nameof(UInt16)} : Its value was {value}");
        }
    }
}