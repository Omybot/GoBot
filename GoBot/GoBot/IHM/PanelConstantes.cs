using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using GoBot.Communications;
using System.Reflection;

namespace GoBot.IHM
{
    public partial class PanelConstantes : UserControl
    {
        public PanelConstantes()
        {
            InitializeComponent();
        }

        private void PanelConstantes_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                numAccelerationLigneLent.Value = Config.CurrentConfig.GRAccelerationLigneLent;
                numAccelerationFinLigneLent.Value = Config.CurrentConfig.GRAccelerationFinLigneLent;
                numAccelerationLigneRapide.Value = Config.CurrentConfig.GRAccelerationLigneRapide;
                numAccelerationFinLigneRapide.Value = Config.CurrentConfig.GRAccelerationFinLigneRapide;
                numAccelerationPivotLent.Value = Config.CurrentConfig.GRAccelerationPivotLent;
                numAccelerationPivotRapide.Value = Config.CurrentConfig.GRAccelerationPivotRapide;

                numVitesseLigneLent.Value = Config.CurrentConfig.GRVitesseLigneLent;
                numVitesseLigneRapide.Value = Config.CurrentConfig.GRVitesseLigneRapide;
                numVitessePivotLent.Value = Config.CurrentConfig.GRVitessePivotLent;
                numVitessePivotRapide.Value = Config.CurrentConfig.GRVitessePivotRapide;

                numBatGrosVert.Value = (decimal)Config.CurrentConfig.BatterieRobotVert;
                numBatGrosOrange.Value = (decimal)Config.CurrentConfig.BatterieRobotOrange;
                numBatGrosRouge.Value = (decimal)Config.CurrentConfig.BatterieRobotRouge;
                numBatGrosCritique.Value = (decimal)Config.CurrentConfig.BatterieRobotCritique;

                batGrosCritique.CouleurRougeCritique();
                batGrosOrange.CouleurOrange();
                batGrosRouge.CouleurRouge();
                batGrosVert.CouleurVert();
                batGrosVide.CouleurGris();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes vous certain de vouloir enregistrer ces valeurs dans le fichier de configuration ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            Config.CurrentConfig.GRVitesseLigneRapide = (int)numVitesseLigneRapide.Value;
            Config.CurrentConfig.GRAccelerationLigneRapide = (int)numAccelerationLigneRapide.Value;
            Config.CurrentConfig.GRAccelerationFinLigneRapide = (int)numAccelerationFinLigneRapide.Value;
            Config.CurrentConfig.GRVitessePivotRapide = (int)numVitessePivotRapide.Value;
            Config.CurrentConfig.GRAccelerationPivotRapide = (int)numAccelerationPivotRapide.Value;

            Config.CurrentConfig.GRVitesseLigneLent = (int)numVitesseLigneLent.Value;
            Config.CurrentConfig.GRAccelerationLigneLent = (int)numAccelerationLigneLent.Value;
            Config.CurrentConfig.GRAccelerationFinLigneLent = (int)numAccelerationFinLigneLent.Value;
            Config.CurrentConfig.GRVitessePivotLent = (int)numVitessePivotLent.Value;
            Config.CurrentConfig.GRAccelerationPivotLent = (int)numAccelerationPivotLent.Value;
            
            Config.CurrentConfig.BatterieRobotVert = (double)numBatGrosVert.Value;
            Config.CurrentConfig.BatterieRobotOrange = (double)numBatGrosOrange.Value;
            Config.CurrentConfig.BatterieRobotRouge = (double)numBatGrosRouge.Value;
            Config.CurrentConfig.BatterieRobotCritique = (double)numBatGrosCritique.Value;
        }
    }
}
