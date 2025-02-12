namespace AdapterPattern
{
    // Concrete Adapter A
    // wariant obiektowy
    public class MotorolaRadioAdapter : IRadioAdapter
    {
        private readonly string pincode;

        // Adaptee
        private MotorolaRadio radio;

        public MotorolaRadioAdapter(string pincode)
        {
            radio = new MotorolaRadio();
            this.pincode = pincode;
        }

        public void Send(string message, byte channel)
        {
            radio.PowerOn(pincode);
            radio.SelectChannel(channel);
            radio.Send(message);
            radio.PowerOff();
        }
    }

    // Concrete Adapter A
    // wariant klasowy
    public class MotorolaRadioClassAdapter : MotorolaRadio, IRadioAdapter
    {
        private readonly string pincode;

        public MotorolaRadioClassAdapter(string pincode)
        {
            this.pincode = pincode;
        }

        public void Send(string message, byte channel)
        {
            PowerOn(pincode);
            SelectChannel(channel);
            Send(message);
            PowerOff();
        }
    }

}
