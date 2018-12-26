using System.Threading.Tasks;
using JetBrains.Annotations;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using VoicePlugin.Client.Overlays;
using VoicePlugin.Shared;

namespace VoicePlugin.Client
{
	[PublicAPI]
	public class VoicePluginService : Service
	{
		private VoiceOverlay overlay;

		public string WhisperText;
		public double WhisperDistance;
		public string NormalText;
		public double NormalDistance;
		public string YellText;
		public double YellDistance;

		public string DefaultColor;
		public string ActivatedColor;

		private string SelectedVoice;

		public VoicePluginService(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, OverlayManager overlay, User user) : base(logger, ticks, events, rpc, overlay, user)
		{
			this.overlay = new VoiceOverlay(this.OverlayManager);
		}

		public override async Task Started()
		{
			var config = await this.Rpc.Event(VoicePluginEvents.GetConfig).Request<Configuration>();
			this.WhisperText = config.WhisperText;
			this.WhisperDistance = config.WhisperDistance;
			this.NormalText = config.NormalText;
			this.NormalDistance = config.NormalDistance;
			this.YellText = config.YellText;
			this.YellDistance = config.YellDistance;

			this.DefaultColor = config.DefaultTextColor;
			this.ActivatedColor = config.ActivatedTextColor;

			this.SelectedVoice = this.NormalText;
			this.overlay.Show();
			this.Ticks.Attach(OnTick);
		}

		private async Task OnTick()
		{
			//TODO
		}
	}
}
