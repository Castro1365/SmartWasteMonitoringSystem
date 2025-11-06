using SQLite;

namespace SmartWasteMonitoringSystem;

[Table("SensorReadings")]
public class SensorReading
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int BinId { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public double FillLevel { get; set; }
    public double BatteryLevel { get; set; }
}