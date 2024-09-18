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
using System.Text.Json;

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
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true,
        };
        private void load()
        {
            
            string current = Directory.GetCurrentDirectory();
            try
            {
                StreamReader reader = new StreamReader(current + "/Games.JSON");
                var json = reader.ReadToEnd();
                GameObjs = JsonSerializer.Deserialize<ObservableCollection<GameObj>>(json, _options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Continueing with Empty List");
            }
            
        }
        public MainWindow()
        {
            DataContext = this;
            gameObjs = new ObservableCollection<GameObj>();
            load();
            SelectedName = "TITLE";
            SelectedImg = "C:\\Users\\madha\\source\\repos\\Game_Library\\Game_Library\\Assets\\Logo.png";
            InitializeComponent();
            Main.Content = new MainMenu(GameObjs, this);
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
            ObservableCollection<screenshotNode> screenshotNodes = new ObservableCollection<screenshotNode>();
            GameObjs.Add(new GameObj(SelectedName,selectGamePath,SelectedImg, screenshotNodes));
            SelectedName = "TITLE";
            SelectedImg = "C:\\Users\\madha\\source\\repos\\Game_Library\\Game_Library\\Assets\\Logo.png";
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
            StreamWriter writer = new StreamWriter(current+"/Games.JSON");
            writer.Write(JsonSerializer.Serialize(GameObjs, _options));
            writer.Close();
        }

        private void addGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            string current = Directory.GetCurrentDirectory();
            StreamWriter writer = new StreamWriter(current + "/Games.JSON");
            writer.Write(JsonSerializer.Serialize(GameObjs));
            writer.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new GamePage(SelectedGame);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Main.Content = new GamePage(SelectedGame);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            if(WindowState is WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}