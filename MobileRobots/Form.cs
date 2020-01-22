using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using System.ComponentModel;

namespace MobileRobots
{
    public partial class Form : System.Windows.Forms.Form
    {
        #region Init
        public Form()
        {
            InitializeComponent();
        }

        // TODO: ---> Parametry Form_Load
        private void Form_Load(object sender, EventArgs e)
        {
            IPBox.Text = "127.0.0.1";
            CMDBox.Enabled = false;
            Eng_L.Enabled = false;
            Eng_R.Enabled = false;
            CMDBox.Visible = false;
            BTNSend.Enabled = false;
            BTNSend.Visible = false;
            LogBOX.Visible = false;
            LogBOX.Enabled = false;
            BTNLogClear.Visible = false;
            SetTimer(Globals.time);
        }
        #endregion

        #region Deklaracje

        TcpClient client;
        NetworkStream stream;
        Timer Timer1;

        public class Globals                         // TODO: ---> Klasa zmiennych globalnych
        {
            public const Int16 time = 300;
            public const Int16 port = 8000;

            public const Int16 hop = 5;             // TODO: ---> Skok podczas sterowania klawiszami
            
            public static String IPAddr = String.Empty;
            public static String CMD = String.Empty;
            public static String LED = String.Empty;
            public static int ENG_L = 0;
            public static int ENG_R = 0;
            public static String msg_buffer_s = String.Empty;
            public static String msg_buffer_r = String.Empty;
            public static String ResponseString = String.Empty;
            public static Int16 Status = 0;
        }

        private void SetTimer(Int16 time)
        {
            Timer1 = new Timer(time);
            Timer1.Elapsed += Timer1_Event;
            Timer1.AutoReset = false;
            Timer1.Enabled = false;
        }
        #endregion

        #region Metody podstawowe
        public void Connect(String IP, Int32 port)
        {
            if (Globals.IPAddr != null)
            {
                try
                {
                    client = new TcpClient { SendTimeout = 1000 };
                    client.Connect(IP, port);
                    stream = client.GetStream();
                    }
                catch (SocketException ex)
                {
                    LogBOX.AppendText(ex.Message);
                    LogBOX.AppendText(Environment.NewLine);
                }
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
                Timer1.Stop();
                client.Close();
                stream.Close();
                client.Dispose();
                stream.Dispose();
            } else 
            {
                LogBOX.AppendText("Not connected.");
                LogBOX.AppendText(Environment.NewLine);
            }
        }

        // Instrukcje wykonywane po przepełnieniu Timer1
        private void Timer1_Event(Object source, ElapsedEventArgs e)
        {
            try
            {
                Timer1.Stop();
                SafeInvoke(Eng_L, () => { Globals.ENG_L = Eng_L.Value; });
                SafeInvoke(Eng_R, () => { Globals.ENG_R = Eng_R.Value; });
                Build_ControlFrame(Globals.ENG_L, Globals.ENG_R);
                Globals.msg_buffer_r = SendReceive(Globals.msg_buffer_s);
                Globals.ResponseString = "Sent: " + Globals.msg_buffer_s + "  " + "Received: " + Globals.msg_buffer_r;
            }
            finally
            {
                UpdateUI();
                Timer1.Start();
                IsConnected();
            }
        }

        // Budowanie ramki do wysłania
        private void Build_ControlFrame(int ENG_L, int ENG_R)
        {
            string LED;
            if (LED_G.Checked & LED_R.Checked) { LED = "03"; }
            else if (LED_G.Checked) { LED = "01"; }
            else if (LED_R.Checked) { LED = "02"; }
            else { LED = "00"; }
            Globals.msg_buffer_s = "[" + LED + U2(ENG_L) + U2(ENG_R) + "]";
        }

        // Wysylanie i odbieranie ramek
        private string SendReceive(string msg)
        {
            try
            {
                byte[] msg_s = Encoding.ASCII.GetBytes(msg);
                stream.Write(msg_s, 0, msg_s.Length);
                String response = String.Empty;
                Byte[] msg_r = new Byte[28];
                Int32 bytes = stream.Read(msg_r, 0, msg_r.Length);
                response = Encoding.ASCII.GetString(msg_r, 0, msg_r.Length);
                return response;
            }
            catch (System.IO.IOException)
            {;
                SafeInvoke(LogBOX, () => { LogBOX.AppendText("Connection interrupted."); LogBOX.AppendText(Environment.NewLine); }) ;
                client.Close();
                stream.Close();
                client.Dispose();
                stream.Dispose();
                Timer1.Stop();
                return String.Empty;
            }
            catch (ObjectDisposedException)
            {
                SafeInvoke(LogBOX, () => { LogBOX.AppendText("Connection interrupted."); LogBOX.AppendText(Environment.NewLine); });
                client.Close();
                stream.Close();
                client.Dispose();
                stream.Dispose();
                Timer1.Stop();
                return String.Empty;
            }
        }
        #endregion

        #region Metody pomocnicze
        private bool IsConnected()
        {
            try
            {
                if (client.Connected == true)
                {
                    SafeInvoke(StatusLabel, () => { StatusLabel.ForeColor = Color.Green; StatusLabel.Text = "Connected"; });
                    SafeInvoke(Eng_L, () => { Eng_L.Enabled = true; });
                    SafeInvoke(Eng_R, () => { Eng_R.Enabled = true; });
                    Timer1.Start();
                    return true;
                }
                else
                {
                    SafeInvoke(StatusLabel, () => { StatusLabel.ForeColor = Color.Red; StatusLabel.Text = "Disconnected"; });
                    SafeInvoke(Eng_L, () => { Eng_L.Enabled = false; });
                    SafeInvoke(Eng_R, () => { Eng_R.Enabled = false; });
                    Timer1.Stop();
                    return false;
                }
            }
            catch (NullReferenceException) 
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "Disconnected";
                Eng_L.Enabled = false;
                Eng_R.Enabled = false;
                Timer1.Stop();
                return false;
            }
        }

        private void UpdateUI()
        {
            SafeInvoke(LogBOX, () => { LogBOX.AppendText(Globals.ResponseString); LogBOX.AppendText(Environment.NewLine); });
            if (Globals.msg_buffer_r.Length == 28 && Globals.msg_buffer_r.Substring(0, 3) == "[00" & Globals.msg_buffer_r.Substring(27, 1) == "]")
            {
                try
                {
                    SafeInvoke(RStatus, () => { RStatus.Text = "Status: " + Globals.msg_buffer_r.Substring(1, 2); });
                    SafeInvoke(BatteryLevel, () => { BatteryLevel.Value = Convert.ToInt32(Globals.msg_buffer_r.Substring(3, 4), 16); });
                    SafeInvoke(Sensor1, () => { Sensor1.Value = Convert.ToInt32(Globals.msg_buffer_r.Substring(7, 4), 16); });
                    SafeInvoke(Sensor2, () => { Sensor2.Value = Convert.ToInt32(Globals.msg_buffer_r.Substring(11, 4), 16); });
                    SafeInvoke(Sensor3, () => { Sensor3.Value = Convert.ToInt32(Globals.msg_buffer_r.Substring(15, 4), 16); });
                    SafeInvoke(Sensor4, () => { Sensor4.Value = Convert.ToInt32(Globals.msg_buffer_r.Substring(19, 4), 16); });
                    SafeInvoke(Sensor5, () => { Sensor5.Value = Convert.ToInt32(Globals.msg_buffer_r.Substring(23, 4), 16); });
                }
                catch (FormatException)
                {
                    SafeInvoke(LogBOX, () => { LogBOX.AppendText("Invalid response, can't update UI controls."); LogBOX.AppendText(Environment.NewLine); });
                }
            }
            else
            {
                SafeInvoke(LogBOX, () => { LogBOX.AppendText("Invalid response, can't update UI controls."); LogBOX.AppendText(Environment.NewLine); });
            }
        }

        // TODO: ---> SafeInvoke
        // Dzięki tej metodzie jesteśmy w stanie edytować kontrolkę LogBOX z poziomu innego threadu (Timer1) niż ten, w którym została utworzona (Form) bez potencjalnych kolizji i nieprzewidzianych skutków
        // https://stackoverflow.com/questions/13345091/is-it-safe-just-to-set-checkforillegalcrossthreadcalls-to-false-to-avoid-cross-t
        // W przypadku tego programu nieprzewidziane skutki objawiały się jako przemieszane ze sobą dane "Sent: XX  Received: XX", np. "S   Received:XXent:XX"

        public static void SafeInvoke(System.Windows.Forms.Control control, System.Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(new System.Windows.Forms.MethodInvoker(() => { action(); }));
            else
                action();
        }

        public static string U2(int integer)               // TODO: ---> Konwersja signed int do hex przy użyciu metody U2 (Uzupełnień do 2)
        {
            byte[] inbyte = new byte[] { (byte)((sbyte)integer) };
            return BitConverter.ToString(inbyte).Replace("-", "");
        }
        #endregion

        #region Kontrolki

        private void Form_Closing(object sender, CancelEventArgs e)
        {
                client.Close();
                stream.Close();
                Timer1.Stop();
                Timer1.Dispose();
        }

        // TODO ---> STOP
        private void BTNSTOP_Click(object sender, EventArgs e)
        {
            //Globals.ENG_L = 0;
            //Globals.ENG_R = 0;
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
                    IsConnected();
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
            IsConnected();
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

        private void IPBox_TextChanged(object sender, EventArgs e)
        {
            Globals.IPAddr = IPBox.Text;
        }
        #endregion

        #region Ruch klawiszami (Bonus)
        private void Form_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "W") { Move_Forward(); }
            if (e.Control && e.KeyCode.ToString() == "S") { Move_Backward(); }
            if (e.Control && e.KeyCode.ToString() == "A") { Move_Left(); }
            if (e.Control && e.KeyCode.ToString() == "D") { Move_Right(); }

            if (e.Control && e.KeyCode.ToString() == "Q") { Move_LeftQ(); }
            if (e.Control && e.KeyCode.ToString() == "E") { Move_RightE(); }
            if (e.Control && e.KeyCode.ToString() == "C") { Move_LeftB(); }
            if (e.Control && e.KeyCode.ToString() == "Z") { Move_RightB(); }

            if (e.Control && e.KeyCode == System.Windows.Forms.Keys.Space) { Move_Stop(); }
        }

        private void Move_Forward()
        {
            if (Eng_L.Value + Globals.hop <= 127) { Eng_L.Value += Globals.hop; } else { Eng_L.Value += Eng_L.Maximum - Eng_L.Value; }
            if (Eng_R.Value + Globals.hop <= 127) { Eng_R.Value += Globals.hop; } else { Eng_R.Value += Eng_R.Maximum - Eng_R.Value; }
        }
        private void Move_Backward()
        {
            if (Eng_L.Value - Globals.hop >= -128) { Eng_L.Value -= Globals.hop; } else { Eng_L.Value -= Math.Abs(Eng_L.Minimum) - Math.Abs(Eng_L.Value); }
            if (Eng_R.Value - Globals.hop >= -128) { Eng_R.Value -= Globals.hop; } else { Eng_R.Value -= Math.Abs(Eng_R.Minimum) - Math.Abs(Eng_R.Value); }
        }
        private void Move_Left()
        {
            if (Eng_L.Value - Globals.hop >= -128) { Eng_L.Value -= Globals.hop; } else { Eng_L.Value -= Math.Abs(Eng_L.Minimum) - Math.Abs(Eng_L.Value); }
            if (Eng_R.Value + Globals.hop <= 127) { Eng_R.Value += Globals.hop; } else { Eng_R.Value += Eng_R.Maximum - Eng_R.Value; }
        }
        private void Move_Right()
        {
            if (Eng_L.Value + Globals.hop <= 127) { Eng_L.Value += Globals.hop; } else { Eng_L.Value += Eng_L.Maximum - Eng_L.Value; }
            if (Eng_R.Value - Globals.hop >= -128) { Eng_R.Value -= Globals.hop; } else { Eng_R.Value -= Math.Abs(Eng_R.Minimum) - Math.Abs(Eng_R.Value); }
        }
        private void Move_LeftQ()
        {
            if (Eng_R.Value + Globals.hop <= 127) { Eng_R.Value += Globals.hop; } else { Eng_R.Value += Eng_R.Maximum - Eng_R.Value; }
        }
        private void Move_RightE()
        {
            if (Eng_L.Value + Globals.hop <= 127) { Eng_L.Value += Globals.hop; } else { Eng_L.Value += Eng_L.Maximum - Eng_L.Value; }
        }
        private void Move_LeftB()
        {
            if (Eng_R.Value + Globals.hop <= 127) { Eng_R.Value -= Globals.hop; } else { Eng_R.Value -= Eng_R.Maximum - Eng_R.Value; }
        }
        private void Move_RightB()
        {
            if (Eng_L.Value + Globals.hop <= 127) { Eng_L.Value -= Globals.hop; } else { Eng_L.Value -= Eng_L.Maximum - Eng_L.Value; }
        }
        private void Move_Stop()
        {
            Eng_L.Value = 0;
            Eng_R.Value = 0;
        }
        #endregion

        #region Test
        private void BTNIsConnected_Click(object sender, EventArgs e)
        {
            UpdateUI();
        }
        
        #endregion
        #region Useless

        private void BTNSend_Click(object sender, EventArgs e)
        {
            //SendReceive("[" + CMDBox.Text + "]");
        }

        private void CMDBox_TextChanged(object sender, EventArgs e)
        {
            //Globals.CMD = Convert.ToString(CMDBox.Text);
        }

        private void Eng_L_Scroll(object sender, EventArgs e)
        {
            //Globals.ENG_L = Eng_L.Value;
        }

        private void Eng_R_Scroll(object sender, EventArgs e)
        {
            //Globals.ENG_R = Eng_R.Value;
        }
        private void LogBOX_TextChanged(object sender, EventArgs e)
        {

        }
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
        private void RStatus_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}