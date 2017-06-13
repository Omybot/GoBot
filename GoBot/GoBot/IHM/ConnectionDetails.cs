using GoBot.Communications;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class ConnectionDetails : UserControl
    {
        private ConnexionUDP _connection;

        public ConnectionDetails()
        {
            InitializeComponent();
        }

        public ConnexionUDP Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
                if(_connection != null)
                {
                    _grpConnection.Text = Connections.GetBoardByConnection(_connection).ToString();
                    _lblIP.Text = _connection.AdresseIp.ToString();
                    _lblInputPort.Text = _connection.PortEntree.ToString();
                    _lblOutputPort.Text = _connection.PortSortie.ToString();
                }
            }
        }
    }
}
