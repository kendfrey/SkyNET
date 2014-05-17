﻿using System;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SkyNET
{
    using Web;

    public class StackOverflowChatClient : IChatClient
    {
        public bool IsLoggedIn { get; private set; }

        private Client Client { get; set; }
        private string FKey { get; set;}

        private ILogger _logger { get; set; }


        public async void Login(BotCredentials credentials)
        {
            Client = new Client();

            try
            {
                _logger.LogMessage("Logging in to Stack Exchange");
                await LoginToStackExchange(credentials);

                _logger.LogMessage("Logging in to Stack Overflow");
                await LoginToStackOverflow();
                this.IsLoggedIn = true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error logging in to Stack Overflow: {0} \r\n Stack Trace: {1}", ex.Message, ex);
                this.IsLoggedIn = false;
            }
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

        private async Task LoginToStackExchange(BotCredentials credentials)
        {
            Response loginResponse = await Client.Request("https://openid.stackexchange.com/account/login/").Get();
            string fkey = GetFKeyFromHtml(loginResponse.Content);
            string form = string.Format("email={0}&password={1}&fkey={2}", Uri.EscapeDataString(credentials.Username), Uri.EscapeDataString(credentials.Password), fkey);
            await Client.Request("https://openid.stackexchange.com/account/login/submit/").Post(form, "application/x-www-form-urlencoded");
        }

        private async Task LoginToStackOverflow()
        {
            Response loginResponse = await Client.Request("http://stackoverflow.com/users/login/").Get();
            string fkey = GetFKeyFromHtml(loginResponse.Content);
            string form = string.Format("openid_identifier={0}&fkey={1}", Uri.EscapeDataString("https://openid.stackexchange.com/"), fkey);
            await Client.Request("http://stackoverflow.com/users/authenticate/").Post(form, "application/x-www-form-urlencoded");
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
