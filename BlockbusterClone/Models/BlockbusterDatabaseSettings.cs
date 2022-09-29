namespace BlockbusterClone.Models
{
    public class BlockbusterDatabaseSettings : IBlockbusterDatabaseSettings
    {
        public string BlockbusterCollection { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
