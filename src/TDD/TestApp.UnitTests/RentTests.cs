namespace TestApp.UnitTests
{
    public class RentTests
    {
        Rent rent;

        public RentTests()
        {
            rent = new Rent();
        }

        // Methoda_Scenario_ExpectedBehavior
        [Fact]
        public void CanReturn_WhenUserIsEmpty_ShouldThrowArgumentNullException()
        {
            // Arrange            

            // Act
            Action act = () => rent.CanReturn(null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void CanReturn_WhenUserIsAdmin_ShouldReturnsTrue()
        {
            // Arrange

            // Act
            var result = rent.CanReturn(new User { IsAdmin = true });

            // Assert
            Assert.True(result);

        }

        [Fact]
        public void CanReturn_WhenUserIsRentee_ShouldReturnsTrue()
        {
            // Arrange            
            User rentee = new User();
            rent.Rentee = rentee;

            // Act
            var result = rent.CanReturn(rentee);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanReturn_WhenUserIsNotRentee_ShouldReturnFalse()
        {
            // Arrange
            rent.Rentee = new User();

            // Act
            var result = rent.CanReturn(new User());

            // Assert
            Assert.False(result);
        }
    }
}