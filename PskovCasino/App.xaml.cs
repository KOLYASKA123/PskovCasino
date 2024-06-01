using Microsoft.Extensions.DependencyInjection;
using PskovCasino.MVVM.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;
using PskovCasino.Core;
using PskovCasino.Services;
using Microsoft.EntityFrameworkCore;
using PskovCasino.MVVM.Model;

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
            services.AddSingleton<RegistrationViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, ViewModel>>(
                serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType)
                );

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            var options = new DbContextOptionsBuilder<CasinoContext>().UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=db;Trusted_Connection=True;").Options;
            using var db = new CasinoContext(options);

            db.Database.EnsureCreated();
            
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
