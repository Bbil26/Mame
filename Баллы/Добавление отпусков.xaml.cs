using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Media;


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

        public ObservableCollection<string> Otpuski
        {
            get { return MainWindow.curChoice._Otpusk; }
        }

        void getScore(int month, int countDays, int maxDays, int flag, int deletable)
        {
            double score = 0;

            ////////////////////////////Прием/////////////////////////////////////
            if (CB_Why.Text == "Прием" && flag == 1)
            {
                for(int i = month-1; i >= 1; i--)
                {
                    switch (i)
                    {
                        case 1:
                            MainWindow.curChoice._Jan = 50; break;
                        case 2:
                            MainWindow.curChoice._Feb = 50; break;
                        case 3:
                            MainWindow.curChoice._Mar = 50; break;
                        case 4:
                            MainWindow.curChoice._Apr = 50; break;
                        case 5:
                            MainWindow.curChoice._May = 50; break;
                        case 6:
                            MainWindow.curChoice._June = 50; break;
                        case 7:
                            MainWindow.curChoice._July = 50; break;
                        case 8:
                            MainWindow.curChoice._Aug = 50; break;
                        case 9:
                            MainWindow.curChoice._Sep = 50; break;
                        case 10:
                            MainWindow.curChoice._Okt = 50; break;
                        case 11:
                            MainWindow.curChoice._Nov = 50; break;
                        case 12:
                            MainWindow.curChoice._Dec = 50; break;
                    }
                }
                
            }

                /////////////////////////////////////////////////////////////////////
            if (CB_Why.Text == "Перевод" && deletable == 0)
            {
                flag = 0;
            }

            if (CB_Why.Text == "Прием" && deletable == 0)
                score = (maxDays - countDays) * 50.00 / maxDays;
            else 
                score = 50 - (maxDays - countDays) * 50.00 / maxDays;

            if (flag == 0) score = -score;

            switch (month)
            {
                case 1:
                    MainWindow.curChoice._Jan += score; break;
                case 2:
                    MainWindow.curChoice._Feb += score; break;
                case 3:
                    MainWindow.curChoice._Mar += score; break;
                case 4:
                    MainWindow.curChoice._Apr += score; break;
                case 5:
                    MainWindow.curChoice._May += score; break;
                case 6:
                    MainWindow.curChoice._June += score; break;
                case 7:
                    MainWindow.curChoice._July += score; break;
                case 8:
                    MainWindow.curChoice._Aug += score; break;
                case 9:
                    MainWindow.curChoice._Sep += score; break;
                case 10:
                    MainWindow.curChoice._Okt += score; break;
                case 11:
                    MainWindow.curChoice._Nov += score; break;
                case 12:
                    MainWindow.curChoice._Dec += score; break;
            }
        }

        private void Btn_Add(object sender, RoutedEventArgs e)
        {
            string line;
            if (CB_Why.Text == "Перевод")
            {
                for (int i = 1; i <= 12; i++)
                {
                    switch (i)
                    {
                        case 1:
                            if (MainWindow.curChoice._Jan == 0)
                                MainWindow.curChoice._Jan = 50; 
                            break;
                        case 2:
                            if (MainWindow.curChoice._Feb == 0)
                            MainWindow.curChoice._Feb = 50; 
                            break;
                        case 3:
                            if (MainWindow.curChoice._Mar == 0)
                                MainWindow.curChoice._Mar = 50; 
                            break;
                        case 4:
                            if (MainWindow.curChoice._Apr == 0)
                                MainWindow.curChoice._Apr = 50; 
                            break;
                        case 5:
                            if (MainWindow.curChoice._May == 0)
                                MainWindow.curChoice._May = 50; 
                            break;
                        case 6:
                            if (MainWindow.curChoice._June == 0)
                                MainWindow.curChoice._June = 50; 
                            break;
                        case 7:
                            if (MainWindow.curChoice._July == 0)
                                MainWindow.curChoice._July = 50; 
                            break;
                        case 8:
                            if (MainWindow.curChoice._Aug == 0)
                                MainWindow.curChoice._Aug = 50; 
                            break;
                        case 9:
                            if (MainWindow.curChoice._Sep == 0)
                                MainWindow.curChoice._Sep = 50; 
                            break;
                        case 10:
                            if (MainWindow.curChoice._Okt == 0)
                                MainWindow.curChoice._Okt = 50; 
                            break;
                        case 11:
                            if (MainWindow.curChoice._Nov == 0)
                                MainWindow.curChoice._Nov = 50; 
                            break;
                        case 12:
                            if (MainWindow.curChoice._Dec == 0)
                                MainWindow.curChoice._Dec = 50; 
                            break;
                    }

                }
            }    

            if ((CB_Why.Text != "" && TB_Start.Foreground.Equals(Brushes.White) &&
                TB_Finish.Foreground.Equals(Brushes.White)) || 
                (CB_Why.Text == "Прием" && TB_Start.Foreground.Equals(Brushes.White)) ||
                (CB_Why.Text == "Сдача крови" && TB_Start.Foreground.Equals(Brushes.White)) ||
                (CB_Why.Text == "Отп за кр" && TB_Start.Foreground.Equals(Brushes.White))
                )
            {
                if (CB_Why.Text == "Прием" || 
                    CB_Why.Text == "Сдача крови" || 
                    CB_Why.Text == "Отп за кр") TB_Finish.Text = "01.01";
                int s_day, s_month, f_day, f_month, countDays = 0, temp = 0, monthDays = 0, countHolidays = 0, tempHoli = 0;
                int.TryParse(TB_Start.Text.Split('.')[0], out s_day);
                int.TryParse(TB_Start.Text.Split('.')[1], out s_month);
                int.TryParse(TB_Finish.Text.Split('.')[0], out f_day);
                int.TryParse(TB_Finish.Text.Split('.')[1], out f_month);

                if (CB_Why.Text == "Прием") f_month = 12;
                if (CB_Why.Text == "Сдача крови" || CB_Why.Text == "Отп за кр" )
                {
                    f_month = s_month;
                    f_day = s_day;
                }
                
                    if (chk_box.IsChecked == true)
                {
                    f_day = 31;
                    f_month = 12;
                }


                    for (int i = s_month; i <= f_month; i++)
                {

                    if (i == 1 || i == 3 || i == 5 || i == 7 ||
                        i == 8 || i == 10 || i == 12)
                    {
                        monthDays = 31;
                    }
                    else if (i == 4 || i == 6 || i == 9 || i == 11)
                    {
                        monthDays = 30;
                    }
                    else if (i == 2)
                    {
                        if (MainWindow.curYear % 4 != 0)
                        {
                            monthDays = 28;
                        }
                        else
                        {
                            monthDays = 29;
                        }
                    }

                    if (s_month == f_month)
                    {
                        temp = f_day - s_day + 1;

                        if (CB_Why.Text != "б/л" && CB_Why.Text != "Отсутствие" && CB_Why.Text != "Перевод")

                        /////////////////////Праздничные дни/////////////////////////
                        foreach (var item in MainWindow.holidays)
                        {
                            tempHoli = 0;
                            if (item.month == i)
                                for (int j = s_day; j <= f_day; j++)
                                    if (j == item.day)
                                    {
                                        countHolidays++;
                                    }
                        }

                        /////////////////////////////////////////////////////////////
                        getScore(i, temp - countHolidays, monthDays, 1, 0);
                        countDays += temp;
                        break;
                    }

                    if (i == s_month) temp = monthDays - s_day + 1;
                    else if (i == f_month) temp = f_day;
                    else temp = monthDays;


                    /////////////////////Праздничные дни/////////////////////////
                    tempHoli = 0;
                    if (CB_Why.Text != "б/л" && CB_Why.Text != "Отсутствие" && CB_Why.Text != "Перевод")
                        foreach (var item in MainWindow.holidays)
                        {
                            if (item.month == i)
                                if (item.month == s_month)
                                    for (int j = s_day; j <= monthDays; j++)
                                    {
                                        if (j == item.day)
                                        {
                                            tempHoli++;
                                            countHolidays++;
                                        }
                                    }
                                else if (item.month == f_month)
                                {
                                    for (int j = 1; j <= f_day; j++)
                                    {
                                        if (j == item.day)
                                        {
                                            tempHoli++;
                                            countHolidays++;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int j = 1; j <= monthDays; j++)
                                    {
                                        if (j == item.day)
                                        {
                                            tempHoli++;
                                            countHolidays++;
                                        }
                                    }
                                }
                        }

                    ///////////////////////////////////////////////////////////////////
                    if (CB_Why.Text == "Прием")
                    {
                        getScore(i, temp, monthDays, 1, 0);
                        break;
                    }
                    else getScore(i, temp - tempHoli, monthDays, 1, 0);
                    countDays += temp;

                }
                

                if (CB_Why.Text != "б/л" && CB_Why.Text != "Отсутствие" && CB_Why.Text != "Перевод")
                    countDays -= countHolidays;
                
                line = "";

                if (chk_box.IsChecked == true)
                {
                    if (CB_Why.Text != "Прием" || CB_Why.Text != "Сдача крови" || CB_Why.Text != "Отп за кр")
                        line = $"{CB_Why.Text} с {TB_Start.Text}.{MainWindow.curYear} по" +
                            $" {TB_Finish.Text}.{MainWindow.curYear} - {countDays} дней";
                    else 
                        line = $"ОШИБКА {TB_Start.Text}.{MainWindow.curYear}";

                }
                else 
                {
                    if (CB_Why.Text == "Сдача крови" || CB_Why.Text == "Отп за кр") line = $"{CB_Why.Text} {TB_Start.Text}.{MainWindow.curYear} - 1 дн";
                    else if (CB_Why.Text != "Прием")
                        line = $"{CB_Why.Text} с {TB_Start.Text}.{MainWindow.curYear} по" +
                            $" {TB_Finish.Text}.{MainWindow.curYear} - {countDays} дней";
                    else 
                        line = $"{CB_Why.Text} с {TB_Start.Text}.{MainWindow.curYear}";
                }
                        

                MainWindow.curChoice._Otpusk.Add(line);
            }
        }

        private void Btn_Del(object sender, RoutedEventArgs e)
        {
            if (LB_Otsyt.SelectedIndex != -1)
            {
                int sMonth, fMonth, sDay, fDay, monthDays = 0, temp, tempHoli = 0;

                ////////////////////////////////Прием//////////////////////////////////////////////////
                if (((string)LB_Otsyt.SelectedItem).Split(' ')[0] == "Прием")
                {
                    int.TryParse
                       (
                           ((string)LB_Otsyt.SelectedItem).Split('.')[0].Split(' ').Last(), out sDay
                       );

                    int.TryParse
                        (
                            ((string)LB_Otsyt.SelectedItem).Split('.')[1].Split(' ')[0], out sMonth
                        );

                    for (int i = sMonth - 1; i >= 1; i--)
                    {
                        switch (i)
                        {
                            case 1:
                                MainWindow.curChoice._Jan = 0; break;
                            case 2:
                                MainWindow.curChoice._Feb = 0; break;
                            case 3:
                                MainWindow.curChoice._Mar = 0; break;
                            case 4:
                                MainWindow.curChoice._Apr = 0; break;
                            case 5:
                                MainWindow.curChoice._May = 0; break;
                            case 6:
                                MainWindow.curChoice._June = 0; break;
                            case 7:
                                MainWindow.curChoice._July = 0; break;
                            case 8:
                                MainWindow.curChoice._Aug = 0; break;
                            case 9:
                                MainWindow.curChoice._Sep = 0; break;
                            case 10:
                                MainWindow.curChoice._Okt = 0; break;
                            case 11:
                                MainWindow.curChoice._Nov = 0; break;
                            case 12:
                                MainWindow.curChoice._Dec = 0; break;
                        }
                    }


                        if (sMonth == 1 || sMonth == 3 || sMonth == 5 || sMonth == 7 ||
                           sMonth == 8 || sMonth == 10 || sMonth == 12)
                        {
                            monthDays = 31;
                        }
                        else if (sMonth == 4 || sMonth == 6 || sMonth == 9 || sMonth == 11)
                        {
                            monthDays = 30;
                        }
                        else if (sMonth == 2)
                        {
                            if (MainWindow.curYear % 4 != 0)
                            {
                                monthDays = 28;
                            }
                            else
                            {
                                monthDays = 29;
                            }
                        }

                    getScore(sMonth, sDay - 1, monthDays, 0, 1);
                    MainWindow.curChoice._Otpusk.Remove((string)LB_Otsyt.SelectedItem);
                    return;

                }
                /////////////////////////////////////////////////////////////////////////////////////
                else if (((string)LB_Otsyt.SelectedItem).Split(' ')[0] == "Перевод")
                {
                    if (
                        MessageBox.Show("Вы действительно хотетите удалить запись?\n" +
                        "Данныя процедура приведет к обнулению отпусков за все месяца.", "Внимание!",
                        MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {

                        for (int i = 1; i <= 12; i++)
                        {

                            switch (i)
                            {
                                case 1:
                                    MainWindow.curChoice._Jan = 0; break;
                                case 2:
                                    MainWindow.curChoice._Feb = 0; break;
                                case 3:
                                    MainWindow.curChoice._Mar = 0; break;
                                case 4:
                                    MainWindow.curChoice._Apr = 0; break;
                                case 5:
                                    MainWindow.curChoice._May = 0; break;
                                case 6:
                                    MainWindow.curChoice._June = 0; break;
                                case 7:
                                    MainWindow.curChoice._July = 0; break;
                                case 8:
                                    MainWindow.curChoice._Aug = 0; break;
                                case 9:
                                    MainWindow.curChoice._Sep = 0; break;
                                case 10:
                                    MainWindow.curChoice._Okt = 0; break;
                                case 11:
                                    MainWindow.curChoice._Nov = 0; break;
                                case 12:
                                    MainWindow.curChoice._Dec = 0; break;
                            }

                        }

                            MainWindow.curChoice._Otpusk.Clear();
                        
                        return;
                    }
                }

                else
                {
                    int.TryParse
                        (
                            ((string)LB_Otsyt.SelectedItem).Split('.')[0].Split(' ').Last(), out sDay
                        );

                    int.TryParse
                        (
                            ((string)LB_Otsyt.SelectedItem).Split('.')[1].Split(' ')[0], out sMonth
                        );

                    fDay = 0; fMonth = 0;

                    if (((string)LB_Otsyt.SelectedItem).Split(' ')[0] != "Сдача" &&
                        (
                        ((string)LB_Otsyt.SelectedItem).Split(' ')[0] != "Отп" && ((string)LB_Otsyt.SelectedItem).Split(' ')[1] != "за")
                        )
                    {
                        int.TryParse
                            (
                                ((string)LB_Otsyt.SelectedItem).Split('.')[2].Split(' ')[2], out fDay
                            );

                        int.TryParse
                            (
                                ((string)LB_Otsyt.SelectedItem).Split('.')[3], out fMonth
                            );
                    }


                    if (((string)LB_Otsyt.SelectedItem).Split(' ')[0] == "Сдача" || 
                        (
                        ((string)LB_Otsyt.SelectedItem).Split(' ')[0] == "Отп" && ((string)LB_Otsyt.SelectedItem).Split(' ')[1] == "за") 
                        )
                    {
                        fDay = sDay;
                        fMonth = sMonth;
                    }
                    for (int i = sMonth; i <= fMonth; i++)
                    {
                        if (i == 1 || i == 3 || i == 5 || i == 7 ||
                           i == 8 || i == 10 || i == 12)
                        {
                            monthDays = 31;
                        }
                        else if (i == 4 || i == 6 || i == 9 || i == 11)
                        {
                            monthDays = 30;
                        }
                        else if (i == 2)
                        {
                            if (MainWindow.curYear % 4 != 0)
                            {
                                monthDays = 28;
                            }
                            else
                            {
                                monthDays = 29;
                            }
                        }

                        if (sMonth == fMonth)
                        {
                            temp = fDay - sDay + 1;
                            tempHoli = 0;
                            if (((string)LB_Otsyt.SelectedItem).Split(' ')[0] != "б/л")
                                foreach (var item in MainWindow.holidays)
                                {                                
                                    if (item.month == i)
                                        for (int j = sDay; j <= fDay; j++)
                                            if (j == item.day)
                                            {
                                                tempHoli++; 
                                            }
                                }


                            getScore(i, temp-tempHoli, monthDays, 0, 1);
                            break;
                        }

                        if (i == sMonth) temp = monthDays - sDay + 1;
                        else if (i == fMonth) temp = fDay;
                        else temp = monthDays;

                        tempHoli = 0;
                        if (((string)LB_Otsyt.SelectedItem).Split(' ')[0] != "б/л")
                            foreach (var item in MainWindow.holidays)
                            {
                                if (item.month == i)
                                    if (item.month == sMonth)
                                        for (int j = fDay; j <= monthDays; j++)
                                        {
                                            if (j == item.day)
                                            {
                                                tempHoli++;
                                            }
                                        }
                                    else if (item.month == fMonth)
                                    {
                                        for (int j = 1; j <= fDay; j++)
                                        {
                                            if (j == item.day)
                                            {
                                                tempHoli++;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int j = 1; j <= monthDays; j++)
                                        {
                                            if (j == item.day)
                                            {
                                                tempHoli++;
                                            }
                                        }
                                    }
                            }

                            getScore(i, temp - tempHoli, monthDays, 0, 1);
                    }
                }

                MainWindow.curChoice._Otpusk.Remove((string)LB_Otsyt.SelectedItem);
            }

        }

        public static int day, month;

        static public bool VallideDate(int day, int month, int year)
        {
            if (month > 12 || month < 1 || day < 1 ||
                (
                    (month == 1 || month == 3 || month == 5 ||
                    month == 7 || month == 8 || month == 10 ||
                    month == 12) && day > 31
                ) ||
                (
                    (month == 4 || month == 6 ||
                    month == 9 || month == 11) && day > 30
                ) ||
                (month == 2 && year % 4 == 0 && day > 29) ||
                (month == 2 && year % 4 != 0 && day > 28)) return false;
            else return true;

        }

        private void TB_TextInput(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.ToCharArray().Length == 5)
            {
                int.TryParse(((TextBox)sender).Text.Split('.')[0], out day);
                int.TryParse(((TextBox)sender).Text.Split('.')[1], out month);
            }

            if (VallideDate(day, month, MainWindow.curYear) == false)
                ((TextBox)sender).Foreground = Brushes.Red;
            else if (((TextBox)sender).Text.ToCharArray().Length == 5)
                ((TextBox)sender).Foreground = Brushes.White;
            else ((TextBox)sender).Foreground = Brushes.LightGray;

        }

        private void Btn_Back(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void TB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (((TextBox)sender).Foreground.Equals(Brushes.DarkKhaki))
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).Foreground = Brushes.LightGray;
            }

            else if (!char.IsDigit(e.Text[0]))
                e.Handled = true;

            else if (((TextBox)sender).Text.ToCharArray().Length == 2)
            {
                ((TextBox)sender).Text += ".";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.ToCharArray().Length;
            }
        }

    }
}
