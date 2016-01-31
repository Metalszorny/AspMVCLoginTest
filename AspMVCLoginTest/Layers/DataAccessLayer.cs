using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspMVCLoginTest.Layers
{
    /// <summary>
    /// Interaction logic for DataAccessLayer.
    /// </summary>
    public class DataAccessLayer
    {
        #region Fields

        // The database connectionString.
        private string url = "Server=localhost; Database=AspMVCLoginTestDatabase; User id=root; Password=RootUser0123456789;";

        #endregion Fields

        #region Methods

        /// <summary>
        /// Lists the users from the Users table.
        /// </summary>
        /// <returns>The list of users or null.</returns>
        public List<Models.User> ListUsers()
        {
            try
            {
                // Open a connection to the database.
                SqlConnection msSqlConnection = new SqlConnection(url);
                msSqlConnection.Open();

                // Get the items from the Users table.
                List<Models.User> users = new List<Models.User>();
                SqlCommand msSqlCommand = new SqlCommand("SELECT * FROM [AspMVCLoginTestDatabase].[dbo].[Users] WHERE IsDeleted = 0", msSqlConnection);

                // Execute.
                SqlDataReader msSqlDataReader = msSqlCommand.ExecuteReader();

                // Store the items in a User list.
                while (msSqlDataReader.Read())
                {
                    users.Add(new Models.User(msSqlDataReader.GetInt32(0), msSqlDataReader.GetString(1), msSqlDataReader.GetString(2), 
                        msSqlDataReader.GetDateTime(4), msSqlDataReader.GetBoolean(5)));
                }

                // Close the datareader and the connection.
                msSqlDataReader.Close();
                msSqlConnection.Close();

                return users;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Adds a user to the Users table.
        /// </summary>
        /// <param name="name">The name for the user.</param>
        /// <param name="email">The email for the user.</param>
        /// <param name="password">The password for the user.</param>
        /// <returns>The outcome of the method.</returns>
        public bool AddUser(string name, string email, string password)
        {
            try
            {
                int id = 0;

                // Open a connection to the database.
                SqlConnection msSqlConnection = new SqlConnection(url);
                msSqlConnection.Open();

                // Get the items from the Users table.
                SqlCommand msSqlCommand1 = new SqlCommand("SELECT * FROM [AspMVCLoginTestDatabase].[dbo].[Users]", msSqlConnection);

                // Execute.
                SqlDataReader msSqlDataReader = msSqlCommand1.ExecuteReader();

                // Get the number of the existing items.
                while (msSqlDataReader.Read())
                {
                    id++;
                }

                // Close the datareader.
                msSqlDataReader.Close();

                // Add new item to the Users table.
                SqlCommand msSqlCommand = new SqlCommand("INSERT INTO [AspMVCLoginTestDatabase].[dbo].[Users] (Id, Name, Email, Password, RegistrationDate, IsDeleted) VALUES (@param1, @param2, @param3, @param4, @param5, @param6)", msSqlConnection);

                // Fill the values of the command.
                msSqlCommand.Parameters.AddWithValue("@param1", id + 1);
                msSqlCommand.Parameters.AddWithValue("@param2", name);
                msSqlCommand.Parameters.AddWithValue("@param3", email);
                msSqlCommand.Parameters.AddWithValue("@param4", password);
                msSqlCommand.Parameters.AddWithValue("@param5", DateTime.Now);
                msSqlCommand.Parameters.AddWithValue("@param6", false);

                // Execute.
                msSqlCommand.ExecuteNonQuery();

                // Close the connection.
                msSqlConnection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Edits a user in the Users table.
        /// </summary>
        /// <param name="input">The values of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The outcome of the method.</returns>
        public bool EditUser(Models.User input, string password)
        {
            try
            {
                // Open a connection to the database.
                SqlConnection msSqlConnection = new SqlConnection(url);
                msSqlConnection.Open();

                // Update the values in the Users table.
                SqlCommand msSqlCommand = new SqlCommand("UPDATE [AspMVCLoginTestDatabase].[dbo].[Users] SET Name = @param2, Email = @param3, Password = @param4 WHERE Id = @param1", msSqlConnection);

                // Fill the values of the command.
                msSqlCommand.Parameters.AddWithValue("@param1", input.Id);
                msSqlCommand.Parameters.AddWithValue("@param2", input.Name);
                msSqlCommand.Parameters.AddWithValue("@param3", input.Email);
                msSqlCommand.Parameters.AddWithValue("@param4", password);

                // Execute.
                msSqlCommand.ExecuteNonQuery();

                // Close the connection.
                msSqlConnection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes a user in the Users table.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The outcome of the method.</returns>
        public bool DeleteUser(int id)
        {
            try
            {
                // Open a connection to the database.
                SqlConnection msSqlConnection = new SqlConnection(url);
                msSqlConnection.Open();

                // Edit the IsDeleted value to true.
                SqlCommand msSqlCommand = new SqlCommand("UPDATE [AspMVCLoginTestDatabase].[dbo].[Users] SET IsDeleted = @param2 WHERE Id = @param1", msSqlConnection);

                // Fill the values of the command.
                msSqlCommand.Parameters.AddWithValue("@param1", id);
                msSqlCommand.Parameters.AddWithValue("@param2", true);

                // Execute.
                msSqlCommand.ExecuteNonQuery();

                // Close the connection.
                msSqlConnection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Finds a user by id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The list of users or null.</returns>
        public List<Models.User> FindUserById(int id)
        {
            try
            {
                // Open a connection to the database.
                SqlConnection msSqlConnection = new SqlConnection(url);
                msSqlConnection.Open();

                // Get the items from the Users table.
                List<Models.User> users = new List<Models.User>();
                SqlCommand msSqlCommand = new SqlCommand("SELECT * FROM [AspMVCLoginTestDatabase].[dbo].[Users] WHERE Id = @param1", msSqlConnection);

                // Fill the values of the command.
                msSqlCommand.Parameters.AddWithValue("@param1", id);

                // Execute.
                SqlDataReader msSqlDataReader = msSqlCommand.ExecuteReader();

                // Store the items in a User object.
                while (msSqlDataReader.Read())
                {
                    users.Add(new Models.User(msSqlDataReader.GetInt32(0), msSqlDataReader.GetString(1), msSqlDataReader.GetString(2),
                        msSqlDataReader.GetDateTime(4), msSqlDataReader.GetBoolean(5)));
                }

                // Close the datareader and the connection.
                msSqlDataReader.Close();
                msSqlConnection.Close();

                return users;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Finds a user by email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>The list of users or null.</returns>
        public List<Models.User> FindUserByEmail(string email)
        {
            try
            {
                // Open a connection to the database.
                SqlConnection msSqlConnection = new SqlConnection(url);
                msSqlConnection.Open();

                // Get the items from the Users table.
                List<Models.User> users = new List<Models.User>();
                SqlCommand msSqlCommand = new SqlCommand("SELECT * FROM [AspMVCLoginTestDatabase].[dbo].[Users] WHERE Email = @param1", msSqlConnection);

                // Fill the values of the command.
                msSqlCommand.Parameters.AddWithValue("@param1", email);

                // Execute.
                SqlDataReader msSqlDataReader = msSqlCommand.ExecuteReader();

                // Store the items in a User object.
                while (msSqlDataReader.Read())
                {
                    users.Add(new Models.User(msSqlDataReader.GetInt32(0), msSqlDataReader.GetString(1), msSqlDataReader.GetString(2),
                        msSqlDataReader.GetDateTime(4), msSqlDataReader.GetBoolean(5)));
                }

                // Close the datareader and the connection.
                msSqlDataReader.Close();
                msSqlConnection.Close();

                return users;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Finds a user by password.
        /// </summary>
        /// <param name="password">The password of the user.</param>
        /// <returns>The list of users or null.</returns>
        public List<Models.User> FindUserById(string password)
        {
            try
            {
                // Open a connection to the database.
                SqlConnection msSqlConnection = new SqlConnection(url);
                msSqlConnection.Open();

                // Get the items from the Users table.
                List<Models.User> users = new List<Models.User>();
                SqlCommand msSqlCommand = new SqlCommand("SELECT * FROM [AspMVCLoginTestDatabase].[dbo].[Users] WHERE Password = @param1", msSqlConnection);

                // Fill the values of the command.
                msSqlCommand.Parameters.AddWithValue("@param1", password);

                // Execute.
                SqlDataReader msSqlDataReader = msSqlCommand.ExecuteReader();

                // Store the items in a User object.
                while (msSqlDataReader.Read())
                {
                    users.Add(new Models.User(msSqlDataReader.GetInt32(0), msSqlDataReader.GetString(1), msSqlDataReader.GetString(2),
                        msSqlDataReader.GetDateTime(4), msSqlDataReader.GetBoolean(5)));
                }

                // Close the datareader and the connection.
                msSqlDataReader.Close();
                msSqlConnection.Close();

                return users;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Finds a user by email and password.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The list of users or null.</returns>
        public List<Models.User> FindUserByEmailAndPassword(string email, string password)
        {
            try
            {
                // Open a connection to the database.
                SqlConnection msSqlConnection = new SqlConnection(url);
                msSqlConnection.Open();

                // Get the items from the Users table.
                List<Models.User> users = new List<Models.User>();
                SqlCommand msSqlCommand = new SqlCommand("SELECT * FROM [AspMVCLoginTestDatabase].[dbo].[Users] WHERE Email = @param1 AND Password = @param2", msSqlConnection);

                // Fill the values of the command.
                msSqlCommand.Parameters.AddWithValue("@param1", email);
                msSqlCommand.Parameters.AddWithValue("@param2", password);

                // Execute.
                SqlDataReader msSqlDataReader = msSqlCommand.ExecuteReader();

                // Store the items in a User object.
                while (msSqlDataReader.Read())
                {
                    users.Add(new Models.User(msSqlDataReader.GetInt32(0), msSqlDataReader.GetString(1), msSqlDataReader.GetString(2),
                        msSqlDataReader.GetDateTime(4), msSqlDataReader.GetBoolean(5)));
                }

                // Close the datareader and the connection.
                msSqlDataReader.Close();
                msSqlConnection.Close();

                return users;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Finds a user by email or password.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The list of users or null.</returns>
        public List<Models.User> FindUserByEmailOrPassword(string email, string password)
        {
            try
            {
                // Open a connection to the database.
                SqlConnection msSqlConnection = new SqlConnection(url);
                msSqlConnection.Open();

                // Get the items from the Users table.
                List<Models.User> users = new List<Models.User>();
                SqlCommand msSqlCommand = new SqlCommand("SELECT * FROM [AspMVCLoginTestDatabase].[dbo].[Users] WHERE Email = @param1 OR Password = @param2", msSqlConnection);

                // Fill the values of the command.
                msSqlCommand.Parameters.AddWithValue("@param1", email);
                msSqlCommand.Parameters.AddWithValue("@param2", password);

                // Execute.
                SqlDataReader msSqlDataReader = msSqlCommand.ExecuteReader();

                // Store the items in a User object.
                while (msSqlDataReader.Read())
                {
                    users.Add(new Models.User(msSqlDataReader.GetInt32(0), msSqlDataReader.GetString(1), msSqlDataReader.GetString(2),
                        msSqlDataReader.GetDateTime(4), msSqlDataReader.GetBoolean(5)));
                }

                // Close the datareader and the connection.
                msSqlDataReader.Close();
                msSqlConnection.Close();

                return users;
            }
            catch
            {
                return null;
            }
        }

        #endregion Methods
    }
}