using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Timers;

namespace MobileRobots
{
    public partial class Form : System.Windows.Forms.Form
    {
        // Inicjalizacja okna
        public Form()
        {
            InitializeComponent();
        }

        // Inicjalizacja łączności i Timera
        private static TcpClient client;
        private static NetworkStream stream;
        private static Timer Timer1;

        // Zmienne globalne i wartości podstawowe
        public class Globals
        {
            public const Int32 port = 8000;
            public const double time = 500;
            public static String IPAddr;
            public static String CMD = "[000000]";
            public static String LED = "00";
            public static String ENG_L = "00";
            public static String ENG_R = "00";
            public static String msg_buffer_s;
            public static String msg_buffer_r;
        }



        // Deklaracja Timera działającego w trakcie aktywnego połączenia
        private void SetTimer(double time)
        {
            Timer1 = new Timer(time);
            Timer1.Elapsed += Timer1Event;
            Timer1.AutoReset = true;
            Timer1.Enabled = true;
        }

        private void Timer1Event(Object source, ElapsedEventArgs e)
        {
            Form_Control_Frame(Globals.LED, Globals.ENG_L, Globals.ENG_R);
        }

        // Funkcje
        public void Connect(String IP, Int32 port)
        {
            if (Globals.IPAddr != null)
            {
                try
                {
                    client = new TcpClient
                    {
                        SendTimeout = 1000
                    };
                    client.Connect(IP, port);
                    stream = client.GetStream();
                    IsConnected();
                    if (IsConnected() == true)
                    {
                        SetTimer(Globals.time);
                    }

                }
                catch (ArgumentNullException ex)
                {
                    LogBOX.Text += "ArgumentNullException: " + ex;
                    LogBOX.AppendText(Environment.NewLine);
                }
                catch (SocketException ex)
                {
                    LogBOX.Text += ex.Message;
                    LogBOX.AppendText(Environment.NewLine);
                }
            }
            else
            {
                LogBOX.Text += "Enter IP Address first.";
                LogBOX.AppendText(Environment.NewLine);
            }
        }

        private void Disconnect()
        {
            if (IsConnected() == true)
            {
                client.Close();
                client.Dispose();
                stream.Close();
                stream.Dispose();
                IsConnected();
                Timer1.Stop();
                Timer1.Dispose();
            } else 
            {
                LogBOX.Text += "Not connected.";
                LogBOX.AppendText(Environment.NewLine);
            }
        }

        //private void Send(string message)
        //{
        //    try
        //    {
        //        message = Convert.ToString(CMDBox.Text);
        //        Byte[] data = Encoding.ASCII.GetBytes(message);
        //        stream.Write(data, 0, data.Length);
        //        LogBOX.Text += "Sent: " + message + "\n";
        //        LogBOX.Text += "Length: " + Convert.ToString(data.Length);
        //        LogBOX.AppendText(Environment.NewLine);
        //    }
        //    catch (NullReferenceException)
        //    {
        //        LogBOX.Text += "Not connected.";
        //        LogBOX.AppendText(Environment.NewLine);
        //    }
        //}

        //private void Receive()
        //{
        //    try
        //    {
        //        Byte[] data = new Byte[256];
        //        String response = String.Empty;
        //        Int32 bytes = stream.Read(data, 0, data.Length);
        //        response = Encoding.ASCII.GetString(data, 0, data.Length);
        //        LogBOX.Text += "Received: " + response;
        //        LogBOX.Text += "Length: " + Convert.ToString(data.Length);
        //        LogBOX.AppendText(Environment.NewLine);
        //    }
        //    catch (NullReferenceException)
        //    {
        //        LogBOX.AppendText("Not connected.");
        //        LogBOX.AppendText(Environment.NewLine);
        //    }
        //}

        // Scalenie komunikacji
        private void SendReceive(string msg)
        {
            try
            {
                // TODO: Wyjątek -> host = cos poprawnego -> Connect
                byte[] msg_s = Encoding.ASCII.GetBytes(msg);          
                stream.Write(msg_s, 0, msg_s.Length);
                LogBOX.Text += "Sent: " + msg;
                LogBOX.AppendText(Environment.NewLine);
                Byte[] msg_r = new Byte[256];
                String response = String.Empty;
                Int32 bytes = stream.Read(msg_r, 0, msg_r.Length);
                response = Encoding.ASCII.GetString(msg_r, 0, msg_r.Length);
                LogBOX.Text += "Received: " + response;
                LogBOX.AppendText(Environment.NewLine);
            }
            catch (NullReferenceException)
            {
                LogBOX.Text += "Cannot connect. Have you entered IP Address?";
                LogBOX.AppendText(Environment.NewLine);
            }
            catch (System.IO.IOException)
            {
                LogBOX.Text += "Cannot communicate with host. Are you connected?";
                LogBOX.AppendText(Environment.NewLine);
            }

        }

        private bool IsConnected()
        {
            try
            {
                if (client.Connected == true)
                {
                    StatusLabel.ForeColor = Color.Green;
                    StatusLabel.Text = "Connected";
                    Eng_L.Enabled = true;
                    Eng_R.Enabled = true;
                    BatteryLevel.Value = 0;
                    return true;
                }
                else
                {
                    StatusLabel.ForeColor = Color.Red;
                    StatusLabel.Text = "Disconnected";
                    Eng_L.Enabled = false;
                    Eng_R.Enabled = false;
                    BatteryLevel.Value = 50;
                    return false;
                };
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
        
        private void Form_Control_Frame(string LED, string ENG_L, string ENG_R)
        {
            if (LED_G.Checked & LED_R.Checked)
            {
                LED = "03";
            }
            else if (LED_G.Checked)
            {
                LED = "01";
            }
            else if (LED_R.Checked)
            {
                LED = "02";
            }
            else
            {
                LED = "00";
            }
            Globals.msg_buffer_s = "[" + LED + ENG_L + ENG_R + "]";
            SendReceive(Globals.msg_buffer_s);
        }

        // Obiekty w Form
        //
        //
        private void Form_Load(object sender, EventArgs e)
        {
            //IPBox.Text = "192.168.2.2";
            Eng_L.Enabled = false;
            Eng_R.Enabled = false;
            CMDBox.Enabled = false;
            BTNSend.Enabled = false;
        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                client.Close();
                stream.Close();
                Timer1.Stop();
                Timer1.Dispose();
        }

        private void ClearLogBTN_Click(object sender, EventArgs e)
        {
            LogBOX.Text = String.Empty;
        }

        private void BTNConnect_Click(object sender, EventArgs e)
        {
            if(IsConnected() == true)
            {
                LogBOX.Text += "Disconnect before trying to connect again.";
                LogBOX.AppendText(Environment.NewLine);
            }
            else
            {
                if (IPBox.Text != null)
                {
                    Connect(Globals.IPAddr, Globals.port);
                }
                else
                {
                    LogBOX.Text += "Error. Make sure you entered proper IP and host is reachable.";
                }

            }
        }

        private void BTNDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void IPBox_TextChanged(object sender, EventArgs e)
        {
            Globals.IPAddr = Convert.ToString(IPBox.Text);
        }

        private void BTNSend_Click(object sender, EventArgs e)
        {
            SendReceive(CMDBox.Text);
        }

        private void CMDBox_TextChanged(object sender, EventArgs e)
        {
            Globals.CMD = Convert.ToString(CMDBox.Text);
        }

        private void Eng_L_Scroll(object sender, EventArgs e)
        {
            Globals.ENG_L = Eng_L.Value.ToString("X2");
            Globals.ENG_R = Eng_R.Value.ToString("X2");
        }

        private void Eng_R_Scroll(object sender, EventArgs e)
        {
            Globals.ENG_L = Eng_L.Value.ToString("X2");
            Globals.ENG_R = Eng_R.Value.ToString("X2");
        }

        // Test

        private void BTNIsConnected_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                LogBOX.Text += "Connected:" + "False";
                
            }
            else
            {
                LogBOX.Text += "Connected:" + client.Connected;
            }

            LogBOX.AppendText(Environment.NewLine);
            IsConnected();
        }
            

        // Useless
        private void StatusLabel_Click(object sender, EventArgs e)
        {

        }
        private void BatteryLevel_Click(object sender, EventArgs e)
        {

        }
        private void LogBOX_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Led_G_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void LED_R_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
