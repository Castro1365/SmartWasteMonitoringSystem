using SQLite;

namespace SmartWasteMonitoringSystem;

[Table("Bins")]
public class Bin
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Indexed(Unique = true)]
    public string BinIdentifier { get; set; } = string.Empty;

    public string LocationName { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Status { get; set; } = "Empty";
}