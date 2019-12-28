using System;
using Godot;
using Xunit;

namespace UnitTests
{
    public class RegExTests
    {
        private readonly RegEx _testObj;

        public RegExTests()
        {
            _testObj = new RegEx();
        }

        // Start Search
        [Theory]
        [InlineData("ab([0-9])", "ab4", 1, 1, "4")]
        private void Search_ShouldReturnCorrectResponse(string pattern, string subject, int groupCount, int groupNum, string match)
        {
            _testObj.Compile(pattern);

            var result = _testObj.Search(subject);

            Assert.Equal(subject, result.Subject);
            Assert.Equal(groupCount, result.GetGroupCount());
            Assert.Equal(match, result.Strings[groupNum]);
        }
        
        
    }
}