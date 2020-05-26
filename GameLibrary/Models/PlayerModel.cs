using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models
{
	public class PlayerModel
	{
		public string Name { get; set; }
		public int[][] DefendField { get; set; }
		public int[][] AttackField { get; set; }
		public int ShipsAlive { get; set; }
	}
}
