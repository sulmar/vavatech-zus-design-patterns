using BridgePattern.AuthorizationMethods;
using BridgePattern.Transfers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BridgePattern.UnitTests
{

    public class HealthInsuranceTransferTests
    {
        [Fact]
        public void MakeTransfer_WhenBankPayment()
        {
            // Arrange
            IAuthorizationMethod authorizationMethod = new LoginAndPasswordAuthorizationMethod();
            HealthInsuranceTransfer transfer = new HealthInsuranceTransfer(authorizationMethod);

            // Act
            transfer.MakeTransfer(1);

            // Assert

        }


        [Fact]
        public void MakeTransfer_WhenBlik()
        {
            // Arrange
            IAuthorizationMethod authorizationMethod = new BlikAuthorizationMethod();
            HealthInsuranceTransfer transfer = new HealthInsuranceTransfer(authorizationMethod);

            // Act
            transfer.MakeTransfer(1);

            // Assert

        }


        [Fact]
        public void MakeTransfer_WhenCreditCart()
        {
            // Arrange
            IAuthorizationMethod authorizationMethod = new PinAuthorizationMethod();
            HealthInsuranceTransfer transfer = new HealthInsuranceTransfer(authorizationMethod);

            // Act
            transfer.MakeTransfer(1);

            // Assert

        }
    }
}
