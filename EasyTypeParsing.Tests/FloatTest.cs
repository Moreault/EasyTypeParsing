namespace EasyTypeParsing.Tests;

[TestClass]
public class FloatTest
{
    [TestClass]
    public class ToFloat : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToFloat();

            //Assert
            result.Should().BeEquivalentTo(Result<float>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNegativeFloat_ReturnAsFloat()
        {
            //Arrange
            var parsed = -Fixture.Create<float>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToFloat();

            //Assert
            result.Should().Be(Result<float>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsPositiveFloat_ReturnAsFloat()
        {
            //Arrange
            var parsed = Fixture.Create<float>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToFloat();

            //Assert
            result.Should().Be(Result<float>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanFloatUpperLimit_ReturnPositiveInfinity()
        {
            //Arrange
            var value = "92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToFloat();

            //Assert
            result.Should().BeEquivalentTo(Result<float>.Success(float.PositiveInfinity));
        }

        [TestMethod]
        public void WhenStringIsLesserThanFloatLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToFloat();

            //Assert
            result.Should().BeEquivalentTo(Result<float>.Success(float.NegativeInfinity));
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToFloat();

            //Assert
            result.Should().BeEquivalentTo(Result<float>.Failure());
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnAsFloat()
        {
            //Arrange
            var parsed = Fixture.Create<float>() + Fixture.Create<float>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToFloat();

            //Assert
            result.Should().BeEquivalentTo(Result<float>.Success(parsed));
        }
    }

    [TestClass]
    public class ToFloatOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<float>();

            //Act
            var result = value.ToFloatOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNegativeFloat_ReturnAsFloat()
        {
            //Arrange
            var parsed = -Fixture.Create<float>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Fixture.Create<float>();

            //Act
            var result = value.ToFloatOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsPositiveFloat_ReturnAsFloat()
        {
            //Arrange
            var parsed = Fixture.Create<float>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Fixture.Create<float>();

            //Act
            var result = value.ToFloatOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanFloatUpperLimit_ReturnPositiveInfinity()
        {
            //Arrange
            var value = "92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
            var defaultValue = Fixture.Create<float>();

            //Act
            var result = value.ToFloatOrDefault(defaultValue);

            //Assert
            result.Should().Be(float.PositiveInfinity);
        }

        [TestMethod]
        public void WhenStringIsLesserThanFloatLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = "-92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";
            var defaultValue = Fixture.Create<float>();

            //Act
            var result = value.ToFloatOrDefault(defaultValue);

            //Assert
            result.Should().Be(float.NegativeInfinity);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<float>();

            //Act
            var result = value.ToFloatOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnParsed()
        {
            //Arrange
            var parsed = Fixture.Create<float>() + Fixture.Create<float>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Fixture.Create<float>();

            //Act
            var result = value.ToFloatOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }
    }

    [TestClass]
    public class ToFloatOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToFloatOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToFloatAndStringIsNegativeFloat_ReturnAsFloat()
        {
            //Arrange
            var parsed = -Fixture.Create<float>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToFloatOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToFloatAndStringIsPositiveFloat_ReturnAsFloat()
        {
            //Arrange
            var parsed = Fixture.Create<float>();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToFloatOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToFloatAndStringIsBiggerThanFloatUpperLimit_ReturnPositiveInfinity()
        {
            //Arrange
            var value = "92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToFloatOrThrow();

            //Assert
            result.Should().Be(float.PositiveInfinity);
        }

        [TestMethod]
        public void WhenConvertingToFloatAndStringIsLesserThanFloatLowerLimit_ReturnNegativeInfinity()
        {
            //Arrange
            var value = "-92233736799999999999999999999999999999999999999999999999999999999976457645674575474576547645764576657620312342141341341243124312436854775809.982222222457454671243123412341243214312342134124312431245674575476745764574572222221111111133232323";

            //Act
            var result = value.ToFloatOrThrow();

            //Assert
            result.Should().Be(float.NegativeInfinity);
        }

        [TestMethod]
        public void WhenConvertingToFloatAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToFloatOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<float>>().WithMessage($"Can't parse string to {nameof(Single)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenConvertingToFloatAndStringHasFloatingPoint_ReturnParsed()
        {
            //Arrange
            var parsed = Fixture.Create<float>() + Fixture.Create<float>() / 100;
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToFloatOrThrow();

            //Assert
            result.Should().Be(parsed);
        }
    }
}