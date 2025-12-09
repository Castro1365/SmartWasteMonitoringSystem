using SQLite;

namespace SmartWasteMonitoringSystem;

public class SensorReading
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int BinId { get; set; }

    public double FillPercent { get; set; }

    public DateTime Timestamp { get; set; }
}