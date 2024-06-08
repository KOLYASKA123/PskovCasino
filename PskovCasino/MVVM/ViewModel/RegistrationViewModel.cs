using Microsoft.EntityFrameworkCore;
using PskovCasino.Core;
using PskovCasino.MVVM.Model;
using PskovCasino.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;


namespace PskovCasino.MVVM.ViewModel
{
    public class RegistrationViewModel : Core.ViewModel
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

        private string _retypePassword;
        public string RetypePassword
        {
            get => _retypePassword;
            set
            {
                _retypePassword = value;
                OnPropertyChanged(nameof(RetypePassword));
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

        public RelayCommand NavigateLoginCommand { get; set; }
        public RelayCommand RegisterCommand { get; set; }

        private void RegisterNewClient()
        {
            if (Password == RetypePassword)
            {
                Me = new()
                {
                    Username = Username,
                    Password = BCrypt.Net.BCrypt.HashPassword(Password),
                    Balance = 0,
                    ClientStatusID = 1
                };
                _db.Clients.Add(Me);
                _db.SaveChanges();
                Navigation.NavigateTo<HomeViewModel>();
            }
        }

        public RegistrationViewModel(INavigationService navService, CasinoContext casinoDbContext)
        {
            Navigation = navService;
            _db = casinoDbContext;
            NavigateLoginCommand = new RelayCommand(execute => Navigation.NavigateTo<LoginViewModel>(), canExecute => true);
            RegisterCommand = new RelayCommand(execute => RegisterNewClient(), canExecute => true);
        }
    }
}
