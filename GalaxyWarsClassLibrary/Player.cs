using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
	/// <summary>
	/// player character class derived from lifeform.
	/// </summary>
	public class Player : Lifeform
	{
		private string _race,
					   _playerClass,
					   _password;

		private int _score,
					_locationX,
					_locationY;
		// fields.

		/// <summary>
		/// player character class derived from lifeform.
		/// </summary>
		/// <param name="name">name of character.</param>
		/// <param name="race">race of character.</param>
		/// <param name="playerClass">in-game class of player.</param>
		/// <param name="password">password for character.</param>
		/// <param name="health">health points of character.</param>
		/// <param name="score">current score of character.</param>
		/// <param name="locationX">location of character on X axis. should refer to
		/// planets array subscript in Galaxy.</param>
		/// <param name="locationY">location of character on X axis. should refer to
		/// planets array subscript in Galaxy.</param>
		/// <param name="weaponInventory">weapon inventory of character. equipped 
		/// weapon defaults to first weapon in this list.</param>
		/// <param name="potionInventory">potion inventory of character.</param>
		/// <param name="treasureInventory">treasure inventory of character.</param>
		/// <param name="itemInventory">item inventory of character.</param>
		public Player(string name,
					  string race,
					  string playerClass,
					  string password,
					  int health,
					  int score,
					  int locationX,
					  int locationY,
					  List<Weapon> weaponInventory,
					  List<Potion> potionInventory,
					  List<Treasure> treasureInventory,
					  List<Item> itemInventory)
		{
			_name = name;
			_race = race;
			_playerClass = playerClass;
			_password = password;
			_health = health;
			_score = score;
			_locationX = locationX;
			_locationY = locationY;
			_weaponInventory = weaponInventory;
			_potionInventory = potionInventory;
			_treasureInventory = treasureInventory;
			_itemInventory = itemInventory;
			_weapon = _weaponInventory[0];
		}
		// constructors.

		/// <summary>
		/// race of player.
		/// </summary>
		public string Race
		{
			get { return _race; }
		}

		/// <summary>
		/// class of player.
		/// </summary>
		public string PlayerClass
		{
			get { return _playerClass; }
		}

		/// <summary>
		/// password for character.
		/// </summary>
		public string Password
		{
			get { return _password; }
		}

		/// <summary>
		/// current score of character.
		/// </summary>
		public int Score
		{
			get { return _score; }
			set { _score = value; }
		}

		/// <summary>
		/// current X axis location of player. should correlate to subscript of
		/// Galaxy.Planets.
		/// </summary>
		public int LocationX
		{
			get { return _locationX; }
			set { _locationX = value; }
		}

		/// <summary>
		/// current Y axis location of player. should correlate to subscript of
		/// Galaxy.Planets.
		/// </summary>
		public int LocationY
		{
			get { return _locationY; }
			set { _locationY = value; }
		}
		// props.
	}
}
