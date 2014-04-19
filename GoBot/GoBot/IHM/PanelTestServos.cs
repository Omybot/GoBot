using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Communications;
using System.Threading;

namespace GoBot.IHM
{
    public partial class PanelTestServos : UserControl
    {
        public PanelTestServos()
        {
            InitializeComponent();
        }

        private void btnChercher_Click(object sender, EventArgs e)
        {
            //Connexions.ConnexionMove.SendMessage(TrameFactory.ServoDemandeId(Carte.RecMove));
            //Thread.Sleep(500);

            listBoxServos.Items.Clear();

            foreach (ServomoteurID servo in Enum.GetValues(typeof(ServomoteurID)))
            {
                if(!servo.ToString().Contains("zLibre"))
                    listBoxServos.Items.Add(servo);
            }
        }

        private void listBoxServos_SelectedValueChanged(object sender, EventArgs e)
        {
            ServomoteurID servo = (ServomoteurID)listBoxServos.SelectedItem;
            panelServo.AfficherServo(servo);
        }
    }
}
