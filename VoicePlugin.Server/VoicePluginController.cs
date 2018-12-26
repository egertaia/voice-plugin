using JetBrains.Annotations;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Controllers;
using NFive.SDK.Server.Events;
using NFive.SDK.Server.Rpc;
using VoicePlugin.Shared;

namespace VoicePlugin.Server
{
	[PublicAPI]
	public class VoicePluginController : ConfigurableController<Configuration>
	{
		public VoicePluginController(ILogger logger, IEventManager events, IRpcHandler rpc, Configuration configuration) : base(logger, events, rpc, configuration)
		{
			this.Rpc.Event(VoicePluginEvents.GetConfig).On(e => e.Reply((Configuration)this.Configuration));
		}
	}
}
