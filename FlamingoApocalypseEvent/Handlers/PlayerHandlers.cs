﻿using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Linq;
using PlayerRoles;
using Exiled.API.Enums;
using System.Collections.Generic;

namespace FlamingoApocalypseEvent.Handlers
{
	internal sealed class PlayerHandlers
	{
		public void OnDying(DyingEventArgs ev)
		{
			if (ev.Attacker != null)
			{
				RoleTypeId attackerRole = ev.Attacker.Role.Type;
				Dictionary<RoleTypeId, RoleTypeId> infectedConfig = Plugin.Singleton.Config.Infected;

				if (infectedConfig.TryGetValue(attackerRole, out RoleTypeId infectedRole) &&
					Player.List.Any(player => player.Role.Type == RoleTypeId.AlphaFlamingo))
				{
					ev.Player.DropItems();
					ev.IsAllowed = false;
					ev.Player.Role.Set(infectedRole, SpawnReason.Revived);
				}
			}
		}
	}
}
