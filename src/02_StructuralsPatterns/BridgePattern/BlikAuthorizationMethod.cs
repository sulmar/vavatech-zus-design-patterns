using System;

namespace BridgePattern
{
    #region Authorization Methods

    public class BlikAuthorizationMethod : IAuthorizationMethod
    {
        public void Authorize()
        {
            Console.WriteLine("Autoryzacja za pomocą kodu BLIK");
        }
    }

    #endregion
}
