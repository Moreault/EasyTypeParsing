using EasyTypeParsing.Tests.Utilities;

namespace EasyTypeParsing.Tests;

[TestClass]
public class EnumTester
{
    [TestClass]
    public class ToEnum : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToEnum<DummyEnum>();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<DummyEnum>(false));
        }

        [TestMethod]
        public void WhenValueDoesNotCorrespondToAnEnumValue_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToEnum<DummyEnum>();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<DummyEnum>(false));
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueButDoesNotHaveTheSameCasing_Parse()
        {
            //Arrange
            var parsed = Fixture.Create<DummyEnum>();
            var value = parsed.ToString().ToUpperInvariant();

            //Act
            var result = value.ToEnum<DummyEnum>();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<DummyEnum>(true, parsed));
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueWithSameCasing_Parse()
        {
            //Arrange
            var parsed = Fixture.Create<DummyEnum>();
            var value = parsed.ToString();

            //Act
            var result = value.ToEnum<DummyEnum>();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<DummyEnum>(true, parsed));
        }
    }

    [TestClass]
    public class ToEnumOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefault(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<DummyEnum>();

            //Act
            var result = value.ToEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueDoesNotCorrespondToAnEnumValue_ReturnDefault()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<DummyEnum>();

            //Act
            var result = value.ToEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueButDoesNotHaveTheSameCasing_Parse()
        {
            //Arrange
            var parsed = Fixture.Create<DummyEnum>();
            var value = parsed.ToString().ToUpperInvariant();
            var defaultValue = Fixture.Create<DummyEnum>();

            //Act
            var result = value.ToEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueWithSameCasing_Parse()
        {
            //Arrange
            var parsed = Fixture.Create<DummyEnum>();
            var value = parsed.ToString();
            var defaultValue = Fixture.Create<DummyEnum>();

            //Act
            var result = value.ToEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }
    }

    [TestClass]
    public class ToEnumOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToEnumOrThrow<DummyEnum>();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenValueDoesNotCorrespondToAnEnumValue_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToEnumOrThrow<DummyEnum>();

            //Assert
            action.Should().Throw<StringParsingException<DummyEnum>>().WithMessage($"Can't parse string to {nameof(DummyEnum)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueButDoesNotHaveTheSameCasing_Parse()
        {
            //Arrange
            var parsed = Fixture.Create<DummyEnum>();
            var value = parsed.ToString().ToUpperInvariant();

            //Act
            var result = value.ToEnumOrThrow<DummyEnum>();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueWithSameCasing_Parse()
        {
            //Arrange
            var parsed = Fixture.Create<DummyEnum>();
            var value = parsed.ToString();

            //Act
            var result = value.ToEnumOrThrow<DummyEnum>();

            //Assert
            result.Should().Be(parsed);
        }
    }
}