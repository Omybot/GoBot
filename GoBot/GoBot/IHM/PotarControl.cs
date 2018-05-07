using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Actionneurs;
using System.Threading;
using GoBot.Threading;
using System.Reflection;

namespace GoBot.IHM
{
    public partial class PotarControl : UserControl
    {
        private ThreadLink _linkPolling;
        private Positionable _currentPositionnable;
        private int _currentPosition;

        public Dictionary<String, PropertyInfo> _positionsProp;


        public PotarControl()
        {
            InitializeComponent();
            _linkPolling = null;
        }

        private void PotarControl_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                cboPositionnable.Items.AddRange(Config.Positionnables.ToArray());
            }
        }

        private void cboPositionnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock (this)
            {
                _currentPositionnable = (Positionable)cboPositionnable.SelectedItem;
                trackBar.Min = _currentPositionnable.Minimum;
                trackBar.Max = _currentPositionnable.Maximum;

                SetPositions(_currentPositionnable);
            }
        }

        private void switchBouton_ValueChanged(object sender, bool value)
        {
            if (value)
            {
                _linkPolling = ThreadManager.CreateThread(link => PollingLoop());
                _linkPolling.StartThread();
            }
            else
            {
                _linkPolling.Cancel();
            }
        }

        private void PollingLoop()
        {
            double posValue;
            double ticksCurrent, ticksMin, ticksRange;
            int pointsParTour = 4096;
            double toursRange = 5;

            _linkPolling.RegisterName();

            ticksCurrent = Devices.Devices.RecGoBot.GetCodeurPosition();
            ticksMin = ticksCurrent;
            ticksRange = pointsParTour * toursRange;

            posValue = _currentPositionnable.Minimum;

            while (!_linkPolling.Cancelled)
            {
                lock (this)
                {
                    _linkPolling.LoopsCount++;

                    toursRange = trackBarSpeed.Value;
                    ticksRange = pointsParTour * toursRange;
                    Thread.Sleep(50);
                    ticksCurrent = Devices.Devices.RecGoBot.GetCodeurPosition();

                    if (ticksCurrent > ticksMin + ticksRange)
                        ticksMin = ticksCurrent - ticksRange;
                    else if (ticksCurrent < ticksMin)
                        ticksMin = ticksCurrent;

                    posValue = (ticksCurrent - ticksMin) / ticksRange * (_currentPositionnable.Maximum - _currentPositionnable.Minimum) + _currentPositionnable.Minimum;

                    posValue = Math.Min(posValue, _currentPositionnable.Maximum);
                    posValue = Math.Max(posValue, _currentPositionnable.Minimum);

                }

                SetPosition((int)posValue);
            }

            _linkPolling = null;
        }

        private void SetPosition(int position)
        {
            if (position != _currentPosition)
            {
                _currentPosition = position;
                _currentPositionnable.SendPosition((int)_currentPosition);
                this.InvokeAuto(() =>
                {
                    trackBar.SetValue(_currentPosition);
                    lblValue.Text = _currentPosition.ToString();
                });
            }
        }

        private void trackBarSpeed_ValueChanged(object sender, double value)
        {
            lblSpeed.Text = "Rapport " + value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String[] tab = ((String)(cboPositions.SelectedItem)).Split(new char[] { ':' });

            String position = tab[0].Trim().ToLower();
            int valeur = Convert.ToInt32(tab[1].Trim());

            int index = cboPositions.SelectedIndex;

            _positionsProp[(String)cboPositions.SelectedItem].SetValue((Positionable)cboPositionnable.SelectedItem, _currentPosition, null);
            trackBar.Min = _currentPositionnable.Minimum;
            trackBar.Max = _currentPositionnable.Maximum;

            SetPositions(_currentPositionnable);
            cboPositions.SelectedIndex = index;
            
            Config.Save();
        }

        private void SetPositions(Positionable pos)
        {
            PropertyInfo[] properties = _currentPositionnable.GetType().GetProperties();

            List<String> noms = new List<string>();
            _positionsProp = new Dictionary<string, PropertyInfo>();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "ID")
                {
                    noms.Add(Config.PropertyNameToScreen(property) + " : " + property.GetValue(_currentPositionnable, null));
                    _positionsProp.Add(noms[noms.Count - 1], property);
                }
            }

            cboPositions.Items.Clear();
            cboPositions.Items.AddRange(noms.ToArray());
            btnSave.Enabled = false;
        }

        private void cboPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            _currentPosition = (int)_positionsProp[(String)cboPositions.SelectedItem].GetValue(cboPositionnable.SelectedItem);
        }
    }
}
