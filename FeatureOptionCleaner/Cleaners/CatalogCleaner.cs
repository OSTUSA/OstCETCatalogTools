using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace FeatureOptionCleaner.Cleaners
{
    public abstract class CatalogCleaner
    {
        /// <summary>
        /// DB connection string
        /// </summary>
        private readonly string _connectionString;


        protected CatalogCleaner(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Query the database with the provided statement and deserializer
        /// </summary>
        /// <typeparam name="T">Deserialized Model type</typeparam>
        /// <param name="commandText">SQL command</param>
        /// <param name="parameters">SQL Command Parameters to add in</param>
        /// <param name="deserializerFuc">Deserializer function</param>
        /// <returns>Deserialized Query Result</returns>
        protected T Query<T>(string commandText, List<KeyValuePair<string, string>> parameters, Func<SqliteDataReader, T> deserializerFuc)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = commandText;
            foreach (var keyValuePair in parameters)
            {
                command.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
            }

            using var reader = command.ExecuteReader();
            var response = deserializerFuc(reader);
            connection.Close();
            return response;
        }

        /// <summary>
        /// Execute Non Query. This is something that does not have a return type like a Delete, insert, ect.
        /// </summary>
        /// <param name="commandText">SQL Command</param>
        /// <param name="parameters">SQL Command parameters</param>
        /// <returns>Number of effected rows.</returns>
        protected int ExecuteNonQuery(string commandText, List<KeyValuePair<string, string>> parameters)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            var command = connection.CreateCommand();
            command.CommandText = commandText;

            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            var numberOfChangedRows = command.ExecuteNonQuery();
            transaction.Commit();
            return numberOfChangedRows;
        }

        /// <summary>
        /// Execute Non Query. DOES NOT SAVE CHANGES. This is something that does not have a return type like a Delete, insert, ect. 
        /// </summary>
        /// <param name="commandText">SQL Command</param>
        /// <param name="parameters">SQL Command parameters</param>
        /// <returns>Number of effected rows.</returns>
        protected int ExecuteNonQueryDryRun(string commandText, List<KeyValuePair<string, string>> parameters)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            var command = connection.CreateCommand();
            command.CommandText = commandText;

            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            var numberOfChangedRows = command.ExecuteNonQuery();
            transaction.Rollback();
            return numberOfChangedRows;
        }

    }
}
