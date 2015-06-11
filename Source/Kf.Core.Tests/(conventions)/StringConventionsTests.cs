using System.Linq;
using System.Reflection;
using Kf.Core.Conventions;
using Xunit;

namespace Kf.Core.Tests.Conventions
{
    public class StringConventionsTests
    {
        private FieldInfo FindStaticFieldInStringConventions(string fieldName) {
            return typeof(StringConventions)
                .GetFields()            
                .Where(m => m.Name.Equals(fieldName))
                .SingleOrDefault();
        }

        [Fact]
        public void NullStringIsDefinedByNameFMT_NULL() {
            var expected = "FMT_NULL";
            var actual = FindStaticFieldInStringConventions(expected);
            Assert.NotNull(actual);            
        }

        [Fact]
        public void NullStringContainsCorrectValue() {
            var expected = "(*null)";
            var sut = FindStaticFieldInStringConventions("FMT_NULL");
            var actual = sut.GetValue(null);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExceptionStringIsDefinedByNameFMT_EXCEPTION() {
            var expected = "FMT_EXCEPTION";
            var actual = FindStaticFieldInStringConventions(expected);
            Assert.NotNull(actual);
        }

        [Fact]
        public void ExceptionStringContainsCorrectValue() {
            var expected = "(*ex!{0})";
            var sut = FindStaticFieldInStringConventions("FMT_EXCEPTION");
            var actual = sut.GetValue(null);
            Assert.Equal(expected, actual);
        }
    }
}
