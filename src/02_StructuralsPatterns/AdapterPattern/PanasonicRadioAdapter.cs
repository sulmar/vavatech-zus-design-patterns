namespace AdapterPattern
{
    public class PanasonicRadioAdapter : IRadioAdapter
    {
        private PanasonicRadio radio = new PanasonicRadio();

        public void Send(string message, byte channel)
        {
            Message msg = new Message();
            msg.Content = message;
            radio.ChooseChannel(channel);
            radio.Send(msg);
        }
    }


}
