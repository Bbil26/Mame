using System.Windows;
using System.Windows.Input;


namespace Баллы
{
    /// <summary>
    /// Логика взаимодействия для Профиль.xaml
    /// </summary>
    public partial class Профиль : Window
    {
        public Профиль()
        {
            InitializeComponent();
            

            if (MainWindow.flagChangeProfile == 1)
            {
                TB_name.Text = MainWindow.curChoice._Name;
                TB_job.Text = MainWindow.curChoice._Job;
                TB_oklad.Text = MainWindow.curChoice._Oklad;
            }
        }

        public static string n, j, o;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                SuccsessFinish();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SuccsessFinish();
        }

        private void SuccsessFinish()
        {
            n = TB_name.Text;
            j = TB_job.Text;
            o = TB_oklad.Text;
            DialogResult = true;
        }
    }
}
