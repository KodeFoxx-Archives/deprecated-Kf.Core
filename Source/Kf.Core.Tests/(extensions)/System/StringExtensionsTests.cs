using System;
using Xunit;

namespace Kf.Core.Tests._extensions_.System
{
    public class StringExtensionsTests
    {
        #region Manipulation - RemoveMultipleWhiteSpaces()
        [Fact]
        public void RemoveMultipleWhitespaces_Returns_Correct_String() {
            // Arrange
            var expected = "This string is cleaned from whitespace overload.";
            var whitespaceOverload = "This            string is cleaned   from   whitespace overload.";
            var actual = String.Empty;

            // Act
            actual = whitespaceOverload.RemoveMultipleWhitespaces();

            // Assert
            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void RemoveMultipleWhitespaces_Doesnt_Throw_Exception_On_Null_String() {
            // Arrange
            var expected = (Exception)null;
            var actual = (Exception)null;
            var nullString = (string)null;

            // Act            
            try {
                var whitespacesRemoved = nullString.RemoveMultipleWhitespaces();
            } catch (Exception ex) {
                actual = ex;
            }

            // Assert
            Assert.Equal<Exception>(expected, actual);
        }
        #endregion

        #region Manipulation - Reverse()
        [Fact]
        public void Reverse_Returs_Correct_String() {
            // Arrange
            var input = "This string will be reversed! 007 will never know ;)...";
            var expected = "...); wonk reven lliw 700 !desrever eb lliw gnirts sihT";

            // Act
            var actual = input.Reverse();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Reverse_Doesnt_Throw_Exception_On_Null_String() {
            // Arrange
            var expected = (Exception)null;
            var actual = (Exception)null;
            var nullString = (string)null;

            // Act            
            try {
                var reversed = nullString.Reverse();
            } catch (Exception ex) {
                actual = ex;
            }

            // Assert
            Assert.Equal<Exception>(expected, actual);
        }
        #endregion

        #region Substring - GetFirst()
        [Fact]
        public void GetFirst_Returns_Correct_String() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = "Guinae";

            // Act
            var actual = input.GetFirst(6);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetFirst_Returns_Full_String_When_Requested_Amount_Exceeds_String_Length() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = "Guinae pig.";

            // Act
            var actual = input.GetFirst(input.Length * 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetFirst_Returns_Empty_String_When_Requested_0_Amount() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = String.Empty;

            // Act
            var actual = input.GetFirst(0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetFirst_Returns_Empty_String_When_Requested_Negative_Amount() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = String.Empty;

            // Act
            var actual = input.GetFirst(-1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetFirst_Doesnt_Throw_Exception_On_Null_String() {
            // Arrange
            var expected = (Exception)null;
            var actual = (Exception)null;
            var nullString = (string)null;

            // Act            
            try {
                var reversed = nullString.GetFirst(5);
            } catch (Exception ex) {
                actual = ex;
            }

            // Assert
            Assert.Equal<Exception>(expected, actual);
        }
        #endregion

        #region Substring - GetLast()
        [Fact]
        public void GetLast_Returns_Correct_String() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = "e pig.";

            // Act
            var actual = input.GetLast(6);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLast_Returns_Full_String_When_Requested_Amount_Exceeds_String_Length() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = "Guinae pig.";

            // Act
            var actual = input.GetLast(input.Length * 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLast_Returns_Empty_String_When_Requested_0_Amount() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = String.Empty;

            // Act
            var actual = input.GetLast(0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLast_Returns_Empty_String_When_Requested_Negative_Amount() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = String.Empty;

            // Act
            var actual = input.GetLast(-1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLast_Doesnt_Throw_Exception_On_Null_String() {
            // Arrange
            var expected = (Exception)null;
            var actual = (Exception)null;
            var nullString = (string)null;

            // Act            
            try {
                var reversed = nullString.GetLast(5);
            } catch (Exception ex) {
                actual = ex;
            }

            // Assert
            Assert.Equal<Exception>(expected, actual);
        }
        #endregion

        #region Substring - SubstringSafe()
        [Fact]
        public void SubstringSafe_Returns_Correct_String() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = "nae";

            // Act
            var actual = input.SubstringSafe(3, 3);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubstringSafe_Returns_Empty_String_When_StartIndex_Exceeds_String_Length() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = "";

            // Act
            var actual = input.SubstringSafe(input.Length * 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubstringSafe_Returns_Full_String_When_StartIndex_Is_Negative_String_Length() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = "Guinae pig.";

            // Act
            var actual = input.SubstringSafe(input.Length * -1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubstringSafe_Returns_Full_String_When_Length_Exceeds_String_Length() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = "Guinae pig.";

            // Act
            var actual = input.SubstringSafe(0, input.Length * 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubstringSafe_Returns_Cubstring_String_When_Length_Exceeds_String_Length() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = "e pig.";

            // Act
            var actual = input.SubstringSafe(5, input.Length * 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubstringSafe_Returns_Empty_String_When_Length_Is_Negative_String_Length() {
            // Arrange            
            var input = "Guinae pig.";
            var expected = "";

            // Act
            var actual = input.SubstringSafe(0, input.Length * -1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubstringSafe_Doesnt_Throw_Exception_On_Null_String() {
            // Arrange
            var expected = (Exception)null;
            var actual = (Exception)null;
            var nullString = (string)null;

            // Act            
            try {
                var reversed = nullString.SubstringSafe(5);
            } catch (Exception ex) {
                actual = ex;
            }

            // Assert
            Assert.Equal<Exception>(expected, actual);
        }
        #endregion
    }
}
