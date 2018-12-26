namespace VoicePlugin.Shared
{
	public class Configuration : IConfiguration
	{
		public string WhisperText { get; set; }
		public double WhisperDistance { get; set; }
		public string NormalText { get; set; }
		public double NormalDistance { get; set; }
		public string YellText { get; set; }
		public double YellDistance { get; set; }
		public string DefaultTextColor { get; set; }
		public string ActivatedTextColor { get; set; }
	}
}
