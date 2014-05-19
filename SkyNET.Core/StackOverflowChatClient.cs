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
                EnterRoom("");
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
            Response response = Client.Request("http://chat.stackoverflow.com/rooms/53848/sky-net-development").Get();
            Fkey = GetFKeyFromHtml(response.Content);
        }

        public void LeaveRoom(string room)
        {
            throw new System.NotImplementedException();
        }

        public void SendMessage(string message, string room)
        {
            throw new System.NotImplementedException();
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
