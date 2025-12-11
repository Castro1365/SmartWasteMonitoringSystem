## Smart Waste Monitoring System — .NET MAUI App with SQLite

### Team Members:

- Castro Fokou

- Rupesh Nepal

----

### Project Overview

The Smart Waste Monitoring System is a mobile/desktop application built with .NET MAUI that allows municipalities and organizations to efficiently monitor the status of waste bins.
The app stores all bin information locally using an SQLite database and uses a PIN security system for user authentication.

This project serves as an example of a modern, multi-layered MAUI application with:

- Clean architecture

- Repository pattern

- Native device features

- Local persistence

- A custom security layer

----

### Main Features

#### 1. PIN Security

The first time the app runs, the user must create a PIN.
The PIN is saved in local storage after being hashed.
On future app launches, the user is asked to enter it again before accessing the dashboard.


#### 2. Dashboard

The dashboard shows all bins currently in the SQLite database.

Each bin has:

- An identifier

- A location name

- A fill status

The list can be expanded later with more features.


#### 3. Local Database

All data is stored using SQLite.

We created a small repository class (AppRepository) to handle:

- Reading/writing bins

- Storing demo bins

- Adding sensor readings

- Getting the latest reading for a bin

This keeps our database code in one place and makes the app easier to maintain.

----

### Project Structure

Here is a simple overview of how the project is organized:
```bash
SmartWasteMonitoringSystem/
│
├── Data/              (SQLite repository)
│       AppRepository.cs
│
├── Models/            (Data models)
│       Bin.cs
│       SensorReading.cs
│
├── Services/          (Security helpers, hashing)
│       PinHasher.cs
│
├── UI Pages/          (Visual pages)
│       PinPage.xaml
│       DashboardPage.xaml
│       ReportsPage.xaml
│
├── App.xaml           (App-level resources)
├── App.xaml.cs        (Startup logic)

```

This layout keeps the code easy to navigate and separates responsibilities properly.

----

### How to Run the App

#### Requirements

- Visual Studio 2022

- .NET 8 / .NET 9 MAUI workload installed

#### Steps

1. Clone the repository

2. Open the solution in Visual Studio

3. Restore NuGet packages

4. Choose a target (Windows Machine or Android Emulator)

5. Press Run

----

### Screenshot Images

Below are the main screens of the Smart Waste Monitoring System:

#### 1. PIN Setup Page 

This screen appears the first time the user opens the app.
They must create a 4-digit PIN before accessing the dashboard.

```bash
/Images/Pin setup page.png
```

#### 2. PIN Unlock Page

On future launches, the user must enter the saved PIN to unlock the application.

```bash
SmartWasteMonitoringSystem/Pin unlock page.png
```

#### 3. Home Page

This is the main navigation screen users see after entering their PIN.  
It provides access to the Dashboard, Alerts, and Reports.
```bash
SmartWasteMonitoringSystem/Home page.png
```

#### 4. Dashboard Page

After unlocking, the dashboard displays a list of bins stored in the SQLite database.

Each bin shows its name and status.
```bash
SmartWasteMonitoringSystem/Dashboard page.png
```

----

### Automated Testing (MSTest)

The project includes an automated test project named
```bash
SmartWasteMonitoringSystem.Tests
```
These tests verify that the app’s security feature (PIN hashing and verification) behaves correctly.

#### 1. What is tested?

- Hashing always produces a non-empty value

- Hashing the same PIN produces the same result

- VerifyPassword() returns true for the correct PIN

- VerifyPassword() returns false for the incorrect PINs

#### 2. Test Results

All tests pass successfully (4 tests total):
```bash
- Hash_GivesSameResult_ForSameInput

- Hash_IsNotEmpty

- Verify_ReturnsTrue_ForCorrectPin

- Verify_ReturnsFalse_ForWrongPin
```
These tests help ensure that the authentication logic remains reliable as the app evolves.

----

### About the Project

This application was created by Castro Fokou and Rupesh Nepal as part of our semester-long capstone project.
The objective was to build a working MAUI application that follows good structure, uses local persistence, and includes at least one native or security feature.
