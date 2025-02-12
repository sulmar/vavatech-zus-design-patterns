using System;

namespace AdapterPattern
{
    // Abstract Adapter
    public interface IRadioAdapter
    {
        void Send(string message, byte channel);
    }

    // Concrete Adapter A
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

    public class MotorolaRadio
    {
        private bool enabled;

        private byte? selectedChannel;

        public MotorolaRadio()
        {
            enabled = false;
        }

        public void PowerOn(string pincode)
        {
            if (pincode == "1234")
            {
                enabled = true;
            }
        }

        public void SelectChannel(byte channel)
        {
            this.selectedChannel = channel;
        }

        public void Send(string message)
        {
            if (enabled && selectedChannel != null)
            {
                Console.WriteLine($"<Xml><Send Channel={selectedChannel}><Message>{message}</Message></xml>");
            }
        }

        public void PowerOff()
        {
            enabled = false;
        }



    }

    public class Message
    {
        public string Content { get; set; }
    }

    public class PanasonicRadio
    {
        private byte channel;

        public void ChooseChannel(byte channel)
        {
            this.channel = channel;
        }

        public void Send(Message message)
        {
            Console.WriteLine($"Send {message} to {channel} by Panasonic");
        }

    }


}
