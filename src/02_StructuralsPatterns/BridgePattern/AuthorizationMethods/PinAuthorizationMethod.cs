using System;

namespace BridgePattern.AuthorizationMethods
{
    public class PinAuthorizationMethod : IAuthorizationMethod
    {
        public void Authorize()
        {
            Console.WriteLine("Autoryzacja za pomocą PIN");
        }
    }
}
