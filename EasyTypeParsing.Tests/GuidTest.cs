namespace EasyTypeParsing.Tests;

[TestClass]
public class GuidTest
{
    [TestClass]
    public class ToGuid : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToGuid();

            //Assert
            result.Should().BeEquivalentTo(Result<Guid>.Failure());
        }

        [TestMethod]
        public void WhenValueIsGuid_ReturnAsGuid()
        {
            //Arrange
            var parsed = Fixture.Create<Guid>();
            var value = parsed.ToString();

            //Act
            var result = value.ToGuid();

            //Assert
            result.Should().BeEquivalentTo(Result<Guid>.Success(parsed));
        }

        [TestMethod]
        public void WhenValueIsNotGuid_ReturnFailure()
        {
            //Arrange
            var value = "this is not a guid";

            //Act
            var result = value.ToGuid();

            //Assert
            result.Should().BeEquivalentTo(Result<Guid>.Failure());
        }
    }

    [TestClass]
    public class ToGuidOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<Guid>();

            //Act
            var result = value.ToGuidOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsGuid_ReturnAsGuid()
        {
            //Arrange
            var parsed = Fixture.Create<Guid>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<Guid>();

            //Act
            var result = value.ToGuidOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotGuid_ReturnFailure()
        {
            //Arrange
            var value = "this is not a guid";
            var defaultValue = Fixture.Create<Guid>();

            //Act
            var result = value.ToGuidOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToGuidOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToGuidOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenValueIsGuid_ReturnAsGuid()
        {
            //Arrange
            var parsed = Fixture.Create<Guid>();
            var value = parsed.ToString();

            //Act
            var result = value.ToGuidOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotGuid_Throw()
        {
            //Arrange
            var value = "this is not a guid";

            //Act
            var action = () => value.ToGuidOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<Guid>>().WithMessage($"Can't parse string to {nameof(Guid)} : Its value was {value}");
        }
    }
}