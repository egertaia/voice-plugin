using JetBrains.Annotations;
using NFive.SDK.Core.Controllers;
using System.Collections.Generic;

namespace VoiceProximity.Shared
{
	/// <inheritdoc />
	[PublicAPI]
	public class Configuration : ControllerConfiguration
	{
		public List<LevelConfiguration> Levels { get; set; } = new List<LevelConfiguration> {
			new LevelConfiguration
			{
				Name = "Whisper",
				Distance = 1.5f
			},
			new LevelConfiguration
			{
				Name = "Normal",
				Distance = 10f
			},
			new LevelConfiguration
			{
				Name = "Yell",
				Distance = 25f
			}
		};

		public HotkeyConfiguration Hotkey { get; set; } = new HotkeyConfiguration();

		public string ActivationEvent { get; set; } = string.Empty;
	}

	[PublicAPI]
	public class LevelConfiguration
	{
		public string Name { get; set; }

		public float Distance { get; set; }
	}

	[PublicAPI]
	public class HotkeyConfiguration
	{
		public int Key { get; set; } = 74;

		public int Modifier { get; set; } = 4;
	}
}
