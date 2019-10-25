using GoBot.Communications;
using GoBot.Communications.UDP;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class ConnectionStatus : UserControl
    {
        private ConnectionChecker _connection;
        private Timer _timer;
        
        public ConnectionStatus()
        {
            InitializeComponent();

            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            this.InvokeAuto(() => _conIndicator.BlinkColor(GetColor(_connection.Connected, _connection.Connected)));
        }

        public ConnectionChecker Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                if (_connection != null)
                    _connection.ConnectionStatusChange -= ConnexionCheck_ConnectionStatusChange;

                _connection = value;

                if (_connection != null)
                {
                    _conIndicator.Color = GetColor(_connection.Connected, _connection.Connected);
                    _connection.ConnectionStatusChange += ConnexionCheck_ConnectionStatusChange;
                }
            }
        }

        public String ConnectionName
        {
            set { _lblName.Text = value; }
        }
        
        private void ConnexionCheck_ConnectionStatusChange(Connection sender, bool connected)
        {
            this.InvokeAuto(() => _conIndicator.BlinkColor(GetColor(_connection.Connected, connected)));
        }

        private ColorPlus GetColor(bool inOK, bool outOk)
        {
            ColorPlus output;

            if (inOK && outOk)
                output = Color.Green;
            else if (!inOK && !outOk)
                output = Color.Red;
            else
                output = Color.Orange;

            return output;
        }
    }
}
