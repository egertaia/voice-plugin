using JetBrains.Annotations;

namespace VoicePlugin.Shared
{
	[PublicAPI]
	public interface IConfiguration
	{
		string WhisperText { get; set; }
		float WhisperDistance { get; set; }
		string NormalText { get; set; }
		float NormalDistance { get; set; }
		string YellText { get; set; }
		float YellDistance { get; set; }
		string DefaultTextColor { get; set; }
		string ActivatedTextColor { get; set; }
	}
}
