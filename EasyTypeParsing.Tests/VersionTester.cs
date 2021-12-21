namespace EasyTypeParsing.Tests;

[TestClass]
public class VersionTester
{
    [TestClass]
    public class ToVersion : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToVersion();

            //Assert
            result.Should().BeEquivalentTo(TryGetResult<Version>.Failure);
        }

        [TestMethod]
        public void WhenIsCorrectlyFormattedVersion_ReturnAsVersion()
        {
            //Arrange
            var parsed = Fixture.Create<Version>();
            var value = parsed.ToString();

            //Act
            var result = value.ToVersion();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<Version>(true, parsed));
        }

        [TestMethod]
        public void WhenValueIsNotVersion_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToVersion();

            //Assert
            result.Should().BeEquivalentTo(TryGetResult<Version>.Failure);
        }
    }

    [TestClass]
    public class ToVersionOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefault(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<Version>();

            //Act
            var result = value.ToVersionOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenIsCorrectlyFormattedVersion_ReturnAsVersion()
        {
            //Arrange
            var parsed = Fixture.Create<Version>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<Version>();

            //Act
            var result = value.ToVersionOrDefault(defaultValue);

            //Assert
            result.Should().BeEquivalentTo(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotVersion_ReturnDefault()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<Version>();

            //Act
            var result = value.ToVersionOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToVersionOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToVersionOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenIsCorrectlyFormattedVersion_ReturnAsVersion()
        {
            //Arrange
            var parsed = Fixture.Create<Version>();
            var value = parsed.ToString();

            //Act
            var result = value.ToVersionOrThrow();

            //Assert
            result.Should().BeEquivalentTo(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotVersion_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToVersionOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<Version>>().WithMessage($"Can't parse string to {nameof(Version)} : Its value was {value}");
        }
    }
}