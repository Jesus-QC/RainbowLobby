using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace RainbowLobby
{
    public class Config : IConfig 
    {
        public static readonly List<int> Speeds = new List<int>() // Numbers that 255 are divisible by
        {
            0, 1, 3, 5, 15, 17, 51, 85, 255
        };

        [Description("Whether or not this plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;
        [Description("The hint text (use <color=%rainbow%> for a raimbow color (remember to close it with </color>))")]
        public string WaitingText { get; set; } = "\n\n\n\n<b>discord.gg/yourdiscord</b>\n<color=%rainbow%><b>My Pretty\nRainbow Server Name</b></color>";
        [Description("Color speed [0-8] (Default 2)")]
        public int ColorSpeed { get; set; } = 2;
    }
}