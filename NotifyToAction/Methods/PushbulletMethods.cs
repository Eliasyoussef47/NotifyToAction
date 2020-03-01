using PushbulletSharp;
using PushbulletSharp.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyToAction
{
    class PushbulletMethods
    {
        public PushbulletMethods()
        {
            Configs configs = ConfigsTools.GetConfigs<Configs>();
            string accessToken = configs.PushbulletAccessToken;
            Client = new PushbulletClient(accessToken);
        }

        PushbulletClient Client;

        public void PushNote(string title, string body)
        {
            PushNoteRequest request = new PushNoteRequest();
            request.Title = title;
            request.Body = body;
            Client.PushNote(request);
        }
    }
}
