using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public interface IAuthorizationMethod
    {
        void Authorize();
    }

    // Abstraction
    public abstract class Transfer
    {
        protected IAuthorizationMethod authorizationMethod;

        protected Transfer(IAuthorizationMethod authorizationMethod)
        {
            this.authorizationMethod = authorizationMethod;
        }

        public abstract void MakeTransfer(decimal amount);
    }

}