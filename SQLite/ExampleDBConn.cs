using SQLite.Schemas;
using UnityEngine;

namespace SQLite
{
    public class ExampleDBConn: DatabaseManager
    {
        private async void Start()
        {
            // Clear all entries in the User table
            await Connection.DropTableAsync<ExampleSchema>();
        
            // Ensure the User table is created
            await CreateTableAsync<ExampleSchema>();


            var newUser = new ExampleSchema()
            {
                Name = "John Doe",
            };

            await InsertRecordAsync(newUser);

            var users = await GetAllRecordsAsync<ExampleSchema>();
            foreach (var user in users)
            {
                Debug.Log($"ID: {user.ID}, Name: {user.Name}");
            }
        }
    }
}