using System;

namespace BridgePattern
{
    #region Transfers

    public class TaxTransfer : Transfer
    {
        public TaxTransfer(IAuthorizationMethod authorizationMethod) : base(authorizationMethod)
        {
        }

        public override void MakeTransfer(decimal amount)
        {
            authorizationMethod.Authorize();

            Console.WriteLine($"Przelew podatkowy {amount}");
        }
    }

    #endregion
}
