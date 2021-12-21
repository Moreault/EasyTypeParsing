namespace EasyTypeParsing.Tests;

[TestClass]
public class DoubleTester
{
    [TestClass]
    public class ToDouble : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<double>(false));
        }

        [TestMethod]
        public void WhenStringIsNegativeDouble_ReturnAsDouble()
        {
            //Arrange
            var parsed = -Fixture.Create<double>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().Be(new TryGetResult<double>(parsed));
        }

        [TestMethod]
        public void WhenStringIsPositiveDouble_ReturnAsDouble()
        {
            //Arrange
            var parsed = Fixture.Create<double>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().Be(new TryGetResult<double>(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanDoubleUpperLimit_ReturnPositiveInfinity()
        {
            //Arrange
            var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<double>(double.PositiveInfinity));
        }

        [TestMethod]
        public void WhenStringIsLesserThanDoubleLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<double>(double.NegativeInfinity));
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<double>(false));
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnAsDouble()
        {
            //Arrange
            var parsed = Fixture.Create<double>() + Fixture.Create<double>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<double>(parsed));
        }
    }

    [TestClass]
    public class ToDoubleOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<double>();

            //Act
            var result = value.ToDoubleOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNegativeDouble_ReturnAsDouble()
        {
            //Arrange
            var parsed = -Fixture.Create<double>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Fixture.Create<double>();

            //Act
            var result = value.ToDoubleOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsPositiveDouble_ReturnAsDouble()
        {
            //Arrange
            var parsed = Fixture.Create<double>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Fixture.Create<double>();

            //Act
            var result = value.ToDoubleOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanDoubleUpperLimit_ReturnPositiveInfinity()
        {
            //Arrange
            var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
            var defaultValue = Fixture.Create<double>();

            //Act
            var result = value.ToDoubleOrDefault(defaultValue);

            //Assert
            result.Should().Be(double.PositiveInfinity);
        }

        [TestMethod]
        public void WhenStringIsLesserThanDoubleLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
            var defaultValue = Fixture.Create<double>();

            //Act
            var result = value.ToDoubleOrDefault(defaultValue);

            //Assert
            result.Should().Be(double.NegativeInfinity);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<double>();

            //Act
            var result = value.ToDoubleOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnParsed()
        {
            //Arrange
            var parsed = Fixture.Create<double>() + Fixture.Create<double>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Fixture.Create<double>();

            //Act
            var result = value.ToDoubleOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }
    }

    [TestClass]
    public class ToDoubleOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToDoubleOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToDoubleAndStringIsNegativeDouble_ReturnAsDouble()
        {
            //Arrange
            var parsed = -Fixture.Create<double>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDoubleOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToDoubleAndStringIsPositiveDouble_ReturnAsDouble()
        {
            //Arrange
            var parsed = Fixture.Create<double>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDoubleOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToDoubleAndStringIsBiggerThanDoubleUpperLimit_ReturnPositiveInfinity()
        {
            //Arrange
            var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToDoubleOrThrow();

            //Assert
            result.Should().Be(double.PositiveInfinity);
        }

        [TestMethod]
        public void WhenConvertingToDoubleAndStringIsLesserThanDoubleLowerLimit_ReturnNegativeInfinity()
        {
            //Arrange
            var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToDoubleOrThrow();

            //Assert
            result.Should().Be(double.NegativeInfinity);
        }

        [TestMethod]
        public void WhenConvertingToDoubleAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToDoubleOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<double>>().WithMessage($"Can't parse string to {nameof(Double)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringHasFloatingPoint_ReturnParsed()
        {
            //Arrange
            var parsed = Fixture.Create<double>() + Fixture.Create<double>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDoubleOrThrow();

            //Assert
            result.Should().Be(parsed);
        }
    }
}