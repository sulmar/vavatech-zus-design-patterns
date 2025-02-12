using System;

namespace BridgePattern
{
    #region Authorization Methods

    public class PinAuthorizationMethod : IAuthorizationMethod
    {
        public void Authorize()
        {
            Console.WriteLine("Autoryzacja za pomocą PIN");
        }
    }

    #endregion
}
