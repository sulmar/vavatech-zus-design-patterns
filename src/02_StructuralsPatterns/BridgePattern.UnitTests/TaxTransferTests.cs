using BridgePattern.AuthorizationMethods;
using BridgePattern.Transfers;
using Xunit;

namespace BridgePattern.UnitTests
{
    public class TaxTransferTests
    {
        [Fact]
        public void MakeTransfer_WhenBankPayment()
        {
            // Arrange
            IAuthorizationMethod authorizationMethod = new LoginAndPasswordAuthorizationMethod();
            TaxTransfer transfer = new TaxTransfer(authorizationMethod);

            // Act
            transfer.MakeTransfer(1);

            // Assert

        }


        [Fact]
        public void MakeTransfer_WhenBlik()
        {
            // Arrange
            IAuthorizationMethod authorizationMethod = new BlikAuthorizationMethod();
            TaxTransfer transfer = new TaxTransfer(authorizationMethod);

            // Act
            transfer.MakeTransfer(1);

            // Assert

        }


        [Fact]
        public void MakeTransfer_WhenCreditCart()
        {
            // Arrange
            IAuthorizationMethod authorizationMethod = new PinAuthorizationMethod();
            TaxTransfer transfer = new TaxTransfer(authorizationMethod);

            // Act
            transfer.MakeTransfer(1);

            // Assert

        }
    }
}
