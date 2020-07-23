using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Bing;
using System.Data.Services.Client;
using System.Net;

using System.Web.UI.WebControls;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;


namespace search
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            try
            {
                richTextBox1.Text = "";
                const string apiKey = "AIzaSyDIm9ZOWD8Zd-2tHy5r3c0R-_XjdEFaXGE";
                const string searchEngineId = "003470263288780838160:ty47piyybua";
                string query1 = textBox1.Text;
                CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
                Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(query1);
                listRequest.Cx = searchEngineId;
                Search search = listRequest.Execute();
                foreach (var item in search.Items)
                {
                    richTextBox1.Text += item.Link;
                    richTextBox1.Text += " \n ";
                }

                richTextBox1.Text += " \n ---------------------- \n ";

                Repeater rptResult = new Repeater();
                string rootUrl = "https://api.datamarket.azure.com/Bing/Search";

                string query = textBox1.Text;
                var bingContainer = new Bing.BingSearchContainer(new Uri(rootUrl));
                string market = "en-us";

                bingContainer.Credentials = new NetworkCredential("bucsexiyu8a87Nw1u3mmTJ/BCPAzGOKFQcydlXYn1S8", "bucsexiyu8a87Nw1u3mmTJ/BCPAzGOKFQcydlXYn1S8");


                var webQuery = bingContainer.Web(query, null, null, null, null, null, null, null);
                webQuery = webQuery.AddQueryOption("$top", 10);


                var webResults = webQuery.Execute();
                System.Windows.Forms.Label lblResults = new System.Windows.Forms.Label();
                StringBuilder searchResult = new StringBuilder();

                foreach (Bing.WebResult wResult in webResults)
                {
                    richTextBox1.Text += wResult.Url;

                }
            }catch(Exception ex){
                richTextBox1.Text = "404 Not Found";
            }
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
