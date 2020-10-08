using System;
using System.Windows.Forms;
using System.Threading;

using GoBot.Devices;

namespace GoBot.IHM.Pages
{
    public partial class PagePepperl : UserControl
    {
        Pepperl _lidar;
        
        private void btnText_Click(object sender, EventArgs e)
        {
            _lidar.ShowMessage(txtText1.Text, txtText2.Text);
        }

        public PagePepperl()
        {
            InitializeComponent();
        }

        private void PagePepperl_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                _lidar = (Pepperl)AllDevices.LidarAvoid;

                foreach (PepperlFreq f in Enum.GetValues(typeof(PepperlFreq)))
                    cboFreq.Items.Add(f);

                foreach (PepperlFilter f in Enum.GetValues(typeof(PepperlFilter)))
                    cboFilter.Items.Add(f);

                UpdateInfos();
            }
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            _lidar.Reboot();
        }

        private void cboFreq_SelectedValueChanged(object sender, EventArgs e)
        {
            PepperlFreq value = (PepperlFreq)cboFreq.SelectedItem;

            if (_lidar.Frequency != value)
            {
                _lidar.SetFrequency(value);
                UpdateInfos();
            }
        }

        private void numFilter_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numFilter.Value;

            if (_lidar.FilterWidth != value)
            {
                _lidar.SetFilter(_lidar.Filter, value);
                UpdateInfos();
            }
        }

        private void cboFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            PepperlFilter value = (PepperlFilter)cboFilter.SelectedItem;

            if (_lidar.Filter != value)
            {
                _lidar.SetFilter(value, _lidar.FilterWidth);
                UpdateInfos();
            }
        }

        private void UpdateInfos()
        {
            cboFilter.SelectedItem = _lidar.Filter;
            cboFreq.SelectedItem = _lidar.Frequency;

            lblPoints.Text = _lidar.PointsPerScan.ToString();
            lblResolution.Text = _lidar.Resolution.ToString();
            lblDistPoints.Text = _lidar.PointsDistanceAt(3000).ToString("0.0") + " mm";

            numFilter.Visible = (_lidar.Filter != PepperlFilter.None);
            lblFilterPoints.Visible = numFilter.Visible;
        }
    }
}
