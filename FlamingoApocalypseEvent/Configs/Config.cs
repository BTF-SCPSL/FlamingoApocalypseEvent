using Exiled.API.Interfaces;
using PlayerRoles;
using System.Collections.Generic;

namespace FlamingoApocalypseEvent.Configs
{
	public sealed class Config : IConfig
	{
		public bool IsEnabled { get; set; } = true;
		public bool Debug { get; set; } = false;

		public string PrefixCommand { get; set; } = "fe";
		public float ChangeSpawnFlamingo { get; set; } = .20f;

		public Dictionary<RoleTypeId, RoleTypeId> Infected = new()
		{
			{ RoleTypeId.AlphaFlamingo, RoleTypeId.Flamingo },
			{ RoleTypeId.Flamingo, RoleTypeId.Flamingo },
			{ RoleTypeId.ZombieFlamingo, RoleTypeId.ZombieFlamingo }
		};
	}
}
