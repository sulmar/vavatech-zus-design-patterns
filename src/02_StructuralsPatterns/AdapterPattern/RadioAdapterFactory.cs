using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class RadioAdapterFactory
    {
        public IRadioAdapter Create(string radioType)
        {
            return radioType switch
            {
                "Motorola" => new MotorolaRadioAdapter("1234"),
                "Hytera" => new HyteraRadioAdapter(),
                "Panasonic" => new PanasonicRadioAdapter(),
                _ => throw new NotSupportedException()
            };
        }
    }
}
