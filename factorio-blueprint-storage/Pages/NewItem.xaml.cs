using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace factorio_blueprint_storage
{
    /// <summary>
    /// Interaction logic for NewItem.xaml
    /// </summary>
    public partial class NewItem : MetroWindow
    {
        public MainService.BPObject newBp;
        public NewItem()
        {
            InitializeComponent();
            ClearForm();
        }

        private void SaveResult(object sender, RoutedEventArgs e)
        {
            //TODO Parsing grid and save data
            int nextID = 1; //TODO Считывание нового ID
            MessageBoxResult boxButton = MessageBoxResult.Yes;
            if (newBp.id != nextID)
                boxButton = MessageBox.Show("Field ID incorrectly! Continue save?(Your [ID] may vary)",
                "Information Message", MessageBoxButton.YesNoCancel);
            switch (boxButton)
            {
                case MessageBoxResult.Yes:
                    //public string name;
                    newBp.name = formName.Text;
                    //public DateTime updateDate;
                    newBp.updateDate = DateTime.Now;
                    //public string description;
                    newBp.description = formDesc.Text;
                    //public string imgLink;
                    if (newBp.imgLink != null)
                    {//TODO не работает копирование
                        File.Copy(newBp.imgLink, @"\\img\\" + nextID + System.IO.Path.GetExtension(newBp.imgLink));
                        newBp.imgLink = nextID + System.IO.Path.GetExtension(newBp.imgLink);
                    }
                    else
                    {
                        newBp.imgLink = "default.jpg";
                    }
                    //public string code;
                    newBp.code = formCode.Text;
                    //public Stack<int> tags;
                    newBp.tags = new Stack<int> { };
                    //Close Window
                    break;
                case MessageBoxResult.No:
                    return;
                case MessageBoxResult.Cancel:
                    break;
            }
            Hide();
        }

        private void CancelAndClose(object sender, RoutedEventArgs e)
        {
            newBp = new MainService.BPObject();
            Close();
        }

        private void ClearForm(object sender=null, RoutedEventArgs e=null)
        {
            //Update fields
            formId.Text = newBp.GetNewID().ToString("0000");
            formName.Text = null;
            formDesc.Text = null;
            formCode.Text = null;
            TextBox_MouseLeave(formName, null);
            TextBox_MouseLeave(formDesc, null);
            TextBox_MouseLeave(formCode, null);
            fromTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            formSetImg.Source = Imaging.CreateBitmapSourceFromHBitmap(
                Properties.Resources._default.GetHbitmap(),
                IntPtr.Zero, Int32Rect.Empty,BitmapSizeOptions.FromEmptyOptions());
            //TODO Tags clear
        }

        private void TextBox_MouseEnter(object sender, RoutedEventArgs e)
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

        private void TextBox_MouseLeave(object sender, RoutedEventArgs e)
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

        private void FormSetImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //TODO запись в новый объект
            OpenFileDialog newPic = new OpenFileDialog();
            newPic.Filter = "Картинки(*.JPG;*.GIF)|*.JPG;*.GIF" + "|Все файлы(*.*)|*.*";
            newPic.CheckFileExists = true;
            newPic.Multiselect = false;
            if (newPic.ShowDialog() == true)
            {
                newBp.imgLink = newPic.FileName;
                formSetImg.Source = new BitmapImage(new Uri(newPic.FileName));
            }
                

        }
    }
}
