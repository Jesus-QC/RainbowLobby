using System;
using System.Collections.Generic;
using System.Drawing;
using Exiled.API.Features;
using MEC;

namespace RainbowLobby.Features
{
    public class RainbowHandler
    {
        public RainbowHandler(Config config)
        {
            _config = config;
        }
        
        private readonly Config _config;
        private static CoroutineHandle _rainbowCoroutine;

        public void OnWaitingForPlayers()
        {
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
            
            var speed = 3;
            
            if(_config.ColorSpeed >= 0 && _config.ColorSpeed < 9)
                 speed = Config.Speeds[_config.ColorSpeed];
            
            for (;;)
            {
                var hexColor = $"#{r:X2}{g:X2}{b:X2}";

                if (r > 0 && b == 0)
                {
                    r -= speed;
                    g += speed;
                }

                if (g > 0 && r == 0)
                {
                    g -= speed;
                    b += speed;
                }

                if (b > 0 && g == 0)
                {
                    b -= speed;
                    r += speed;
                }
                    
                
                Map.ShowHint(_config.WaitingText.Replace("%rainbow%", hexColor), 0.8f);
                
                yield return Timing.WaitForSeconds(0.5f);
            }
        }
    }
}