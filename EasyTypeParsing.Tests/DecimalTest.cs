namespace EasyTypeParsing.Tests;

[TestClass]
public class DecimalTest
{
    [TestClass]
    public class ToDecimal : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToDecimal();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<decimal>(false));
        }

        [TestMethod]
        public void WhenStringIsNegativeDecimal_ReturnAsDecimal()
        {
            //Arrange
            var parsed = -Fixture.Create<decimal>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDecimal();

            //Assert
            result.Should().Be(Result<decimal>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsPositiveDecimal_ReturnAsDecimal()
        {
            //Arrange
            var parsed = Fixture.Create<decimal>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDecimal();

            //Assert
            result.Should().Be(Result<decimal>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanDecimalUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToDecimal();

            //Assert
            result.Should().BeEquivalentTo(Result<decimal>.Failure());
        }

        [TestMethod]
        public void WhenStringIsLesserThanDecimalLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToDecimal();

            //Assert
            result.Should().BeEquivalentTo(Result<decimal>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToDecimal();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<decimal>(false));
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnAsDecimal()
        {
            //Arrange
            var parsed = Fixture.Create<decimal>() + Fixture.Create<decimal>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDecimal();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<decimal>(parsed));
        }
    }

    [TestClass]
    public class ToDecimalOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<decimal>();

            //Act
            var result = value.ToDecimalOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNegativeDecimal_ReturnAsDecimal()
        {
            //Arrange
            var parsed = -Fixture.Create<decimal>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Fixture.Create<decimal>();

            //Act
            var result = value.ToDecimalOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsPositiveDecimal_ReturnAsDecimal()
        {
            //Arrange
            var parsed = Fixture.Create<decimal>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Fixture.Create<decimal>();

            //Act
            var result = value.ToDecimalOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanDecimalUpperLimit_ReturnPositiveInfinity()
        {
            //Arrange
            var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
            var defaultValue = Fixture.Create<decimal>();

            //Act
            var result = value.ToDecimalOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanDecimalLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
            var defaultValue = Fixture.Create<decimal>();

            //Act
            var result = value.ToDecimalOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<decimal>();

            //Act
            var result = value.ToDecimalOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnParsed()
        {
            //Arrange
            var parsed = Fixture.Create<decimal>() + Fixture.Create<decimal>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Fixture.Create<decimal>();

            //Act
            var result = value.ToDecimalOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }
    }

    [TestClass]
    public class ToDecimalOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToDecimalOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToDecimalAndStringIsNegativeDecimal_ReturnAsDecimal()
        {
            //Arrange
            var parsed = -Fixture.Create<decimal>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDecimalOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToDecimalAndStringIsPositiveDecimal_ReturnAsDecimal()
        {
            //Arrange
            var parsed = Fixture.Create<decimal>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDecimalOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToDecimalAndStringIsBiggerThanDecimalUpperLimit_ReturnPositiveInfinity()
        {
            //Arrange
            var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            Action action = () => value.ToDecimalOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<decimal>>().WithMessage($"Can't parse string to {nameof(Decimal)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToDecimalAndStringIsLesserThanDecimalLowerLimit_ReturnNegativeInfinity()
        {
            //Arrange
            var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            Action action = () => value.ToDecimalOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<decimal>>().WithMessage($"Can't parse string to {nameof(Decimal)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToDecimalAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToDecimalOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<decimal>>().WithMessage($"Can't parse string to {nameof(Decimal)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringHasFloatingPoint_ReturnParsed()
        {
            //Arrange
            var parsed = Fixture.Create<decimal>() + Fixture.Create<decimal>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDecimalOrThrow();

            //Assert
            result.Should().Be(parsed);
        }
    }
}