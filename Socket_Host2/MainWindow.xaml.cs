using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace Socket_Host2
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string caracter = null;
        public IPAddress ipDest;
        public int Messaggi = 0;
        public int portDest;
        public bool connessioneStabilita = false;
        public MainWindow()
        {
            InitializeComponent();

            grdScelta.Visibility = Visibility.Visible;

            IPEndPoint localendpoint = new IPEndPoint(IPAddress.Parse("192.168.1.127"), 57000);

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
                            Ricevi(message);
                        }));
                    }
                }
            });
        }

        private void btnInvia_Click(object sender, RoutedEventArgs e)
        {
            lstRicezione.Items.Add("You: \t" + txtMsg.Text);
            Messaggi++;


            Comunicazione(txtMsg.Text);
        }
        public void Ricevi(string text)
        {
            if (text == "o")
                imgScelta.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
            else if (text == "x")
                imgScelta.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else if (text == "Confirmed: o")
            {
                caracter = "x";
                grdScelta.Visibility = Visibility.Hidden;
            }
            else if (text == "Confirmed: x")
            {
                caracter = "o";
                grdScelta.Visibility = Visibility.Hidden;
            }
            else
                lstRicezione.Items.Add("Him: \t" + text);
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
            if (caracter == "o")
                img1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (caracter == "o")
                img2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (caracter == "o")
                img3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (caracter == "o")
                img4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (caracter == "o")
                img5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (caracter == "o")
                img6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (caracter == "o")
                img7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (caracter == "o")
                img8.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img8.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (caracter == "o")
                img9.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img9.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }
        #endregion

        private void btnDadi_Click(object sender, RoutedEventArgs e)
        {
            Random rdn = new Random();

            int i = rdn.Next(0, 5);

            if (i % 2 == 0)
            {
                imgScelta.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
                Comunicazione("x");
            }
            else
            {
                imgScelta.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
                Comunicazione("o");
            }
        }
    }
}
