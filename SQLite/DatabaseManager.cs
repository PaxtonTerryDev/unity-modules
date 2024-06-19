using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite.Schemas;
using UnityEngine;
namespace SQLite
{
   /// <summary>
/// Manages the SQLite database connection and operations asynchronously, so it doesn't block any threads. 
/// </summary>
public class DatabaseManager : MonoBehaviour
{
    private string _dbPath;
    protected SQLiteAsyncConnection Connection;

    /// <summary>
    /// Initializes the database connection.
    /// </summary>
    private async void Awake()
    {
        _dbPath = Path.Combine(Application.persistentDataPath, "mydatabase.db");
        Connection = new SQLiteAsyncConnection(_dbPath);
        Debug.Log($"Database created at: {_dbPath}");

        // Ensure the database is created and tables are set up on startup
        await CreateTableAsync<ExampleSchema>();
    }

    /// <summary>
    /// Creates a table if it does not already exist asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the table to create.</typeparam>
    public async Task CreateTableAsync<T>() where T : new()
    {
        await Connection.CreateTableAsync<T>();
        Debug.Log($"Table {typeof(T).Name} created.");
    }

    /// <summary>
    /// Inserts a new record into the specified table asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the record to insert.</typeparam>
    /// <param name="record">The record to insert.</param>
    public async Task InsertRecordAsync<T>(T record) where T : new()
    {
        await Connection.InsertAsync(record);
        Debug.Log($"Record inserted into table {typeof(T).Name}.");
    }

    /// <summary>
    /// Retrieves all records from the specified table asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the records to retrieve.</typeparam>
    /// <returns>A list of records from the table.</returns>
    public async Task<List<T>> GetAllRecordsAsync<T>() where T : new()
    {
        return await Connection.Table<T>().ToListAsync();
    }

    /// <summary>
    /// Closes the database connection asynchronously.
    /// </summary>
    private async void OnDestroy()
    {
        await Connection.CloseAsync();
        Debug.Log("Database connection closed.");
    }
}
}
