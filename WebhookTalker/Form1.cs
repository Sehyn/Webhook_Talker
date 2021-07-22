using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebhookTalker
{

    public partial class Form1 : Form
    {
        private static string WebhookURL = "";
        private static string Message = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            Message = TxtMessage.Text;
            WebhookURL = TxtWebhookurl.Text;

            Http.Post(WebhookURL, new NameValueCollection()
            {
                { "username", "FLUVE.ME | Beep Boop" },
                { "avatar_url", "https://cdn.discordapp.com/attachments/696080024742395914/718483498947838063/beetlejuice-1.jpg" },
                { "content", Message.ToString() }
            });
        }

        class Http
        {
            public static byte[] Post(string uri, NameValueCollection pairs)
            {
                using (WebClient webClient = new WebClient())
                    return webClient.UploadValues(uri, pairs);
            }
        }
    }
}
