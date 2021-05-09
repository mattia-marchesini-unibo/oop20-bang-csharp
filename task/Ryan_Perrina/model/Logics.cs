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
			IPlayer currentPlayer = this.table.CurrentPlayer;
			HashSet<IPlayer> targets = new HashSet<IPlayer>();

			IPlayer cur = currentPlayer;
			for (int i = 1; i <= currentPlayer.Sight; i++)
			{
				var playerSx = this.table.Players.GetNextOf(cur);
				i = i + playerSx.Retreat;
				if (i <= currentPlayer.Sight)
				{
					targets.Add(playerSx);
				}
				cur = this.table.Players.GetNextOf(cur);
			}

			cur = currentPlayer;
			for (int i = 1; i <= currentPlayer.Sight; i++)
			{
				var playerDx = this.table.Players.GetPrevOf(cur);
				i = i + playerDx.Retreat;
				if (i <= currentPlayer.Sight)
				{
					targets.Add(playerDx);
				}
				cur = this.table.Players.GetPrevOf(cur);
			}
			targets.Remove(currentPlayer);
			return targets;
		}
	}
}
