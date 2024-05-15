using UnityEngine;

namespace Main.Scripts.Work_Flow.States
{
    public class BootState : State
    {
        private readonly (int width, int height) _screenResolution = new (600,800) ;
        public BootState(StateData data) : base(data) { }

        public override void Entire()
        {
            base.Entire();
            SetupScreen();
        }

        private void SetupScreen()
        {
            var screenMode = FullScreenMode.Windowed;
            var windowPosition = Vector2Int.zero;
            windowPosition.x = (int)(Screen.currentResolution.width / 2 - _screenResolution.width / 2);
            windowPosition.y = (int)(Screen.currentResolution.height / 2 - _screenResolution.height / 2);
            Screen.fullScreenMode = screenMode;
            Screen.SetResolution(_screenResolution.width, _screenResolution.height, screenMode, 
                Screen.currentResolution.refreshRateRatio);
            Screen.MoveMainWindowTo(Screen.mainWindowDisplayInfo,windowPosition);
            QualitySettings.vSyncCount = 1;
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
