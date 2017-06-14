using GoBot.Communications;
using System;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class ConnectionStatus : UserControl
    {
        private Connection _connection;
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
            this.InvokeAuto(() => _conIndicator.SetConnectionState(_connection.Connected, _connection.ConnectionChecker.Connected, true));
        }

        public Connection Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                if (_connection != null && _connection.ConnectionChecker != null)
                    _connection.ConnectionChecker.ConnectionStatusChange -= ConnexionCheck_ConnectionStatusChange;

                _connection = value;

                if (_connection != null && _connection.ConnectionChecker != null)
                {
                    _conIndicator.SetConnectionState(_connection.Connected, _connection.ConnectionChecker.Connected, false);
                    _connection.ConnectionChecker.ConnectionStatusChange += ConnexionCheck_ConnectionStatusChange;
                    _lblName.Text = Connections.GetBoardByConnection(_connection).ToString();
                }
            }
        }
        
        private void ConnexionCheck_ConnectionStatusChange(Connection sender, bool connected)
        {
            this.InvokeAuto(() => _conIndicator.SetConnectionState(sender.Connected, connected, true));
        }
    }
}
