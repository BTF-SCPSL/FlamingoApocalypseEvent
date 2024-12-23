using CommandSystem;
using FlamingoApocalypseEvent.Abstracts;
using FlamingoApocalypseEvent.API.Core;
using System;

namespace FlamingoApocalypseEvent.Commands.RemoteAdmin
{
	public class StopCommand : ACommand
	{
		public override string Command => "stop";

		public override string[] Aliases => [];

		public override string Description => "Останавливает заражение(Ивент)";

		protected override bool NextExecute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (Event.StopEvent())
			{
				response = "Ивент остановлен!";
				return true;
			} else
			{
				response = "Ивент не был запущен!";
				return false;
			}
		}
	}
}
