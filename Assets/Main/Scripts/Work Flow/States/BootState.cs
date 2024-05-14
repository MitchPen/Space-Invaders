using UnityEngine;

namespace Main.Scripts.Work_Flow.States
{
    public class BootState : State
    {
        private readonly (int width, int heigh) _resolution = new (600,800) ;
        public BootState(StateData data) : base(data) { }

        public override void Entire()
        {
            base.Entire();
            var screenMode = FullScreenMode.Windowed;
            Screen.fullScreenMode = screenMode;
            Screen.SetResolution(_resolution.width, _resolution.heigh, screenMode, 
                Screen.currentResolution.refreshRateRatio);
            QualitySettings.vSyncCount = 1;
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
