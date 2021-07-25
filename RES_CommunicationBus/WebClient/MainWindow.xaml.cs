using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Common;
using Common.CommunicationBus;
using Common.CommunicationModel;
using Common.Helpers;
using Common.Helpers;
using ModelPodataka.DataModel;
using Newtonsoft.Json; // Nuget Package


namespace WebClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValidationOfRequest validation = new ValidationOfRequest();
            if(!validation.ValidateRequest(TextBoxEnter.Text))
            {
                MessageBox.Show("Pls enter valid request.");
                return;
            }

            Request request = RequestFactory.ConvertStringToRequest(TextBoxEnter.Text);
            string json = JsonConvert.SerializeObject(request, Formatting.Indented);
            JsonFormat.Text = json;
            CommunicationBusModule cmb = new CommunicationBusModule();
            string response = cmb.SendRequest(json);
            XmlFormat.Text = cmb.XmlRequest.ToString();

            txtBoxResponse.Text = response;
        }
    }
}

