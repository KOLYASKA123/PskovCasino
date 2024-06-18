using PskovCasino.MVVM.ViewModel;



namespace PskovCasino
{
    public class AuthTest : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly RegistrationViewModel _registrationViewModel;
        private readonly LoginViewModel _loginViewModel;

        public AuthTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _registrationViewModel = new RegistrationViewModel();
            _loginViewModel = new LoginViewModel();
        }

        [Fact]
        public void ShouldLogin()
        {
            var username = "user";
            var password = "password";

            _loginViewModel.Username = username;
            _loginViewModel.Password = password;

            _loginViewModel.Login(_fixture.Context);

            Assert.NotNull(_loginViewModel.Me);
        }

        [Fact]
        public void ShouldRegister()
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
    }
}