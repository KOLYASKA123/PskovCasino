using PskovCasino.Core;
using PskovCasino.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PskovCasino.MVVM.Model;

namespace PskovCasino.MVVM.ViewModel
{
    public class HomeViewModel : Core.ViewModel
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

        private Client _me;
        public Client Me
        {
            get => _me;
            set
            {
                _me = value;
                OnPropertyChanged(nameof(Me));
            }
        }

        public RelayCommand NavigateProfileCommand { get; set; }
        public RelayCommand NavigateGameSessionsCommand { get; set; }

        public HomeViewModel(INavigationService navService, RegistrationViewModel registrationViewModel, LoginViewModel loginViewModel)
        {
            Me = registrationViewModel.Me is null ? loginViewModel.Me : registrationViewModel.Me;
            Navigation = navService;
            NavigateProfileCommand = new RelayCommand(execute => Navigation.HomeNavigateTo<ProfileViewModel>(), canExecute => true);
            NavigateGameSessionsCommand = new RelayCommand(execute => Navigation.HomeNavigateTo<GameSessionsViewModel>(), canExecute => true);
        }
    }
}
