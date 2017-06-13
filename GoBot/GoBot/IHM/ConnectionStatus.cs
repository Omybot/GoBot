using GoBot.Communications;
using System;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class ConnectionStatus : UserControl
    {
        private Connexion _connection;
        
        public ConnectionStatus()
        {
            InitializeComponent();
        }

        public Connexion Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                if (_connection != null && _connection.ConnexionCheck != null)
                    _connection.ConnexionCheck.ConnectionStatusChange -= ConnexionCheck_ConnectionStatusChange;

                _connection = value;

                if (_connection != null && _connection.ConnexionCheck != null)
                {
                    _conIndicator.SetConnectionState(_connection.ConnexionCheck.Connected, false);
                    _connection.ConnexionCheck.ConnectionStatusChange += ConnexionCheck_ConnectionStatusChange;
                    _lblName.Text = Connections.GetBoardByConnection(_connection).ToString();
                }
            }
        }
        
        private void ConnexionCheck_ConnectionStatusChange(Connexion sender, bool connected)
        {
            this.InvokeAuto(() => _conIndicator.SetConnectionState(connected, true));
        }
    }
}
