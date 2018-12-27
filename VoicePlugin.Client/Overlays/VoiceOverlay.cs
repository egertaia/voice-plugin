using NFive.SDK.Client.Interface;


namespace VoicePlugin.Client.Overlays
{
	public class VoiceOverlay : Overlay
	{
		public VoiceOverlay(OverlayManager manager) : base("VoiceOverlay.html", manager) { }

		public void UpdateVoiceOverlay(string voiceLevelString)
		{
			Send("update-voice", voiceLevelString);
		}
	}
}
