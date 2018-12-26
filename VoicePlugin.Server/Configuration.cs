using NFive.SDK.Core.Controllers;

namespace VoicePlugin.Server
{
	public class Configuration : ControllerConfiguration
	{
		public string WhisperText { get; set; } = "Whisper";
		public double WhisperDistance { get; set; } = 1.5;
		public string NormalText { get; set; } = "Normal";
		public double NormalDistance { get; set; } = 10.0;
		public string YellText { get; set; } = "Yell";
		public double YellDistance { get; set; } = 25.0;
		public string DefaultTextColor { get; set; } = "#fff";
		public string ActivatedTextColor { get; set; } = "#76AEC7";
	}
}
