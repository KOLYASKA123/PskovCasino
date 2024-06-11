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

        private Button? _pressedConnectionButton;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (_pressedConnectionButton == null)
                {
                    button.Content = "Покинуть игру";
                    _pressedConnectionButton = button;
                    button.Command = ((GameSessionsViewModel)DataContext).ConnectCommand;

                }
                else
                {
                    button.Content = "Присоединиться";
                    _pressedConnectionButton = null;
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

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is ListViewItem listViewItem)
            {
                Button button = FindVisualChild<Button>(listViewItem);
                if (_pressedConnectionButton != null && _pressedConnectionButton == button)
                {
                    button.IsEnabled = true; 
                }
                else if (_pressedConnectionButton == null)
                {
                    button.IsEnabled = true;
                }
            }
        }

        private void ListViewItem_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is ListViewItem listViewItem)
            {
                Button button = FindVisualChild<Button>(listViewItem);
                button.IsEnabled = false;
            }
        }
    }
}
