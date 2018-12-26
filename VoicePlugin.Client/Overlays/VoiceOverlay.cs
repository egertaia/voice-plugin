using NFive.SDK.Client.Interface;


namespace VoicePlugin.Client.Overlays
{
	public class VoiceOverlay : Overlay
	{
		public VoiceOverlay(OverlayManager manager) : base("VoiceOverlay.html", manager) { }

		public void Talk(string voiceLevelString)
		{
			Send("talk", voiceLevelString);
		}
	}
}
