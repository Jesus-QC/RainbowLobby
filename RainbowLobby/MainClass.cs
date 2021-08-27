using System;
using System.Collections.Generic;
using Exiled.API.Features;
using MEC;
using RainbowLobby.Features;

namespace RainbowLobby
{
    public class MainClass : Plugin<Config>
    {
        public override string Author { get; } = "Jesus-QC";
        public override string Name { get; } = "RainbowLobby";
        public override string Prefix { get; } = "RainbowLobby";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        public static Config Cfg { get; private set; }
        private RainbowHandler _handler;
        
        public override void OnEnabled()
        {
            Cfg = Config;

            _handler = new RainbowHandler();
            
            Exiled.Events.Handlers.Server.WaitingForPlayers += _handler.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted += _handler.OnRoundStarted;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= _handler.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted -= _handler.OnRoundStarted;
            
            _handler = null;

            Cfg = null;
            
            base.OnDisabled();
        }

        
    }
}