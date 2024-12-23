using CommandSystem;
using FlamingoApocalypseEvent.API.Helpers;
using System;

namespace FlamingoApocalypseEvent.Abstracts
{
	public abstract class ACommand : ICommand
	{
		public abstract string Command { get; }

		public abstract string[] Aliases { get; }

		public abstract string Description { get; }

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (!sender.HasPermission(Command))
			{
				response = "У Вас недостаточно прав.";
				return false;
			}

			return NextExecute(arguments, sender, out response);
		}

		protected abstract bool NextExecute(ArraySegment<string> arguments, ICommandSender sender, out string response);
	}
}
