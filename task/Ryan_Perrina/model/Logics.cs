using System.Collections.Generic;

namespace model
{
    public class Logics
    {
        private Table table;
        
        public Logics(Table table)
        {
            this.table = table;
        }

		public HashSet<IPlayer> GetTargets()
		{
			IPlayer currentPlayer = this.table.GetCurrentPlayer();
			HashSet<IPlayer> targets = new HashSet<IPlayer>();

			IPlayer cur = currentPlayer;
			for (int i = 1; i <= currentPlayer.Sight; i++)
			{
				var playerSx = this.table.GetPlayers().GetNextOf(cur);
				i = i + playerSx.GetRetreat();
				if (i <= currentPlayer.Sight)
				{
					targets.Add(playerSx);
				}
				cur = this.table.GetPlayers().GetNextOf(cur);
			}

			cur = currentPlayer;
			for (int i = 1; i <= currentPlayer.Sight; i++)
			{
				var playerDx = this.table.GetPlayers().GetPrevOf(cur);
				i = i + playerDx.GetRetreat();
				if (i <= currentPlayer.Sight)
				{
					targets.Add(playerDx);
				}
				cur = this.table.GetPlayers().GetPrevOf(cur);
			}
			targets.Remove(currentPlayer);
			return targets;
		}
	}
}
