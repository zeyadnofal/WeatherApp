# WPF Weather App

A simple WPF weather application using MahApps.Metro UI and the OpenWeatherMap API.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)

## Introduction

This project is a WPF weather application that provides current weather information for a specified city. It uses the MahApps.Metro library for a modern UI look and feel and integrates with the OpenWeatherMap API to fetch weather data.

## Features

- Search for weather information by city name.
- Display current temperature, weather description, and city name.
- Error handling for invalid city names using MahApps.Metro dialogs.

## Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- An API key from [OpenWeatherMap](https://openweathermap.org/api)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/WPFWeatherApp.git
   cd WPFWeatherApp
   ```
2. Open the project in Visual Studio.

3. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```
4. Add your OpenWeatherMap API key in the `WeatherService.cs` file:
  ```cs
  private const string ApiKey = "YOUR_API_KEY";
  ```
5. Build and run the project.

### Usage
1. Launch the application.
2. Enter the city name in the textbox.
3. Click the "Search" button to fetch and display the weather information.

### Project Structure
```
WPFWeatherApp/
├── Models/
│   └── WeatherModel.cs
├── Services/
│   └── WeatherService.cs
├── ViewModels/
│   └── WeatherViewModel.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── App.xaml
├── App.xaml.cs
└── README.md
```

### Explanation
- Models: Contains data models for the application.
- Services: Contains services for fetching data from external APIs.
- ViewModels: Contains the ViewModel classes following the MVVM pattern.
- MainWindow.xaml: The main window of the application.
- MainWindow.xaml.cs: Code-behind for the main window.
- App.xaml: Application-level XAML file.
- App.xaml.cs: Application-level code-behind file.

### Contributing
Contributions are welcome! Please fork the repository and submit a pull request with your changes.

1. Fork the repository.
2. Create a new branch: git checkout -b feature-branch.
3. Make your changes and commit them: git commit -m 'Add some feature'.
4. Push to the branch: git push origin feature-branch.
5. Submit a pull request.

Replace `https://github.com/yourusername/WPFWeatherApp.git` with the actual URL of your GitHub repository.  
Also, make sure to update the `ApiKey` value in the `WeatherService.cs` file with your actual OpenWeatherMap API key.
