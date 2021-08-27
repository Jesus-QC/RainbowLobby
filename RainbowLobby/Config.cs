using System.ComponentModel;
using Exiled.API.Interfaces;

namespace RainbowLobby
{
    public class Config : IConfig
    {
        [Description("Whether or not this plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;
        [Description("The hint text (use <color=%rainbow%> for a raimbow color (remember to close it with </color>))")]
        public string WaitingText { get; set; } = "\n\n\n\n<b>discord.gg/yourdiscord</b>\n<color=%rainbow%><b>My Pretty\nRainbow Server Name</b></color>";
    }
}