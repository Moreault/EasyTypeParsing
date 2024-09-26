namespace EasyTypeParsing.Tests;

[TestClass]
public sealed class TimeOnlyTests : Tester
{
    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToTimeOnly_WhenValueIsEmpty_ReturnFailure(string value)
    {
        //Arrange

        //Act
        var result = value.ToTimeOnly();

        //Assert
        result.Should().BeEquivalentTo(Result<TimeOnly>.Failure());
    }

    [TestMethod]
    public void ToTimeOnly_WhenValueIsValidTimeOnly_ReturnAsTimeOnly()
    {
        //Arrange
        var parsed = Dummy.Create<TimeOnly>();
        var value = parsed.ToString();

        //Act
        var result = value.ToTimeOnly();

        //Assert
        result.Value.Should().BeCloseTo(parsed, TimeSpan.FromMinutes(1));
    }

    [TestMethod]
    public void ToTimeOnly_WhenValueIsValidTimeOnly_CorrectlyReApplyMilliseconds()
    {
        //Arrange
        var parsed = new TimeOnly(14, 43, 26, 535);
        const string value = "14:43:26.535";

        //Act
        var result = value.ToTimeOnly();

        //Assert
        result.Should().BeEquivalentTo(Result<TimeOnly>.Success(parsed));
    }

    [TestMethod]
    public void ToTimeOnly_WhenValueIsNotTimeOnly_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.ToTimeOnly();

        //Assert
        result.Should().BeEquivalentTo(Result<TimeOnly>.Failure());
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToTimeOnlyOrDefault_WhenValueIsEmpty_ReturnDefault(string value)
    {
        //Arrange
        var defaultValue = Dummy.Create<TimeOnly>();

        //Act
        var result = value.ToTimeOnlyOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void ToTimeOnlyOrDefault_WhenValueIsValidTimeOnly_ReturnAsTimeOnly()
    {
        //Arrange
        var parsed = Dummy.Create<TimeOnly>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<TimeOnly>();

        //Act
        var result = value.ToTimeOnlyOrDefault(defaultValue);

        //Assert
        result.Should().BeCloseTo(parsed, TimeSpan.FromMinutes(1));
    }

    [TestMethod]
    public void ToTimeOnlyOrDefault_WhenValueIsValidTimeOnly_CorrectlyReApplyMilliseconds()
    {
        //Arrange
        var parsed = new TimeOnly(14, 43, 26, 535);
        const string value = "14:43:26.535";
        var defaultValue = Dummy.Create<TimeOnly>();

        //Act
        var result = value.ToTimeOnlyOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void ToTimeOnlyOrDefault_WhenValueIsNotTimeOnly_ReturnDefault()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<TimeOnly>();

        //Act
        var result = value.ToTimeOnlyOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToTimeOnlyOrThrow_WhenValueIsEmpty_Throw(string value)
    {
        //Arrange

        //Act
        Action action = () => value.ToTimeOnlyOrThrow();

        //Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void ToTimeOnlyOrThrow_WhenValueIsValidTimeOnly_ReturnAsTimeOnly()
    {
        //Arrange
        var parsed = Dummy.Create<TimeOnly>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ToTimeOnlyOrThrow();

        //Assert
        result.Should().BeCloseTo(parsed, TimeSpan.FromMinutes(1));
    }

    [TestMethod]
    public void ToTimeOnlyOrThrow_WhenValueIsValidTimeOnly_CorrectlyReApplyMilliseconds()
    {
        //Arrange
        var parsed = new TimeOnly(14, 43, 26, 535);
        const string value = "14:43:26.535";

        //Act
        var result = value.ToTimeOnlyOrThrow();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void ToTimeOnlyOrThrow_WhenValueIsNotTimeOnly_Throw()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        Action action = () => value.ToTimeOnlyOrThrow();

        //Assert
        action.Should().Throw<StringParsingException<TimeOnly>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(TimeOnly)));
    }
}