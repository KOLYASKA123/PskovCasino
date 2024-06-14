using Microsoft.Extensions.DependencyInjection;
using PskovCasino.MVVM.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;
using PskovCasino.Core;
using PskovCasino.Services;
using Microsoft.EntityFrameworkCore;
using PskovCasino.MVVM.Model;
using PskovCasino.MVVM.View;

namespace PskovCasino
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddSingleton(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();
            
            services.AddSingleton(provider => new RegistrationView()
            {
                DataContext = provider.GetRequiredService<RegistrationViewModel>()
            });
            services.AddSingleton<RegistrationViewModel>();

            services.AddSingleton(provider => new LoginView
            {
                DataContext = provider.GetRequiredService<LoginViewModel>()
            });
            services.AddSingleton<LoginViewModel>();

            services.AddSingleton(provider => new HomeView
            {
                DataContext = provider.GetRequiredService<HomeViewModel>()
            });
            services.AddSingleton<HomeViewModel>();

            services.AddSingleton(provider => new ProfileView
            {
                DataContext = provider.GetRequiredService<ProfileViewModel>()
            });
            services.AddSingleton<ProfileViewModel>();

            services.AddSingleton(provider => new GameSessionsView
            {
                DataContext = provider.GetRequiredService<GameSessionsViewModel>()
            });
            services.AddSingleton<GameSessionsViewModel>();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddDbContext<CasinoContext>(options =>
            {
                //options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=db;Trusted_Connection=True;");
                options.UseSqlite("Filename=../../../MyLocalLibrary.db");
            });

            services.AddSingleton<Func<Type, ViewModel>>(
                serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType)
                );

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CasinoContext>();
                db.Database.EnsureCreated();
            }


            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            /*var options = new DbContextOptionsBuilder<CasinoContext>().Use("Filename=./MVVM/Model/DB.db").Options;
            using var db = new CasinoContext(options);

            db.Database.EnsureCreated();*/

            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
