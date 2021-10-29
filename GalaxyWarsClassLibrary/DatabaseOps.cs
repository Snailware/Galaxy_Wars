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
        /// read planets table in database and create planets.
        /// </summary>
        /// <returns>list of planets.</returns>
        public static List<Planet> ReadPlanets()
        {
            const string Query = "SELECT name, description, population FROM planets;";
            // SQL query to execute.

            List<Planet> output = new List<Planet>();
            // list to hold resulting objects.

            if (ConnectionString is null)
            {
                ConnectionString = FileOps.GetConnectionString(@"..\..\..\GalaxyWarsClassLibrary\ConnectionString.txt");
            }
            // get connection string if needed.

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
                output.Add(new Planet(planetName: dataReader.GetString(0),
                                      planetDescription: dataReader.GetString(1),
                                      population: dataReader.GetInt32(2),
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
        /// read aliens table in database and create aliens.
        /// </summary>
        /// <returns>list of aliens.</returns>
        public static List<Alien> ReadAliens()
        {
            const string Query = "SELECT name, description, health, armor, money FROM aliens;";
            // SQL query to execute.

            List<Alien> output = new List<Alien>();
            // list to hold resulting objects.

            if (ConnectionString is null)
            {
                ConnectionString = FileOps.GetConnectionString(@"..\..\..\GalaxyWarsClassLibrary\ConnectionString.txt");
            }
            // get connection string if needed.

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
                output.Add(new Alien(name: dataReader.GetString(0),
                                     description: dataReader.GetString(1),
                                     health: dataReader.GetInt32(2),
                                     armor: dataReader.GetInt32(3),
                                     money: dataReader.GetInt32(4)));
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
        /// read weapons table in database and create weapons.
        /// </summary>
        /// <returns>list of weapons.</returns>
        public static List<Weapon> ReadWeapons()
		{
            // TODO write this method.
            const string Query = "SELECT name, description, price, quest, damageType, amtOfDamage, FROM weapons ;";
            // SQL query to execute.

            List<Weapon> output = new List<Weapon>();
            // list to hold resulting objects.

            if (ConnectionString is null)
            {
                ConnectionString = FileOps.GetConnectionString(@"..\..\..\GalaxyWarsClassLibrary\ConnectionString.txt");
            }
            // get connection string if needed.

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
                output.Add(new Weapon(name: dataReader.GetString(0),
                                      description: dataReader.GetString(1),
                                      price: dataReader.GetInt32(2),
                                      quest: dataReader.GetBoolean(3),
                                      damageType: dataReader.GetString(4),
                                      amtOfDamage: dataReader.GetInt32(5)));


            }
            // read all records in table and construct objects based on data. 

            dataReader.Close();
            command.Dispose();
            connection.Close();
            // close all objects.

            return output;
        }

        /// <summary>
        /// read potions table in database and create potions.
        /// </summary>
        /// <returns>list of potions.</returns>
        public static List<Potion> ReadPotions()
		{
            // TODO write this method.
            const string Query = "SELECT name, description, price, quest, healthEffect, damageEffect FROM Potions;";
            // SQL query to execute.

            List<Potion> output = new List<Potion>();
            // list to hold resulting objects.

            if (ConnectionString is null)
            {
                ConnectionString = FileOps.GetConnectionString(@"..\..\..\GalaxyWarsClassLibrary\ConnectionString.txt");
            }
            // get connection string if needed.

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
                output.Add(new Potion(name: dataReader.GetString(0),
                                      description: dataReader.GetString(1),
                                      price: dataReader.GetInt32(2),
                                      quest: dataReader.GetBoolean(3),
                      healthEffect: dataReader.GetInt32(4),
                      damageEffect: dataReader.GetInt32(5)));
            }
            // read all records in table and construct objects based on data. 

            dataReader.Close();
            command.Dispose();
            connection.Close();
            // close all objects.

            return output;
        }

        /// <summary>
        /// read treasures table in database and create treasures.
        /// </summary>
        /// <returns>list of treasures.</returns>
        public static List<Treasure> ReadTreasures()
		{
            // TODO write this method.
            const string Query = "SELECT name, description, price, quest FROM treasure;";
            // SQL query to execute.

            List<Treasure> output = new List<Treasure>();
            // list to hold resulting objects.

            if (ConnectionString is null)
            {
                ConnectionString = FileOps.GetConnectionString(@"..\..\..\GalaxyWarsClassLibrary\ConnectionString.txt");
            }
            // get connection string if needed.

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
                output.Add(new Treasure(name: dataReader.GetString(0),
                                      description: dataReader.GetString(1),
                                      price: dataReader.GetInt32(2),
                                      quest: dataReader.GetBoolean(3)));
            }
            // read all records in table and construct objects based on data. 

            dataReader.Close();
            command.Dispose();
            connection.Close();
            // close all objects.

            return output;
        }

        /// <summary>
        /// read items table in database and create items.
        /// </summary>
        /// <returns>list of items.</returns>
        public static List<Item> ReadItems()
		{
            // TODO write this method.
            const string Query = "SELECT name, description, price, quest FROM items";
            // SQL query to execute.

            List<Item> output = new List<Item>();
            // list to hold resulting objects.

            if (ConnectionString is null)
            {
                ConnectionString = FileOps.GetConnectionString(@"..\..\..\GalaxyWarsClassLibrary\ConnectionString.txt");
            }
            // get connection string if needed.

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
                output.Add(new Item(name: dataReader.GetString(0),
                                      description: dataReader.GetString(1),
                                      price: dataReader.GetInt32(2),
                                      quest: dataReader.GetBoolean(3)));
            }
            // read all records in table and construct objects based on data. 

            dataReader.Close();
            command.Dispose();
            connection.Close();
            // close all objects.

            return output;
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
            const string Query = "SELECT * FROM saves;";
            // SQL query to execute.

            string status = "success";

            try
            {
                if (ConnectionString is null)
                {
                    ConnectionString = FileOps.GetConnectionString(@"..\..\..\GalaxyWarsClassLibrary\ConnectionString.txt");
                }
                // get connection string if needed.

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

                if (ConnectionString is null)
                {
                    ConnectionString = FileOps.GetConnectionString(@"..\..\..\GalaxyWarsClassLibrary\ConnectionString.txt");
                }
                // get connection string if needed.

                if (SaveAlreadyExists(name, password))
                {
                    string query = $"UPDATE saves SET gamestate = '{gameStateJson}' WHERE name = '{name}' AND password = '{password}';";
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
                    string query = $"INSERT INTO saves VALUES ('{name}', '{password}', '{gameStateJson}');";
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
        private static bool SaveAlreadyExists(string name, string password)
        {
            const string Query = "SELECT name, password FROM saves;";
            // SQL query to execute.

            bool saveExists = false;
            // save exists flag.

            if (ConnectionString is null)
            {
                ConnectionString = FileOps.GetConnectionString(@"..\..\..\GalaxyWarsClassLibrary\ConnectionString.txt");
            }
            // get connection string if needed.

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
