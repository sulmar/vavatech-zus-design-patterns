using System;

namespace AdapterPattern
{

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
