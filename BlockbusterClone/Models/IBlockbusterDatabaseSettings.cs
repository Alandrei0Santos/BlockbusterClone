namespace BlockbusterClone.Models
{
    public interface IBlockbusterDatabaseSettings
    {
        string BlockbusterCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
