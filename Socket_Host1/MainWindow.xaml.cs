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
        public string enemy = null;
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
                            Ricevi(message);
                        }));
                    }
                }
            });
        }
        public void Ricevi(string text)
        {
            if (text == "o")
                imgScelta.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
            else if (text == "x")
                imgScelta.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else if (text == "Confirmed: o")
            {
                DatiRisultato = "x";
                grdScelta.Visibility = Visibility.Hidden;
            }
            else if (text == "Confirmed: x")
            {
                DatiRisultato = "o";
                grdScelta.Visibility = Visibility.Hidden;
            }
            else if (text.Split(',')[0] == "Botton")
            {
                string nome = text.Split(',')[1].Split('.')[0];

                if (nome == "1")
                {
                    if (DatiRisultato == "o")
                        img1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
                    else
                        img1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");

                    btn1.IsEnabled = false;

                    SocketClassi.InfGiochi.Tabellone[0, 0] = enemy;

                    bool vincita = false;
                    string vincitore = null;
                    SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
                    if (vincitore == enemy && vincita == true)
                        MessageBox.Show("OK");
                }
                else if (nome == "2")
                {
                    if (DatiRisultato == "o")
                        img2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
                    else
                        img2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");

                    btn2.IsEnabled = false;

                    SocketClassi.InfGiochi.Tabellone[0, 1] = enemy;

                    bool vincita = false;
                    string vincitore = null;
                    SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
                    if (vincitore == enemy && vincita == true)
                        MessageBox.Show("OK");
                }
                else if (nome == "3")
                {
                    if (DatiRisultato == "o")
                        img3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
                    else
                        img3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");

                    btn3.IsEnabled = false;

                    SocketClassi.InfGiochi.Tabellone[0, 2] = enemy;

                    bool vincita = false;
                    string vincitore = null;
                    SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
                    if (vincitore == enemy && vincita == true)
                        MessageBox.Show("OK");
                }
                else if (nome == "4")
                {
                    if (DatiRisultato == "o")
                        img4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
                    else
                        img4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");

                    btn4.IsEnabled = false;

                    SocketClassi.InfGiochi.Tabellone[1, 0] = enemy;

                    bool vincita = false;
                    string vincitore = null;
                    SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
                    if (vincitore == enemy && vincita == true)
                        MessageBox.Show("OK");
                }
                else if (nome == "5")
                {
                    if (DatiRisultato == "o")
                        img5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
                    else
                        img5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");

                    btn5.IsEnabled = false;

                    SocketClassi.InfGiochi.Tabellone[1, 1] = enemy;

                    bool vincita = false;
                    string vincitore = null;
                    SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
                    if (vincitore == enemy && vincita == true)
                        MessageBox.Show("OK");
                }
                else if (nome == "6")
                {
                    if (DatiRisultato == "o")
                        img6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
                    else
                        img6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");

                    btn6.IsEnabled = false;

                    SocketClassi.InfGiochi.Tabellone[1, 2] = enemy;

                    bool vincita = false;
                    string vincitore = null;
                    SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
                    if (vincitore == enemy && vincita == true)
                        MessageBox.Show("OK");
                }
                else if (nome == "7")
                {
                    if (DatiRisultato == "o")
                        img7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
                    else
                        img7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");

                    btn7.IsEnabled = false;

                    SocketClassi.InfGiochi.Tabellone[2, 0] = enemy;

                    bool vincita = false;
                    string vincitore = null;
                    SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
                    if (vincitore == enemy && vincita == true)
                        MessageBox.Show("OK");
                }
                else if (nome == "8")
                {
                    if (DatiRisultato == "o")
                        img8.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
                    else
                        img8.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");

                    btn8.IsEnabled = false;

                    SocketClassi.InfGiochi.Tabellone[2, 1] = enemy;

                    bool vincita = false;
                    string vincitore = null;
                    SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
                    if (vincitore == enemy && vincita == true)
                        MessageBox.Show("OK");
                }
                else if (nome == "9")
                {
                    if (DatiRisultato == "o")
                        img9.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");
                    else
                        img9.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");

                    btn9.IsEnabled = false;

                    SocketClassi.InfGiochi.Tabellone[2, 2] = enemy;

                    bool vincita = false;
                    string vincitore = null;
                    SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
                    if (vincitore == enemy && vincita == true)
                        MessageBox.Show("OK Vincita nemico");
                }

                SocketClassi.InfGiochi.RicezioneBottini();
            }
            else
                lstRicezione.Items.Add("Him: \t" + text);
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

            Comunicazione("Botton,1.0,0");
            btn1.IsEnabled = false;

            SocketClassi.InfGiochi.Tabellone[0, 0] = DatiRisultato;

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

            Comunicazione("Botton,2.0,1");
            btn2.IsEnabled = false;

            SocketClassi.InfGiochi.Tabellone[0, 1] = DatiRisultato;

            bool vincita = false;
            string vincitore = null;
            SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
            if (vincitore == DatiRisultato && vincita == true)
                MessageBox.Show("OK");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");

            Comunicazione("Botton,3.0,2");
            btn3.IsEnabled = false;

            SocketClassi.InfGiochi.Tabellone[0, 2] = DatiRisultato;

            bool vincita = false;
            string vincitore = null;
            SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
            if (vincitore == DatiRisultato && vincita == true)
                MessageBox.Show("OK");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");

            Comunicazione("Botton,4.1,0");
            btn4.IsEnabled = false;

            SocketClassi.InfGiochi.Tabellone[1, 0] = DatiRisultato;

            bool vincita = false;
            string vincitore = null;
            SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
            if (vincitore == DatiRisultato && vincita == true)
                MessageBox.Show("OK");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");

            Comunicazione("Botton,5.1,1");
            btn5.IsEnabled = false;

            SocketClassi.InfGiochi.Tabellone[1, 1] = DatiRisultato;

            bool vincita = false;
            string vincitore = null;
            SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
            if (vincitore == DatiRisultato && vincita == true)
                MessageBox.Show("OK");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");

            Comunicazione("Botton,6.1,2");
            btn6.IsEnabled = false;

            SocketClassi.InfGiochi.Tabellone[1, 2] = DatiRisultato;

            bool vincita = false;
            string vincitore = null;
            SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
            if (vincitore == DatiRisultato && vincita == true)
                MessageBox.Show("OK");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");

            Comunicazione("Botton,7.2,0");
            btn7.IsEnabled = false;

            SocketClassi.InfGiochi.Tabellone[2, 0] = DatiRisultato;

            bool vincita = false;
            string vincitore = null;
            SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
            if (vincitore == DatiRisultato && vincita == true)
                MessageBox.Show("OK");
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img8.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img8.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");

            Comunicazione("Botton,8.2,1");
            btn8.IsEnabled = false;

            SocketClassi.InfGiochi.Tabellone[2, 1] = DatiRisultato;

            bool vincita = false;
            string vincitore = null;
            SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
            if (vincitore == DatiRisultato && vincita == true)
                MessageBox.Show("OK");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (DatiRisultato == "o")
                img9.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\o.png");
            else
                img9.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resurce\Images\x.png");

            Comunicazione("Botton,9.2,2");
            btn9.IsEnabled = false;

            SocketClassi.InfGiochi.Tabellone[2, 2] = DatiRisultato;

            bool vincita = false;
            string vincitore = null;
            SocketClassi.InfGiochi.Controllo(ref vincita, ref vincitore);
            if (vincitore == DatiRisultato && vincita == true)
                MessageBox.Show("OK");
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
