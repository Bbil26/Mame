using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

namespace Загрузка__Выгруз
{
    public class People
    {
        public string _Namep { get; set; }
        public string _Jobp { get; set; }
        public string _Okladp { get; set; }
        public ObservableCollection<string> _Otpuskp { get; set; }
        public double Janp { get; set; }
        public double Febp { get; set; }
        public double Marp { get; set; }
        public double Aprp { get; set; }
        public double Mayp { get; set; }
        public double Junep { get; set; }
        public double Julyp { get; set; }
        public double Augp { get; set; }
        public double Sepp { get; set; }
        public double Oktp { get; set; }
        public double Novp { get; set; }
        public double Decp { get; set; }

    }
        public class ClassInput
    {
        public static List<People> getData()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = Environment.CurrentDirectory;
            dlg.Filter = "csv files (*.csv)|*.csv";
            dlg.Title = "Выбор файла";

            if (dlg.ShowDialog() == true)
            {
                List<People> data = new List<People>() { };

                string line;
                string[] subline = new string[2];
                StreamReader sr = new StreamReader(dlg.FileName);
                while ((line = sr.ReadLine()) != null)
                {
                    String name = "", job = "", oklad = "";
                    foreach(string i in line.Split(';'))
                    {
                        subline = i.Split('=');
                        if (subline[0] == "Name")
                            name = subline[1].Trim('"');
                        else if (subline[0] == "Job")
                            job = subline[1].Trim('"');
                        else if (subline[0] == "Oklad")
                            oklad = subline[1].Trim('"');
                    }
                    
                    data.Add(new People()
                    {
                        _Namep = name,
                        _Jobp= job,
                        _Okladp = oklad
                    });
                }
                return data;
            }

            return null;
        }
        
    }

}
