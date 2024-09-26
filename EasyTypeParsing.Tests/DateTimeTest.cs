namespace EasyTypeParsing.Tests;

[TestClass]
public class DateTimeTest : Tester
{
    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToDateTime_WhenValueIsEmpty_ReturnFailure(string value)
    {
        //Arrange

        //Act
        var result = value.ToDateTime();

        //Assert
        result.Should().BeEquivalentTo(Result<DateTime>.Failure());
    }

    [TestMethod]
    public void ToDateTime_WhenValueIsValidDateTime_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ToDateTime();

        //Assert
        result.Should().BeEquivalentTo(Result<DateTime>.Success(parsed));
    }

    [TestMethod]
    public void ToDateTime_WhenValueIsValidDateTime_CorrectlyReApplyMilliseconds()
    {
        //Arrange
        var parsed = new DateTime(2022, 3, 7, 14, 43, 26, 535);
        const string value = "03/07/2022 14:43:26.535";

        //Act
        var result = value.ToDateTime();

        //Assert
        result.Should().BeEquivalentTo(Result<DateTime>.Success(parsed));
    }

    [TestMethod]
    public void ToDateTime_WhenValueIsNotDateTime_ReturnFailure()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        var result = value.ToDateTime();

        //Assert
        result.Should().BeEquivalentTo(Result<DateTime>.Failure());
    }

    [TestMethod]
    public void ToDateTime_WhenValueIsNotUsingSameCultureInfo_ReturnFailure()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.ToDateTime(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        result.Should().BeEquivalentTo(Result<DateTime>.Failure());
    }

    [TestMethod]
    public void ToDateTime_WhenValueIsUsingSameCultureInfo_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.ToDateTime(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().BeEquivalentTo(Result<DateTime>.Success(parsed));
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToDateTimeOrDefault_WhenValueIsEmpty_ReturnDefault(string value)
    {
        //Arrange
        var defaultValue = Dummy.Create<DateTime>();

        //Act
        var result = value.ToDateTimeOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void ToDateTimeOrDefault_WhenValueIsValidDateTime_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);
        var defaultValue = Dummy.Create<DateTime>();

        //Act
        var result = value.ToDateTimeOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void ToDateTimeOrDefault_WhenValueIsValidDateTime_CorrectlyReApplyMilliseconds()
    {
        //Arrange
        var parsed = new DateTime(2022, 3, 7, 14, 43, 26, 535);
        const string value = "03/07/2022 14:43:26.535";
        var defaultValue = Dummy.Create<DateTime>();

        //Act
        var result = value.ToDateTimeOrDefault(defaultValue);

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void ToDateTimeOrDefault_WhenValueIsNotDateTime_ReturnDefault()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var defaultValue = Dummy.Create<DateTime>();

        //Act
        var result = value.ToDateTimeOrDefault(defaultValue);

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void ToDateTimeOrDefault_WhenValueIsNotUsingSameCultureInfo_ReturnDefault()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
        var defaultValue = Dummy.Create<DateTime>();

        //Act
        var result = value.ToDateTimeOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert
        result.Should().Be(defaultValue);
    }

    [TestMethod]
    public void ToDateTimeOrDefault_WhenValueIsUsingSameCultureInfo_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
        var defaultValue = Dummy.Create<DateTime>();

        //Act
        var result = value.ToDateTimeOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToDateTimeOrThrow_WhenValueIsEmpty_Throw(string value)
    {
        //Arrange

        //Act
        Action action = () => value.ToDateTimeOrThrow();

        //Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void ToDateTimeOrThrow_WhenValueIsValidDateTime_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.ToDateTimeOrThrow();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void ToDateTimeOrThrow_WhenValueIsValidDateTime_CorrectlyReApplyMilliseconds()
    {
        //Arrange
        var parsed = new DateTime(2022, 3, 7, 14, 43, 26, 535);
        const string value = "03/07/2022 14:43:26.535";

        //Act
        var result = value.ToDateTimeOrThrow();

        //Assert
        result.Should().Be(parsed);
    }

    [TestMethod]
    public void ToDateTimeOrThrow_WhenValueIsNotDateTime_Throw()
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        Action action = () => value.ToDateTimeOrThrow();

        //Assert
        action.Should().Throw<StringParsingException<DateTime>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(DateTime)));
    }

    [TestMethod]
    public void ToDateTimeOrThrow_WhenValueIsNotUsingSameCultureInfo_Throw()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        Action action = () => value.ToDateTimeOrThrow(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

        //Assert    
        action.Should().Throw<StringParsingException<DateTime>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(DateTime)));
    }

    [TestMethod]
    public void ToDateTimeOrThrow_WhenValueIsUsingSameCultureInfo_ReturnAsDateTime()
    {
        //Arrange
        var parsed = Dummy.Create<DateTime>().TrimMilliseconds();
        var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

        //Act
        var result = value.ToDateTimeOrThrow(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

        //Assert
        result.Should().Be(parsed);
    }
}