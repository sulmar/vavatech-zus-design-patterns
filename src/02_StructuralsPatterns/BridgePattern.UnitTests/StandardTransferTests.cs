using BridgePattern.AuthorizationMethods;
using BridgePattern.Transfers;
using Xunit;

namespace BridgePattern.UnitTests
{

    public class StandardTransferTests
    {
        [Fact]                
        public void MakeTransfer_WhenBankPayment()
        {
            // Arrange
            IAuthorizationMethod authorizationMethod = new LoginAndPasswordAuthorizationMethod();
            StandardTransfer transfer = new StandardTransfer(authorizationMethod);

            // Act
            transfer.MakeTransfer(1);

            // Assert

        }


        [Fact]
        public void MakeTransfer_WhenBlik()
        {
            // Arrange
            IAuthorizationMethod authorizationMethod = new BlikAuthorizationMethod();
            StandardTransfer transfer = new StandardTransfer(authorizationMethod);

            // Act
            transfer.MakeTransfer(1);

            // Assert

        }


        [Fact]
        public void MakeTransfer_WhenCreditCart()
        {
            // Arrange
            IAuthorizationMethod authorizationMethod = new PinAuthorizationMethod();
            StandardTransfer transfer = new StandardTransfer(authorizationMethod);

            // Act
            transfer.MakeTransfer(1);

            // Assert

        }
    }
}
