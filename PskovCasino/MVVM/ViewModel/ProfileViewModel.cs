using Azure.Identity;
using Microsoft.EntityFrameworkCore;
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
    public class ProfileViewModel : Core.ViewModel
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

        private string _balance;
        public string Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        private int _currentClientStatus;
        public int CurrentClientStatus
        {
            get => _currentClientStatus;
            set
            {
                _currentClientStatus = value;
                OnPropertyChanged(nameof(CurrentClientStatus));
            }
        }

        private List<ClientStatus> _clientStatuses;
        public List<ClientStatus> ClientStatuses
        {
            get => _clientStatuses;
        }
       

        public RelayCommand SaveChangesCommand { get; set; }
        private void SaveChanges()
        {
            _db.Database.ExecuteSql($"""
                UPDATE Clients
                SET Username={Username},
                ClientStatusID={CurrentClientStatus + 1},
                Balance={Balance}
                WHERE ID={Me.ID}
                """);
            _db.SaveChanges();
            _db.Entry(Me).Reload();
            Me = _db.Clients.Include(c => c.ClientStatus).SingleOrDefault(c => c.ID == Me.ID);
        }

        public void SaveChanges(CasinoContext context, Client client)
        {
            context.Clients.Update(client);
            context.SaveChanges();
        }

        public RelayCommand DeleteMeCommand { get; set; }
        private void DeleteMe()
        {
            _db.Database.ExecuteSql($"""
                DELETE FROM Clients
                WHERE ID={Me.ID}
                """);
            _db.SaveChanges();
            Me = new Client();
            Navigation.NavigateTo<RegistrationViewModel>();
        }
        public string DeleteMe(CasinoContext context, Client me)
        {
            context.Clients.Remove(me);
            context.SaveChanges();
            return "OK";
        }


        public ProfileViewModel(INavigationService navService, CasinoContext casinoDbContext, HomeViewModel homeViewModel)
        {
            _navigation = navService;
            _db = casinoDbContext;
            Me = homeViewModel.Me;

            _clientStatuses = _db.ClientStatuses.FromSql($"""
                SELECT * FROM ClientStatuses
                """).ToList();
            CurrentClientStatus = Me.ClientStatusID - 1;
            SaveChangesCommand = new RelayCommand(execute => SaveChanges(), canExecute => true);
            DeleteMeCommand = new RelayCommand(execute => DeleteMe(), canExecute => true);
        }

        public ProfileViewModel()
        {

        }
    }
}
