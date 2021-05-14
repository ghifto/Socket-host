using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Socket_Host1
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IPAddress ipDest;
        public int portDest;
        public bool connessioneStabilita = false;
        public MainWindow()
        {
            InitializeComponent();

            IPEndPoint localendpoint = new IPEndPoint(IPAddress.Parse("100.200.100.7"), 56000);

            Thread t1 = new Thread(new ParameterizedThreadStart(SocketReceive));

            t1.Start(localendpoint);
        }

        public async void SocketReceive(object sourceEndPoint)
        {
            IPEndPoint sourceEP = (IPEndPoint)sourceEndPoint;

            Socket t = new Socket(sourceEP.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

            t.Bind(sourceEP);

            Byte[] byteRicevuti = new byte[256];

            string message = "";

            int bytes = 0;


            await Task.Run(() =>
            {
                while (true)
                {
                    if (t.Available > 0)
                    {
                        message = "";
                        bytes = t.Receive(byteRicevuti, byteRicevuti.Length, 0);
                        message = message + Encoding.ASCII.GetString(byteRicevuti, 0, bytes);

                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            lstRicezione.Items.Add("Him: \t" + message);
                        }));
                    }
                }
            });
        }

        private void btnInvia_Click(object sender, RoutedEventArgs e)
        {
            lstRicezione.Items.Add("You: \t" + txtMsg.Text);

            Comunicazione(txtMsg.Text);
        }
        public void Comunicazione(string text)
        {

            IPEndPoint remoteEndPoint = new IPEndPoint(ipDest, portDest);

            Socket s = new Socket(ipDest.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

            Byte[] byteInviati = Encoding.ASCII.GetBytes(text);

            s.SendTo(byteInviati, remoteEndPoint);
        }

        private void btnConnetti_Click(object sender, RoutedEventArgs e)
        {
            btnInvia.IsEnabled = true;

            ipDest = IPAddress.Parse(txtIpAdd.Text);
            portDest = int.Parse(txtDestPort.Text);

            grdConnessione.Visibility = Visibility.Hidden;
            grdGioco.Visibility = Visibility.Visible;
            imgScheda.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\tris.png");
        }

        #region Bottoni Controllo
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            img1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void ckbHost_Checked(object sender, RoutedEventArgs e)
        {
            ckbClient.IsChecked = false;

            Comunicazione("Host");
        }

        private void ckbClient_Checked(object sender, RoutedEventArgs e)
        {
            ckbHost.IsChecked = false;

            Comunicazione("Client");
        }
    }
}
