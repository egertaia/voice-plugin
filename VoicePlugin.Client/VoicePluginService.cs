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
			this.SelectedVoice = this.config.Voice.VoiceStyles[0].Text;
			this.LastString = GetProperHtmlString(false);
			API.NetworkSetTalkerProximity(this.config.Voice.VoiceStyles[0].Distance);

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
			this.overlay.UpdateVoiceOverlay(CorrectFormat(this.config.Text.DefaultColor));

		}

		private async Task OnTick()
		{
			if (Game.Player == null) return;
			
			if (Input.IsControlJustPressed((Control)this.config.Cycle.Key, true, (InputModifier)this.config.Cycle.InputModifier)) CycleVoiceLevel();

			var talkString = GetProperHtmlString(API.NetworkIsPlayerTalking(API.PlayerId()));
			if (!string.Equals(talkString, LastString)) {
				this.LastString = talkString;
				this.overlay.UpdateVoiceOverlay(talkString);
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
			//TODO: Fix this
			for (var i = 0; i < this.config.Voice.VoiceStyles.Count; i++)
			{
				var voiceStyle = this.config.Voice.VoiceStyles[i];
				if (string.Equals(this.SelectedVoice, voiceStyle.Text))
				{
					//If it is last in the list return to first
					if(this.config.Voice.VoiceStyles.Count - 1 == i)
					{
						this.SelectedVoice = this.config.Voice.VoiceStyles[0].Text;
						API.NetworkSetTalkerProximity(this.config.Voice.VoiceStyles[0].Distance);
					}
					//Get the next.
					else
					{
						this.SelectedVoice = this.config.Voice.VoiceStyles[i+1].Text;
						API.NetworkSetTalkerProximity(this.config.Voice.VoiceStyles[i+1].Distance);
					}
					break;
				}
			}
		}
	}
}
