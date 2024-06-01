namespace EasyTypeParsing.Tests;

[TestClass]
public class EnumTest
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
            result.Should().BeEquivalentTo(Result<DummyEnum>.Failure());
        }

        [TestMethod]
        public void WhenValueDoesNotCorrespondToAnEnumValue_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToEnum<DummyEnum>();

            //Assert
            result.Should().BeEquivalentTo(Result<DummyEnum>.Failure());
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueButDoesNotHaveTheSameCasing_Parse()
        {
            //Arrange
            var parsed = Dummy.Create<DummyEnum>();
            var value = parsed.ToString().ToUpperInvariant();

            //Act
            var result = value.ToEnum<DummyEnum>();

            //Assert
            result.Should().BeEquivalentTo(Result<DummyEnum>.Success(parsed));
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueWithSameCasing_Parse()
        {
            //Arrange
            var parsed = Dummy.Create<DummyEnum>();
            var value = parsed.ToString();

            //Act
            var result = value.ToEnum<DummyEnum>();

            //Assert
            result.Should().BeEquivalentTo(Result<DummyEnum>.Success(parsed));
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
            var defaultValue = Dummy.Create<DummyEnum>();

            //Act
            var result = value.ToEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueDoesNotCorrespondToAnEnumValue_ReturnDefault()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<DummyEnum>();

            //Act
            var result = value.ToEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueButDoesNotHaveTheSameCasing_Parse()
        {
            //Arrange
            var parsed = Dummy.Create<DummyEnum>();
            var value = parsed.ToString().ToUpperInvariant();
            var defaultValue = Dummy.Create<DummyEnum>();

            //Act
            var result = value.ToEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueWithSameCasing_Parse()
        {
            //Arrange
            var parsed = Dummy.Create<DummyEnum>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<DummyEnum>();

            //Act
            var result = value.ToEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }
    }

    [TestClass]
    public class ToNullableEnum : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToNullableEnum<DummyEnum>();

            //Assert
            result.Should().BeEquivalentTo(Result<DummyEnum?>.Failure());
        }

        [TestMethod]
        public void WhenValueDoesNotCorrespondToAnEnumValue_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToNullableEnum<DummyEnum>();

            //Assert
            result.Should().BeEquivalentTo(Result<DummyEnum?>.Failure());
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueButDoesNotHaveTheSameCasing_Parse()
        {
            //Arrange
            var parsed = Dummy.Create<DummyEnum>();
            var value = parsed.ToString().ToUpperInvariant();

            //Act
            var result = value.ToNullableEnum<DummyEnum>();

            //Assert
            result.Should().BeEquivalentTo(Result<DummyEnum?>.Success(parsed));
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueWithSameCasing_Parse()
        {
            //Arrange
            var parsed = Dummy.Create<DummyEnum>();
            var value = parsed.ToString();

            //Act
            var result = value.ToNullableEnum<DummyEnum>();

            //Assert
            result.Should().BeEquivalentTo(Result<DummyEnum?>.Success(parsed));
        }
    }

    [TestClass]
    public class ToNullableEnumOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmptyAndDefaultValueIsNotSpecified_ReturnNull(string value)
        {
            //Arrange

            //Act
            var result = value.ToNullableEnumOrDefault<DummyEnum>();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefault(string value)
        {
            //Arrange
            var defaultValue = Dummy.Create<DummyEnum?>();

            //Act
            var result = value.ToNullableEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueDoesNotCorrespondToAnEnumValue_ReturnDefault()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<DummyEnum?>();

            //Act
            var result = value.ToNullableEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueButDoesNotHaveTheSameCasing_Parse()
        {
            //Arrange
            var parsed = Dummy.Create<DummyEnum>();
            var value = parsed.ToString().ToUpperInvariant();
            var defaultValue = Dummy.Create<DummyEnum?>();

            //Act
            var result = value.ToNullableEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueCorrespondsToAnEnumValueWithSameCasing_Parse()
        {
            //Arrange
            var parsed = Dummy.Create<DummyEnum>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<DummyEnum?>();

            //Act
            var result = value.ToNullableEnumOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }
    }
}