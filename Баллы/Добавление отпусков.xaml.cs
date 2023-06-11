using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Логика;

namespace Баллы
{
    /// <summary>
    /// Логика взаимодействия для Добавление_отпусков.xaml
    /// </summary>
    public partial class Добавление_отпусков : Window
    {
        public Добавление_отпусков()
        {
            InitializeComponent();
            DataContext = this;
            
        }
        int i = 1;
        public ObservableCollection<string> Otpuski
        {
            get { return MainWindow.curChoice._Otpusk; }
        }

        private void Btn_Add(object sender, RoutedEventArgs e)
        {
            
            MainWindow.curChoice._Otpusk.Add(i.ToString());
            i++;
        }

        private void Btn_Del(object sender, RoutedEventArgs e)
        {
            MainWindow.curChoice._Otpusk.Remove((string)LB_Otsyt.SelectedItem);
        }

        public static int day, month;

        private void TB_TextInput(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.ToCharArray().Length == 5)
            {
                int.TryParse(((TextBox)sender).Text.Split('.')[0], out day);
                int.TryParse(((TextBox)sender).Text.Split('.')[1], out month);
            }

            if (month > 12 || 
                (
                    (month == 1 || month == 3 || month == 5 ||
                    month == 7 || month == 8 || month == 10 || 
                    month == 12) && day > 31
                ) ||
                (
                    (month == 4 || month == 6 ||
                    month == 9 || month == 11) && day > 30
                ) //||s
                //(month == 2 && MainWindow.)

                ) ((TextBox)sender).Foreground = Brushes.Red;
            else ((TextBox)sender).Foreground = Brushes.Black;


        }

        private void TB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (((TextBox)sender).Foreground.Equals(Brushes.Gray))
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).Foreground = Brushes.Black;
            }
            
            else if (!char.IsDigit(e.Text[0]))
                e.Handled= true;

            else if (((TextBox)sender).Text.ToCharArray().Length == 2)
            {
                ((TextBox)sender).Text += ".";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.ToCharArray().Length;
            }
            

        }

    }
}
