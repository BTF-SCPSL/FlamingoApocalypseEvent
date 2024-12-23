using FlamingoApocalypseEvent.API.Core;

namespace FlamingoApocalypseEvent.Handlers
{
	internal sealed class ServerHandlers
	{
		public void OnRestartingRound()
		{
			Event.StopEvent();
		}
	}
}
