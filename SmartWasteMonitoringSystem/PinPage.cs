using System;
using System.Linq;
using Microsoft.Maui.Storage;

namespace SmartWasteMonitoringSystem;

public class PinPage : ContentPage
{
    private readonly Label _titleLabel;
    private readonly Entry _pinEntry;
    private readonly Button _confirmButton;

    private bool _isSetMode;

    public PinPage()
    {
        _titleLabel = new Label
        {
            Text = "Set your 4-digit PIN",
            FontSize = 22,
            HorizontalOptions = LayoutOptions.Center
        };

        _pinEntry = new Entry
        {
            Placeholder = "Enter 4-digit PIN",
            IsPassword = true,
            Keyboard = Keyboard.Numeric,
            MaxLength = 4,
            HorizontalOptions = LayoutOptions.Fill
        };

        _confirmButton = new Button
        {
            Text = "Continue"
        };
        _confirmButton.Clicked += OnConfirmPin;

        Content = new VerticalStackLayout
        {
            Padding = 24,
            Spacing = 16,
            Children =
            {
                _titleLabel,
                _pinEntry,
                _confirmButton
            }
        };

        Title = "Security";
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var storedHash = await SecureStorage.GetAsync("pinHash");
        _isSetMode = string.IsNullOrEmpty(storedHash);

        if (_isSetMode)
        {
            _titleLabel.Text = "Set your 4-digit PIN";
            _confirmButton.Text = "Save PIN";
        }
        else
        {
            _titleLabel.Text = "Enter your PIN";
            _confirmButton.Text = "Unlock";
        }
    }

    private async void OnConfirmPin(object? sender, EventArgs e)
    {
        var pin = _pinEntry.Text?.Trim() ?? string.Empty;

        if (pin.Length != 4 || !pin.All(char.IsDigit))
        {
            await DisplayAlert("Invalid PIN", "PIN must be exactly 4 digits.", "OK");
            return;
        }

        var storedHash = await SecureStorage.GetAsync("pinHash");

        if (_isSetMode)
        {
            await SecureStorage.SetAsync("pinHash", PinHasher.Hash(pin));
            await DisplayAlert("PIN Saved", "Your PIN was saved.", "OK");
            Application.Current!.MainPage = new AppShell();   // OK if this gives a yellow warning
        }
        else
        {
            if (storedHash is not null && PinHasher.Verify(pin, storedHash))
            {
                await DisplayAlert("Unlocked", "PIN is correct.", "OK");
                Application.Current!.MainPage = new AppShell();
            }
            else
            {
                await DisplayAlert("Error", "Incorrect PIN. Try again.", "OK");
            }
        }
    }
}