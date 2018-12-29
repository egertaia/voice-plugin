using NFive.SDK.Client.Interface;

namespace VoiceProximity.Client.Overlays
{
	public class VoiceOverlay : Overlay
	{
		public VoiceOverlay(OverlayManager manager) : base("VoiceOverlay.html", manager) { }

		public void Level(string value) => Send("level", value);

		public void Talking(bool value) => Send("talking", value);
	}
}
