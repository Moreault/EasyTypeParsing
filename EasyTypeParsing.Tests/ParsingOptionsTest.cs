namespace EasyTypeParsing.Tests;

[TestClass]
public sealed class ParsingOptionsTest : RecordTester<ParsingOptions>
{
    [TestMethod]
    public void WhenDefault_UseDefaultValues()
    {
        //Arrange

        //Act
        var result = new ParsingOptions();

        //Assert
        result.Should().BeEquivalentTo(new ParsingOptions
        {
            FormatProvider = CultureInfo.InvariantCulture,
            NumberStyles = NumberStyles.Any,
            DateStyles = DateTimeStyles.None
        });
    }

    [TestMethod]
    public void WhenSettingFormatProvider_ReturnSameFormatProvider() => CustomCases.WhenHasCultureInfo(cultureInfo =>
    {
        //Arrange

        //Act
        var result = new ParsingOptions { FormatProvider = cultureInfo };

        //Assert
        result.FormatProvider.Should().Be(cultureInfo);
    });

    [TestMethod]
    [DataRow(NumberStyles.None)]
    [DataRow(NumberStyles.AllowLeadingWhite)]
    [DataRow(NumberStyles.AllowTrailingWhite)]
    [DataRow(NumberStyles.AllowLeadingSign)]
    [DataRow(NumberStyles.AllowTrailingSign)]
    [DataRow(NumberStyles.AllowParentheses)]
    [DataRow(NumberStyles.AllowDecimalPoint)]
    [DataRow(NumberStyles.AllowThousands)]
    [DataRow(NumberStyles.AllowExponent)]
    [DataRow(NumberStyles.AllowCurrencySymbol)]
    [DataRow(NumberStyles.AllowHexSpecifier)]
    [DataRow(NumberStyles.Integer)]
    [DataRow(NumberStyles.HexNumber)]
    [DataRow(NumberStyles.Number)]
    [DataRow(NumberStyles.Float)]
    [DataRow(NumberStyles.Currency)]
    [DataRow(NumberStyles.Any)]
    public void WhenSettingNumberStyles_ReturnSameNumberStyles(NumberStyles numberStyles)
    {
        //Arrange

        //Act
        var result = new ParsingOptions { NumberStyles = numberStyles };

        //Assert
        result.NumberStyles.Should().Be(numberStyles);
    }

    [TestMethod]
    [DataRow(DateTimeStyles.None)]
    [DataRow(DateTimeStyles.AllowLeadingWhite)]
    [DataRow(DateTimeStyles.AllowTrailingWhite)]
    [DataRow(DateTimeStyles.AllowInnerWhite)]
    [DataRow(DateTimeStyles.AllowWhiteSpaces)]
    [DataRow(DateTimeStyles.NoCurrentDateDefault)]
    [DataRow(DateTimeStyles.AdjustToUniversal)]
    [DataRow(DateTimeStyles.AssumeLocal)]
    [DataRow(DateTimeStyles.AssumeUniversal)]
    [DataRow(DateTimeStyles.RoundtripKind)]
    public void WhenSettingDateStyles_ReturnSameDateStyles(DateTimeStyles dateStyles)
    {
        //Arrange

        //Act
        var result = new ParsingOptions { DateStyles = dateStyles };

        //Assert
        result.DateStyles.Should().Be(dateStyles);
    }

    [TestMethod]
    public void Always_HasValueEquality() => Ensure.ValueEquality<ParsingOptions>(Fixture);
}

public static class CustomCases
{
    public static void WhenHasCultureInfo(Action<CultureInfo> action)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));
        var cultures = new List<CultureInfo>
        {
            CultureInfo.InvariantCulture,
            CultureInfo.CreateSpecificCulture("en-us"),
            CultureInfo.CreateSpecificCulture("en-ca"),
            CultureInfo.CreateSpecificCulture("fr-ca"),
        };

        foreach (var culture in cultures)
        {
            action.Invoke(culture);
        }
    }
}