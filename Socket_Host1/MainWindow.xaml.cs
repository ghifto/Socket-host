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
        public string DatiRisultato;
        public IPAddress ipDest;
        public int Messaggi = 0;
        public int portDest;
        public bool connessioneStabilita = false;
        public MainWindow()
        {
            InitializeComponent();

            grdScelta.Visibility = Visibility.Visible;

            IPEndPoint localendpoint = new IPEndPoint(IPAddress.Parse("192.168.1.127"), 56000);

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
                            Messaggi++;
                            lstRicezione.SelectedItem = Messaggi;
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
            bool vincita = false;
            string vincitore = null; 
            if(DatiRisultato == "o")
                img1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
            SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
            if (vincitore == DatiRisultato && vincita == true)
                MessageBox.Show("OK");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img8.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img8.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img9.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img9.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
        }
        #endregion

        private void btnDadi_Click(object sender, RoutedEventArgs e)
        {
            Random rdn = new Random();
            
            int i = rdn.Next(0, 5);

            lstRicezione.Items.Add(i);
            if(i % 2 == 0)
            {
                imgScelta.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
                Comunicazione("x");
                DatiRisultato = "x";
            }
            else
            {
                imgScelta.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
                Comunicazione("o");
                DatiRisultato = "o";
            }
        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {
            Comunicazione("Confirmed: " + DatiRisultato);
            grdScelta.Visibility = Visibility.Hidden;
        }
    }
}
