using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Game_Library.Models.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page, INotifyPropertyChanged
    {
        private MainWindow mainWindowFrame;
        private GameObj selectedGame;

        public GameObj SelectedGame
        {
            get { return selectedGame; }
            set 
            { 
                selectedGame = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainMenu(ObservableCollection<GameObj> gameObjs, MainWindow main)
        {
            DataContext = this;
            menuGameObjs = gameObjs;
            mainWindowFrame = main;
            InitializeComponent();
        }
        private ObservableCollection<GameObj> menuGameObjs;

        public ObservableCollection<GameObj> MenuGameObjs
        {
            get { return menuGameObjs; }
            set { menuGameObjs = value; }
        }

        private void GameSelected_Click(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Main.Content = new GamePage(SelectedGame);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void delGame_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGame != null)
            {
                menuGameObjs.Remove(SelectedGame);
            }
            else
            {

            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mainWindowFrame.Main.Content = new GamePage(SelectedGame);
        }
    }
}
