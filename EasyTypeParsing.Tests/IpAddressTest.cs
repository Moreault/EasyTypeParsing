namespace EasyTypeParsing.Tests;

[TestClass]
public class IpAddressTest
{
    [TestClass]
    public class ToIpAddress : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToIpAddress();

            //Assert
            result.Should().BeEquivalentTo(Result<IPAddress>.Failure());
        }

        [TestMethod]
        public void WhenIsCorrectlyFormattedIPAddress_ReturnAsIPAddress()
        {
            //Arrange
            var parsed = Dummy.Create<IPAddress>();
            var value = parsed.ToString();

            //Act
            var result = value.ToIpAddress();

            //Assert
            result.Should().BeEquivalentTo(Result<IPAddress>.Success(parsed));
        }

        [TestMethod]
        public void WhenValueIsNotIPAddress_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToIpAddress();

            //Assert
            result.Should().BeEquivalentTo(Result<IPAddress>.Failure());
        }
    }

    [TestClass]
    public class ToIpAddressOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefault(string value)
        {
            //Arrange
            var defaultValue = Dummy.Create<IPAddress>();

            //Act
            var result = value.ToIpAddressOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenIsCorrectlyFormattedIPAddress_ReturnAsIPAddress()
        {
            //Arrange
            var parsed = Dummy.Create<IPAddress>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<IPAddress>();

            //Act
            var result = value.ToIpAddressOrDefault(defaultValue);

            //Assert
            result.Should().BeEquivalentTo(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotIPAddress_ReturnDefault()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<IPAddress>();

            //Act
            var result = value.ToIpAddressOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToIpAddressOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToIpAddressOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenIsCorrectlyFormattedIPAddress_ReturnAsIPAddress()
        {
            //Arrange
            var parsed = Dummy.Create<IPAddress>();
            var value = parsed.ToString();

            //Act
            var result = value.ToIpAddressOrThrow();

            //Assert
            result.Should().BeEquivalentTo(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotIPAddress_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            Action action = () => value.ToIpAddressOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<IPAddress>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(IPAddress)));
        }
    }
}