using System.Collections.Generic;
using System.Text;
using Kf.Core.Helpers.ForEach;
using Xunit;

namespace Kf.Core.Tests._helpers_.ForEach
{
    public class ForEachHelperTests
    {
        [Fact]
        public void Index_Int32_Returns_Correct_Enumerable_For_Enumerable_Of_T() {
            // Arrange
            var collection = new List<string>() { "Seperate", "values", "forming", "a", "string", "." };

            // Act
            var completeString = new StringBuilder();
            var actualTotal = 0L;
            var actualAmount = 0;
            foreach (var @string in ForEachHelper.Index(collection)) {
                completeString.Append(@string.Value);
                actualTotal += @string.Index;
                actualAmount++;
            }

            // Assert
            Assert.Equal(15, actualTotal);
            Assert.Equal(6, actualAmount);
            Assert.Equal("Seperatevaluesformingastring.", completeString.ToString());
        }
    }
}
