using Egertaia.VoiceProximity.Shared;
using JetBrains.Annotations;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Controllers;
using NFive.SDK.Server.Events;
using NFive.SDK.Server.Rcon;
using NFive.SDK.Server.Rpc;

namespace Egertaia.VoiceProximity.Server
{
	/// <inheritdoc />
	[PublicAPI]
	public class VoiceProximityController : ConfigurableController<Configuration>
	{
		/// <inheritdoc />
		public VoiceProximityController(ILogger logger, IEventManager events, IRpcHandler rpc, IRconManager rcon, Configuration configuration) : base(logger, events, rpc, rcon, configuration)
		{
			this.Rpc.Event(VoiceProximityEvents.GetConfig).On(e => e.Reply(this.Configuration));
		}

		/// <inheritdoc />
		public override void Reload(Configuration configuration)
		{
			this.Rpc.Event(VoiceProximityEvents.GetConfig).Trigger(configuration);
		}
	}
}
