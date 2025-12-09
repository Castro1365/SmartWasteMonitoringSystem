namespace SmartWasteMonitoringSystem;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.Repo.InitAsync();
        await LoadBinsAsync();
    }

    private async Task LoadBinsAsync()
    {
        var bins = await App.Repo.GetBinsAsync();
        BinsList.ItemsSource = bins;

        var count = await App.Repo.GetBinCountAsync();
        CountLabel.Text = $"Rows in DB: {count}";
    }

    private async void SeedBins(object sender, EventArgs e)
    {
        await App.Repo.InitAsync();
        await App.Repo.SeedDemoBinsAsync();
        await LoadBinsAsync();
        await DisplayAlert("Seeded", "Demo bins saved to SQLite.", "OK");
    }

    private async void ClearAll(object sender, EventArgs e)
    {
        var confirm = await DisplayAlert(
            "Confirm",
            "Clear all bins from SQLite?",
            "Yes", "No");

        if (!confirm) return;

        await App.Repo.DeleteAllBinsAsync();
        await LoadBinsAsync();
    }

    private async void RefreshBins(object sender, EventArgs e)
    {
        await LoadBinsAsync();
    }
}