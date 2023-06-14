using FilmReviewAPI.Utils;

namespace FilmReviewAPI.Tests.Utils
{
    public class PasswordHashUtilsTests
    {
        [Fact]
        public void CreatePasswordHash_ValidPassword_ReturnsNonEmptyHashAndSalt()
        {
            // Arrange
            var password = "P@ssw0rd";

            // Act
            PasswordHashUtils.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            // Assert
            Assert.NotNull(passwordHash);
            Assert.NotEmpty(passwordHash);
            Assert.NotNull(passwordSalt);
            Assert.NotEmpty(passwordSalt);
        }

        [Fact]
        public void VerifyPasswordHash_ValidPassword_ReturnsTrue()
        {
            // Arrange
            var password = "P@ssw0rd";
            byte[] passwordHash;
            byte[] passwordSalt;
            PasswordHashUtils.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            // Act
            var result = PasswordHashUtils.VerifyPasswordHash(password, passwordHash, passwordSalt);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifyPasswordHash_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            var password = "P@ssw0rd";
            var invalidPassword = "InvalidP@ssw0rd";
            byte[] passwordHash;
            byte[] passwordSalt;
            PasswordHashUtils.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            // Act
            var result = PasswordHashUtils.VerifyPasswordHash(invalidPassword, passwordHash, passwordSalt);

            // Assert
            Assert.False(result);
        }
    }
}