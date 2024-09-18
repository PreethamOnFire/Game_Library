using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Game_Library.Models.Views
{
    /// <summary>
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private screenshotNode screenshotEntry;

        public screenshotNode ScreenshotEntry
        {
            get { return screenshotEntry; }
            set { 
                screenshotEntry = value;
                OnPropertyChanged();
            }
        }
        private string? selectedImage;

        public string? SelectedImage
        {
            get { return selectedImage; }
            set {
                selectedImage = value; 
                OnPropertyChanged();
            }
        }


        public EditorWindow(screenshotNode screenshotNode)
        {
            DataContext = this;
            ScreenshotEntry = screenshotNode;
            selectedImage = screenshotEntry.imgPath;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void AddImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? success = openFileDialog.ShowDialog();
            if (success == true)
            {
                ScreenshotEntry.imgPath = openFileDialog.FileName;
                SelectedImage = openFileDialog.FileName;
            }
            else
            {
               
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState is WindowState.Maximized)
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
    }
}
