using System;

namespace BridgePattern.AuthorizationMethods
{
    #region Authorization Methods

    public class LoginAndPasswordAuthorizationMethod : IAuthorizationMethod
    {
        public void Authorize()
        {
            Console.WriteLine("Autoryzacja za pomocą loginu i hasła.");
        }
    }

    #endregion
}
