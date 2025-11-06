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
    }

    private async void SeedBins(object sender, EventArgs e)
    {
        await App.Repo.InitAsync();
        await App.Repo.SeedDemoBinsAsync();
        await LoadBinsAsync();
        await DisplayAlert("Seeded", "Demo bins saved to SQLite.", "OK");
    }

    private async void RefreshBins(object sender, EventArgs e)
    {
        await LoadBinsAsync();
    }
}