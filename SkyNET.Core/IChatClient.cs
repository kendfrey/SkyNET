using System;

namespace SkyNET
{
    public interface IChatClient
    {
        void Login(BotCredentials credentials);
        void EnterRoom(string room);
        void LeaveRoom(string room);
        void SendMessage(string message, string room);

        bool IsLoggedIn { get; set; }

        event EventHandler<MessageReceivedEventArgs> MessageReceived;
        event EventHandler<UserEnteredEventArgs> UserEntered;
        event EventHandler<UserLeftEventArgs> UserLeft;
    }

    public class MessageReceivedEventArgs : EventArgs
    {
        public string Message
        {
            get;
            set;
        }

        public string Room
        {
            get;
            set;
        }
    }

    public class UserEnteredEventArgs : EventArgs
    {
        public string User
        {
            get;
            set;
        }

        public string Room
        {
            get;
            set;
        }
    }

    public class UserLeftEventArgs : EventArgs
    {
        public string User
        {
            get;
            set;
        }

        public string Room
        {
            get;
            set;
        }
    }
}
