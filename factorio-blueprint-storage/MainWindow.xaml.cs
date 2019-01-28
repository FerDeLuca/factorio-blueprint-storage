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

        private void UpdateDataList(object sender, RoutedEventArgs e)
        {

        }

        private void OpacityWindowsChecking(object sender, RoutedEventArgs e)
        {
            if (((MenuItem)sender).IsChecked)
            {
                OpacityWindowsSlider.IsEnabled = true;
                this.Opacity = OpacityWindowsSlider.Value / 100;

            }
            else
            {
                OpacityWindowsSlider.IsEnabled = false;
                //OpacityWindowsSlider.Visibility = Visibility.Hidden;
                this.Opacity = 1;
            }
        }

        private void OpacityWindowsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Opacity = ((Slider)sender).Value/100;
        }


        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                if (e.ClickCount != 2)
                    Application.Current.MainWindow.DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TopmostWin(object sender, RoutedEventArgs e)
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

        private void ViewChanged(object sender, RoutedEventArgs e)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeRender">false-Blocks,true-Tree</param>
        void RenderingPage(bool typeRender)
        {

        }

        private void CollectionState(object sender, RoutedEventArgs e)
        {
            bCollectionEnable = !bCollectionEnable;
            if (bCollectionEnable)
                ((MenuItem)sender).Background = new SolidColorBrush(Color.FromRgb(0xcd, 0xd3, 0xd8));
            else
                ((MenuItem)sender).Background = new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0xff));
        }

        private void AddNewItemBtn(object sender, RoutedEventArgs e)
        {
            BPObject addItemBP;
            NewItem newItem = new NewItem();
            newItem.Owner = Window.GetWindow(this);
            newItem.ShowDialog();
            addItemBP = newItem.newBP;
            newItem.Close();


        }
    }
    public struct BPObject
    {
        public string name;
    }
}
