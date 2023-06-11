using System;
using System.Windows;
using System.Windows.Controls;
using Логика;

namespace Баллы
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListPeoples listPeoples;
        public MainWindow()
        {
            InitializeComponent();
            
            //Create create = new Create();
            
            listPeoples = new ListPeoples(1);
            ListP.DataContext = listPeoples;
            TB_Year.Text = DateTime.Now.Year.ToString();
        }
        int curYear;
        private void Otpusk(object sender, RoutedEventArgs e)
        {
            if(ListP.SelectedIndex != -1)
            {
                Добавление_отпусков dlg = new Добавление_отпусков();
                dlg.ShowDialog();
            }
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            Профиль prof = new Профиль();
            prof.ShowDialog();

            if(prof.DialogResult == true)
            {
                string name, job, oklad;
                name = Профиль.n;
                job = Профиль.j;
                oklad = Профиль.o;
                listPeoples.AddItem(name, job, oklad);
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
                }
                flagChangeProfile = 0;
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (ListP.SelectedItem != null)
                listPeoples.DeleteItem((TeloPeople)ListP.SelectedItem);
        }

        private void Load_List(object sender, RoutedEventArgs e)
        {
            listPeoples = new ListPeoples();
            ListP.DataContext = listPeoples;
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
    }
}
