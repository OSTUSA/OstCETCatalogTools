using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace DataLayer.CatalogDb3
{
    public abstract class CetCatalog<TModel>
    {
        /// <summary>
        /// DB connection string
        /// </summary>
        private readonly string _connectionString;

        protected CetCatalog(string connectionString)
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
        protected async Task<IEnumerable<TModel>> QueryAsync(string commandText, List<KeyValuePair<string, string>> parameters)
        {
            await using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = commandText;
            foreach (var keyValuePair in parameters)
            {
                command.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
            }

            await using var reader = await command.ExecuteReaderAsync();
            var response = await DeserializeAsync(reader);
            return response;
        }

        /// <summary>
        /// Execute Non Query. This is something that does not have a return type like a Delete, insert, ect.
        /// </summary>
        /// <param name="commandText">SQL Command</param>
        /// <param name="parameters">SQL Command parameters</param>
        /// <returns>Number of effected rows.</returns>
        protected async Task<int> ExecuteNonQueryAsync(string commandText, List<KeyValuePair<string, string>> parameters)
        {
            await using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            await using var transaction = await connection.BeginTransactionAsync();
            var command = connection.CreateCommand();
            command.CommandText = commandText;

            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            var numberOfChangedRows = await command.ExecuteNonQueryAsync();
            await transaction.CommitAsync();
            return numberOfChangedRows;
        }

        /// <summary>
        /// Execute Non Query. DOES NOT SAVE CHANGES. This is something that does not have a return type like a Delete, insert, ect. 
        /// </summary>
        /// <param name="commandText">SQL Command</param>
        /// <param name="parameters">SQL Command parameters</param>
        /// <returns>Number of effected rows.</returns>
        protected async Task<int> ExecuteNonQueryDryRunAsync(string commandText, List<KeyValuePair<string, string>> parameters)
        {
            await using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            await using var transaction = await connection.BeginTransactionAsync();
            var command = connection.CreateCommand();
            command.CommandText = commandText;

            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            var numberOfChangedRows = await command.ExecuteNonQueryAsync();
            await transaction.RollbackAsync();
            return numberOfChangedRows;
        }

        /// <summary>
        /// Check to see if a query has a row response.
        /// </summary>
        /// <param name="commandText">SQL command</param>
        /// <returns>True if response contains rows.</returns>
        protected async Task<bool> ResponseHasRows(string commandText)
        {
            await using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = commandText;

            await using var reader = await command.ExecuteReaderAsync();
            return reader.HasRows;
        }

        /// <summary>
        /// Checks to see if the meta exists in master table.
        /// </summary>
        /// <param name="type">type to look for</param>
        /// <param name="name">Name of item</param>
        /// <returns>True if result has rows.</returns>
        protected Task<bool> MetaExists(string type, string name)
        {
            var tableCheck =
                $"SELECT name FROM sqlite_master WHERE type='{type}' AND name='{name}'";
            return ResponseHasRows(tableCheck);
        }

        /// <summary>
        /// DeserializeAsync query response into model collection
        /// </summary>
        /// <param name="reader">SqLite Data Reader</param>
        /// <returns>Deserialized Query Result</returns>
        protected abstract Task<IEnumerable<TModel>> DeserializeAsync(SqliteDataReader reader);
    }
}
