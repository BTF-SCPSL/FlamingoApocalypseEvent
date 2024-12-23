using Exiled.API.Features;
using System;
using FlamingoApocalypseEvent.Configs;
using FlamingoApocalypseEvent.Handlers;

namespace FlamingoApocalypseEvent
{
    public sealed class Plugin : Plugin<Config>
    {
		public override string Author => "Руслан0308c";
		public override Version RequiredExiledVersion => new(9, 0, 1);
		public override Version Version => new(1, 0, 0);

		public static Plugin Singleton { get; private set; }

		internal ServerHandlers _serverHandlers { get; private set; }
		internal PlayerHandlers _playerHandlers { get; private set; }

		public override void OnEnabled()
		{
			Singleton = this;

			_serverHandlers = new();
			_playerHandlers = new();

			base.OnEnabled();
		}

		public override void OnDisabled()
		{
			Singleton = null;

			_serverHandlers = null;
			_playerHandlers = null;

			base.OnDisabled();
		}
	}
}
