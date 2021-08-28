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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineShopping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnMenuItemClick(object sender, RoutedEventArgs e)
        {
            CircleEase ease = new CircleEase() { EasingMode = EasingMode.EaseOut };
            DoubleAnimation doubleAnimation = new DoubleAnimation();

            Button button = (Button)sender;
            Grid grid;

            switch (button.Name)
            {
                case nameof(btnCatalogs):
                    {
                        grid = grdCatalogs;
                        break;
                    }
                case nameof(btnReports):
                    {
                        grid = grdReports;
                        break;
                    }
                case nameof(btnOperations):
                    {
                        grid = grdOperations;
                        break;
                    }
                default:
                    return;
            }

            StackPanel stackPanel = (StackPanel)grid.Children[0];
            int childCount = stackPanel.Children.Count;

            if (grid.Height != 0)
            {
                doubleAnimation.To = 0;
            }
            else
            {
                doubleAnimation.To = childCount * 30;
            }

            doubleAnimation.Duration = TimeSpan.FromMilliseconds(childCount * 150);
            doubleAnimation.EasingFunction = ease;
            grid.BeginAnimation(HeightProperty, doubleAnimation);
        }
    }
}
