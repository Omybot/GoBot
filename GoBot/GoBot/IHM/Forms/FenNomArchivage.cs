using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class FenNomArchivage : Form
    {
        public String Nom { get; set; }
        public bool OK { get; set; }

        public FenNomArchivage()
        {
            InitializeComponent();
            OK = false;
        }

        private void FenNomArchivage_Load(object sender, EventArgs e)
        {
            lblDate.Text = Nom;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Nom = txtNom.Text;
            OK = true;
            this.Close();
        }
    }
}
