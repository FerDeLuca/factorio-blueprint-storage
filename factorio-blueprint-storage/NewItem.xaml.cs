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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace factorio_blueprint_storage
{
    /// <summary>
    /// Interaction logic for NewItem.xaml
    /// </summary>
    public partial class NewItem : MetroWindow
    {
        public BPObject newBP;
        public NewItem()
        {
            InitializeComponent();

            //Update fields
            BpName_MouseLeave(bpName, null);
            BpName_MouseLeave(bpDescription, null);
        }

        private void SaveResult(object sender, RoutedEventArgs e)
        {
            //TODO Parsing grid and save data
            Hide();
        }

        private void CancelAndClose(object sender, RoutedEventArgs e)
        {
            newBP = new BPObject();
            Close();
        }

        private void ClearForm(object sender, RoutedEventArgs e)
        {

        }

        private void BpName_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() == typeof(TextBox) && ((TextBox)sender).Text.Contains(((TextBox)sender).Tag.ToString()))
            {
                ((TextBox)sender).Clear();
                ((TextBox)sender).Foreground = new SolidColorBrush(Color.FromRgb(0x0, 0x0, 0x0));
            }
            if (sender.GetType() == typeof(TextBlock) && ((TextBlock)sender).Text.Contains(((TextBlock)sender).Tag.ToString()))
            {
                ((TextBlock)sender).Text = "";
                ((TextBlock)sender).Foreground = new SolidColorBrush(Color.FromRgb(0x0, 0x0, 0x0));
            }
        }

        private void BpName_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() == typeof(TextBox) && string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = ((TextBox)sender).Tag.ToString();
                ((TextBox)sender).Foreground = new SolidColorBrush(Color.FromRgb(0xcd, 0xd3, 0xd8));
            }
            if (sender.GetType() == typeof(TextBlock) && string.IsNullOrWhiteSpace(((TextBlock)sender).Text))
            {
                ((TextBlock)sender).Text = ((TextBlock)sender).Tag.ToString();
                ((TextBlock)sender).Foreground = new SolidColorBrush(Color.FromRgb(0xcd, 0xd3, 0xd8));
            }
        }
    }
}
