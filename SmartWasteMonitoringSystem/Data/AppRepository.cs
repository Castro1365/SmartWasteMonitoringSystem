using System.IO;
using SQLite;

namespace SmartWasteMonitoringSystem;

public class AppRepository
{
    private readonly SQLiteAsyncConnection _db;
    private bool _initialized;

    public AppRepository(string dbPath)
    {
        _db = new SQLiteAsyncConnection(dbPath);
    }

    public async Task InitAsync()
    {
        if (_initialized) return;

        await _db.CreateTableAsync<Bin>();
        await _db.CreateTableAsync<SensorReading>();

        _initialized = true;
    }

    // ---------- BINS ----------

    public Task<List<Bin>> GetBinsAsync() =>
        _db.Table<Bin>().ToListAsync();

    public Task<int> AddBinAsync(Bin bin) =>
        _db.InsertAsync(bin);

    public Task<int> DeleteAllBinsAsync() =>
        _db.DeleteAllAsync<Bin>();

    public Task<int> GetBinCountAsync() =>
        _db.Table<Bin>().CountAsync();

    public async Task SeedDemoBinsAsync()
    {
        if (await _db.Table<Bin>().CountAsync() > 0)
            return;

        var demo = new[]
        {
            new Bin { BinIdentifier="BIN-001", LocationName="Elm Street",     Status="Full",      Latitude=46.49, Longitude=-80.99 },
            new Bin { BinIdentifier="BIN-002", LocationName="Notre Dame Ave", Status="Half-Full", Latitude=46.50, Longitude=-80.98 },
            new Bin { BinIdentifier="BIN-003", LocationName="Lasalle Blvd",   Status="Empty",     Latitude=46.51, Longitude=-81.00 }
        };

        await _db.InsertAllAsync(demo);
    }

    // ---------- SENSOR READINGS (optional for later) ----------

    public Task<int> AddReadingAsync(SensorReading reading) =>
        _db.InsertAsync(reading);

    public Task<SensorReading?> GetLatestReadingAsync(int binId) =>
        _db.Table<SensorReading>()
           .Where(r => r.BinId == binId)
           .OrderByDescending(r => r.Timestamp)
           .FirstOrDefaultAsync();
}