namespace EasyTypeParsing.Tests;

[TestClass]
public sealed class DateOnlyTests : Tester
{
    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToDateOnly_WhenValueIsEmpty_ReturnFailure(string value)
    {
        //Arrange

        //Act
        var result = value.ToDateOnly();

        //Assert
        result.Should().BeEquivalentTo(Result<DateOnly>.Failure());
    }

    [TestMethod]
    public void ToDateOnly_WhenValueIsValidDateOnly_ReturnAsDateOnly()
    {
        //Arrange
        var parsed = Dummy.Create<DateOnly>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ToDateOnly();

        //Assert
        result.Should().BeEquivalentTo(Result<DateOnly>.Success(parsed));
    }

    [TestMethod]
    public void ToDateOnly_WhenValueIsNotDateOnly_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.ToDateOnly();

        //Assert
        result.Should().BeEquivalentTo(Result<DateOnly>.Failure());
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToDateOnlyOrDefault_WhenValueIsEmpty_ReturnDefault(string value)
    {
        //Arrange
        var defaultValue = Dummy.Create<DateOnly>();

        //Act
        var result = value.ToDateOnlyOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void ToDateOnlyOrDefault_WhenValueIsValidDateOnly_ReturnAsDateOnly()
    {
        //Arrange
        var parsed = Dummy.Create<DateOnly>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<DateOnly>();

        //Act
        var result = value.ToDateOnlyOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void ToDateOnlyOrDefault_WhenValueIsNotDateOnly_ReturnDefault()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<DateOnly>();

        //Act
        var result = value.ToDateOnlyOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToDateOnlyOrThrow_WhenValueIsEmpty_Throw(string value)
    {
        //Arrange

        //Act
        Action action = () => value.ToDateOnlyOrThrow();

        //Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void ToDateOnlyOrThrow_WhenValueIsValidDateOnly_ReturnAsDateOnly()
    {
        //Arrange
        var parsed = Dummy.Create<DateOnly>();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ToDateOnlyOrThrow();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void ToDateOnlyOrThrow_WhenValueIsNotDateOnly_Throw()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        Action action = () => value.ToDateOnlyOrThrow();

        //Assert
        action.Should().Throw<StringParsingException<DateOnly>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(DateOnly)));
    }
}