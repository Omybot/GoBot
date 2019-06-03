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
    public partial class PanelSpeedConfig : UserControl
    {
        private bool _loaded;

        public PanelSpeedConfig()
        {
            InitializeComponent();
            _loaded = false;
        }

        private void PanelConstantes_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                numAccelerationLigneLent.Value = Config.CurrentConfig.ConfigLent.LineAcceleration;
                numAccelerationFinLigneLent.Value = Config.CurrentConfig.ConfigLent.LineDeceleration;
                numVitesseLigneLent.Value = Config.CurrentConfig.ConfigLent.LineSpeed;
                numAccelerationPivotLent.Value = Config.CurrentConfig.ConfigLent.PivotAcceleration;
                numDecelerationPivotLent.Value = Config.CurrentConfig.ConfigLent.PivotDeceleration;
                numVitessePivotLent.Value = Config.CurrentConfig.ConfigLent.PivotSpeed;

                numAccelerationLigneRapide.Value = Config.CurrentConfig.ConfigRapide.LineAcceleration;
                numAccelerationFinLigneRapide.Value = Config.CurrentConfig.ConfigRapide.LineDeceleration;
                numVitesseLigneRapide.Value = Config.CurrentConfig.ConfigRapide.LineSpeed;
                numAccelerationPivotRapide.Value = Config.CurrentConfig.ConfigRapide.PivotAcceleration;
                numDecelerationPivotRapide.Value = Config.CurrentConfig.ConfigRapide.PivotDeceleration;
                numVitessePivotRapide.Value = Config.CurrentConfig.ConfigRapide.PivotSpeed;

                _loaded = true;
            }
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (_loaded)
            {
                Config.CurrentConfig.ConfigRapide.SetParams(
                    (int)numVitesseLigneRapide.Value,
                    (int)numAccelerationLigneRapide.Value,
                    (int)numAccelerationFinLigneRapide.Value,
                    (int)numVitessePivotRapide.Value,
                    (int)numAccelerationPivotRapide.Value,
                    (int)numDecelerationPivotRapide.Value);

                Config.CurrentConfig.ConfigLent.SetParams(
                    (int)numVitesseLigneLent.Value,
                    (int)numAccelerationLigneLent.Value,
                    (int)numAccelerationFinLigneLent.Value,
                    (int)numVitessePivotLent.Value,
                    (int)numAccelerationPivotLent.Value,
                    (int)numDecelerationPivotLent.Value);

                Config.Save();
            }
        }
    }
}
