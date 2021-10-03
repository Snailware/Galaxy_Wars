using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GalaxyWarsClassLibrary
{	
	/// <summary>
	/// class for performing database operations.
	/// </summary>
	public static class DatabaseOps
	{
		/// <summary>
		/// connection string to be used with database.
		/// </summary>
		public static string ConnectionString { get; set; }
		// props.
	
		/// <summary>
		/// read planets table in database and create objects.
		/// </summary>
		/// <returns>list of constructed planets.</returns>
		public static List<Planet> ReadPlanets()
		{
			const string Query = "SELECT * FROM planets";
			// SQL query to execute.

			List<Planet> output = new List<Planet>();
			// list to hold resulting objects.

			SqlConnection connection = new SqlConnection(ConnectionString);
			// create connection using connection string.

			connection.Open();
			// open database connection. 

			SqlCommand command = new SqlCommand(Query, connection);
			// create command object.

			SqlDataReader dataReader = command.ExecuteReader();
			// execute command & create reader obj.

			while (dataReader.Read())
			{
				output.Add(new Planet(planetName: dataReader.GetString(1),
									  planetDescription: dataReader.GetString(2),
									  population: dataReader.GetInt32(3),
									  alien: Alien.Generate()));
			}
			// read all records in table and construct objects based on data. 

			dataReader.Close();
			command.Dispose();
			connection.Close();
			// close all objects.

			return output;
			// return results.
		}

		/// <summary>
		/// read aliens table in database and create objects.
		/// </summary>
		/// <returns>list of constructed aliens.</returns>
		public static List<Alien> ReadAliens()
		{
			const string Query = "SELECT * FROM aliens";
			// SQL query to execute.

			List<Alien> output = new List<Alien>();
			// list to hold resulting objects.

			SqlConnection connection = new SqlConnection(ConnectionString);
			// create connection using connection string.

			connection.Open();
			// open database connection. 

			SqlCommand command = new SqlCommand(Query, connection);
			// create command object.

			SqlDataReader dataReader = command.ExecuteReader();
			// execute command & create reader obj.

			while (dataReader.Read())
			{
				output.Add(new Alien(name: dataReader.GetString(1),
									 description: dataReader.GetString(2),
									 health: dataReader.GetInt32(3),
									 armor: dataReader.GetInt32(4),
									 money: dataReader.GetInt32(5)));
			}
			// read all records in table and construct objects based on data. 

			dataReader.Close();
			command.Dispose();
			connection.Close();
			// close all objects.

			return output;
			// return results.
		}

		/// <summary>
		/// check credentials against database records, and return gamestate 
		/// if match is found. 
		/// </summary>
		/// <param name="name">name of character to check against records.</param>
		/// <param name="password">password of character to check against records.</param>
		/// <returns>filled GameState if match found, empty GameState if not.</returns>
		public static string AuthAndLoadGame(string name, string password)
		{
			const string Query = "SELECT * FROM saves";
			// SQL query to execute.

			string status = "success";

			try
			{
				SqlConnection connection = new SqlConnection(ConnectionString);
				// create connection using connection string.

				connection.Open();
				// open database connection. 

				SqlCommand command = new SqlCommand(Query, connection);
				// create command object.

				SqlDataReader dataReader = command.ExecuteReader();
				// execute command & create reader obj.

				while (dataReader.Read())
				{
					if (dataReader.GetString(0) == name &&
						dataReader.GetString(1) == password)
					// TODO might need to check these conditions depending on query output.
					{
						GameState output = JsonSerializer.Deserialize<GameState>(dataReader.GetString(2));
						// deserialize obj.

						Galaxy.ActionStatement = output.ActionStatement;
						Galaxy.Treasures = output.Treasures;
						Galaxy.Items = output.Items;
						Galaxy.Potions = output.Potions;
						Galaxy.Weapons = output.Weapons;
						Galaxy.Aliens = output.Aliens;
						Galaxy.Planets = output.Planets;
						Galaxy.CurrentSystem = output.CurrentSystem;
						// load data to galaxy.

						break;
						// exit loop.
					}
				}
				// iter over records. if match is found, deserialize & load state.

				dataReader.Close();
				command.Dispose();
				connection.Close();
				// close all objs.
			} 
			catch (Exception ex)
			{
				status = ex.Message;
			}

			return status;
			// return status string.
		}

		/// <summary>
		/// save gameState to database.
		/// </summary>
		/// <param name="gameState">gameState to save to database.</param>
		public static string SaveGame()
		{
			try
			{
				GameState saveState = new GameState(actionStatement: Galaxy.ActionStatement,
													player: Galaxy.Player,
													weapons: Galaxy.Weapons,
													potions: Galaxy.Potions,
													treasures: Galaxy.Treasures,
													items: Galaxy.Items,
													aliens: Galaxy.Aliens,
													planets: Galaxy.Planets,
													currentSystem: Galaxy.CurrentSystem);
				// create save state based on Galaxy.

				string name = saveState.Player.Name;
				string password = saveState.Player.Password;
				string gameStateJson = JsonSerializer.Serialize(saveState);
				// data to store in db.

				if (SaveAlreadyExists(name, password))
				{
					string query = $"UPDATE saves SET gamestate = '{gameStateJson}' WHERE name = '{name}' AND password = '{password}'";
					// SQL query to execute.

					SqlConnection connection = new SqlConnection(ConnectionString);
					// create connection using connection string.

					connection.Open();
					// open database connection. 

					SqlCommand command = new SqlCommand(query, connection);
					SqlDataAdapter adapter = new SqlDataAdapter();
					adapter.UpdateCommand = new SqlCommand(query, connection);
					adapter.UpdateCommand.ExecuteNonQuery();
					// create objs and execute sql query.

					command.Dispose();
					adapter.Dispose();
					connection.Close();
					// close all objects.
				}
				// update record if match is found.

				else
				{
					string query = $"INSERT INTO saves VALUES ('{name}', '{password}', '{gameStateJson}')";
					// SQL query to execute.
					// TODO might need to change this depending on syntax.

					SqlConnection connection = new SqlConnection(ConnectionString);
					// create connection using connection string.

					connection.Open();
					// open database connection. 

					SqlCommand command = new SqlCommand(query, connection);
					SqlDataAdapter adapter = new SqlDataAdapter();
					adapter.InsertCommand = new SqlCommand(query, connection);
					adapter.InsertCommand.ExecuteNonQuery();
					// create objs and execute sql query.

					command.Dispose();
					adapter.Dispose();
					connection.Close();
					// close all objects.
				}
				// create new record if no match found. 

				return "success";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		/// <summary>
		/// check if save exists belonging to name and password.
		/// </summary>
		/// <param name="name">name of player.</param>
		/// <param name="password">password of player.</param>
		/// <returns>true if match is found, false otherwise.</returns>
		public static bool SaveAlreadyExists(string name, string password)
		{
			const string Query = "SELECT name, password FROM saves";
			// SQL query to execute.

			bool saveExists = false;
			// save exists flag.

			SqlConnection connection = new SqlConnection(ConnectionString);
			// create connection using connection string.

			connection.Open();
			// open database connection. 

			SqlCommand command = new SqlCommand(Query, connection);
			// create command object.

			SqlDataReader dataReader = command.ExecuteReader();
			// execute command & create reader obj.

			while (dataReader.Read())
			{
				if (dataReader.GetString(0) == name &&
					dataReader.GetString(1) == password)
				// TODO might need to check these conditions depending on query output.
				{
					saveExists = true;

					break;
					// exit loop.
				}
			}
			// iter over records. if match is found, set flag to true.

			dataReader.Close();
			command.Dispose();
			connection.Close();
			// close connection.

			return saveExists;
			// return flag status.
		}
		// methods.
	}
}
