using PskovCasino.Core;
using PskovCasino.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged(nameof(Navigation));
            }
        }

        public RelayCommand NavigateHomeCommand { get; set; }
        public RelayCommand NavigateRegistrationCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateHomeCommand = new RelayCommand(execute => Navigation.NavigateTo<HomeViewModel>(), canExecute => true);
            NavigateRegistrationCommand = new RelayCommand(execute => Navigation.NavigateTo<RegistrationViewModel>(), canExecute => true);
            Navigation.NavigateTo<RegistrationViewModel>();
        }
    }
}
