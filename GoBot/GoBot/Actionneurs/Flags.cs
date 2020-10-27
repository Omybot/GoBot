namespace GoBot.Actionneurs
{
    class Flags
    {
        bool _leftOpened, _rightOpened;

        public bool LeftOpened => _leftOpened;
        public bool RightOpened => _rightOpened;

        public Flags()
        {
            _leftOpened = false;
            _rightOpened = false;
        }

        public void DoCloseRight()
        {
            Config.CurrentConfig.ServoFlagRight.SendPosition(Config.CurrentConfig.ServoFlagRight.PositionClose);
            _rightOpened = false;
        }

        public void DoOpenRight()
        {
            Config.CurrentConfig.ServoFlagRight.SendPosition(Config.CurrentConfig.ServoFlagRight.PositionOpen);
            _rightOpened = true;
        }

        public void DoCloseLeft()
        {
            Config.CurrentConfig.ServoFlagLeft.SendPosition(Config.CurrentConfig.ServoFlagLeft.PositionClose);
            _leftOpened = false;
        }

        public void DoOpenLeft()
        {
            Config.CurrentConfig.ServoFlagLeft.SendPosition(Config.CurrentConfig.ServoFlagLeft.PositionOpen);
            _leftOpened = true;
        }
    }
}
