using System.IO;

namespace SmartWasteMonitoringSystem;

public partial class App : Application
{
    public static AppRepository Repo { get; private set; } = null!;

    public App()
    {
        InitializeComponent();

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "smartbin.db3");
        Repo = new AppRepository(dbPath);

        // Start at PIN screen
        MainPage = new PinPage();
    }
}