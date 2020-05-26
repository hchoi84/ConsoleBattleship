using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
	public static class Field
	{
		public static int[][] Initialize(int x, int y)
		{
			x++;
			y++;
			int[][] field = new int[x][];

			for (int i = 0; i < field.Length; i++)
			{
				field[i] = new int[y];
				field[i][0] = i + 64;
			}

			for (int i = 0; i < y; i++)
			{
				field[0][i] = i;
			}

			return field;
		}

		public static bool CoordinateValidator(string coordinate)
		{
			if (coordinate.Length > 2) return false;

			int row = Convert.ToInt32(coordinate[0]);
			int col = int.Parse(coordinate[1].ToString());

			if ((row >= 65 && row <= 69) &&
					(col >= 1 && col <= 5)) return true;

			return false;
		}

	}
}
