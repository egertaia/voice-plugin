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
		private VoiceOverlay overlay;

		public string WhisperText;
		public float WhisperDistance;
		public string NormalText;
		public float NormalDistance;
		public string YellText;
		public float YellDistance;

		public string DefaultColor;
		public string ActivatedColor;

		private string SelectedVoice;
		private string LastString;

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
			this.LastString = GetProperHtmlString(false);
			this.overlay.Talk(CorrectFormat("#fff"));

			this.overlay.Show();
			this.Ticks.Attach(OnTick);
		}

		private async Task OnTick()
		{
			if (Input.IsControlJustPressed(Control.VehicleHeadlight, true, InputModifier.Shift)) CycleVoiceLevel();

			var talkString = GetProperHtmlString(API.NetworkIsPlayerTalking(API.PlayerId()));
			if (LastString != talkString) {
				this.LastString = talkString;
				this.overlay.Talk(talkString);
			}

		}

		private string GetProperHtmlString(bool isTalking)
		{
			if (isTalking) return CorrectFormat(this.ActivatedColor);
			return CorrectFormat(this.DefaultColor);
		}

		private string CorrectFormat(string color)
		{
			return "<span id=\"level\" style=\"color:" + color + "\"> " + this.SelectedVoice + "</span>";
		}

		private void CycleVoiceLevel()
		{
			if(this.SelectedVoice == this.NormalText)
			{
				this.SelectedVoice = this.YellText;
				API.NetworkSetTalkerProximity(this.YellDistance);
			}

			else if(this.SelectedVoice == this.YellText)
			{
				this.SelectedVoice = this.WhisperText;
				API.NetworkSetTalkerProximity(this.WhisperDistance);
			}

			else if(this.SelectedVoice == this.WhisperText)
			{
				this.SelectedVoice = this.NormalText;
				API.NetworkSetTalkerProximity(this.NormalDistance);
			}
		}
	}
}
