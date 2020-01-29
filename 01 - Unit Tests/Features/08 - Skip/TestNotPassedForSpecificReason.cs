using Xunit;

namespace Features.Tests._08___Skip
{
    public class TestNotPassedForSpecificReason
    {
        [Fact(DisplayName = "New Client 2.0", Skip = "New 2.0 version is breaking")]
        [Trait("Category", "Scape from tests")]
        public void Test_NotPass_NonCompatibleVersion()
        {
            Assert.True(false);
        }
    }
}
