namespace EasyTypeParsing.Tests;

[TestClass]
public class BoolTest
{
    [TestClass]
    public class ToBool : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToBool();

            //Assert
            result.Should().BeEquivalentTo(Result<bool>.Failure());
        }

        [TestMethod]
        public void WhenValueIsTrue_ReturnTrue()
        {
            //Arrange
            var value = true.ToString();

            //Act
            var result = value.ToBool();

            //Assert
            result.Should().BeEquivalentTo(Result<bool>.Success(true));
        }

        [TestMethod]
        public void WhenValueIsTrueInDifferentCaps_ReturnTrue()
        {
            //Arrange
            var value = "TrUe";

            //Act
            var result = value.ToBool();

            //Assert
            result.Should().BeEquivalentTo(Result<bool>.Success(true));
        }

        [TestMethod]
        public void WhenValueIsFalse_ReturnFalse()
        {
            //Arrange
            var value = false.ToString();

            //Act
            var result = value.ToBool();

            //Assert
            result.Should().BeEquivalentTo(Result<bool>.Success(false));
        }

        [TestMethod]
        public void WhenValueIsFalseInDifferentCaps_ReturnFalse()
        {
            //Arrange
            var value = "FaLsE";

            //Act
            var result = value.ToBool();

            //Assert
            result.Should().BeEquivalentTo(Result<bool>.Success(false));
        }

        [TestMethod]
        public void WhenValueIsNotTrueOrFalse_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToBool();

            //Assert
            result.Should().BeEquivalentTo(Result<bool>.Failure());
        }
    }

    [TestClass]
    public class ToBoolOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefault(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<bool>();

            //Act
            var result = value.ToBoolOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsTrue_ReturnTrue()
        {
            //Arrange
            var value = true.ToString();
            var defaultValue = Fixture.Create<bool>();

            //Act
            var result = value.ToBoolOrDefault(defaultValue);

            //Assert
            result.Should().Be(true);
        }

        [TestMethod]
        public void WhenValueIsTrueInDifferentCaps_ReturnTrue()
        {
            //Arrange
            var value = "TrUe";
            var defaultValue = Fixture.Create<bool>();

            //Act
            var result = value.ToBoolOrDefault(defaultValue);

            //Assert
            result.Should().Be(true);
        }

        [TestMethod]
        public void WhenValueIsFalse_ReturnFalse()
        {
            //Arrange
            var value = false.ToString();
            var defaultValue = Fixture.Create<bool>();

            //Act
            var result = value.ToBoolOrDefault(defaultValue);

            //Assert
            result.Should().Be(false);
        }

        [TestMethod]
        public void WhenValueIsFalseInDifferentCaps_ReturnFalse()
        {
            //Arrange
            var value = "FaLsE";
            var defaultValue = Fixture.Create<bool>();

            //Act
            var result = value.ToBoolOrDefault(defaultValue);

            //Assert
            result.Should().Be(false);
        }

        [TestMethod]
        public void WhenValueIsNotTrueOrFalse_ReturnDefault()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<bool>();

            //Act
            var result = value.ToBoolOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToBoolOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToBoolOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenValueIsTrue_ReturnTrue()
        {
            //Arrange
            var value = true.ToString();

            //Act
            var result = value.ToBoolOrThrow();

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenValueIsTrueInDifferentCaps_ReturnTrue()
        {
            //Arrange
            var value = "TrUe";

            //Act
            var result = value.ToBoolOrThrow();

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenValueIsFalse_ReturnFalse()
        {
            //Arrange
            var value = false.ToString();

            //Act
            var result = value.ToBoolOrThrow();

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenValueIsFalseInDifferentCaps_ReturnFalse()
        {
            //Arrange
            var value = "FaLsE";

            //Act
            var result = value.ToBoolOrThrow();

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenValueIsNotTrueOrFalse_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToBoolOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<bool>>().WithMessage($"Can't parse string to {nameof(Boolean)} : Its value was {value}");
        }
    }
}