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

        [Fact]
        public void ForEachPerformsCorrectAlgorithm() {
            var sut = Enumerable.Range(0, 500);
            var result = sut.ForEach(i => { return 0; });
            Assert.True(result.All(i => i == 0));
        }

        [Fact]
        public void ForEachCanReturnDifferentType() {
            var sut = Enumerable.Range(0, 500);
            var result = sut.ForEach(i => { return i.ToString("000"); });
            Assert.True(result.All(i => i.Length.Equals(3)));
        }

        [Fact]
        public void ForEachCanReturnAndCOntinueLinqStyle() {
            var sut = Enumerable.Range(0, 500);
            var result = sut.ForEach(i => { return i.ToString("000"); });
            result = result.Where(x => x.Contains("449"));
            Assert.True(result.Count().Equals(1));
        }
    }
}
