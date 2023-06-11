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
                    ObservableCollection<String> otpusk = new ObservableCollection<string>();
                    String name = "", job = "", oklad = "", temp = "";
                    double jan = 0, feb = 0, mar = 0, apr = 0, may = 0,
                        june = 0, july = 0, aug = 0, sep = 0, okt = 0,
                        nov = 0, dec = 0;

                    foreach(string i in line.Split(';'))
                    {
                        subline = i.Split('=');
                        if (subline[0] == "Name")
                            name = subline[1].Trim('"');
                        else if (subline[0] == "Job")
                            job = subline[1].Trim('"');
                        else if (subline[0] == "Oklad")
                            oklad = subline[1].Trim('"');
                        else if (subline[0] == "Jan")
                            double.TryParse(subline[1].Trim('"'), out jan);
                        else if (subline[0] == "Feb")
                            double.TryParse(subline[1].Trim('"'), out feb);
                        else if (subline[0] == "Mar")
                            double.TryParse(subline[1].Trim('"'), out mar);
                        else if (subline[0] == "Apr")
                            double.TryParse(subline[1].Trim('"'), out apr);
                        else if (subline[0] == "May")
                            double.TryParse(subline[1].Trim('"'), out may);
                        else if (subline[0] == "June")
                            double.TryParse(subline[1].Trim('"'), out june);
                        else if (subline[0] == "July")
                            double.TryParse(subline[1].Trim('"'), out july);
                        else if (subline[0] == "Aug")
                            double.TryParse(subline[1].Trim('"'), out aug);
                        else if (subline[0] == "Sep")
                            double.TryParse(subline[1].Trim('"'), out sep);
                        else if (subline[0] == "Okt")
                            double.TryParse(subline[1].Trim('"'), out okt);
                        else if (subline[0] == "Nov")
                            double.TryParse(subline[1].Trim('"'), out nov);
                        else if (subline[0] == "Dec")
                            double.TryParse(subline[1].Trim('"'), out dec);
                        else if (subline[0] == "Otpusk")
                            temp = subline[1].Trim('"');
                    }
                    
                    foreach(var i in temp.Split('\t'))
                        otpusk.Add(i);
                    
                    otpusk.RemoveAt(otpusk.Count - 1);

                    data.Add(new People()
                    {
                        _Namep = name,
                        _Jobp= job,
                        _Okladp = oklad,
                        Janp = 50 - jan,     Julyp = 50 - july,
                        Febp = 50 - feb,     Augp = 50 - aug,
                        Marp = 50 - mar,     Sepp = 50 - sep,
                        Aprp = 50 - apr,      Oktp = 50 - okt,
                        Mayp = 50 - may,     Novp = 50 - nov,
                        Junep = 50 - june,   Decp = 50 - dec,
                        _Otpuskp = otpusk,
                    });;
                }
                return data;
            }

            return null;
        }
        
    }

}
