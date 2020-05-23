using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
	public static class FieldGenerator
	{
		public static int[][] GenerateBattleField(int x, int y)
		{
			x++;
			y++;
			int[][] field = new int[x][];

			for (var i = 0; i < x; i++)
			{
				field[i] = new int[y];

				for (var j = 0; j < y; j++)
				{
					if			(i == 0)	field[i][j] = j;
					else if (j == 0)	field[i][j] = i;
					else							field[i][j] = 0;
				}
			}

			return field;
		}

		public static string ConvertFieldToString(int[][] field)
		{
			string fieldText = "";

			for (var i = 0; i < field.Length; i++)
			{
				for (var j = 0; j < field[i].Length; j++)
				{
					if (field[i][j] == 0)
					{
						fieldText += "  ";
					}
					else if (i == 0)
					{
						fieldText += " " + field[i][j];
					}
					else if (j == 0)
					{
						string character = " " + Convert.ToChar(field[i][j] + 64).ToString();
						fieldText += character;
					}
				}
				fieldText += "\n";
			}

			return fieldText;
		}
	}
}
