using GameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
	public static class Player
	{
		public static List<PlayerModel> Initialize(int numberOfPlayers, int fieldWidth, int fieldHeight)
		{
			List<PlayerModel> players = new List<PlayerModel>();

			for (var i = 0; i < numberOfPlayers; i++)
			{
				PlayerModel player = new PlayerModel();
				player.Name = $"Player{i}";
				player.DefendField = Field.Initialize(fieldWidth, fieldHeight);
				player.AttackField = Field.Initialize(fieldWidth, fieldHeight);
				players.Add(player);
			}

			return players;
		}

		public static void PlaceShips(PlayerModel player, string[] shipCoordinates)
		{
			foreach (string shipCoordinate in shipCoordinates)
			{
				int i = Convert.ToInt32(shipCoordinate[0]) % 64;
				int j = int.Parse(shipCoordinate[1].ToString());

				player.DefendField[i][j] = 1;
				player.ShipsAlive++;
			}
		}

		public static string GetAttackResult(PlayerModel activePlayer, PlayerModel opponent, string attackCoordinate)
		{
			int i = Convert.ToInt32(attackCoordinate[0]) % 64;
			int j = int.Parse(attackCoordinate[1].ToString());

			int attackLocResult = opponent.DefendField[i][j];

			if (attackLocResult == 0)
			{
				opponent.DefendField[i][j] = 3;
				activePlayer.AttackField[i][j] = 3;
				return $"{ attackCoordinate } was a MISS";
			}
			
			if (attackLocResult == 1)
			{
				opponent.DefendField[i][j] = 2;
				activePlayer.AttackField[i][j] = 4;
				opponent.ShipsAlive--;
				return $"{ attackCoordinate } was a HIT";
			}

			return $"{ attackCoordinate } had no change because it was previously attacked";
		}

		public static bool IsStillAlive(PlayerModel opponent)
		{
			return opponent.ShipsAlive == 0 ? false : true;
		}
	}
}
