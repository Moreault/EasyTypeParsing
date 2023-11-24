using EasyTypeParsing.Tests.Utilities;

namespace EasyTypeParsing.Tests;

[TestClass]
public class DateTimeTest
{
    [TestClass]
    public class ToDateTime : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToDateTime();

            //Assert
            result.Should().BeEquivalentTo(TryGetResult<DateTime>.Failure);
        }

        [TestMethod]
        public void WhenValueIsValidDateTime_ReturnAsDateTime()
        {
            //Arrange
            var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDateTime();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<DateTime>(true, parsed));
        }

        [TestMethod]
        public void WhenValueIsValidDateTime_CorrectlyReApplyMilliseconds()
        {
            //Arrange
            var parsed = new DateTime(2022, 3, 7, 14, 43, 26, 535);
            const string value = "03/07/2022 14:43:26.535";

            //Act
            var result = value.ToDateTime();

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<DateTime>(true, parsed));
        }

        [TestMethod]
        public void WhenValueIsNotDateTime_ReturnFailure()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var result = value.ToDateTime();

            //Assert
            result.Should().BeEquivalentTo(TryGetResult<DateTime>.Failure);
        }

        [TestMethod]
        public void WhenValueIsNotUsingSameCultureInfo_ReturnFailure()
        {
            //Arrange
            var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

            //Act
            var result = value.ToDateTime(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

            //Assert
            result.Should().BeEquivalentTo(TryGetResult<DateTime>.Failure);
        }

        [TestMethod]
        public void WhenValueIsUsingSameCultureInfo_ReturnAsDateTime()
        {
            //Arrange
            var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

            //Act
            var result = value.ToDateTime(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

            //Assert
            result.Should().BeEquivalentTo(new TryGetResult<DateTime>(true, parsed));
        }
    }

    [TestClass]
    public class ToDateTimeOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefault(string value)
        {
            //Arrange
            var defaultValue = Fixture.Create<DateTime>();

            //Act
            var result = value.ToDateTimeOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsValidDateTime_ReturnAsDateTime()
        {
            //Arrange
            var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.InvariantCulture);
            var defaultValue = Fixture.Create<DateTime>();

            //Act
            var result = value.ToDateTimeOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueIsValidDateTime_CorrectlyReApplyMilliseconds()
        {
            //Arrange
            var parsed = new DateTime(2022, 3, 7, 14, 43, 26, 535);
            const string value = "03/07/2022 14:43:26.535";
            var defaultValue = Fixture.Create<DateTime>();

            //Act
            var result = value.ToDateTimeOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueIsNotDateTime_ReturnDefault()
        {
            //Arrange
            var value = Fixture.Create<string>();
            var defaultValue = Fixture.Create<DateTime>();

            //Act
            var result = value.ToDateTimeOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsNotUsingSameCultureInfo_ReturnDefault()
        {
            //Arrange
            var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
            var defaultValue = Fixture.Create<DateTime>();

            //Act
            var result = value.ToDateTimeOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenValueIsUsingSameCultureInfo_ReturnAsDateTime()
        {
            //Arrange
            var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));
            var defaultValue = Fixture.Create<DateTime>();

            //Act
            var result = value.ToDateTimeOrDefault(defaultValue, new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

            //Assert
            result.Should().Be(parsed);
        }
    }

    [TestClass]
    public class ToDateTimeOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToDateTimeOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenValueIsValidDateTime_ReturnAsDateTime()
        {
            //Arrange
            var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.ToDateTimeOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenValueIsValidDateTime_CorrectlyReApplyMilliseconds()
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
        public void WhenValueIsNotDateTime_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => value.ToDateTimeOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<DateTime>>().WithMessage($"Can't parse string to {nameof(DateTime)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenValueIsNotUsingSameCultureInfo_Throw()
        {
            //Arrange
            var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

            //Act
            Action action = () => value.ToDateTimeOrThrow(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("en-us") });

            //Assert
            action.Should().Throw<StringParsingException<DateTime>>().WithMessage($"Can't parse string to {nameof(DateTime)} : Its value was {value}");
        }

        [TestMethod]
        public void WhenValueIsUsingSameCultureInfo_ReturnAsDateTime()
        {
            //Arrange
            var parsed = Fixture.Create<DateTime>().TrimMilliseconds();
            var value = parsed.ToString(CultureInfo.CreateSpecificCulture("fr-ca"));

            //Act
            var result = value.ToDateTimeOrThrow(new ParsingOptions { FormatProvider = CultureInfo.CreateSpecificCulture("fr-ca") });

            //Assert
            result.Should().Be(parsed);
        }
    }
}