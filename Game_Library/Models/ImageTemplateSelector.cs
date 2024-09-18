using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game_Library.Models
{
    class ImageTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item is screenshotNode G)
            {
                Uri img = new Uri(G.imgPath);
                ImageSource imageSource = new BitmapImage(img);
                double dimensions = imageSource.Width/imageSource.Height;
                if (dimensions == 1)
                {
                    if (G.imgPath == "C:\\Users\\madha\\source\\repos\\Game_Library\\Game_Library\\Assets\\Logo.png")
                    {
                        return element.FindResource("TextOnly") as DataTemplate;
                    }
                    else
                    {
                        return element.FindResource("Traditional") as DataTemplate;
                    }
                } else
                {
                    return element.FindResource("16:9") as DataTemplate;  
                }
            }
            return null;
        }
    }
}
