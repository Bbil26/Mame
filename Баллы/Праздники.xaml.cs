using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Логика;

namespace Баллы
{
    /// <summary>
    /// Логика взаимодействия для Праздники.xaml
    /// </summary>
    public partial class Праздники : Window
    {
        public Праздники()
        {
            InitializeComponent();
            LB_holi.DataContext = MainWindow.listPeoples;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            int addDay, addMonth;


            int.TryParse(TB_Data_Holi.Text.Split('.')[0], out addDay);
            int.TryParse(TB_Data_Holi.Text.Split('.')[1], out addMonth);

            foreach (var date in MainWindow.holidays)
                if (date.day == addDay && date.month == addMonth)
                    return;

            MainWindow.listPeoples._holidays.Add(new Логика.Holidays
            {
                day = addDay,
                month = addMonth,

            });
        }

        private void Button_Del(object sender, RoutedEventArgs e)
        {
            MainWindow.listPeoples._holidays.Remove((Holidays)LB_holi.SelectedItem);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void TB_Data_Holi_TextChanged(object sender, TextChangedEventArgs e)
        {
            int day, month;
            if (TB_Data_Holi.Text.Length == 5)
            {
                int.TryParse(TB_Data_Holi.Text.Split('.')[0], out day);
                int.TryParse(TB_Data_Holi.Text.Split('.')[1], out month);

                if (Добавление_отпусков.VallideDate(day, month, MainWindow.curYear) == true)
                {
                    add_btn.IsEnabled = true;
                }
                else
                {
                    add_btn.IsEnabled = false;
                }    
            }
            else add_btn.IsEnabled = false;
            

        }

        private void TB_Data_Holi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
            else if (((TextBox)sender).Text.ToCharArray().Length == 2)
            {
                ((TextBox)sender).Text += ".";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.ToCharArray().Length;
            }
        }
    }
}
