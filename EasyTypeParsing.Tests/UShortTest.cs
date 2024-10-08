﻿namespace EasyTypeParsing.Tests;

[TestClass]
public class UShortTest
{
    [TestClass]
    public class ToUShort : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().BeEquivalentTo(Result<ushort>.Failure());
        }

        [TestMethod]
        public void WhenStringIsUShort_ReturnAsUShort()
        {
            //Arrange
            var parsed = Dummy.Create<ushort>();
            var value = parsed.ToString();

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().Be(Result<ushort>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanUShortUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = "18446744073709551616";

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().BeEquivalentTo(Result<ushort>.Failure());
        }

        [TestMethod]
        public void WhenStringIsLesserThanUShortLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-1";

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().BeEquivalentTo(Result<ushort>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().BeEquivalentTo(Result<ushort>.Failure());
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Create<ushort>()}.{Dummy.Create<ushort>()}";

            //Act
            var result = value.ToUShort();

            //Assert
            result.Should().BeEquivalentTo(Result<ushort>.Failure());
        }
    }

    [TestClass]
    public class ToUShortOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Dummy.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsPositiveUShort_ReturnAsUShort()
        {
            //Arrange
            var parsed = Dummy.Create<ushort>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanUShortUpperLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = "18446744073709551616";
            var defaultValue = Dummy.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanUShortLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = " -1";
            var defaultValue = Dummy.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Dummy.Create<ushort>()}.{Dummy.Create<ushort>()}";
            var defaultValue = Dummy.Create<ushort>();

            //Act
            var result = value.ToUShortOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToUShortOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToUShortOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToUShortAndStringIsPositiveUShort_ReturnAsUShort()
        {
            //Arrange
            var parsed = Dummy.Create<ushort>();
            var value = parsed.ToString();

            //Act
            var result = value.ToUShortOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToUShortAndStringIsBiggerThanUShortUpperLimit_Throw()
        {
            //Arrange
            var value = "18446744073709551616";

            //Act
            Action action = () => value.ToUShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ushort>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt16)));
        }

        [TestMethod]
        public void WhenConvertingToUShortAndStringIsLesserThanUShortLowerLimit_Throw()
        {
            //Arrange
            var value = "-1";

            //Act
            Action action = () => value.ToUShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ushort>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt16)));
        }

        [TestMethod]
        public void WhenConvertingToUShortAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            Action action = () => value.ToUShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ushort>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt16)));
        }

        [TestMethod]
        public void WhenConvertingToUShortAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Dummy.Create<ushort>()}.{Dummy.Create<ushort>()}";

            //Act
            Action action = () => value.ToUShortOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<ushort>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt16)));
        }
    }
}