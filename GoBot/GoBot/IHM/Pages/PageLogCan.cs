using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

using GoBot.Communications;
using GoBot.Communications.CAN;

namespace GoBot.IHM.Pages
{
    public partial class PageLogCan : UserControl
    {
        private FramesLog _log;
        private Dictionary<CanBoard, Color> _boardColor;

        private DateTime _startTime;
        private DateTime _previousTime, _previousDisplayTime;
        private System.Windows.Forms.Timer _displayTimer;
        private int _counter = 0;
        private Thread _thReplay;

        private List<CheckedListBox> _boxLists;

        bool _loading;

        public PageLogCan()
        {
            InitializeComponent();

            _loading = true;

            dgvLog.Columns.Add("ID", "ID");
            dgvLog.Columns[0].Width = 40;
            dgvLog.Columns.Add("Heure", "Heure");
            dgvLog.Columns[1].Width = 80;
            dgvLog.Columns.Add("Expediteur", "Expediteur");
            dgvLog.Columns[2].Width = 70;
            dgvLog.Columns.Add("Destinataire", "Destinataire");
            dgvLog.Columns[3].Width = 70;
            dgvLog.Columns.Add("Message", "Message");
            dgvLog.Columns[4].Width = 300;
            dgvLog.Columns.Add("Trame", "Trame");
            dgvLog.Columns[5].Width = dgvLog.Width - 18 - dgvLog.Columns[0].Width - dgvLog.Columns[1].Width - dgvLog.Columns[2].Width - dgvLog.Columns[3].Width - dgvLog.Columns[4].Width;

            _boardColor = new Dictionary<CanBoard, Color>();
            _boardColor.Add(CanBoard.PC, Color.FromArgb(180, 245, 245));
            _boardColor.Add(CanBoard.CanServo1, Color.FromArgb(130, 255, 220));
            _boardColor.Add(CanBoard.CanServo2, Color.FromArgb(160, 255, 220));
            _boardColor.Add(CanBoard.CanServo3, Color.FromArgb(190, 255, 220));
            _boardColor.Add(CanBoard.CanServo4, Color.FromArgb(220, 255, 220));
            _boardColor.Add(CanBoard.CanServo5, Color.FromArgb(250, 255, 220));
            _boardColor.Add(CanBoard.CanServo6, Color.FromArgb(100, 255, 220));

            _boxLists = new List<CheckedListBox>();
            _boxLists.Add(lstSender);
            _boxLists.Add(lstReceiver);
            _boxLists.Add(lstFunctions);

            if (Config.CurrentConfig.LogsCanFunctions == null)
                Config.CurrentConfig.LogsCanFunctions = new SerializableDictionary<CanFrameFunction, bool>();
            if (Config.CurrentConfig.LogsCanSenders == null)
                Config.CurrentConfig.LogsCanSenders = new SerializableDictionary<CanBoard, bool>();
            if (Config.CurrentConfig.LogsCanReceivers== null)
                Config.CurrentConfig.LogsCanReceivers = new SerializableDictionary<CanBoard, bool>();

            // L'ajout de champs déclenche le SetCheck event qui ajoute les éléments automatiquement dans le dictionnaire
            foreach (CanFrameFunction func in Enum.GetValues(typeof(CanFrameFunction)))
            {
                if (!Config.CurrentConfig.LogsCanFunctions.ContainsKey(func))
                    Config.CurrentConfig.LogsCanFunctions.Add(func, true);

                lstFunctions.Items.Add(func.ToString(), Config.CurrentConfig.LogsCanFunctions[func]);
            }

            foreach (CanBoard board in Enum.GetValues(typeof(CanBoard)))
            {
                if (!Config.CurrentConfig.LogsCanSenders.ContainsKey(board))
                    Config.CurrentConfig.LogsCanSenders.Add(board, true);
                lstSender.Items.Add(board.ToString(), Config.CurrentConfig.LogsCanSenders[board]);

                if (!Config.CurrentConfig.LogsCanReceivers.ContainsKey(board))
                    Config.CurrentConfig.LogsCanReceivers.Add(board, true);
                lstReceiver.Items.Add(board.ToString(), Config.CurrentConfig.LogsCanReceivers[board]);
            }

            _loading = false;
            _log = new FramesLog();
        }

        #region Publiques

        public void Clear()
        {
            _log = new FramesLog();
        }

        public void DisplayFrame(TimedFrame tFrame)
        {
            String time = "";

            try
            {
                if (rdoTimeAbsolute.Checked)
                    time = tFrame.Date.ToString("hh:mm:ss:fff");
                if (rdoTimeFromStart.Checked)
                    time = (tFrame.Date - _startTime).ToString(@"hh\:mm\:ss\:fff");
                if (rdoTimeFromPrev.Checked)
                    time = ((int)(tFrame.Date - _previousTime).TotalMilliseconds).ToString() + " ms";
                if (rdoTimeFromPrevDisplay.Checked)
                    time = ((int)(tFrame.Date - _previousDisplayTime).TotalMilliseconds).ToString() + " ms";

                CanBoard board = CanFrameFactory.ExtractBoard(tFrame.Frame);
                CanBoard sender = CanFrameFactory.ExtractSender(tFrame.Frame, tFrame.IsInputFrame);
                CanBoard receiver = CanFrameFactory.ExtractReceiver(tFrame.Frame, tFrame.IsInputFrame);

                if (board == CanBoard.PC) throw new Exception();

                bool receiverVisible = Config.CurrentConfig.LogsCanReceivers[receiver];
                bool senderVisible = Config.CurrentConfig.LogsCanSenders[sender];
                bool functionVisible = Config.CurrentConfig.LogsCanFunctions[CanFrameFactory.ExtractFunction(tFrame.Frame)];

                if (senderVisible && receiverVisible && functionVisible)
                {
                    dgvLog.Rows.Add(_counter, time, sender.ToString(), receiver.ToString(), CanFrameDecoder.Decode(tFrame.Frame), tFrame.Frame.ToString());
                    _previousDisplayTime = tFrame.Date;

                    if (rdoColorByBoard.Checked)
                        dgvLog.Rows[dgvLog.Rows.Count - 1].DefaultCellStyle.BackColor = _boardColor[board];
                    else if (rdoColorByReceiver.Checked)
                        dgvLog.Rows[dgvLog.Rows.Count - 1].DefaultCellStyle.BackColor = _boardColor[receiver];
                    else if (rdoColorBySender.Checked)
                        dgvLog.Rows[dgvLog.Rows.Count - 1].DefaultCellStyle.BackColor = _boardColor[sender];
                }
            }
            catch (Exception)
            {
                dgvLog.Rows.Add(_counter, time, "?", "?", "Inconnu !", tFrame.Frame.ToString());
                dgvLog.Rows[dgvLog.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
            }

            _counter++;
            _previousTime = tFrame.Date;
        }

        public void DisplayLog()
        {
            try
            {
                dgvLog.Rows.Clear();

                if (_log.Frames.Count > 0)
                {

                    _startTime = _log.Frames[0].Date;
                    _previousTime = _log.Frames[0].Date;
                    _previousDisplayTime = _log.Frames[0].Date;
                    _counter = 0;

                    for (int iFrame = 0; iFrame < _log.Frames.Count; iFrame++)
                        DisplayFrame(_log.Frames[iFrame]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de décoder toutes les trames contenues dans ce fichier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadLog()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fichiers replay trames (*" + FramesLog.FileExtension + ")| *" + FramesLog.FileExtension + "";
            open.Multiselect = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                foreach (String fichier in open.FileNames)
                {
                    LoadLog(fichier);
                }
                _log.Sort();
                DisplayLog();
            }
        }

        public void LoadLog(String file)
        {
            FramesLog log = new FramesLog();
            log.Import(file);

            foreach (TimedFrame t in log.Frames)
                _log.Frames.Add(t);
        }

        #endregion

        #region Privées

        private void EnableAllCheckBoxes(bool enable)
        {
            for (int iList = 0; iList < _boxLists.Count; iList++)
                for (int iItem = 0; iItem < _boxLists[iList].Items.Count; iItem++)
                    _boxLists[iList].SetItemChecked(iItem, enable);
        }

        private TimedFrame GetFrameFromLine(DataGridViewRow line)
        {
            return _log.Frames[Convert.ToInt32(dgvLog["ID", line.Index].Value)];
        }

        private void ShowFramesReceiver(CanBoard board, bool show)
        {
            lstReceiver.Items.Remove(board.ToString());
            lstReceiver.Items.Add(board.ToString(), show);
            Config.CurrentConfig.LogsCanReceivers[board] = show;
        }

        private void ShowFramesSender(CanBoard board, bool show)
        {
            lstSender.Items.Remove(board.ToString());
            lstSender.Items.Add(board.ToString(), show);
            Config.CurrentConfig.LogsCanSenders[board] = show;
        }

        private void ShowFrameFunction(CanFrameFunction func, bool show)
        {
            lstFunctions.Items.Remove(func.ToString());
            lstFunctions.Items.Add(func.ToString(), show);
            Config.CurrentConfig.LogsCanFunctions[func] = show;
        }

        private FramesLog CreateLogFromSelection()
        {
            FramesLog logSelection = new FramesLog();

            foreach (DataGridViewRow line in dgvLog.SelectedRows)
            {
                TimedFrame trameReplay = GetFrameFromLine(line);
                logSelection.AddFrame(trameReplay.Frame, trameReplay.IsInputFrame, trameReplay.Date);
            }

            return logSelection;
        }

        private void ReplayLog(FramesLog log)
        {
            _thReplay = new Thread(_log.ReplayInputFrames);
            _thReplay.Start();
        }

        #endregion

        #region Events

        private void btnReplayAll_Click(object sender, EventArgs e)
        {
            ReplayLog(_log);
        }

        private void btnReplaySelected_Click(object sender, EventArgs e)
        {
            ReplayLog(CreateLogFromSelection());
        }

        private void lstSender_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode && !_loading)
            {
                String boardStr = (String)lstSender.Items[e.Index];
                CanBoard board = (CanBoard)Enum.Parse(typeof(CanBoard), boardStr);

                Config.CurrentConfig.LogsCanReceivers[board] = (e.NewValue == CheckState.Checked);
            }
        }

        private void lstReceiver_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode && !_loading)
            {
                String boardStr = (String)lstReceiver.Items[e.Index];
                CanBoard board = (CanBoard)Enum.Parse(typeof(CanBoard), boardStr);

                Config.CurrentConfig.LogsCanReceivers[board] = (e.NewValue == CheckState.Checked);
            }
        }

        private void lstFunctions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode && !_loading)
            {
                String funcStr = (String)lstFunctions.Items[e.Index];
                CanFrameFunction func = (CanFrameFunction)Enum.Parse(typeof(CanFrameFunction), funcStr);

                Config.CurrentConfig.LogsCanFunctions[func] = (e.NewValue == CheckState.Checked);
            }
        }

        private void mnuHideSameSenderFrames_Click(object sender, EventArgs e)
        {
            if (dgvLog.SelectedRows.Count >= 1)
            {
                foreach (DataGridViewRow line in dgvLog.SelectedRows)
                {
                    TimedFrame tFrame = GetFrameFromLine(line);
                    ShowFramesSender(CanFrameFactory.ExtractSender(tFrame.Frame, tFrame.IsInputFrame), false);
                }

                DisplayLog();
            }
        }

        private void mnuHideSameReceiverFrames_Click(object sender, EventArgs e)
        {
            if (dgvLog.SelectedRows.Count >= 1)
            {
                foreach (DataGridViewRow line in dgvLog.SelectedRows)
                {
                    TimedFrame tFrame = GetFrameFromLine(line);
                    ShowFramesReceiver(CanFrameFactory.ExtractReceiver(tFrame.Frame, tFrame.IsInputFrame), false);
                }

                DisplayLog();
            }
        }

        private void mnuHideSameBoardFrames_Click(object sender, EventArgs e)
        {
            if (dgvLog.SelectedRows.Count >= 1)
            {
                foreach (DataGridViewRow line in dgvLog.SelectedRows)
                {
                    CanBoard board = CanFrameFactory.ExtractBoard(GetFrameFromLine(line).Frame);
                    ShowFramesReceiver(board, false);
                    ShowFramesSender(board, false);
                }

                DisplayLog();
            }
        }

        private void mnuHideAllFrames_Click(object sender, EventArgs e)
        {
            if (dgvLog.SelectedRows.Count >= 1)
            {
                foreach (DataGridViewRow line in dgvLog.Rows)
                {
                    TimedFrame tFrame = GetFrameFromLine(line);
                    ShowFrameFunction(CanFrameFactory.ExtractFunction(tFrame.Frame), false);
                }

                DisplayLog();
            }
        }

        private void mnuFrameCopy_Click(object sender, EventArgs e)
        {
            if (dgvLog.Rows.Count > 0)
                Clipboard.SetText(GetFrameFromLine(dgvLog.SelectedRows[0]).Frame.ToString());
        }

        private void btnAllCheck_Click(object sender, EventArgs e)
        {
            EnableAllCheckBoxes(true);
        }

        private void btnAllUncheck_Click(object sender, EventArgs e)
        {
            EnableAllCheckBoxes(false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayLog();
        }

        private void dgvLog_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex > 0 && e.ColumnIndex > 0)
                dgvLog.CurrentCell = dgvLog.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void mnuHideSameTypeFrames_Click(object sender, EventArgs e)
        {
            if (dgvLog.SelectedRows.Count >= 1)
            {
                foreach (DataGridViewRow line in dgvLog.SelectedRows)
                {
                    TimedFrame tFrame = GetFrameFromLine(line);
                    ShowFrameFunction(CanFrameFactory.ExtractFunction(tFrame.Frame), false);
                }

                DisplayLog();
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (_displayTimer == null || !_displayTimer.Enabled)
            {
                _log = new FramesLog();
                _displayTimer = new System.Windows.Forms.Timer();
                _displayTimer.Interval = 1000;
                _displayTimer.Tick += displayTimer_Tick;
                _displayTimer.Start();

                Connections.ConnectionCan.FrameReceived += new CanConnection.NewFrameDelegate((frame) => _log.AddFrame(frame, true));
                Connections.ConnectionCan.FrameSend += new CanConnection.NewFrameDelegate((frame) => _log.AddFrame(frame, false));

                btnReplayAll.Enabled = false;
                btnReplaySelected.Enabled = false;
                btnLoad.Enabled = false;
                btnDisplay.Text = "Arrêter la surveillance";
                btnDisplay.Image = Properties.Resources.GlassPause48;
            }
            else
            {
                _displayTimer.Stop();


                Connections.ConnectionCan.FrameReceived -= new CanConnection.NewFrameDelegate((frame) => _log.AddFrame(frame, true));
                Connections.ConnectionCan.FrameSend -= new CanConnection.NewFrameDelegate((frame) => _log.AddFrame(frame, false));

                btnReplayAll.Enabled = true;
                btnReplaySelected.Enabled = true;
                btnLoad.Enabled = true;
                btnDisplay.Text = "Lancer la surveillance";
                btnDisplay.Image = Properties.Resources.GlassStart48;
            }
        }

        void displayTimer_Tick(object sender, EventArgs e)
        {
            int nbTrames = _log.Frames.Count;
            for (int i = _counter; i < nbTrames; i++)
                DisplayFrame(_log.Frames[i]);

            if (boxScroll.Checked && dgvLog.Rows.Count > 10)
                dgvLog.FirstDisplayedScrollingRowIndex = dgvLog.RowCount - 1;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadLog();
        }

        #endregion

    }
}
