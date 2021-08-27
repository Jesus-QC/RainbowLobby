using System;
using System.Collections.Generic;
using System.Drawing;
using Exiled.API.Features;
using MEC;

namespace RainbowLobby.Features
{
    public class RainbowHandler
    {
        private static CoroutineHandle _rainbowCoroutine;

        public void OnWaitingForPlayers()
        {
            Log.Info(_rainbowCoroutine.IsRunning);
            
            if (!_rainbowCoroutine.IsRunning)
                _rainbowCoroutine = Timing.RunCoroutine(RainbowCoroutine());
        }

        public void OnRoundStarted()
        {
            Timing.KillCoroutines(_rainbowCoroutine);
            Map.ShowHint("",1);
        }

        private IEnumerator<float> RainbowCoroutine()
        {
            int r = 255, g = 0, b = 0;
            for (;;)
            {
                var hexColor = $"#{r:X2}{g:X2}{b:X2}";

                if (r > 0 && b == 0)
                    r -= 3;g += 3;
                if (g > 0 && r == 0)
                    g -= 3; b += 3;
                if (b > 0 && g == 0)
                    b -= 3; r += 3;
                
                Map.ShowHint(MainClass.Cfg.WaitingText.Replace("%rainbow%", hexColor), 0.8f);
                
                yield return Timing.WaitForSeconds(0.5f);
            }
        }
    }
}