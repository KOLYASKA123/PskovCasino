using PskovCasino.Core;
using PskovCasino.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.ViewModel
{
    public class LoginViewModel : Core.ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged(nameof(Navigation));
            }
        }

        public RelayCommand NavigateRegistrationCommand { get; set; }

        public LoginViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateRegistrationCommand = new RelayCommand(execute => Navigation.NavigateTo<RegistrationViewModel>(), canExecute => true);
        }
    }
}
