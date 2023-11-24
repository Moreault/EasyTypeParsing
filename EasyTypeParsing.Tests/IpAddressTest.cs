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
            result.Should().BeEquivalentTo(TryGetResult<IPAddress>.Failure);
        }

        [TestMethod]
        public void WhenIsCorrectlyFormattedIPAddress_ReturnAsIPAddress()
        {
            //Arrange
            var parsed = Fixture.Create<IPAddress>();
            var value = parsed.ToString();

            //Act
            var result = value.ToIpAddress();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<IPAddress>(true, parsed));
        }

        [TestMethod]
        public void WhenValueIsNotIPAddress_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToIpAddress();

            //Assert
            result.Should().BeEquivalentTo(TryGetResult<IPAddress>.Failure);
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
            var defaultValue = Fixture.Create<IPAddress>();

            //Act
            var result = value.ToIpAddressOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenIsCorrectlyFormattedIPAddress_ReturnAsIPAddress()
        {
            //Arrange
            var parsed = Fixture.Create<IPAddress>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<IPAddress>();

            //Act
            var result = value.ToIpAddressOrDefault(defaultValue);

            //Assert
            result.Should().BeEquivalentTo(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotIPAddress_ReturnDefault()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<IPAddress>();

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
            var parsed = Fixture.Create<IPAddress>();
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
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToIpAddressOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<IPAddress>>().WithMessage($"Can't parse string to {nameof(IPAddress)} : Its value was {value}");
        }
    }
}