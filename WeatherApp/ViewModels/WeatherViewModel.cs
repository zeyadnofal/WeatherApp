using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private WeatherModel _weather;
        private readonly WeatherService _weatherService;
        public string _cityName;
        private readonly IDialogCoordinator _dialogCoordinator;

        public WeatherModel Weather
        {
            get => _weather;
            set
            {
                _weather = value;
                OnPropertyChanged();
            }
        }

        public string CityName
        {
            get => _cityName;
            set
            {
                _cityName = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; }

        public WeatherViewModel(IDialogCoordinator dialogCoordinator)
        {
            _weatherService = new WeatherService();
            _dialogCoordinator = dialogCoordinator ?? throw new ArgumentNullException(nameof(dialogCoordinator));
            SearchCommand = new RelayCommand(async _ => await LoadWeatherAsync());
            CityName = "London";
            LoadWeatherAsync().ConfigureAwait(false);
        }
        private async Task LoadWeatherAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(CityName))
                {
                    Weather = await _weatherService.GetWeatherAsync(CityName);
                }
            }
            catch (HttpRequestException)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error", "City not found");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));

            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
