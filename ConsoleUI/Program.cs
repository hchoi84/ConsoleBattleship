using GameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] generatedField = FieldGenerator.GenerateBattleField(5, 5);
			string field = FieldGenerator.ConvertFieldToString(generatedField);

			string[] lines = field.Split('\n');

			Console.WriteLine(lines[0]);

			for (var i = 1; i < lines.Length; i++)
			{
				for (var j = 0; j < lines[i].Length; j++)
				{
					if (lines[i][j] == '1' || lines[i][j] == '3')
					{
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.Write(lines[i][j]);
					}
					else if (lines[i][j] == '2' || lines[i][j] == '4')
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write(lines[i][j]);
					}
					else
					{
						Console.Write(lines[i][j]);
					}
					Console.ResetColor();
				}
				Console.Write("\n");
			}

			Console.ReadLine();
		}
	}
}

/* WALKTHROUGH
 *	- Display basic game info and rules
 *	- Display the game field (Excel format)
 *		- Letters on the top
 *		- Numbers on the left
 *	- Ask for Player's
 *		- Name
 *		- 5 spots (can't all be the same)
 *	- Clear the screen
 *	- Have player enter "START" when ready
 *	- Each players turn should clear the screen and load up the field with
 *		- Battleships (Blue O)
 *		- Launched spots (Black X)
 *		- Hit spots (Red X)
 *	- Allow player to shoot at the same spot (dumb mistake is allowed)
 *	- When one player loses all 5 ships, GAME OVER
 *	- Displays
 *		- Player 1 Field
 *		- Player 2 Field
 *		- Number of shots taken
 *		- Accuracy
 */

/* QUESTIONS
 *	- Local or LAN? LOCAL
 *	- Allow ships to be placed on the same spot? NO
 *	- Allow more than 2 players? MAYBE (future update)
 *	- Allow computer? MAYBE
 *	- Allow shooting at the same spot? YES
 *	- Display battlefield of the player? YES
 *	- Display stats (shot spots, hit spots, ship spots)? YES
 *	- Enter coordinates at once or separate (Column then Row)? SEPARATE
 *	- Allow ship placement outside of the field? NO
 *	- Allow shooting outside of the field? YES
 */

/* REQUIREMENTS
 *	- 2 People Players
 *	- Show fields with ship, shots, and misses
 *	- One ship per spot WITHIN field
 *	- Multiple shots in one spot is okay. Do notify player
 *	- Shooting outside of the field is okay. Do notify player
 *	- Enter coordinates separately (Column then Row)
 *	- Completely end the game once a player loses all 5 ships
 *	- Display stats screen on GAME OVER screen
 */