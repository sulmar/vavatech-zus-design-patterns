using System;

namespace BridgePattern.Transfers
{
    // Refined Abstraction
    public class HealthInsuranceTransfer : Transfer
    {
        public HealthInsuranceTransfer(IAuthorizationMethod authorizationMethod) : base(authorizationMethod)
        {
        }

        public override void MakeTransfer(decimal amount)
        {
            authorizationMethod.Authorize();

            Console.WriteLine($"Przelew składki zdrowotnej {amount}");
        }
    }

}
