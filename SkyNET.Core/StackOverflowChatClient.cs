using System;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SkyNET
{
    using Web;

    public class StackOverflowChatClient : IChatClient
    {
        private Client Client { get; set; }
        public bool IsLoggedIn { get; set; }

        private string Fkey { get; set; }

        public void Login(BotCredentials credentials)
        {
            Client = new Client();
            try
            {
                LoginToStackExchange(credentials);
                LoginToStackOverflow();
                IsLoggedIn = true;
            }
            catch
            {
                IsLoggedIn = false;
                throw;
            }
        }

        public void EnterRoom(string room)
        {
            //Hard coded to the SkyNet Development chat for now
            // TODO: Find a way to invite the bot to any room.
            Response response = Client.Request("http://chat.stackoverflow.com/rooms/53848/").Get();
            Fkey = GetFKeyFromHtml(response.Content);
        }

        public void LeaveRoom(string room)
        {
            Response response = Client.Request(string.Format("http://chat.stackoverflow.com/rooms/{0}/leave", room)).Get();
        }

        public void SendMessage(string message, string room)
        {
            string form = string.Format("text={0}&fkey={1}", Uri.EscapeDataString(message), Fkey);
            Response response = Client.Request(string.Format("http://chat.stackoverflow.com/chats/{0}/messages/new", room)).Post(form, "application/x-www-form-urlencoded");
        }

        private void LoginToStackExchange(BotCredentials credentials)
        {
            Response loginResponse = Client.Request("https://openid.stackexchange.com/account/login/").Get();
            string fkey = GetFKeyFromHtml(loginResponse.Content);
            string form = string.Format("email={0}&password={1}&fkey={2}", Uri.EscapeDataString(credentials.Username), Uri.EscapeDataString(credentials.Password), fkey);
            Client.Request("https://openid.stackexchange.com/account/login/submit/").Post(form, "application/x-www-form-urlencoded");
        }

        private void LoginToStackOverflow()
        {
            Response loginResponse = Client.Request("http://stackoverflow.com/users/login/").Get();
            string fkey = GetFKeyFromHtml(loginResponse.Content);
            string form = string.Format("openid_identifier={0}&fkey={1}", Uri.EscapeDataString("https://openid.stackexchange.com/"), fkey);
            Client.Request("http://stackoverflow.com/users/authenticate/").Post(form, "application/x-www-form-urlencoded");
        }

        private string GetFKeyFromHtml(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.SelectSingleNode("//input[@name='fkey']").Attributes["value"].Value;
        }

        public event System.EventHandler<MessageReceivedEventArgs> MessageReceived;

        public event System.EventHandler<UserEnteredEventArgs> UserEntered;

        public event System.EventHandler<UserLeftEventArgs> UserLeft;
    }
}
