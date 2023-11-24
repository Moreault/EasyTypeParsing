namespace EasyTypeParsing.Tests;

[TestClass]
public class TimeSpanTest
{
    [TestClass]
    public class ToTimeSpan : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToTimeSpan();

            //Assert
            result.Should().BeEquivalentTo(TryGetResult<TimeSpan>.Failure);
        }

        [TestMethod]
        public void WhenValueIsValidTimeSpan_ReturnAsTimeSpan()
        {
            //Arrange
            var parsed = Fixture.Create<TimeSpan>();
            var value = parsed.ToString();

            //Act
            var result = value.ToTimeSpan();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<TimeSpan>(true, parsed));
        }

        [TestMethod]
        public void WhenValueIsNotTimeSpan_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToTimeSpan();

            //Assert
            result.Should().BeEquivalentTo(TryGetResult<TimeSpan>.Failure);
        }
    }

    [TestClass]
    public class ToTimeSpanOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefault(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<TimeSpan>();

            //Act
            var result = value.ToTimeSpanOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsValidTimeSpan_ReturnAsTimeSpan()
        {
            //Arrange
            var parsed = Fixture.Create<TimeSpan>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<TimeSpan>();

            //Act
            var result = value.ToTimeSpanOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotTimeSpan_ReturnDefault()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<TimeSpan>();

            //Act
            var result = value.ToTimeSpanOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToTimeSpanOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToTimeSpanOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenValueIsValidTimeSpan_ReturnAsTimeSpan()
        {
            //Arrange
            var parsed = Fixture.Create<TimeSpan>();
            var value = parsed.ToString();

            //Act
            var result = value.ToTimeSpanOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotTimeSpan_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToTimeSpanOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<TimeSpan>>().WithMessage($"Can't parse string to {nameof(TimeSpan)} : Its value was {value}");
        }
    }
}