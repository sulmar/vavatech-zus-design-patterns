using System;

namespace BridgePattern.AuthorizationMethods
{
    public class BlikAuthorizationMethod : IAuthorizationMethod
    {
        public void Authorize()
        {
            Console.WriteLine("Autoryzacja za pomocą kodu BLIK");
        }
    }
}
