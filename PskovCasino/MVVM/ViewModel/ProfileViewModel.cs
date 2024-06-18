using Azure.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PskovCasino.Core;
using PskovCasino.MVVM.Model;
using PskovCasino.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.ViewModel
{
    public class ProfileViewModel: Core.ViewModel
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

        private Client _me;
        public Client Me
        {
            get => _me;
            set
            {
                _me = value;
                OnPropertyChanged(nameof(Client));
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

        public string _balance;
        public string Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        public int _clientStatus;
        public int ClientStatus
        {
            get => _clientStatus;
            set
            {
                _clientStatus = value;
                OnPropertyChanged(nameof(ClientStatus));
            }
        }

        public RelayCommand SaveChangesCommand { get; set; }
        private void SaveChanges()
        {

        }

        public ProfileViewModel(INavigationService navService, CasinoContext casinoDbContext, HomeViewModel homeViewModel)
        {
            _navigation = navService;
            _db = casinoDbContext;
            Me = homeViewModel.Me;
        }
    }
}
