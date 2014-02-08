using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IhmRobot
{
    public partial class FenGoBot : Form
    {
        public FenGoBot()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Depl_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Texte par défaut TextBox
        private void txtDistanceGR_Enter(object sender, EventArgs e)
        {
            if (txtDistanceGR.Text == "Distance")
            {
                txtDistanceGR.ForeColor = Color.Black;
                txtDistanceGR.Text = "";
            }
        }

        private void txtDistanceGR_Leave(object sender, EventArgs e)
        {
            if (txtDistanceGR.Text == "")
            {
                txtDistanceGR.ForeColor = Color.LightGray;
                txtDistanceGR.Text = "Distance";
            }
        }

        private void txtAngleGR_Enter(object sender, EventArgs e)
        {
            if (txtAngleGR.Text == "Angle")
            {
                txtAngleGR.ForeColor = Color.Black;
                txtAngleGR.Text = "";
            }
        }

        private void txtAngleGR_Leave(object sender, EventArgs e)
        {
            if (txtAngleGR.Text == "")
            {
                txtAngleGR.ForeColor = Color.LightGray;
                txtAngleGR.Text = "Angle";
            }
        }
        #endregion

        private void btnAvanceGR_Click(object sender, EventArgs e)
        {
            int resultat;
            if (Int32.TryParse(txtDistanceGR.Text, out resultat) && resultat != 0)
                // Robot.avance(resultat);
                resultat = resultat;
            else
                txtDistanceGR.BackColor = Color.Red;
        }
    }
}
