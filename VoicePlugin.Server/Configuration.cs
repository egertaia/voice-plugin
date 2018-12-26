using NFive.SDK.Core.Controllers;

namespace VoicePlugin.Server
{
	public class Configuration : ControllerConfiguration
	{
		public string WhisperText { get; set; } = "Whisper";
		public float WhisperDistance { get; set; } = 1.5f;
		public string NormalText { get; set; } = "Normal";
		public float NormalDistance { get; set; } = 10.0f;
		public string YellText { get; set; } = "Yell";
		public float YellDistance { get; set; } = 25.0f;
		public string DefaultTextColor { get; set; } = "#fff";
		public string ActivatedTextColor { get; set; } = "#76AEC7";
	}
}
