using System;
using Exiled.API.Features;
using RainbowLobby.Features;

namespace RainbowLobby
{
    public class MainClass : Plugin<Config>
    {
        public override string Author { get; } = "Jesus-QC";
        public override string Name { get; } = "RainbowLobby";
        public override string Prefix { get; } = "RainbowLobby";
        public override Version Version { get; } = new Version(1, 0, 1, 2);
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);
        
        private RainbowHandler _handler;
        
        public override void OnEnabled()
        {
            _handler = new RainbowHandler(Config);
            
            Exiled.Events.Handlers.Server.WaitingForPlayers += _handler.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted += _handler.OnRoundStarted;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= _handler.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted -= _handler.OnRoundStarted;
            
            _handler = null;

            base.OnDisabled();
        }
    }
}
