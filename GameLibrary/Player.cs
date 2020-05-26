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

		public static void PlaceShips(int[][] defendField, string[] shipCoordinates)
		{
			foreach (string shipCoordinate in shipCoordinates)
			{
				int i = Convert.ToInt32(shipCoordinate[0]) % 64;
				int j = int.Parse(shipCoordinate[1].ToString());

				defendField[i][j] = 1;
			}
		}
	}
}
