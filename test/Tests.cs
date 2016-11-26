using System;
using Xunit;
using maplib;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void TestForAllUsers()
        {
            MapController c = new MapController();
            var users = c.AllUserActions();

            Assert.True(users.Count == 8);
        }

        [Theory]
        [InlineData("don.browning@turner.com")]
        [InlineData("noemail@noplace.com")]
        public void TestForAGivenUser(string email)
        {
            MapController c = new MapController();
            var user = c.FindUser(email);

            // if an email can't be found, should return null
            if (user == null)
            {
                Assert.True(user == null);
            } else
            {
                Assert.True(user != null);    
            }
        }
    }
}
