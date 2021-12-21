namespace EasyTypeParsing.Tests;

[TestClass]
public class SByteTester
{
    [TestClass]
    public class ToSByte : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToSByte();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<sbyte>(false));
        }

        [TestMethod]
        public void WhenStringIsNegativeSByte_ReturnAsSByte()
        {
            //Arrange
            var parsed = (sbyte)-Fixture.Create<sbyte>();
            var value = parsed.ToString();

            //Act
            var result = value.ToSByte();

            //Assert
            result.Should().Be(new TryGetResult<sbyte>(parsed));
        }

        [TestMethod]
        public void WhenStringIsPositiveSByte_ReturnAsSByte()
        {
            //Arrange
            var parsed = Fixture.Create<sbyte>();
            var value = parsed.ToString();

            //Act
            var result = value.ToSByte();

            //Assert
            result.Should().Be(new TryGetResult<sbyte>(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanSByteUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = "-129";

            //Act
            var result = value.ToSByte();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<sbyte>(false));
        }

        [TestMethod]
        public void WhenStringIsLesserThanSByteLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "128";

            //Act
            var result = value.ToSByte();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<sbyte>(false));
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToSByte();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<sbyte>(false));
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Fixture.Create<sbyte>()}.{Fixture.Create<sbyte>()}";

            //Act
            var result = value.ToSByte();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<sbyte>(false));
        }
    }

    [TestClass]
    public class ToSByteOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<sbyte>();

            //Act
            var result = value.ToSByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNegativeSByte_ReturnAsSByte()
        {
            //Arrange
            var parsed = (sbyte)-Fixture.Create<sbyte>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<sbyte>();

            //Act
            var result = value.ToSByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsPositiveSByte_ReturnAsSByte()
        {
            //Arrange
            var parsed = Fixture.Create<sbyte>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<sbyte>();

            //Act
            var result = value.ToSByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanSByteUpperLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = "128";
            var defaultValue = Fixture.Create<sbyte>();

            //Act
            var result = value.ToSByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanSByteLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = " -129";
            var defaultValue = Fixture.Create<sbyte>();

            //Act
            var result = value.ToSByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<sbyte>();

            //Act
            var result = value.ToSByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Fixture.Create<sbyte>()}.{Fixture.Create<sbyte>()}";
            var defaultValue = Fixture.Create<sbyte>();

            //Act
            var result = value.ToSByteOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToSByteOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToSByteOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToSByteAndStringIsNegativeSByte_ReturnAsSByte()
        {
            //Arrange
            var parsed = (sbyte)-Fixture.Create<sbyte>();
            var value = parsed.ToString();

            //Act
            var result = value.ToSByteOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToSByteAndStringIsPositiveSByte_ReturnAsSByte()
        {
            //Arrange
            var parsed = Fixture.Create<sbyte>();
            var value = parsed.ToString();

            //Act
            var result = value.ToSByteOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToSByteAndStringIsBiggerThanSByteUpperLimit_Throw()
        {
            //Arrange
            var value = "128";

            //Act
            Action action = () => value.ToSByteOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<sbyte>>().WithMessage($"Can't parse string to {nameof(SByte)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToSByteAndStringIsLesserThanSByteLowerLimit_Throw()
        {
            //Arrange
            var value = "-129";

            //Act
            Action action = () => value.ToSByteOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<sbyte>>().WithMessage($"Can't parse string to {nameof(SByte)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToSByteAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToSByteOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<sbyte>>().WithMessage($"Can't parse string to {nameof(SByte)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToSByteAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Fixture.Create<sbyte>()}.{Fixture.Create<sbyte>()}";

            //Act
            Action action = () => value.ToSByteOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<sbyte>>().WithMessage($"Can't parse string to {nameof(SByte)} : Its value was {value}");
        }
    }
}