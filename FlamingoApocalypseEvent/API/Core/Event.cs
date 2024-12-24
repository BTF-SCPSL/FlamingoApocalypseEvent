using Exiled.API.Extensions;
using Exiled.API.Features;
using PlayerRoles;
using System;

namespace FlamingoApocalypseEvent.API.Core
{
	public class Event
	{
		public static Event Singleton { get; private set; }

		public static bool StartEvent()
		{
			if (IsEvent())
			{
				return false;
			}

			Singleton = new();

			Singleton.Start();

			return true;
		}

		public static bool StopEvent()
		{
			if (!IsEvent())
			{
				return false;
			}

			Singleton.Stop();

			Singleton = null;
			return true;
		}

		public static bool IsEvent()
		{
			return Singleton != null;
		}

		private void StartEvents()
		{
			Exiled.Events.Handlers.Server.RestartingRound += Plugin.Singleton._serverHandlers.OnRestartingRound;
			Exiled.Events.Handlers.Player.Dying += Plugin.Singleton._playerHandlers.OnDying;
		}

		private void StopEvents()
		{
			Exiled.Events.Handlers.Server.RestartingRound -= Plugin.Singleton._serverHandlers.OnRestartingRound;
			Exiled.Events.Handlers.Player.Dying -= Plugin.Singleton._playerHandlers.OnDying;
		}

		private void Start()
		{

			if (Round.IsLobby)
			{
				int count = (int)Math.Ceiling(Player.List.Count * Plugin.Singleton.Config.ChangeSpawnFlamingo);

				Log.Debug("Count flamingo: " + count);

				for (int i = 0; i < count; i++)
				{
					Player player = Player.List.GetRandomValue();
					switch (i)
					{
						case 0:
							player.Role.Set(RoleTypeId.AlphaFlamingo);
							break;
						default:
							player.Role.Set(RoleTypeId.Flamingo);
							break;
					}
				}

				Round.Start();
			}

			StartEvents();
		}

		private void Stop()
		{
			StopEvents();
		}
	}
}
