using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Egertaia.VoiceProximity.Shared;
using JetBrains.Annotations;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Input;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using System.Threading.Tasks;
using Egertaia.VoiceProximity.Client.Overlays;

namespace Egertaia.VoiceProximity.Client
{
	/// <inheritdoc />
	[PublicAPI]
	public class VoiceProximityService : Service
	{
		private Configuration config;
		private VoiceOverlay overlay;
		private int level;
		private bool last;

		/// <inheritdoc />
		public VoiceProximityService(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, ICommandManager commands, OverlayManager overlay, User user) : base(logger, ticks, events, rpc, commands, overlay, user) { }

		/// <inheritdoc />
		public override async Task Started()
		{
			// Request server config
			this.config = await this.Rpc.Event(VoiceProximityEvents.GetConfig).Request<Configuration>();

			// Update local config on server config change
			this.Rpc.Event(VoiceProximityEvents.GetConfig).On<Configuration>((e, c) => this.config = c);

			// Set default talker proximity
			API.NetworkSetTalkerProximity(this.config.Levels[this.level].Distance);

			// Create overlay
			this.overlay = new VoiceOverlay(this.OverlayManager);
			this.overlay.Level(this.config.Levels[this.level].Name);

			if (!string.IsNullOrWhiteSpace(this.config.ActivationEvent))
			{
				//  Show overlay once activation event has fired
				this.Rpc.Event(this.config.ActivationEvent.Trim()).On(e => this.overlay.Show());
			}
			else
			{
				// Show overlay immediately
				this.overlay.Show();
			}

			this.Ticks.Attach(new Action(OnTick));
		}

		private void OnTick()
		{
			if (Input.IsControlJustPressed((Control)this.config.Hotkey.Key, true, (InputModifier)this.config.Hotkey.Modifier))
			{
				this.level = (this.level + 1) % this.config.Levels.Count;

				API.NetworkSetTalkerProximity(this.config.Levels[this.level].Distance);
				this.overlay.Level(this.config.Levels[this.level].Name);
			}

			var talking = API.NetworkIsPlayerTalking(API.PlayerId());

			if (talking != this.last)
			{
				this.last = talking;
				this.overlay.Talking(talking);
			}
		}
	}
}
