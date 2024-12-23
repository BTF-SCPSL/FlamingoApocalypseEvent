using CommandSystem;
using FlamingoApocalypseEvent.Abstracts;
using FlamingoApocalypseEvent.API.Core;
using System;

namespace FlamingoApocalypseEvent.Commands.RemoteAdmin
{
	public sealed class StartCommand : ACommand
	{
		public override string Command => "start";

		public override string[] Aliases => [];

		public override string Description => "Запускает ивент(запускать желательно, до старта раунда)";

		protected override bool NextExecute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (Event.StartEvent())
			{
				response = "Ивент запущен!";
				return true;
			} else
			{
				response = "Инвет уже запущен!";
				return false;
			}
		}
	}
}
