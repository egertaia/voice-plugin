using System.Threading.Tasks;
using CitizenFX.Core.Native;
using JetBrains.Annotations;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Client.Input;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using VoicePlugin.Client.Overlays;
using VoicePlugin.Shared;
using CitizenFX.Core;

namespace VoicePlugin.Client
{
	[PublicAPI]
	public class VoicePluginService : Service
	{
		private Configuration config;
		private VoiceOverlay overlay;
		private string SelectedVoice;
		private string LastString;

		public VoicePluginService(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, OverlayManager overlay, User user) : base(logger, ticks, events, rpc, overlay, user) { }

		public override async Task Started()
		{
			// Request server config
			this.config = await this.Rpc.Event(VoicePluginEvents.GetConfig).Request<Configuration>();

			// Update local config on server config change
			this.Rpc.Event(VoicePluginEvents.GetConfig).On<Configuration>((e, c) => this.config = c);

			//set default talker proximity and text
			this.SelectedVoice = this.config.Normal.Text;
			this.LastString = GetProperHtmlString(false);
			API.NetworkSetTalkerProximity(this.config.Normal.Distance);

			// Create overlay
			this.overlay = new VoiceOverlay(this.OverlayManager);

			if (!string.IsNullOrWhiteSpace(this.config.ActivationEvent))
			{
				// Attach tick handler once activation event has fired
				this.Rpc.Event(this.config.ActivationEvent.Trim()).On(e => this.Ticks.Attach(OnTick));
			}
			else
			{
				// Attach tick handler immediately
				this.Ticks.Attach(OnTick);
			}

			this.overlay.Show();
			this.overlay.Talk(CorrectFormat(this.config.Text.DefaultColor));

		}

		private async Task OnTick()
		{
			if (Game.Player == null) return;
			
			if (Input.IsControlJustPressed(Control.VehicleHeadlight, true, InputModifier.Shift)) CycleVoiceLevel();

			var talkString = GetProperHtmlString(API.NetworkIsPlayerTalking(API.PlayerId()));
			if (!string.Equals(talkString, LastString)) {
				this.LastString = talkString;
				this.overlay.Talk(talkString);
			}

		}

		private string GetProperHtmlString(bool isTalking)
		{
			if (isTalking) return CorrectFormat(this.config.Text.ActivatedColor);
			return CorrectFormat(this.config.Text.DefaultColor);
		}

		private string CorrectFormat(string color)
		{
			return "<span id=\"level\" style=\"color:" + color + "\"> " + this.SelectedVoice + "</span>";
		}

		private void CycleVoiceLevel()
		{
			if(this.SelectedVoice == this.config.Normal.Text)
			{
				this.SelectedVoice = this.config.Yell.Text;
				API.NetworkSetTalkerProximity(this.config.Yell.Distance);
			}

			else if(this.SelectedVoice == this.config.Yell.Text)
			{
				this.SelectedVoice = this.config.Whisper.Text;
				API.NetworkSetTalkerProximity(this.config.Whisper.Distance);
			}

			else if(this.SelectedVoice == this.config.Whisper.Text)
			{
				this.SelectedVoice = this.config.Normal.Text;
				API.NetworkSetTalkerProximity(this.config.Normal.Distance);
			}
		}
	}
}
