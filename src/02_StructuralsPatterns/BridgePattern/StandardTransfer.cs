using System;

namespace BridgePattern
{
    #region Transfers

    // Refined Abstraction
    public class StandardTransfer : Transfer
    {
        public StandardTransfer(IAuthorizationMethod authorizationMethod) : base(authorizationMethod)
        {
        }

        public override void MakeTransfer(decimal amount)
        {
            authorizationMethod.Authorize();

            Console.WriteLine($"Przelew standardowy {amount}");
        }
    }

    #endregion
}
