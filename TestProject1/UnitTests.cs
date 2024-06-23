using Microsoft.EntityFrameworkCore;
using PskovCasino.MVVM.Model;
using PskovCasino.MVVM.ViewModel;
using System.Windows.Input;


namespace PskovCasino.UnitTests
{
    public class Test : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly RegistrationViewModel _registrationViewModel;
        private readonly LoginViewModel _loginViewModel;
        private readonly GameSessionsViewModel _gameSessionsViewModel;
        private readonly ProfileViewModel _profileViewModel;
        private Client _me;

        public Test(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _registrationViewModel = new RegistrationViewModel();
            _loginViewModel = new LoginViewModel();
            _gameSessionsViewModel = new GameSessionsViewModel();
            _profileViewModel = new ProfileViewModel();
        }

        [Fact]
        public void B_ShouldRegister()
        {
            var username = "cho-to_tam";
            var password = "password";
            var retypePassword = "password";

            _registrationViewModel.Username = username;
            _registrationViewModel.Password = password;
            _registrationViewModel.RetypePassword = retypePassword;

            _registrationViewModel.RegisterNewClient(_fixture.Context);

            Assert.NotNull(_registrationViewModel.Me);
        }

        [Fact]
        public void A_ShouldLogin()
        {
            var username = "user";
            var password = "password";

            _loginViewModel.Username = username;
            _loginViewModel.Password = password;

            _loginViewModel.Login(_fixture.Context);

            _me = _loginViewModel.Me;
            Assert.NotNull(_loginViewModel.Me);
        }

        [Fact]
        public void C_ShouldCreateNewGameSession()
        {
            _gameSessionsViewModel.SelectedGameTypeForCreating = 0;
            _gameSessionsViewModel.MinimalParticipantsCountToStartForCreating = "3";
            _gameSessionsViewModel.CreateNewGame(_fixture.Context);

            Assert.Equal("OK", _gameSessionsViewModel.CreateNewGame(_fixture.Context));
        }

        [Fact]
        public void D_ShouldConnectToGameSession()
        {
            _gameSessionsViewModel.Me = _fixture.Context.Clients.Include(c => c.ClientStatus).SingleOrDefault(c => c.Username == "user");
            Assert.Equal("OK", _gameSessionsViewModel.Connect(_fixture.Context, 1));
        }

        [Fact]
        public void E_ShouldDisconnectFromGameSession()
        {
            _gameSessionsViewModel.Me = _fixture.Context.Clients.Include(c => c.ClientStatus).SingleOrDefault(c => c.Username == "user");
            var participant = new GameParticipant
            {
                ClientID = _gameSessionsViewModel.Me.ID,
                GameSessionID = 1,
                WinPayment = 0,
                InitialPayment = 0
            };
            _fixture.Context.GameParticipants.Add(participant);
            _fixture.Context.SaveChanges();
            Assert.Equal(_gameSessionsViewModel.Disconnect(_fixture.Context, participant), "OK");
        }

        [Fact]
        public void F_ShouldChangeUserData()
        {
            _profileViewModel.Me = _fixture.Context.Clients.Include(c => c.ClientStatus).SingleOrDefault(c => c.Username == "user");
            _profileViewModel.Me.Balance = 123;
            
            _profileViewModel.SaveChanges(_fixture.Context, _profileViewModel.Me);
            Assert.NotEqual(
                0,
                _fixture.Context.Clients.Include(c => c.ClientStatus).SingleOrDefault(c => c.Username == "user").Balance
                );
        }

        [Fact]
        public void G_ShouldDeleteUser()
        {
            _profileViewModel.Me = _fixture.Context.Clients.Include(c => c.ClientStatus).SingleOrDefault(c => c.Username == "user");
            Assert.Equal("OK", _profileViewModel.DeleteMe(_fixture.Context, _profileViewModel.Me));
        }


        /// <summary>
        /// Сквозной тест приложения. Следует запускать отдельно от остальных тестов.
        /// </summary>
        [Fact]
        public void H_AllShouldWork()
        {
            // Регистрация
            var username = "cho-to_tam";
            var password = "password";
            var retypePassword = "password";
            _registrationViewModel.Username = username;
            _registrationViewModel.Password = password;
            _registrationViewModel.RetypePassword = retypePassword;
            _registrationViewModel.RegisterNewClient(_fixture.Context);
            Assert.NotNull(_registrationViewModel.Me);

            // Авторизация
            username = "cho-to_tam";
            password = "password";
            _loginViewModel.Username = username;
            _loginViewModel.Password = password;
            _loginViewModel.Login(_fixture.Context);
            _me = _loginViewModel.Me;
            Assert.NotNull(_loginViewModel.Me);

            // Создание игровой сессии
            _gameSessionsViewModel.SelectedGameTypeForCreating = 0;
            _gameSessionsViewModel.MinimalParticipantsCountToStartForCreating = "3";
            Assert.Equal("OK", _gameSessionsViewModel.CreateNewGame(_fixture.Context));

            // Подключение к игровой сессии
            _gameSessionsViewModel.Me = _loginViewModel.Me;
            Assert.Equal("OK", _gameSessionsViewModel.Connect(_fixture.Context, 1));

            var lst = _fixture.Context.GameSessions.ToList();
            var lst2 = _fixture.Context.GameParticipants.ToList();

            // Изменение данных пользователя
            _profileViewModel.Me = _loginViewModel.Me;
            _profileViewModel.Me.Balance = 123;

            _profileViewModel.SaveChanges(_fixture.Context, _profileViewModel.Me);
            Assert.NotEqual(
                0,
                _fixture.Context.Clients.Include(c => c.ClientStatus).SingleOrDefault(c => c.Username == "cho-to_tam").Balance
                );

            // Удаление пользователя
            Assert.Equal("OK", _profileViewModel.DeleteMe(_fixture.Context, _profileViewModel.Me));
        }
    }
}