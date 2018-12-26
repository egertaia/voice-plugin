namespace VoicePlugin.Shared
{
	public class Configuration : IConfiguration
	{
		public string WhisperText { get; set; }
		public float WhisperDistance { get; set; }
		public string NormalText { get; set; }
		public float NormalDistance { get; set; }
		public string YellText { get; set; }
		public float YellDistance { get; set; }
		public string DefaultTextColor { get; set; }
		public string ActivatedTextColor { get; set; }
	}
}
