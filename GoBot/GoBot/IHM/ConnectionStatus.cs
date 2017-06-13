using GoBot.Communications;
using System;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class ConnectionStatus : UserControl
    {
        private Connection _connection;
        
        public ConnectionStatus()
        {
            InitializeComponent();
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
                    _conIndicator.SetConnectionState(_connection.ConnectionChecker.Connected, false);
                    _connection.ConnectionChecker.ConnectionStatusChange += ConnexionCheck_ConnectionStatusChange;
                    _lblName.Text = Connections.GetBoardByConnection(_connection).ToString();
                }
            }
        }
        
        private void ConnexionCheck_ConnectionStatusChange(Connection sender, bool connected)
        {
            this.InvokeAuto(() => _conIndicator.SetConnectionState(connected, true));
        }
    }
}
