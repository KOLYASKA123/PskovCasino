using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PskovCasino.Core;
using PskovCasino.MVVM.Model;
using PskovCasino.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Windows.Data;

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

        private List<GameType> _gameTypes;
        public List<GameType> GameTypes
        {
            get => _gameTypes;
        }

        private List<GameType> _gameTypesForCreating;
        public List<GameType> GameTypesForCreating
        {
            get => _gameTypesForCreating;
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

        private int _currentGameSessionID;
        public int CurrentGameSessionID
        {
            get => _currentGameSessionID;
            set
            {
                _currentGameSessionID = value;
                OnPropertyChanged(nameof(CurrentGameSessionID));
            }
        }

        private string _filterID;
        public string FilterID
        {
            get => _filterID;
            set
            {
                _filterID = value;
                OnPropertyChanged(nameof(FilterID));
            }
        }

        private int _filterGameType;
        public int FilterGameType
        {
            get => _filterGameType;
            set
            {
                _filterGameType = value;
                OnPropertyChanged(nameof(FilterGameType));
            }
        }

        private int _selectedGameTypeForCreating;
        public int SelectedGameTypeForCreating
        {
            get => _selectedGameTypeForCreating;
            set
            {
                _selectedGameTypeForCreating = value;
                OnPropertyChanged(nameof(SelectedGameTypeForCreating));
            }
        }

        private string _filterMinimalParticipantsCountToStart;
        public string FilterMinimalParticipantsCountToStart
        {
            get => _filterMinimalParticipantsCountToStart;
            set
            {
                _filterMinimalParticipantsCountToStart = value;
                OnPropertyChanged(nameof(FilterMinimalParticipantsCountToStart));
            }
        }

        private string _minimalParticipantsCountToStartForCreating;
        public string MinimalParticipantsCountToStartForCreating
        {
            get => _minimalParticipantsCountToStartForCreating;
            set
            {
                _minimalParticipantsCountToStartForCreating = value;
                OnPropertyChanged(nameof(MinimalParticipantsCountToStartForCreating));
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

        private void GameParticipants_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }

        public RelayCommand ConnectCommand { get; set; }
        /// <summary>
        /// Позволяет присоединиться к игровой сессии по ID.
        /// </summary>
        /// <param name="id">ID игровой сессии</param>
        private void Connect(object id)
        {
            var ID = (int)id;
            CurrentGameSessionID = ID;
            _db.Database.ExecuteSql(
                $"""
                INSERT INTO GameParticipants (ClientID, GameSessionID, InitialPayment, WinPayment)
                VALUES ({Me.ID}, {ID}, 0, 0)
                """
                );
            _db.SaveChanges();
        }

        public string Connect(CasinoContext context, int id)
        {
            context.GameParticipants.Add(
                new GameParticipant
                {
                    ClientID = Me.ID,
                    GameSessionID = id,
                    InitialPayment = 0,
                    WinPayment = 0,
                });
            context.SaveChanges();
            return "OK";
        }

        public RelayCommand DisconnectCommand { get; set; }
        /// <summary>
        /// Позволяет покинуть игровую сессию по ID.
        /// </summary>
        /// <param name="id">ID игровой сессии</param>
        private void Disconnect(object id)
        {
            var ID = (int)id;
            CurrentGameSessionID = 0;
            _db.Database.ExecuteSql(
                $"""
                DELETE FROM GameParticipants
                WHERE GameSessionID = {ID} AND ClientID = {Me.ID}
                """
                );
            _db.SaveChanges();
        }

        public string Disconnect(CasinoContext context, GameParticipant me)
        {
            context.GameParticipants.Remove(me);
            context.SaveChanges();
            return "OK";
        }


        public RelayCommand FilterCommand { get; set; }
        private void Filter()
        {
            var filters = new List<string>();
            var parameters = new List<object>();

            if (!string.IsNullOrEmpty(FilterID))
            {
                filters.Add("ID = @p0");
                parameters.Add(new SqliteParameter("@p0", FilterID));
            }
            if (FilterGameType != 5)
            {
                filters.Add("GameTypeID = @p1");
                parameters.Add(new SqliteParameter("@p1", FilterGameType + 1));
            }
            if (!string.IsNullOrEmpty(FilterMinimalParticipantsCountToStart))
            {
                filters.Add("MimimalParticipantsCountToStart = @p2");
                parameters.Add(new SqliteParameter("@p2", FilterMinimalParticipantsCountToStart));
            }

            string query;
            if (filters.Count > 0)
            {
                string condition = string.Join(" AND ", filters);
                query = $"""
            SELECT ID, GameTypeID, MimimalParticipantsCountToStart 
            FROM GameSessions 
            WHERE {condition}
        """;
            }
            else
            {
                query = "SELECT * FROM GameSessions";
            }

            GameSessions = new ObservableCollection<GameSession>(
                _db.GameSessions.FromSqlRaw(query, parameters.ToArray())
                    .Include(gs => gs.GameType)
                    .ToList()
            );
        }

        public RelayCommand CreateNewGameCommand { get; set; }
        private void CreateNewGame()
        {
            _db.Database.ExecuteSql($"""
                INSERT INTO GameSessions (GameTypeID, MimimalParticipantsCountToStart)
                VALUES ({SelectedGameTypeForCreating + 1}, {MinimalParticipantsCountToStartForCreating})
                """);
            _db.SaveChanges();
        }

        public string CreateNewGame(CasinoContext context)
        {
            context.GameSessions.Add(
                new GameSession
                {
                    GameTypeID = SelectedGameTypeForCreating + 1,
                    MimimalParticipantsCountToStart = int.Parse(MinimalParticipantsCountToStartForCreating)
                });
            context.SaveChanges();
            return "OK";
        }

        public GameSessionsViewModel(INavigationService navService, CasinoContext casinoDbContext, HomeViewModel homeViewModel)
        {
            _navigation = navService;
            _db = casinoDbContext;
            Me = homeViewModel.Me;

            _gameTypes = _db.GameTypes.FromSql(
                $"""
                SELECT * FROM GameTypes
                """).ToList();

            _gameTypesForCreating = new(_gameTypes);

            _gameTypes.Add(new GameType { ID = 6, Name = "" });

            FilterID = "";
            FilterGameType = 5;
            FilterMinimalParticipantsCountToStart = "";

            SelectedGameTypeForCreating = 0;

            GameSessions = new ObservableCollection<GameSession>(
                _db.GameSessions.FromSql(
                    $"""
                    SELECT * FROM GameSessions
                    """)
                .Include(gs => gs.GameType)
                .ToList());

            CurrentGameSessionID = 0;

            foreach (GameSession gameSession in GameSessions)
            {
                gameSession.GameParticipants = new ObservableCollection<GameParticipant>(
                    _db.GameParticipants.FromSql(
                        $"""
                        SELECT * FROM GameParticipants
                        WHERE GameSessionID = {gameSession.ID}
                        """
                        )
                    .Include(gp => gp.Client).ToList());
                gameSession.GameParticipants.CollectionChanged += GameParticipants_CollectionChanged;
                if (gameSession.GameParticipants.Any(gm => gm.ClientID == Me.ID))
                {
                    CurrentGameSessionID = gameSession.ID;
                }
            }
            GameSessions.CollectionChanged += GameSessions_CollectionChanged;
            ConnectCommand = new RelayCommand(Connect, canExecute => true);
            DisconnectCommand = new RelayCommand(Disconnect, canExecute => true);
            FilterCommand = new RelayCommand(execute => Filter(), canExecute => true);
            CreateNewGameCommand = new RelayCommand(execite => CreateNewGame(), canExecute => true);
        }

        public GameSessionsViewModel()
        {

        }
    }
}
