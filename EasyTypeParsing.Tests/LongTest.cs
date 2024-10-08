﻿namespace EasyTypeParsing.Tests;

[TestClass]
public class LongTest
{
    [TestClass]
    public class ToLong : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().BeEquivalentTo(Result<long>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNegativeLong_ReturnAsLong()
        {
            //Arrange
            var parsed = -Dummy.Create<long>();
            var value = parsed.ToString();

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().Be(Result<long>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsPositiveLong_ReturnAsLong()
        {
            //Arrange
            var parsed = Dummy.Create<long>();
            var value = parsed.ToString();

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().Be(Result<long>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanLongUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = "9223372036854775808";

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().BeEquivalentTo(Result<long>.Failure());
        }

        [TestMethod]
        public void WhenStringIsLesserThanLongLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-9223372036854775809";

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().BeEquivalentTo(Result<long>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().BeEquivalentTo(Result<long>.Failure());
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Create<long>()}.{Dummy.Create<long>()}";

            //Act
            var result = value.ToLong();

            //Assert
            result.Should().BeEquivalentTo(Result<long>.Failure());
        }
    }

    [TestClass]
    public class ToLongOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Dummy.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNegativeLong_ReturnAsLong()
        {
            //Arrange
            var parsed = -Dummy.Create<long>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsPositiveLong_ReturnAsLong()
        {
            //Arrange
            var parsed = Dummy.Create<long>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanLongUpperLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = "9223372036854775808";
            var defaultValue = Dummy.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanLongLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = " -9223372036854775809";
            var defaultValue = Dummy.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Dummy.Create<long>()}.{Dummy.Create<long>()}";
            var defaultValue = Dummy.Create<long>();

            //Act
            var result = value.ToLongOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToLongOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToLongOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToLongAndStringIsNegativeLong_ReturnAsLong()
        {
            //Arrange
            var parsed = -Dummy.Create<long>();
            var value = parsed.ToString();

            //Act
            var result = value.ToLongOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToLongAndStringIsPositiveLong_ReturnAsLong()
        {
            //Arrange
            var parsed = Dummy.Create<long>();
            var value = parsed.ToString();

            //Act
            var result = value.ToLongOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToLongAndStringIsBiggerThanLongUpperLimit_Throw()
        {
            //Arrange
            var value = "9223372036854775808";

            //Act
            Action action = () => value.ToLongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<long>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Int64)));
        }

        [TestMethod]
        public void WhenConvertingToLongAndStringIsLesserThanLongLowerLimit_Throw()
        {
            //Arrange
            var value = "-9223372036854775809";

            //Act
            Action action = () => value.ToLongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<long>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Int64)));
        }

        [TestMethod]
        public void WhenConvertingToLongAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            Action action = () => value.ToLongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<long>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Int64)));
        }

        [TestMethod]
        public void WhenConvertingToIntAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Dummy.Create<long>()}.{Dummy.Create<long>()}";

            //Act
            Action action = () => value.ToLongOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<long>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(Int64)));
        }
    }
}