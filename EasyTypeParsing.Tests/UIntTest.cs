﻿namespace EasyTypeParsing.Tests;

[TestClass]
public class UIntTest
{
    [TestClass]
    public class ToUInt : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnFailure(string value)
        {
            //Arrange

            //Act
            var result = value.ToUInt();

            //Assert
            result.Should().BeEquivalentTo(Result<uint>.Failure());
        }

        [TestMethod]
        public void WhenStringIsUInt_ReturnAsUInt()
        {
            //Arrange
            var parsed = Dummy.Create<uint>();
            var value = parsed.ToString();

            //Act
            var result = value.ToUInt();

            //Assert
            result.Should().Be(Result<uint>.Success(parsed));
        }

        [TestMethod]
        public void WhenStringIsBiggerThanUintUpperLimit_ReturnFailure()
        {
            //Arrange
            var value = "4294967296";

            //Act
            var result = value.ToUInt();

            //Assert
            result.Should().BeEquivalentTo(Result<uint>.Failure());
        }

        [TestMethod]
        public void WhenStringIsLesserThanUIntLowerLimit_ReturnFailure()
        {
            //Arrange
            var value = "-1";

            //Act
            var result = value.ToUInt();

            //Assert
            result.Should().BeEquivalentTo(Result<uint>.Failure());
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnFailure()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            var result = value.ToUInt();

            //Assert
            result.Should().BeEquivalentTo(Result<uint>.Failure());
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnFailure()
        {
            //Arrange
            var value = $"{Dummy.Create<uint>()}.{Dummy.Create<uint>()}";

            //Act
            var result = value.ToUInt();

            //Assert
            result.Should().BeEquivalentTo(Result<uint>.Failure());
        }
    }

    [TestClass]
    public class ToUIntOrDefault : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsEmpty_ReturnDefaultValue(string value)
        {
            //Arrange
            var defaultValue = Dummy.Create<uint>();

            //Act
            var result = value.ToUIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsPositiveUInt_ReturnAsUInt()
        {
            //Arrange
            var parsed = Dummy.Create<uint>();
            var value = parsed.ToString();
            var defaultValue = Dummy.Create<uint>();

            //Act
            var result = value.ToUIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenStringIsBiggerThanUIntUpperLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = "4294967296";
            var defaultValue = Dummy.Create<uint>();

            //Act
            var result = value.ToUIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsLesserThanUIntLowerLimit_ReturnDefaultValue()
        {
            //Arrange
            var value = " -1";
            var defaultValue = Dummy.Create<uint>();

            //Act
            var result = value.ToUIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringIsNotNumeric_ReturnDefaultValue()
        {
            //Arrange
            var value = Dummy.Create<string>();
            var defaultValue = Dummy.Create<uint>();

            //Act
            var result = value.ToUIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }

        [TestMethod]
        public void WhenStringHasFloatingPoint_ReturnDefaultValue()
        {
            //Arrange
            var value = $"{Dummy.Create<uint>()}.{Dummy.Create<uint>()}";
            var defaultValue = Dummy.Create<uint>();

            //Act
            var result = value.ToUIntOrDefault(defaultValue);

            //Assert
            result.Should().Be(defaultValue);
        }
    }

    [TestClass]
    public class ToUIntOrThrow : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenValueIsNullOrWhiteSpace_Throw(string value)
        {
            //Arrange

            //Act
            Action action = () => value.ToUIntOrThrow();

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenConvertingToUIntAndStringIsPositiveUInt_ReturnAsUInt()
        {
            //Arrange
            var parsed = Dummy.Create<uint>();
            var value = parsed.ToString();

            //Act
            var result = value.ToUIntOrThrow();

            //Assert
            result.Should().Be(parsed);
        }

        [TestMethod]
        public void WhenConvertingToUIntAndStringIsBiggerThanUIntUpperLimit_Throw()
        {
            //Arrange
            var value = "4294967296";

            //Act
            Action action = () => value.ToUIntOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<uint>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt32)));
        }

        [TestMethod]
        public void WhenConvertingToUIntAndStringIsLesserThanUIntLowerLimit_Throw()
        {
            //Arrange
            var value = "-1";

            //Act
            Action action = () => value.ToUIntOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<uint>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt32)));
        }

        [TestMethod]
        public void WhenConvertingToUIntAndStringIsNotNumeric_Throw()
        {
            //Arrange
            var value = Dummy.Create<string>();

            //Act
            Action action = () => value.ToUIntOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<uint>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt32)));
        }

        [TestMethod]
        public void WhenConvertingToUIntAndStringHasFloatingPoint_Throw()
        {
            //Arrange
            var value = $"{Dummy.Create<uint>()}.{Dummy.Create<uint>()}";

            //Act
            Action action = () => value.ToUIntOrThrow();

            //Assert
            action.Should().Throw<StringParsingException<uint>>().WithMessage(string.Format(ExceptionMessages.ParsingException, value, nameof(UInt32)));
        }
    }
}