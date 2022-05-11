using PhoneBookApp.Abstractions;
using PhoneBookApp.Domain.Validators;

namespace PhoneBookApp.UnitTests.Tests
{
    public class ContactItemValidatorTests
    {
        private readonly IContactItemValidator _sut;

        public ContactItemValidatorTests()
        {
            _sut = new ContactItemValidator();
        }

        [Fact]
        public void ContactItemIsComplete_NullContactItem_Should_ReturnFalse()
        {
            // Arrange

            // Act
            var complete = _sut.ContactItemIsComplete(null);

            // Assert
            Assert.False(complete, "ContactItem was null, it should not be identified as complete");
        }
    }
}
