using NFive.SDK.Core.Controllers;
using JetBrains.Annotations;

namespace VoicePlugin.Shared
{
	[PublicAPI]
	public class Configuration : ControllerConfiguration
	{
		public WhisperConfiguration Whisper { get; set; } = new WhisperConfiguration();
		public NormalConfiguration Normal { get; set; } = new NormalConfiguration();
		public YellConfiguration Yell { get; set; } = new YellConfiguration();
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
	public class WhisperConfiguration : IVoiceConfiguration
	{
		public string Text { get; set; } = "Whisper";
		public float Distance { get; set; } = 1.5f;
	}

	[PublicAPI]
	public class NormalConfiguration : IVoiceConfiguration
	{
		public string Text { get; set; } = "Normal";
		public float Distance { get; set; } = 10.0f;
	}

	[PublicAPI]
	public class YellConfiguration : IVoiceConfiguration
	{
		public string Text { get; set; } = "Yell";
		public float Distance { get; set; } = 25.0f;
	}

	public interface IVoiceConfiguration
	{
		string Text { get; set; }
		float Distance { get; set; }
	}
}
