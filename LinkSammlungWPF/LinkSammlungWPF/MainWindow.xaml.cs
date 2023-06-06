using System;
using LinkSammlungWPF;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        List<Link> linkVar = new List<Link>();
        List<Link> linkVarFORID = new List<Link>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private Link makeNewLink(string id, string linkName,string linkURL, string erstellung)
        {
            Link link = new Link();

            linkName = NameTextBox.Text;
            linkURL = UrlTextBox.Text;

            link.id = id;
            link.linkName = linkName;
            link.linkURL = linkURL;
            link.erstellung = erstellung;

            LinkBoxList.Items.Add(linkName);
            linkVar.Add(link);

            return link;
        }

        public void clickLink(object sender, RoutedEventArgs e)
        {
            foreach (Link item in linkVar)
            {
                if (item.linkName == LinkBoxList.SelectedItem.ToString())
                {
                    Process.Start("explorer", item.linkURL);
                }
            }
        }

        public void AddLinkButton_Click(object sender, RoutedEventArgs e)
        {
            Link link = new Link();

            try
            {
                HttpClient client = new HttpClient();
                string data = "";
                data = client.GetStringAsync("http://localhost:3002/Link").Result;
                var list = JsonSerializer.Deserialize<List<Link>>(data);
                
                if (list != null)
                {
                        link=makeNewLink(link.id, link.linkName, link.linkURL, link.erstellung);
                        var noteJson = JsonSerializer.Serialize(link);
                        var requestContent = new StringContent(noteJson, Encoding.UTF8, "application/json");

                        var response = client.PostAsync("http://localhost:3002/addLink", requestContent);
                }


                Link link2 = new Link();

                string data2 = "";
                data2 = client.GetStringAsync("http://localhost:3002/Link").Result;
                var list2 = JsonSerializer.Deserialize<List<Link>>(data2);
                link2.id = list2.Last().id;

                linkVarFORID.Add(link2);

            }
            catch (Exception ex)
            {
               
            }
        }

        public void DeleteLinkButton_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int help = 0;
            help = LinkBoxList.SelectedIndex;

            try
            {
                HttpClient client = new HttpClient();

                string data = "";
                data = client.GetStringAsync("http://localhost:3002/Link").Result;
                var list = JsonSerializer.Deserialize<List<Link>>(data);


                Link link = linkVarFORID[help];
                if (link != null && list != null)
                {
                    var response = client.DeleteAsync("http://localhost:3002/deleteLink/" + link.id);
                    LinkBoxList.Items.Remove(LinkBoxList.SelectedItem);
                }
            }
            catch
            {

            }
        }

        private void ClearFieldButton_Click(object sender, RoutedEventArgs e)
        {
            NameTextBox.Text = "";
            UrlTextBox.Text = ""; 
        }
     
    }
}
