using Xunit;
using Microsoft.AspNetCore.Identity;
using server;

namespace Server.Tests
{

    public class unitTests
    {
        [Fact]
        public void Should_Hash_And_Verify_Password()
        {
            var hasher = new PasswordHasher<string>();
            var password = "test123";
            var hashed = hasher.HashPassword(null, password);

            var result = hasher.VerifyHashedPassword(null, hashed, password);
            Assert.Equal(PasswordVerificationResult.Success, result);
        }

        [Fact]
        public void GenerateSlugs_ShouldReturnString_OfCorrectLength()
        {
            int length = 16;
            var slug = TicketRoutes.GenerateSlugs(length);

            Assert.Equal(length, slug.Length);
        }

        [Fact]
        public void GenerateSlugs_ShouldOnlyContainValidCharacters()
        {
            var validChars = "QWERTYUIOPASDFGHJKLZXCVBNM" +
                             "qwertyuiopasdfghjklzxcvbnm" +
                             "0123456789";

            var slug = TicketRoutes.GenerateSlugs(16);

            Assert.All(slug, c => Assert.Contains(c, validChars));
        }

        [Fact]
        public void GenerateSlugs_ShouldGenerateUniqueValues()
        {
            var slug1 = TicketRoutes.GenerateSlugs(12);
            var slug2 = TicketRoutes.GenerateSlugs(12);

            Assert.NotEqual(slug1, slug2);
        }
    }
}

    