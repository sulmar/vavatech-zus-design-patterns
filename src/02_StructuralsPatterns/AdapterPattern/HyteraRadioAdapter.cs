namespace AdapterPattern
{
    // Concrete Adapter B
    public class HyteraRadioAdapter : IRadioAdapter
    {
        private HyteraRadio radio;

        public HyteraRadioAdapter()
        {
            radio = new HyteraRadio();
        }

        public void Send(string message, byte channel)
        {
            radio.Init();
            radio.SendMessage(channel, message);
            radio.Release();
        }
    }


}
