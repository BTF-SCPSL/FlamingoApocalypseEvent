using CommandSystem;
using System;
using FlamingoApocalypseEvent.API.Helpers;
using System.Linq;
using FlamingoApocalypseEvent.Abstracts;

namespace FlamingoApocalypseEvent.Commands.RemoteAdmin
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	public sealed class MainCommand : ParentCommand
	{
		public MainCommand() => LoadGeneratedCommands();

		public override string Command => "flamingoevent";

		public override string[] Aliases => ["fe"];

		public override string Description => "Ивент фламинго апокалипсис";

		public override void LoadGeneratedCommands()
		{
			RegisterCommand(new StartCommand());
			RegisterCommand(new  StopCommand());
		}

		protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			response = "\n Доступные команды:";

			foreach (ACommand command in AllCommands.Cast<ACommand>())
			{
				if (sender.HasPermission(command.Command))
				{
					response += $"\n\n- {command.Command} ({string.Join(", ", command.Aliases)})\n{command.Description}";
				}
			}

			return false;
		}
	}
}
