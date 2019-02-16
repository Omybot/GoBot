using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GoBot.Communications;
using GoBot.Communications.UDP;

namespace GoBot.IHM
{
    public partial class PanelLogUdp : UserControl
    {
        private FramesLog _log;
        private Dictionary<Board, Color> _boardColor;

        private DateTime _startTime;
        private DateTime _previousTime, _previousDisplayTime;
        private System.Windows.Forms.Timer _displayTimer;
        private int _counter = 0;
        private Thread _thReplay;

        private List<CheckedListBox> _boxLists;
        private Dictionary<CheckedListBox, Dictionary<UdpFrameFunction, bool>> _configFunctions;
        private Dictionary<Board, CheckedListBox> _lstFunctions;

        bool _loading;

        public PanelLogUdp()
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

            _boardColor = new Dictionary<Board, Color>();
            _boardColor.Add(Board.PC, Color.FromArgb(180, 245, 245));
            _boardColor.Add(Board.RecMove, Color.FromArgb(143, 255, 143));
            _boardColor.Add(Board.RecIO, Color.FromArgb(210, 254, 211));
            _boardColor.Add(Board.RecGB, Color.FromArgb(251, 217, 231));
            _boardColor.Add(Board.RecCan, Color.FromArgb(254, 244, 188));

            _boxLists = new List<CheckedListBox>();
            _boxLists.Add(lstSender);
            _boxLists.Add(lstReceiver);
            _boxLists.Add(lstRecIOFunctions);
            _boxLists.Add(lstRecMoveFunctions);
            _boxLists.Add(lstRecGoBotFunctions);
            _boxLists.Add(lstRecCanFunctions);

            if (Config.CurrentConfig.LogsFonctionsMove == null)
                Config.CurrentConfig.LogsFonctionsMove = new SerializableDictionary<UdpFrameFunction, bool>();
            if (Config.CurrentConfig.LogsFonctionsIO == null)
                Config.CurrentConfig.LogsFonctionsIO = new SerializableDictionary<UdpFrameFunction, bool>();
            if (Config.CurrentConfig.LogsFonctionsGB == null)
                Config.CurrentConfig.LogsFonctionsGB = new SerializableDictionary<UdpFrameFunction, bool>();
            if (Config.CurrentConfig.LogsFonctionsCan == null)
                Config.CurrentConfig.LogsFonctionsCan = new SerializableDictionary<UdpFrameFunction, bool>();
            if (Config.CurrentConfig.LogsExpediteurs == null)
                Config.CurrentConfig.LogsExpediteurs = new SerializableDictionary<Board, bool>();
            if (Config.CurrentConfig.LogsDestinataires == null)
                Config.CurrentConfig.LogsDestinataires = new SerializableDictionary<Board, bool>();

            _configFunctions = new Dictionary<CheckedListBox, Dictionary<UdpFrameFunction, bool>>();
            _configFunctions.Add(lstRecIOFunctions, Config.CurrentConfig.LogsFonctionsIO);
            _configFunctions.Add(lstRecMoveFunctions, Config.CurrentConfig.LogsFonctionsMove);
            _configFunctions.Add(lstRecGoBotFunctions, Config.CurrentConfig.LogsFonctionsGB);
            _configFunctions.Add(lstRecCanFunctions, Config.CurrentConfig.LogsFonctionsCan);

            _lstFunctions = new Dictionary<Board, CheckedListBox>();
            _lstFunctions.Add(Board.RecIO, lstRecIOFunctions);
            _lstFunctions.Add(Board.RecMove, lstRecMoveFunctions);
            _lstFunctions.Add(Board.RecGB, lstRecGoBotFunctions);
            _lstFunctions.Add(Board.RecCan, lstRecCanFunctions);

            foreach (CheckedListBox lst in _configFunctions.Keys)
            {
                // L'ajout de champs déclenche le SetCheck event qui ajoute les éléments automatiquement dans le dictionnaire
                foreach (UdpFrameFunction func in Enum.GetValues(typeof(UdpFrameFunction)))
                {
                    if (!_configFunctions[lst].ContainsKey(func))
                        _configFunctions[lst].Add(func, true);

                    lst.Items.Add(func.ToString(), _configFunctions[lst][func]);
                }
            }

            foreach (Board board in Enum.GetValues(typeof(Board)))
            {
                if (!Config.CurrentConfig.LogsExpediteurs.ContainsKey(board))
                    Config.CurrentConfig.LogsExpediteurs.Add(board, true);
                lstSender.Items.Add(board.ToString(), Config.CurrentConfig.LogsExpediteurs[board]);

                if (!Config.CurrentConfig.LogsDestinataires.ContainsKey(board))
                    Config.CurrentConfig.LogsDestinataires.Add(board, true);
                lstReceiver.Items.Add(board.ToString(), Config.CurrentConfig.LogsDestinataires[board]);
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

                Board board = UdpFrameFactory.ExtractBoard(tFrame.Frame);
                Board sender = UdpFrameFactory.ExtractSender(tFrame.Frame, tFrame.IsInputFrame);
                Board receiver = UdpFrameFactory.ExtractReceiver(tFrame.Frame, tFrame.IsInputFrame);
                UdpFrameFunction func = UdpFrameFactory.ExtractFunction(tFrame.Frame);

                if (board == Board.PC) throw new Exception();

                bool receiverVisible = Config.CurrentConfig.LogsDestinataires[receiver];
                bool senderVisible = Config.CurrentConfig.LogsExpediteurs[sender];
                bool functionVisible = (_configFunctions[_lstFunctions[board]][func]);

                if (senderVisible && receiverVisible && functionVisible)
                {
                    dgvLog.Rows.Add(_counter, time, sender.ToString(), receiver.ToString(), UdpFrameDecoder.Decode(tFrame.Frame), tFrame.Frame.ToString());
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

        private void ShowFramesReceiver(Board board, bool show)
        {
            lstReceiver.Items.Remove(board.ToString());
            lstReceiver.Items.Add(board.ToString(), show);
            Config.CurrentConfig.LogsDestinataires[board] = show;
        }

        private void ShowFramesSender(Board board, bool show)
        {
            lstSender.Items.Remove(board.ToString());
            lstSender.Items.Add(board.ToString(), show);
            Config.CurrentConfig.LogsExpediteurs[board] = show;
        }

        private void ShowFrameFunction(Board board, UdpFrameFunction func, bool show)
        {
            _lstFunctions[board].Items.Remove(func.ToString());
            _lstFunctions[board].Items.Add(func.ToString(), show);
            _configFunctions[_lstFunctions[board]][func] = show;
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
                Board board = (Board)Enum.Parse(typeof(Board), boardStr);

                Config.CurrentConfig.LogsExpediteurs[board] = (e.NewValue == CheckState.Checked);
            }
        }

        private void lstReceiver_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode && !_loading)
            {
                String boardStr = (String)lstReceiver.Items[e.Index];
                Board board = (Board)Enum.Parse(typeof(Board), boardStr);

                Config.CurrentConfig.LogsDestinataires[board] = (e.NewValue == CheckState.Checked);
            }
        }

        private void lstFunctions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode && !_loading)
            {
                CheckedListBox lst = (CheckedListBox)sender;
                String funcStr = (String)lst.Items[e.Index];
                UdpFrameFunction func = (UdpFrameFunction)Enum.Parse(typeof(UdpFrameFunction), funcStr);

                _configFunctions[lst][func] = (e.NewValue == CheckState.Checked);
            }
        }

        private void mnuHideSameSenderFrames_Click(object sender, EventArgs e)
        {
            if (dgvLog.SelectedRows.Count >= 1)
            {
                foreach (DataGridViewRow line in dgvLog.SelectedRows)
                {
                    TimedFrame tFrame = GetFrameFromLine(line);
                    ShowFramesSender(UdpFrameFactory.ExtractSender(tFrame.Frame, tFrame.IsInputFrame), false);
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
                    ShowFramesReceiver(UdpFrameFactory.ExtractReceiver(tFrame.Frame, tFrame.IsInputFrame), false);
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
                    Board board = UdpFrameFactory.ExtractBoard(GetFrameFromLine(line).Frame);
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
                    ShowFrameFunction(UdpFrameFactory.ExtractBoard(tFrame.Frame), UdpFrameFactory.ExtractFunction(tFrame.Frame), false);
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
                    ShowFrameFunction(UdpFrameFactory.ExtractBoard(tFrame.Frame), UdpFrameFactory.ExtractFunction(tFrame.Frame), false);
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

                Connections.AllConnections.ForEach(conn =>
                {
                    if (conn.GetType() == typeof(UDPConnection))
                    {
                        conn.FrameReceived += new Connection.NewFrameDelegate((frame) => _log.AddFrame(frame, true));
                        conn.FrameSend += new Connection.NewFrameDelegate((frame) => _log.AddFrame(frame, false));
                    }
                });

                btnReplayAll.Enabled = false;
                btnReplaySelected.Enabled = false;
                btnLoad.Enabled = false;
                btnDisplay.Text = "Arrêter la surveillance";
                btnDisplay.Image = Properties.Resources.GlassPause48;
            }
            else
            {
                _displayTimer.Stop();

                Connections.AllConnections.ForEach(conn =>
                {
                    if (conn.GetType() == typeof(UDPConnection))
                    {
                        conn.FrameReceived -= new Connection.NewFrameDelegate((frame) => _log.AddFrame(frame, true));
                        conn.FrameSend -= new Connection.NewFrameDelegate((frame) => _log.AddFrame(frame, false));
                    }
                });

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
