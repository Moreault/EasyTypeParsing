namespace EasyTypeParsing.Tests;

[TestClass]
public class DoubleTest
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
            result.Should().BeEquivalentTo(Result<double>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNegativeDouble_ReturnAsDouble()
        {
            //Arrange
            var parsed = -Dummy.Create<double>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().Be(Result<double>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsPositiveDouble_ReturnAsDouble()
        {
            //Arrange
            var parsed = Dummy.Create<double>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().Be(Result<double>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanDoubleUpperLimit_ReturnPositiveInfinity()
        {
            //Arrange
            var value = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().BeEquivalentTo(Result<double>.Success(double.PositiveInfinity));
        }

        [TestMethod]
        public void WhenStringIsLesserThanDoubleLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999223373679999999999999999999999999999999999999999999999999999999997645764567457547457699999999999999999999999999999999999999999999999999547645764576657620312342141341341243124312436854775809.999999999999999999999999999999999999999999999999999999982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().BeEquivalentTo(Result<double>.Success(double.NegativeInfinity));
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().BeEquivalentTo(Result<double>.Failure());
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnAsDouble()
        {
            //Arrange
            var parsed = Dummy.Create<double>() + Dummy.Create<double>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDouble();

            //Assert
            result.Should().BeEquivalentTo(Result<double>.Success(parsed));
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
            var defaultValue = Dummy.Create<double>();

            //Act
            var result = value.ToDoubleOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNegativeDouble_ReturnAsDouble()
        {
            //Arrange
            var parsed = -Dummy.Create<double>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Dummy.Create<double>();

            //Act
            var result = value.ToDoubleOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsPositiveDouble_ReturnAsDouble()
        {
            //Arrange
            var parsed = Dummy.Create<double>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Dummy.Create<double>();

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
            var defaultValue = Dummy.Create<double>();

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
            var defaultValue = Dummy.Create<double>();

            //Act
            var result = value.ToDoubleOrDefault(defaultValue);

            //Assert
            result.Should().Be(double.NegativeInfinity);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<double>();

            //Act
            var result = value.ToDoubleOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnParsed()
        {
            //Arrange
            var parsed = Dummy.Create<double>() + Dummy.Create<double>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Dummy.Create<double>();

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
            var parsed = -Dummy.Create<double>();
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
            var parsed = Dummy.Create<double>();
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
            var value = Dummy.Create<string>();

            //Act
            Action action = () => value.ToDoubleOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<double>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Double)));
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringHasFloatingPoint_ReturnParsed()
        {
            //Arrange
            var parsed = Dummy.Create<double>() + Dummy.Create<double>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDoubleOrThrow();

            //Assert
            result.Should().Be(parsed);
        }
    }
}