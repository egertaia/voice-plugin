using NFive.SDK.Core.Controllers;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace VoicePlugin.Shared
{
	[PublicAPI]
	public class Configuration : ControllerConfiguration
	{
		public VoiceConfiguration Voice { get; set; } = new VoiceConfiguration();
		public TextConfiguration Text { get; set; } = new TextConfiguration();
		public KeyConfiguration Cycle { get; set; } = new KeyConfiguration();
		public string ActivationEvent { get; set; } = string.Empty;

	}

	[PublicAPI]
	public class KeyConfiguration
	{
		public int Key { get; set; } = 74;
		public int InputModifier { get; set; } = 4;
	}

	[PublicAPI]
	public class TextConfiguration
	{
		public string DefaultColor { get; set; } = "#fff";
		public string ActivatedColor { get; set; } = "#76AEC7";
	}

	[PublicAPI]
	public class VoiceConfiguration
	{
		public List<VoiceStyleConfiguration> VoiceStyles { get; set; } =
			new List<VoiceStyleConfiguration>
			{
				new VoiceStyleConfiguration("Normal", 10f),
				new VoiceStyleConfiguration("Yell", 25f),
				new VoiceStyleConfiguration("Whisper", 1.5f)
			};
	}

	[PublicAPI]
	public class VoiceStyleConfiguration
	{
		public VoiceStyleConfiguration(){ }
		public VoiceStyleConfiguration(string text, float distance)
		{
			this.Text = text;
			this.Distance = distance;
		}

		public string Text { get; set; } = "Text";
		public float Distance { get; set; } = 25f;
	}
}
