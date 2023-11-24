namespace EasyTypeParsing.Tests;

[TestClass]
public class BigIntegerTest
{
    [TestClass]
    public class ToBigInteger : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToBigInteger();

            //Assert
            result.Should().BeEquivalentTo(TryGetResult<BigInteger>.Failure);
        }

        [TestMethod]
        public void WhenValueIsNumeric_ReturnAsBigInteger()
        {
            //Arrange
            var parsed = Fixture.Create<BigInteger>();
            var value = parsed.ToString();

            //Act
            var result = value.ToBigInteger();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<BigInteger>(true, parsed));
        }

        [TestMethod]
        public void WhenValueIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToBigInteger();

            //Assert
            result.Should().BeEquivalentTo(TryGetResult<BigInteger>.Failure);
        }
    }

    [TestClass]
    public class ToBigIntegerOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<BigInteger>();

            //Act
            var result = value.ToBigIntegerOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsNumeric_ReturnAsBigInteger()
        {
            //Arrange
            var parsed = Fixture.Create<BigInteger>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<BigInteger>();

            //Act
            var result = value.ToBigIntegerOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<BigInteger>();

            //Act
            var result = value.ToBigIntegerOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToBigIntegerOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToBigIntegerOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenValueIsNumeric_ReturnAsBigInteger()
        {
            //Arrange
            var parsed = Fixture.Create<BigInteger>();
            var value = parsed.ToString();

            //Act
            var result = value.ToBigIntegerOrThrow();

            //Assert
            result.Should().BeEquivalentTo(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToBigIntegerOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<BigInteger>>().WithMessage($"Can't parse string to {nameof(BigInteger)} : Its value was {value}");
        }
    }
}