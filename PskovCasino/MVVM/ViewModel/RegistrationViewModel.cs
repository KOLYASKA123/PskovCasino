using PskovCasino.Core;
using PskovCasino.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.ViewModel
{
    public class RegistrationViewModel : Core.ViewModel
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

        public RelayCommand NavigateLoginCommand { get; set; }

        public RegistrationViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateLoginCommand = new RelayCommand(execute => Navigation.NavigateTo<LoginViewModel>(), canExecute => true);
        }
    }
}
