using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PskovCasino.MVVM.Model;
using PskovCasino.MVVM.ViewModel;

namespace PskovCasino.MVVM.View
{
    /// <summary>
    /// Interaction logic for GameSessionsView.xaml
    /// </summary>
    public partial class GameSessionsView : UserControl
    {
        public GameSessionsView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (listView.SelectedIndex != -1 && listView.IsEnabled)
                {
                    button.Content = "Покинуть игру";
                    ((GameSessionsViewModel)DataContext).CurrentGameSessionID = listView.SelectedIndex + 1;
                    listView.IsEnabled = false;
                    button.Command = ((GameSessionsViewModel)DataContext).ConnectCommand;

                }
                else
                {
                    button.Content = "Присоединиться";
                    listView.IsEnabled = true;
                    button.Command = ((GameSessionsViewModel)DataContext).DisconnectCommand;
                }
            }
        }

        private T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child is T childOfType)
                {
                    return childOfType;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedIndex == -1)
            {
                connectionButton.IsEnabled = false;
            }
            else connectionButton.IsEnabled = true;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listView.SelectedIndex = ((GameSessionsViewModel)DataContext).CurrentGameSessionID - 1;
            if (listView.SelectedIndex != -1)
            {
                listView.IsEnabled = false;
                connectionButton.Content = "Покинуть игру";
                connectionButton.Command = ((GameSessionsViewModel)DataContext).ConnectCommand;
            }
            else
            {
                listView.IsEnabled = true;
                connectionButton.Content = "Присоединиться";
                connectionButton.Command = ((GameSessionsViewModel)DataContext).DisconnectCommand;
                connectionButton.IsEnabled = false;
            }
        }
    }
}
