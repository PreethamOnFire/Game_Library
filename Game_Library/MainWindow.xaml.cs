using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Game_Library.Models;
using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Game_Library.Models.Views;
using System.IO;

namespace Game_Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
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

        private void load(ObservableCollection<GameObj> games)
        {
            string current = Directory.GetCurrentDirectory();
            StreamReader reader = new StreamReader(current + "/Games.txt");
            while(reader.Peek() > -1)
            {
                string line = reader.ReadLine();
                string[] bits = line.Split("\t");
                games.Add(new GameObj(bits[0], bits[1], bits[2], bool.Parse(bits[3])));
            }
        }
        public MainWindow()
        {
            DataContext = this;
            gameObjs = new ObservableCollection<GameObj>();
            load(gameObjs);
            InitializeComponent();
            Main.Content = new Models.Views.MainMenu(GameObjs, this);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<GameObj> gameObjs;

        public  ObservableCollection<GameObj> GameObjs
        {
            get { return gameObjs; }
            set 
            { 
                gameObjs = value;
            }
        }

        private string selectedName;

        public string SelectedName
        {
            get { return selectedName; }
            set 
            { 
                selectedName = value;
                OnPropertyChanged();
            }
        }

        private string selectedImg;

        public string SelectedImg
        {
            get { return selectedImg; }
            set 
            { 
                selectedImg = value;
                OnPropertyChanged();
            }
        }


        private string selectGamePath;

        private void fileSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? success = dialog.ShowDialog();

            if (success == true)
            {
                selectGamePath = dialog.FileName;
                SelectedName = dialog.SafeFileName;
            }
            else
            {

            }
        }
        private void imgSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? success = dialog.ShowDialog();

            if (success == true)
            {
                SelectedImg = dialog.FileName;
            }
            else
            {

            }
        }
        private void addGame(object sender, RoutedEventArgs e)
        {
            GameObjs.Add(new GameObj(SelectedName,selectGamePath,SelectedImg));
            SelectedName = "";
            SelectedImg = "";
            
            Main.Refresh();
            
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void delGame_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGame != null)
            {
                gameObjs.Remove(SelectedGame);
            }
            else
            {

            }
        }

        private void saveGame_Click(object sender, RoutedEventArgs e)
        {
            string current = Directory.GetCurrentDirectory();
            StreamWriter writer = new StreamWriter(current+"/Games.txt");
            foreach (GameObj gameObj in GameObjs)
            {
                writer.WriteLine(gameObj);
            }
            writer.Close();
        }

        private void addGame_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}