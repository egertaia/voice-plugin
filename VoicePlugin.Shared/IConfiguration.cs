using JetBrains.Annotations;

namespace VoicePlugin.Shared
{
	[PublicAPI]
	public interface IConfiguration
	{
		string WhisperText { get; set; }
		double WhisperDistance { get; set; }
		string NormalText { get; set; }
		double NormalDistance { get; set; }
		string YellText { get; set; }
		double YellDistance { get; set; }
		string DefaultTextColor { get; set; }
		string ActivatedTextColor { get; set; }
	}
}
