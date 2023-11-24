namespace EasyTypeParsing.Tests;

[TestClass]
public class CharTest
{
    [TestClass]
    public class ToChar : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void WhenValueIsNullOrEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToChar();

            //Assert
            result.Should().BeEquivalentTo(Result<char>.Failure());
        }

        [TestMethod]
        public void WhenValueIsWhiteSpace_ReturnAsChar()
        {
            //Arrange
            var value = " ";

            //Act
            var result = value.ToChar();

            //Assert
            result.Should().Be(Result<char>.Success(' '));
        }

        [TestMethod]
        public void WhenValueIsNotChar_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToChar();

            //Assert
            result.Should().BeEquivalentTo(Result<char>.Failure());
        }

        [TestMethod]
        public void WhenValueIsSingleChar_ReturnAsChar()
        {
            //Arrange
            var parsed = Fixture.Create<char>();
            var value = parsed.ToString();

            //Act
            var result = value.ToChar();

            //Assert
            result.Should().Be(Result<char>.Success(parsed));
        }
    }

    [TestClass]
    public class ToCharOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void WhenValueIsNullOrEmpty_ReturnFailure(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<char>();

            //Act
            var result = value.ToCharOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsWhiteSpace_ReturnAsChar()
        {
            //Arrange
            var value = " ";
            var defaultValue = Fixture.Create<char>();

            //Act
            var result = value.ToCharOrDefault(defaultValue);

            //Assert
            result.Should().Be(' ');
        }

        [TestMethod]
        public void WhenValueIsNotChar_ReturnDefaultValue()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<char>();

            //Act
            var result = value.ToCharOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsSingleChar_ReturnAsChar()
        {
            //Arrange
            var parsed = Fixture.Create<char>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<char>();

            //Act
            var result = value.ToCharOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }
    }

    [TestClass]
    public class ToCharOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void WhenValueIsNullOrEmpty_Throw(string value)
        {
            //Arrange

            //Act
            var action = () => value.ToCharOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenValueIsWhiteSpace_ReturnAsChar()
        {
            //Arrange
            var value = " ";

            //Act
            var result = value.ToCharOrThrow();

            //Assert
            result.Should().Be(' ');
        }

        [TestMethod]
        public void WhenValueIsNotChar_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var action = () => value.ToCharOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<char>>().WithMessage($"Can't parse string to {nameof(Char)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenValueIsSingleChar_ReturnAsChar()
        {
            //Arrange
            var parsed = Fixture.Create<char>();
            var value = parsed.ToString();

            //Act
            var result = value.ToCharOrThrow();

            //Assert
            result.Should().Be(parsed);
        }
    }

}