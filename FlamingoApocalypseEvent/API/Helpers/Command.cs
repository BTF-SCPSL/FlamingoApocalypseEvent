using CommandSystem;
using Exiled.Permissions.Extensions;

namespace FlamingoApocalypseEvent.API.Helpers
{
	public static class Command
	{
		public static bool HasPermission(this ICommandSender sender, string command)
		{
			return sender.CheckPermission(Plugin.Singleton.Config.PrefixCommand + '.' + command);
		}
	}
}
