using PskovCasino.Core;
using PskovCasino.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.VisualBasic.Logging;
using PskovCasino.MVVM.Model;
using Microsoft.EntityFrameworkCore;

namespace PskovCasino.MVVM.ViewModel
{
    public class LoginViewModel : Core.ViewModel
    {
        private INavigationService _navigation;
        private readonly CasinoContext _db;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged(nameof(Navigation));
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
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

        public RelayCommand NavigateRegistrationCommand { get; set; }

        public RelayCommand LoginCommand { get; set; }

        private void Login()
        {
            Me = _db.Clients.Include(c => c.ClientStatus).SingleOrDefault(c => c.Username == Username);
            if (Me != null && BCrypt.Net.BCrypt.Verify(Password, Me.Password))
            {
                Navigation.NavigateTo<HomeViewModel>();
            }
        }

        public LoginViewModel(INavigationService navService, CasinoContext casinoDbContext)
        {
            Navigation = navService;
            _db = casinoDbContext;
            NavigateRegistrationCommand = new RelayCommand(execute => Navigation.NavigateTo<RegistrationViewModel>(), canExecute => true);
            LoginCommand = new RelayCommand(execute => Login(), canExecute => true);
        }
    }
}
