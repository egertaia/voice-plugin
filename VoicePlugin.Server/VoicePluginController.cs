using JetBrains.Annotations;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Controllers;
using NFive.SDK.Server.Events;
using NFive.SDK.Server.Rpc;
using VoicePlugin.Shared;

namespace VoicePlugin.Server
{
	/// <inheritdoc />
	[PublicAPI]
	public class VoicePluginController : ConfigurableController<Configuration>
	{
		/// <inheritdoc />
		public VoicePluginController(ILogger logger, IEventManager events, IRpcHandler rpc, Configuration configuration) : base(logger, events, rpc, configuration)
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
