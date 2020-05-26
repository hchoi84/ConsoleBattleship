using GameLibrary;
using GameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			PrintGameRule();
			GetConfirmation("Press ENTER to start");
			ClearScreen();

			int numberOfPlayers = 2;
			int fieldWidth = 5;
			int fieldHeight = 5;

			List<PlayerModel> players = Player.Initialize(numberOfPlayers, fieldWidth, fieldHeight);
			int turnIndex = 0;
			PlayerModel winner = null;

			for (var i = 0; i < players.Count; i++)
			{
				players[i].Name = GetPlayerName(i);
				string[] shipCoordinates = GetShipLocations();
				Player.PlaceShips(players[i], shipCoordinates);
				Console.WriteLine();
				PrintField(players[i].DefendField);
				GetConfirmation("Press ENTER after review");
				ClearScreen();
			}

			while (winner == null)
			{
				int playerIndex = turnIndex % players.Count;
				PlayerModel activePlayer = players[playerIndex];
				GetConfirmation($"{ activePlayer.Name }, have a seat and press ENTER when ready");
				ClearScreen();

				PrintField(activePlayer.DefendField);
				Console.WriteLine();
				PrintField(activePlayer.AttackField);

				string attackCoordinate = GetAttackCoordinate();
				PlayerModel opponent = players[(turnIndex + 1) % players.Count];
				string attackResult = Player.GetAttackResult(activePlayer, opponent, attackCoordinate);
				Console.WriteLine(attackResult);
				bool isStillAlive = Player.IsStillAlive(opponent);
				if (!isStillAlive)
				{
					winner = activePlayer;
					break;
				}

				GetConfirmation("Press ENTER after review");
				ClearScreen();

				turnIndex++;
			}

			Console.WriteLine($"{ winner.Name } is the WINNER!");

			Console.ReadLine();
		}

		private static void PrintGameRule()
		{
			Console.WriteLine("Welcome to Battleship Console!");
			Console.WriteLine("Here's a quick overview of the game:");
			Console.WriteLine("This is a 2 player game.");
			Console.WriteLine("Each player will place 5 ships on a 5 x 5 grid.");
			Console.WriteLine("Whoever sinks the opponents 5 ships first wins.");
			Console.WriteLine();
			Console.WriteLine("Ships aren't stackable. Meaning, you can't place multiple ships on the same coordinate");
			Console.WriteLine("Player will be able to attack same coordinate more than once. It's a punishment for lack of attention :)");
			Console.WriteLine("Good luck!");
		}

		private static void GetConfirmation(string instruction)
		{
			bool isConfirmed = false;

			while (!isConfirmed)
			{
				Console.WriteLine(instruction);

				if (Console.ReadKey(true).Key == ConsoleKey.Enter)
				{
					isConfirmed = true;
				}
				else
				{
					Console.WriteLine("Invalid entry");
				}
			}
		}

		private static void ClearScreen() => Console.Clear();

		private static string GetPlayerName(int index)
		{
			Console.WriteLine($"Player { index + 1 }, please enter your name: (10 characters max)");
			string name = Console.ReadLine();

			while (name.Length > 10)
			{
				Console.WriteLine("Name is too long. Please keep it below 10 characters");
			}

			return name;
		}

		private static string[] GetShipLocations()
		{
			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Please enter 5 ship locations separated by a comma (ex: a1,a2,a3,a4,a5)");
				string[] response = Console.ReadLine().Trim().ToUpper().Replace(" ", "").Split(',');

				while (response.Length != 5)
				{
					Console.WriteLine($"You've entered { response.Length } ship coordinates.");
					Console.WriteLine("Please enter 5 ship locations separated by a comma (ex: a1,a2,a3,a4,a5)");
					response = Console.ReadLine().Trim().ToUpper().Replace(" ", "").Split(',');
				}

				bool isValidCoordinate = true;

				foreach (string coordinate in response)
				{
					isValidCoordinate = Field.CoordinateValidator(coordinate);
					if (!isValidCoordinate)
					{
						Console.WriteLine($"Coordinate { coordinate } is not valid. Please enter coordinates within the grid");
						break;
					}
				}

				if (isValidCoordinate)
				{
					return response;
				}
			}
		}

		private static void PrintField(int[][] field)
		{
			Dictionary<int, string> legend = new Dictionary<int, string>
			{
				{ 0, " " }, { 1, "O" },{ 2, "O" },{ 3, "X" },{ 4, "X" },
			};

			for (var i = 0; i < field.Length; i++)
			{
				for (var j = 0; j < field[i].Length; j++)
				{
					if (i == 0)
					{
						Console.Write(field[i][j]);
						continue;
					}

					if (j == 0)
					{
						Console.Write(Convert.ToChar(field[i][j]));
						continue;
					}

					if (field[i][j] == 2 || field[i][j] == 4)
					{
						Console.ForegroundColor = ConsoleColor.Red;
					}

					Console.Write(legend[field[i][j]]);
					Console.ResetColor();
				}

				Console.WriteLine();
			}

			Console.WriteLine();
		}

		private static string GetAttackCoordinate()
		{
			Console.WriteLine("Enter coordinate you'd like to attack:");
			string response = Console.ReadLine().Trim().Replace(" ","").ToUpper();
			bool isValid = Field.CoordinateValidator(response);

			while (!isValid)
			{
				Console.WriteLine("Invalid attack location");
				Console.WriteLine("Please enter coordinate within the field");
				response = Console.ReadLine().Trim().Replace(" ", "").ToUpper();
				isValid = Field.CoordinateValidator(response);
			}
			
			Console.WriteLine();

			return response;
		}
	}
}