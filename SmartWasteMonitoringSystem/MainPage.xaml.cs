namespace SmartWasteMonitoringSystem;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void GoToDashboard(object sender, EventArgs e) =>
        await Navigation.PushAsync(new DashboardPage());

    private async void GoToAlerts(object sender, EventArgs e) =>
        await Navigation.PushAsync(new AlertsPage());

    private async void GoToReports(object sender, EventArgs e) =>
        await Navigation.PushAsync(new ReportsPage());
}