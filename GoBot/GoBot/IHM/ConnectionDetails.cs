using GoBot.Communications;
using GoBot.Communications.UDP;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class ConnectionDetails : UserControl
    {
        private UDPConnection _connection;

        public ConnectionDetails()
        {
            InitializeComponent();
        }

        public UDPConnection Connection
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
                    _lblIP.Text = _connection.IPAddress.ToString();
                    _lblInputPort.Text = _connection.InputPort.ToString();
                    _lblOutputPort.Text = _connection.OutputPort.ToString();
                }
            }
        }
    }
}
