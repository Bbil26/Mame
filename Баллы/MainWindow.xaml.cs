﻿using otchet;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Логика;
using Brushes = System.Windows.Media.Brushes;

namespace Баллы
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public ListPeoples listPeoples;
        int RB_Detector;
        public MainWindow()
        {
            InitializeComponent();

            listPeoples = new ListPeoples(1);
            ListP.DataContext = listPeoples;
            TB_Year.Text = DateTime.Now.Year.ToString();
            holidays = listPeoples._holidays;
        }

        static public ObservableCollection<Holidays> holidays;
        private void Otpusk(object sender, RoutedEventArgs e)
        {
            if (ListP.SelectedIndex != -1)
            {
                Добавление_отпусков dlg = new Добавление_отпусков();
                dlg.ShowDialog();

                listPeoples.AutoSave();
            }
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            Профиль prof = new Профиль();
            prof.ShowDialog();

            if (prof.DialogResult == true)
            {
                string name, job, oklad;
                name = Профиль.n;
                job = Профиль.j;
                oklad = Профиль.o;
                listPeoples.AddItem(name, job, oklad);

                listPeoples.AutoSave();
            }
        }

        public static TeloPeople curChoice;
        public static int flagChangeProfile = 0;
        private void Edit(object sender, RoutedEventArgs e)
        {
            if (ListP.SelectedIndex != -1)
            {
                flagChangeProfile = 1;

                Профиль prof = new Профиль();
                prof.ShowDialog();

                if (prof.DialogResult == true)
                {
                    ((TeloPeople)ListP.SelectedItem)._Name = Профиль.n;
                    ((TeloPeople)ListP.SelectedItem)._Job = Профиль.j;
                    ((TeloPeople)ListP.SelectedItem)._Oklad = Профиль.o;
                    ((TeloPeople)ListP.SelectedItem).VisualList = Профиль.n;

                    listPeoples.AutoSave();
                }
                flagChangeProfile = 0;
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (ListP.SelectedItem != null)
                if (
                    MessageBox.Show("Вы действительно хотетите удалить запись?", "Внимание!",
                    MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    listPeoples.AutoSave(); // Сохранение до удаления
                    listPeoples.DeleteItem((TeloPeople)ListP.SelectedItem);
                    listPeoples.AutoSave(); // Сохранения после удаления
                }
        }

        private void Load_List(object sender, RoutedEventArgs e)
        {
            if (ListP.Items.Count > 0)
            {
                if (
                MessageBox.Show("Список непустой. Данная процедура \nбезвозвратно очистит текущий список.\n" +
                "Вы действительно хотите продолжить?", "Внимание!",
                    MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK
                )
                {
                    listPeoples = new ListPeoples();
                    ListP.DataContext = listPeoples;
                    holidays = listPeoples._holidays;
                }       
            }
            else
            {
                listPeoples = new ListPeoples();
                ListP.DataContext = listPeoples;
                holidays = listPeoples._holidays;
            }

        }

        private void Save_List(object sender, RoutedEventArgs e)
        {
            if (listPeoples != null)
                listPeoples.OutputToFile();
        }

        private void ListP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curChoice = (TeloPeople)((ListBox)sender).SelectedItem;
        }

        public static int curYear;
        private void TB_Year_TextInput(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TB_Year.Text, out curYear))
            {
                SolidColorBrush brush = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#fafafa"));
                TB_Year.Foreground = brush;
            }
            else
                TB_Year.Foreground = Brushes.Red;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RB_6.IsChecked == true) RB_Detector = 6;
            else if (RB_9.IsChecked == true) RB_Detector = 9;
            else RB_Detector = 12;

            try
            {
                Create create = new Create(listPeoples._telopeople, RB_Detector);
            }
            catch { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Праздники holi = new Праздники();
            holi.ShowDialog();

                string pathToAutoSave = Environment.CurrentDirectory + $"\\СохраненныеПраздники\\ПеременныеПраздники.csv";

                if (!Directory.Exists(Environment.CurrentDirectory + $"\\СохраненныеПраздники"))
                    Directory.CreateDirectory(Environment.CurrentDirectory + $"\\СохраненныеПраздники");

                StreamWriter sw = new StreamWriter(pathToAutoSave, false, Encoding.UTF8);
                
            foreach (var holiday in holidays)
                    sw.Write($"{holiday.day}.{holiday.month};");
                sw.Close();
        }
    }
}
