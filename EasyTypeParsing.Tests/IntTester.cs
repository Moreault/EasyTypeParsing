namespace EasyTypeParsing.Tests;

[TestClass]
public class IntTester
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
            result.Should().BeEquivalentTo(new TryGetResult<int>(false));
        }

        [TestMethod]
        public void WhenStringIsNegativeInt_ReturnAsInt()
        {
            //Arrange
            var parsed = -Fixture.Create<int>();
            var value = parsed.ToString();

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().Be(new TryGetResult<int>(parsed));
        }

        [TestMethod]
        public void WhenStringIsPositiveInt_ReturnAsInt()
        {
            //Arrange
            var parsed = Fixture.Create<int>();
            var value = parsed.ToString();

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().Be(new TryGetResult<int>(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanIntUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = ((long)int.MaxValue + 1).ToString();

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<int>(false));
        }

        [TestMethod]
        public void WhenStringIsLesserThanIntLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = ((long)int.MinValue - 1).ToString();

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<int>(false));
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<int>(false));
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Fixture.Create<int>()}.{Fixture.Create<int>()}";

            //Act
            var result = value.ToInt();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<int>(false));
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
            var defaultValue = Fixture.Create<int>();

            //Act
            var result = value.ToIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNegativeInt_ReturnAsInt()
        {
            //Arrange
            var parsed = -Fixture.Create<int>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<int>();

            //Act
            var result = value.ToIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsPositiveInt_ReturnAsInt()
        {
            //Arrange
            var parsed = Fixture.Create<int>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<int>();

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
            var defaultValue = Fixture.Create<int>();

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
            var defaultValue = Fixture.Create<int>();

            //Act
            var result = value.ToIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<int>();

            //Act
            var result = value.ToIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Fixture.Create<int>()}.{Fixture.Create<int>()}";
            var defaultValue = Fixture.Create<int>();

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
            var parsed = -Fixture.Create<int>();
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
            var parsed = Fixture.Create<int>();
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
            action.Should().Throw<StringParsingException<int>>().WithMessage($"Can't parse string to {nameof(Int32)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringIsLesserThanIntLowerLimit_Throw()
        {
            //Arrange
            var value = ((long)int.MinValue - 1).ToString();

            //Act
            Action action = () => value.ToIntOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<int>>().WithMessage($"Can't parse string to {nameof(Int32)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToIntOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<int>>().WithMessage($"Can't parse string to {nameof(Int32)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Fixture.Create<int>()}.{Fixture.Create<int>()}";

            //Act
            Action action = () => value.ToIntOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<int>>().WithMessage($"Can't parse string to {nameof(Int32)} : Its value was {value}");
        }
    }
}