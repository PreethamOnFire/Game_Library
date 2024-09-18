using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Threading;

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

        private screenshotNode selectedNode;

        public screenshotNode SelectedNode
        {
            get { return selectedNode; }
            set { selectedNode = value; }
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

        private async void AddEntry_Click(object sender, RoutedEventArgs e)
        {
            DateTime _day = DateTime.Now;
            screenshotNode newEntry = new screenshotNode("TITLE", "C:\\Users\\madha\\source\\repos\\Game_Library\\Game_Library\\Assets\\Logo.png", _day, "CONTENT");
            Window Editor = new EditorWindow(newEntry);
            Editor.ShowDialog();
            selectedGame.screenshotNodes.Add(newEntry);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (selectedNode != null)
            {
                SelectedGame.screenshotNodes.Remove(selectedNode);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Window Editor = new EditorWindow(selectedNode);
            Editor.ShowDialog();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
