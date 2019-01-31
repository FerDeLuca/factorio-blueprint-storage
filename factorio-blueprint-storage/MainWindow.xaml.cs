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
using MahApps.Metro.Controls;


namespace factorio_blueprint_storage
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        bool bCollectionEnable = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        void UpdateDataList(object sender, RoutedEventArgs e)
        {

        }

        void OpacityWindowsChecking(object sender, RoutedEventArgs e)
        {
            if (((MenuItem)sender).IsChecked)
            {
                OpacityWindowsSlider.IsEnabled = true;
                this.Opacity = OpacityWindowsSlider.Value / 100;

            }
            else
            {
                OpacityWindowsSlider.IsEnabled = false;
                this.Opacity = 1;
            }
        }

        void OpacityWindowsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Opacity = ((Slider)sender).Value/100;
        }

        void TopmostWin(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content.ToString().StartsWith(" "))
            {
                this.Topmost = true;
                ((Button)sender).Content = "Topmost";
            }
            else
            {
                this.Topmost = false;
                ((Button)sender).Content = " Topmost";
            }
        }

        void ViewChanged(object sender, RoutedEventArgs e)
        {
            if (((MenuItem)sender).Header.ToString().Contains("Блочный"))
            {
                tView.IsChecked = false;
                bView.IsChecked = true;
                RenderingPage(false);
            }
            else
            {
                bView.IsChecked = false;
                tView.IsChecked = true;
                RenderingPage(true);
            }

        }

        void RenderingPage(bool Type)
        {

        }

        void CollectionState(object sender, RoutedEventArgs e)
        {
            bCollectionEnable = !bCollectionEnable;
            if (bCollectionEnable)
                ((MenuItem)sender).Background = new SolidColorBrush(Color.FromRgb(0xcd, 0xd3, 0xd8));
            else
                ((MenuItem)sender).Background = new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0xff));
        }

        void AddNewItemBtn(object sender, RoutedEventArgs e)
        {
            MainService.BPObject addItemBP;
            NewItem newItem = new NewItem
            {
                Owner = Window.GetWindow(this)
            };
            newItem.ShowDialog();
            addItemBP = newItem.newBp;
            newItem.Close();

            if(addItemBP.code != null && addItemBP.code.Length>10)
                MainService.AddBlueprintObj(addItemBP);
        }
    }

   
}
