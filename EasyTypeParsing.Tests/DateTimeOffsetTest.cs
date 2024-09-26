namespace EasyTypeParsing.Tests;

[TestClass]
public class DateTimeOffsetTest
{
    [TestClass]
    public class ToDateTimeOffset : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToDateTimeOffset();

            //Assert
            result.Should().BeEquivalentTo(Result<DateTimeOffset>.Failure());
        }

        [TestMethod]
        public void WhenValueIsValidDateTimeOffset_ReturnAsDateTimeOffset()
        {
            //Arrange
            var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDateTimeOffset();

            //Assert
            result.Should().BeEquivalentTo(Result<DateTimeOffset>.Success(parsed));
        }

        [TestMethod]
        public void WhenValueIsNotDateTimeOffset_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToDateTimeOffset();

            //Assert
            result.Should().BeEquivalentTo(Result<DateTimeOffset>.Failure());
        }

        [TestMethod]
        public void WhenValueIsNotUsingSameCultureInfo_ReturnFailure()
        {
            //Arrange
            var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

            //Act
            var result = value.ToDateTimeOffset(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

            //Assert
            result.Should().BeEquivalentTo(Result<DateTimeOffset>.Failure());
        }

        [TestMethod]
        public void WhenValueIsUsingSameCultureInfo_ReturnAsDateTimeOffset()
        {
            //Arrange
            var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

            //Act
            var result = value.ToDateTimeOffset(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

            //Assert
            result.Should().BeEquivalentTo(Result<DateTimeOffset>.Success(parsed));
        }
    }

    [TestClass]
    public class ToDateTimeOffsetOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefault(string value)
        {
            //Arrange
            var defaultValue = Dummy.Create<DateTimeOffset>();

            //Act
            var result = value.ToDateTimeOffsetOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsValidDateTimeOffset_ReturnAsDateTimeOffset()
        {
            //Arrange
            var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Dummy.Create<DateTimeOffset>();

            //Act
            var result = value.ToDateTimeOffsetOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotDateTimeOffset_ReturnDefault()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<DateTimeOffset>();

            //Act
            var result = value.ToDateTimeOffsetOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsNotUsingSameCultureInfo_ReturnDefault()
        {
            //Arrange
            var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
            var defaultValue = Dummy.Create<DateTimeOffset>();

            //Act
            var result = value.ToDateTimeOffsetOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsUsingSameCultureInfo_ReturnAsDateTimeOffset()
        {
            //Arrange
            var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
            var defaultValue = Dummy.Create<DateTimeOffset>();

            //Act
            var result = value.ToDateTimeOffsetOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

            //Assert
            result.Should().Be(parsed);
        }
    }

    [TestClass]
    public class ToDateTimeOffsetOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToDateTimeOffsetOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenValueIsValidDateTimeOffset_ReturnAsDateTimeOffset()
        {
            //Arrange
            var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDateTimeOffsetOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotDateTimeOffset_Throw()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            Action action = () => value.ToDateTimeOffsetOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<DateTimeOffset>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(DateTimeOffset)));
        }

        [TestMethod]
        public void WhenValueIsNotUsingSameCultureInfo_Throw()
        {
            //Arrange
            var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

            //Act
            Action action = () => value.ToDateTimeOffsetOrThrow(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

            //Assert
            action.Should().Throw<StringParsingException<DateTimeOffset>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(DateTimeOffset)));
        }

        [TestMethod]
        public void WhenValueIsUsingSameCultureInfo_ReturnAsDateTimeOffset()
        {
            //Arrange
            var parsed = Dummy.Create<DateTimeOffset>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

            //Act
            var result = value.ToDateTimeOffsetOrThrow(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

            //Assert
            result.Should().Be(parsed);
        }
    }
}