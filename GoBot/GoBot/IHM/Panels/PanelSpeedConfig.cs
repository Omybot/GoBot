using System;
using System.Windows.Forms;

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

        private void PanelSpeedConfig_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                numSlowLineAcceleration.Value = Config.CurrentConfig.ConfigLent.LineAcceleration;
                numSlowLineDeceleration.Value = Config.CurrentConfig.ConfigLent.LineDeceleration;
                numSlowLineSpeed.Value = Config.CurrentConfig.ConfigLent.LineSpeed;
                numSlowPivotAcceleration.Value = Config.CurrentConfig.ConfigLent.PivotAcceleration;
                numSlowPivotDeceleration.Value = Config.CurrentConfig.ConfigLent.PivotDeceleration;
                numSlowPivotSpeed.Value = Config.CurrentConfig.ConfigLent.PivotSpeed;

                numFastLineAcceleration.Value = Config.CurrentConfig.ConfigRapide.LineAcceleration;
                numFastLineDeceleration.Value = Config.CurrentConfig.ConfigRapide.LineDeceleration;
                numFastLineSpeed.Value = Config.CurrentConfig.ConfigRapide.LineSpeed;
                numFastPivotAcceleration.Value = Config.CurrentConfig.ConfigRapide.PivotAcceleration;
                numFastPivotDeceleration.Value = Config.CurrentConfig.ConfigRapide.PivotDeceleration;
                numFastPivotSpeed.Value = Config.CurrentConfig.ConfigRapide.PivotSpeed;

                _loaded = true;
            }
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (_loaded)
            {
                Config.CurrentConfig.ConfigRapide.SetParams(
                    (int)numFastLineSpeed.Value,
                    (int)numFastLineAcceleration.Value,
                    (int)numFastLineDeceleration.Value,
                    (int)numFastPivotSpeed.Value,
                    (int)numFastPivotAcceleration.Value,
                    (int)numFastPivotDeceleration.Value);

                Config.CurrentConfig.ConfigLent.SetParams(
                    (int)numSlowLineSpeed.Value,
                    (int)numSlowLineAcceleration.Value,
                    (int)numSlowLineDeceleration.Value,
                    (int)numSlowPivotSpeed.Value,
                    (int)numSlowPivotAcceleration.Value,
                    (int)numSlowPivotDeceleration.Value);

                Config.Save();
            }
        }
    }
}
