using JetBrains.Annotations;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Controllers;
using NFive.SDK.Server.Events;
using NFive.SDK.Server.Rcon;
using NFive.SDK.Server.Rpc;
using VoiceProximity.Shared;

namespace VoiceProximity.Server
{
	/// <inheritdoc />
	[PublicAPI]
	public class VoiceProximityController : ConfigurableController<Configuration>
	{
		/// <inheritdoc />
		public VoiceProximityController(ILogger logger, IEventManager events, IRpcHandler rpc, IRconManager rcon, Configuration configuration) : base(logger, events, rpc, rcon, configuration)
		{
			this.Rpc.Event(VoicePluginEvents.GetConfig).On(e => e.Reply(this.Configuration));
		}

		/// <inheritdoc />
		public override void Reload(Configuration configuration)
		{
			this.Rpc.Event(VoicePluginEvents.GetConfig).Trigger(configuration);
		}
	}
}
