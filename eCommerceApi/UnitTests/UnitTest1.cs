namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a = 1;
            int b = 1;
            int expected = 3;

            Assert.Equal(expected, a + b); 
        }
    }
}
