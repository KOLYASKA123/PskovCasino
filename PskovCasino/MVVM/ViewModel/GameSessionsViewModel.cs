using PskovCasino.MVVM.Model;
using PskovCasino.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.ViewModel
{
    public class GameSessionsViewModel : Core.ViewModel
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

        private ObservableCollection<GameSession> _gameSessions;

        public ObservableCollection<GameSession> GameSessions
        {
            get => _gameSessions;
            set
            {
                _gameSessions = value;
                OnPropertyChanged(nameof(GameSessions));
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

        private void GameSessions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Обработка изменений в коллекции
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (GameSession item in e.NewItems)
                    {
                        
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (GameSession item in e.OldItems)
                    {
                        
                    }
                    break;
            }
        }

        public GameSessionsViewModel(INavigationService navService, CasinoContext casinoDbContext, HomeViewModel homeViewModel)
        {
            _navigation = navService;
            _db = casinoDbContext;
            Me = homeViewModel.Me;
            GameSessions = new ObservableCollection<GameSession>([.. _db.GameSessions]);
            GameSessions.CollectionChanged += GameSessions_CollectionChanged;
        }
    }
}
