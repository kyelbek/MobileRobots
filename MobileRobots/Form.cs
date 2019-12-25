﻿using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using System.ComponentModel;
using WinForms = System.Windows.Forms;

// TODO: Lepsze sprawdzanie połączenia (W nowym Timerze?)
// TODO: Spróbować poprawnie rozłączyć połączenie (Żeby w Herculesie pokazywał, że klient został rozłączony)

namespace MobileRobots
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        #region Deklaracje
        // Zmienne globalne i wartości podstawowe

        public class Globals
        {
            public const Int32 port = 8000;
            public const double time = 500;
            public static String IPAddr;
            public static String CMD;
            public static int LED;
            public static int ENG_L;
            public static int ENG_R;
            public static byte[] msg_buffer_s;
            public static byte[] msg_buffer_r;
        }

        private static TcpClient client;
        private static NetworkStream stream;
        private static Timer Timer1;

        private void SetTimer(double time)
        {
            Timer1 = new Timer(time);
            Timer1.Elapsed += Timer1_Event;
            Timer1.AutoReset = true;
            Timer1.Enabled = true;
        }
        #endregion

        #region Funkcje
        public void Connect(String IP, Int32 port)
        {
            if (Globals.IPAddr != null)
            {
                try
                {
                    client = new TcpClient { SendTimeout = 1000 };
                    client.Connect(IP, port);
                    stream = client.GetStream();
                    IsConnected();
                    if (IsConnected() == true)
                    {
                        // TODO: ---> Włączanie/Wyłączanie zegara
                        SetTimer(Globals.time);
                    }
                }
                catch (SocketException ex)
                {
                    LogBOX.AppendText(ex.Message);
                    LogBOX.AppendText(Environment.NewLine);
                }
                //catch (ArgumentNullException ex)
                //{
                //    LogBOX.AppendText("ArgumentNullException: " + ex);
                //    LogBOX.AppendText(Environment.NewLine);
                //}
            }
            else
            {
                LogBOX.AppendText("Enter IP Address first.");
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
                Timer1.Stop();
                Timer1.Dispose();
                IsConnected();
            } else 
            {
                LogBOX.AppendText("Not connected.");
                LogBOX.AppendText(Environment.NewLine);
            }
        }
        // Funkcja wykonywana po przepełnieniu timera
        private void Timer1_Event(Object source, ElapsedEventArgs e)
        {
            Build_ControlFrame(Globals.ENG_L, Globals.ENG_R);
        }

        // Budowanie aktualnej ramki do przesłania
        private void Build_ControlFrame(int ENG_L, int ENG_R)
        {
            int LED;
            if (LED_G.Checked & LED_R.Checked) { LED = 3; }
            else if (LED_G.Checked) { LED = 1; }
            else if (LED_R.Checked) { LED = 2; }
            else { LED = 0; }
            Globals.msg_buffer_s = new byte[] { Convert.ToByte('['), (byte)LED, (byte)((sbyte)ENG_L), (byte)((sbyte)ENG_R), Convert.ToByte(']') };
            Globals.msg_buffer_r = SendReceive(Globals.msg_buffer_s);
        }

        // Wysylanie i odbieranie ramek
        private byte[] SendReceive(byte[] msg)
        {
            try
            {
                byte[] msg_s = msg;
                stream.Write(msg_s, 0, msg_s.Length);
                Invoke("Sent: " + Encoding.ASCII.GetString(msg));
                Byte[] msg_r = new byte[32]; //= new Byte[256];
                String response = String.Empty;
                Int32 bytes = stream.Read(msg_r, 0, msg_r.Length);
                response = Encoding.ASCII.GetString(msg_r, 0, msg_r.Length);
                Invoke("  Received: " + response);
                Invoke(Environment.NewLine);
                return msg_r;
            }
            catch (System.IO.IOException)
            {
                Invoke(Environment.NewLine);
                Invoke("Connection interrupted.");
                Invoke(Environment.NewLine);
                Timer1.Stop();
                Timer1.Dispose();
                return null;
            }
        }
        #endregion

        #region Metody pomocnicze
        // Dzięki tej metodzie jesteśmy w stanie edytować kontrolkę LogBOX z poziomu innego threadu niż ten, w którym została utworzona (Timer1) bez potencjalnych kolizji i nieprzewidzianych skutków
        // https://stackoverflow.com/questions/13345091/is-it-safe-just-to-set-checkforillegalcrossthreadcalls-to-false-to-avoid-cross-t
        // W przypadku tego programu nieprzewidziane skutki objawiały się jako przemieszane ze sobą dane "Sent: XX  Received: XX", np. "S   Received:XXent:XX"

        // TODO: ---> Invoker
        void Invoke(string str)
        {
            if (LogBOX.InvokeRequired)
                LogBOX.Invoke(new Action<string>(Invoke), str);
            else
                LogBOX.AppendText(str);
        }

        // TODO: ---> Konwersja do Signed HEX
        // Jest możliwość bezpośredniego zapisania wartości ujemnej w formie ciągu bitów przy pomocy Two's complement (negacja ciągu bajtów i dodanie 1)
        // C# nie ma w sobie jako takiej natywnej metody wskazywania negatywnych HEXów
        public static string IntToSigHEX(int integer)
        {
            byte[] inbyte = new byte[] { (byte)((sbyte)integer) };
            return BitConverter.ToString(inbyte).Replace("-", "");
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
                IPBox.Enabled = true;
                return false;
            }
        }
        #endregion

        #region Kontrolki
        // TODO: ---> Parametry Form_Load
        private void Form_Load(object sender, EventArgs e)
        {
            IPBox.Text = "192.168.2.2";
            Eng_L.Enabled = false;
            Eng_R.Enabled = false;
            CMDBox.Enabled = false;
            CMDBox.Visible = true;
            BTNSend.Enabled = false;
            BTNSend.Visible = true;
            LogBOX.Visible = false;
            LogBOX.Enabled = false;
            BTNLogClear.Visible = false;
        }

        private void Form_Closing(object sender, CancelEventArgs e)
        {
                client.Close();
                stream.Close();
                Timer1.Stop();
                Timer1.Dispose();
        }

        // TODO ---> STOP AWARYJNY
        private void BTNSTOP_Click(object sender, EventArgs e)
        {
            Globals.ENG_L = 0;
            Globals.ENG_R = 0;
            Eng_L.Value = 0;
            Eng_R.Value = 0;
            LED_G.Checked = false;
            LED_R.Checked = false;
        }

        private void ClearLogBTN_Click(object sender, EventArgs e)
        {
            LogBOX.Text = String.Empty;
        }

        private void BTNConnect_Click(object sender, EventArgs e)
        {
            Globals.IPAddr = IPBox.Text;
            if(IsConnected() == true)
            {
                LogBOX.AppendText("Disconnect before trying to connect again.");
                LogBOX.AppendText(Environment.NewLine);
            }
            else
            {
                if (IPBox.Text != "")
                {
                    Connect(Globals.IPAddr, Globals.port);
                }
                else
                {
                    LogBOX.AppendText("Error. Make sure you entered proper IP address and host is reachable.");
                    LogBOX.AppendText(Environment.NewLine);
                }

            }
        }

        private void BTNDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void IPBox_TextChanged(object sender, EventArgs e)
        {
            Globals.IPAddr = IPBox.Text;
        }

        private void BTNSend_Click(object sender, EventArgs e)
        {
            //SendReceive("[" + CMDBox.Text + "]");
        }

        private void CMDBox_TextChanged(object sender, EventArgs e)
        {
            Globals.CMD = Convert.ToString(CMDBox.Text);
        }

        private void Eng_L_Scroll(object sender, EventArgs e)
        {
            // Globals.ENG_L = Convert.ToInt32(Eng_L.Value);
            Globals.ENG_L = Eng_L.Value;
        }

        private void Eng_R_Scroll(object sender, EventArgs e)
        {
            Globals.ENG_R = Convert.ToInt32(Eng_R.Value);
        }
        #endregion

        #region Test

        private void BTNIsConnected_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                LogBOX.AppendText("Connected:" + "False");               
            }
            else
            {
                IsConnected();
                LogBOX.AppendText("Connected:" + client.Connected);
            }
            LogBOX.AppendText(Environment.NewLine);     
        }

        private void BTNLog_Click(object sender, EventArgs e)
        {
            if (LogBOX.Visible == true)
            {
                LogBOX.Visible = false;
                LogBOX.Enabled = false;
                BTNLogClear.Visible = false;
                BTNLog.Text = "Log";
            }
            else
            {
                LogBOX.Visible = true;
                LogBOX.Enabled = true;
                BTNLogClear.Visible = true;
                BTNLog.Text = "Sensors";
            }
        }

        void Form_KeyPress(object sender, WinForms::KeyPressEventArgs e)
        {

        }

        private void BTNSettings_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Useless
        private void StatusLabel_Click(object sender, EventArgs e)
        {

        }
        private void BatteryLevel_Click(object sender, EventArgs e)
        {

        }

        private void Led_G_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void LED_R_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Battery_Label_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}