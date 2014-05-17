
namespace SkyNET
{
    public class StackOverflowChatClient : IChatClient
    {
        public void Login(BotCredentials credentials)
        {
            throw new System.NotImplementedException();
        }

        public void EnterRoom(string room)
        {
            throw new System.NotImplementedException();
        }

        public void LeaveRoom(string room)
        {
            throw new System.NotImplementedException();
        }

        public void SendMessage(string message, string room)
        {
            throw new System.NotImplementedException();
        }

        public event System.EventHandler<MessageReceivedEventArgs> MessageReceived;

        public event System.EventHandler<UserEnteredEventArgs> UserEntered;

        public event System.EventHandler<UserLeftEventArgs> UserLeft;
    }
}
