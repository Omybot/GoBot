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
            if (!Execution.DesignMode)
            {
                numAccelerationLigneLent.Value = Config.CurrentConfig.ConfigLent.LineAcceleration;
                numAccelerationFinLigneLent.Value = Config.CurrentConfig.ConfigLent.LineDeceleration;
                numVitesseLigneLent.Value = Config.CurrentConfig.ConfigLent.LineSpeed;
                numAccelerationPivotLent.Value = Config.CurrentConfig.ConfigLent.PivotAcceleration;
                numVitessePivotLent.Value = Config.CurrentConfig.ConfigLent.PivotSpeed;

                numAccelerationLigneRapide.Value = Config.CurrentConfig.ConfigRapide.LineAcceleration;
                numAccelerationFinLigneRapide.Value = Config.CurrentConfig.ConfigRapide.LineDeceleration;
                numVitesseLigneRapide.Value = Config.CurrentConfig.ConfigRapide.LineSpeed;
                numAccelerationPivotRapide.Value = Config.CurrentConfig.ConfigRapide.PivotAcceleration;
                numVitessePivotRapide.Value = Config.CurrentConfig.ConfigRapide.PivotSpeed;
                
                numBatGrosVert.Value = (decimal)Config.CurrentConfig.BatterieRobotVert;
                numBatGrosOrange.Value = (decimal)Config.CurrentConfig.BatterieRobotOrange;
                numBatGrosRouge.Value = (decimal)Config.CurrentConfig.BatterieRobotRouge;
                numBatGrosCritique.Value = (decimal)Config.CurrentConfig.BatterieRobotCritique;

                batGrosCritique.CurrentState = Composants.Battery.State.VeryLow;
                batGrosOrange.CurrentState = Composants.Battery.State.Average;
                batGrosRouge.CurrentState = Composants.Battery.State.Low;
                batGrosVert.CurrentState = Composants.Battery.State.High;
                batGrosVide.CurrentState = Composants.Battery.State.Absent;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes vous certain de vouloir enregistrer ces valeurs dans le fichier de configuration ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            Config.CurrentConfig.ConfigRapide.SetParams(
                (int)numVitesseLigneRapide.Value,
                (int)numAccelerationLigneRapide.Value,
                (int)numAccelerationFinLigneRapide.Value,
                (int)numVitessePivotRapide.Value,
                (int)numAccelerationPivotRapide.Value,
                (int)numAccelerationPivotRapide.Value);

            Config.CurrentConfig.ConfigLent.SetParams(
                (int)numVitesseLigneLent.Value,
                (int)numAccelerationLigneLent.Value,
                (int)numAccelerationFinLigneLent.Value,
                (int)numVitessePivotLent.Value,
                (int)numAccelerationPivotLent.Value,
                (int)numAccelerationPivotLent.Value);
            
            Config.CurrentConfig.BatterieRobotVert = (double)numBatGrosVert.Value;
            Config.CurrentConfig.BatterieRobotOrange = (double)numBatGrosOrange.Value;
            Config.CurrentConfig.BatterieRobotRouge = (double)numBatGrosRouge.Value;
            Config.CurrentConfig.BatterieRobotCritique = (double)numBatGrosCritique.Value;
        }
    }
}
