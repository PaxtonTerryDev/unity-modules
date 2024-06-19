namespace SQLite.Schemas
{
    public class ExampleSchema
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}