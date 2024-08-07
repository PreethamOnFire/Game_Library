using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Game_Library.Models.Views
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private GameObj selectedGame;

        public GameObj SelectedGame
        {
            get { return selectedGame; }
            set { selectedGame = value; }
        }

        public GamePage(GameObj selectedGame)
        {
            DataContext = this;
            SelectedGame = selectedGame;
            InitializeComponent();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(selectedGame.executablePath);
        }
    }
}
