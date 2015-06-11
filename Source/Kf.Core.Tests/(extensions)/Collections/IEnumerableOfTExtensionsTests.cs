using System.Linq;
using Xunit;

namespace Kf.Core.Tests._extensions_.Collections
{
    public class IEnumerableOfTExtensionsTests
    {
        [Fact]
        public void Index_Returns_Correct_Values_And_Index() {
            // Arrange
            var index = 0;
            var sut = Enumerable.Range(0, 500);

            // Act
            var foreachWithIndex = sut.Index();

            // Assert            
            foreach (var element in foreachWithIndex) {
                Assert.Equal(index, element.Index);
                Assert.Equal(index, element.Value);
                Assert.Equal(element.Value, element.Index);
                index++;
            }
        }
    }
}
