using SQLite;

namespace SmartWasteMonitoringSystem;

public class Bin
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(50)]
    public string BinIdentifier { get; set; } = string.Empty;

    [MaxLength(100)]
    public string LocationName { get; set; } = string.Empty;

    [MaxLength(30)]
    public string Status { get; set; } = string.Empty;

    public double Latitude { get; set; }
    public double Longitude { get; set; }
}