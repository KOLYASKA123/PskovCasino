﻿using Microsoft.EntityFrameworkCore;
using PskovCasino.Core;
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

        public RelayCommand ConnectCommand { get; set; }

        
        /// <summary>
        /// Позволяет подключиться к игровой сессии по ID.
        /// </summary>
        /// <param name="id">ID игровой сессии</param>
        private void Connect(object id)
        {
            var ID = (int)id;
        }

        public RelayCommand DisconnectCommand { get; set; }

        

        public GameSessionsViewModel(INavigationService navService, CasinoContext casinoDbContext, HomeViewModel homeViewModel)
        {
            _navigation = navService;
            _db = casinoDbContext;
            Me = homeViewModel.Me;
            
            GameSessions = new ObservableCollection<GameSession>(
                _db.GameSessions.FromSql(
                    $"""
                    SELECT gs.ID, gs.MimimalParticipantsCountToStart, gt.ID AS GameTypeID, gt.Name AS GameTypeName
                    FROM GameSessions gs
                    JOIN GameTypes gt ON gt.ID = gs.GameTypeID
                    """).Include(gs => gs.GameType).ToList());
            GameSessions.CollectionChanged += GameSessions_CollectionChanged;
            ConnectCommand = new RelayCommand(Connect, canExecute => true);
        }
    }
}
