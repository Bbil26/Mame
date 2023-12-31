﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Shapes;
using Загрузка__Выгруз;

namespace Логика
{
    public class Holidays
    {
        public int day { get; set; }
        public int month { get; set; }
        public String VisualHoli
        {
            get { return Visualname(); }
        }

        private string Visualname()
        {
            string line = "";
            if (day.ToString().Length == 1) line += "0" + day.ToString() + ".";
            else line += day.ToString() + ".";
            if (month.ToString().Length == 1) line += "0" + month.ToString();
            else line += month.ToString();
            return line;
        }
    }
    public class TeloPeople : INotifyPropertyChanged
    {
        private People _people;

        public TeloPeople(People p)
        {
            _people = p;
        }

        public String _Name
        {
            get { return _people._Namep; }
            set { _people._Namep = value; }
        }

        public String _Job
        {
            get { return _people._Jobp; }
            set { _people._Jobp = value; }
        }

        public String _Oklad
        {
            get { return _people._Okladp; }
            set { _people._Okladp = value; }
        }

        public ObservableCollection<string> _Otpusk
        {
            get { return _people._Otpuskp; }
            set { _people._Otpuskp = value; }
        }

        public double _Jan
        {
            get { return _people.Janp; }
            set { _people.Janp = value; }
        }

        public double _Feb
        {
            get { return _people.Febp; }
            set { _people.Febp = value; }
        }

        public double _Mar
        {
            get { return _people.Marp; }
            set { _people.Marp = value; }
        }

        public double _Apr
        {
            get { return _people.Aprp; }
            set { _people.Aprp = value; }
        }

        public double _May
        {
            get { return _people.Mayp; }
            set { _people.Mayp = value; }
        }
        public double _June
        {
            get { return _people.Junep; }
            set { _people.Junep = value; }
        }
        public double _July
        {
            get { return _people.Julyp; }
            set { _people.Julyp = value; }
        }
        public double _Aug
        {
            get { return _people.Augp; }
            set { _people.Augp = value; }
        }
        public double _Sep
        {
            get { return _people.Sepp; }
            set { _people.Sepp = value; }
        }
        public double _Okt
        {
            get { return _people.Oktp; }
            set { _people.Oktp = value; }
        }
        public double _Nov
        {
            get { return _people.Novp; }
            set { _people.Novp = value; }
        }
        public double _Dec
        {
            get { return _people.Decp; }
            set { _people.Decp = value; }
        }

        public String VisualList
        {
            get { return _people._Namep + " - " + _people._Jobp; }
            set { _people._Namep = value; NotifyPropertyChanged(); }
        }

        //Для обновления заголовков элементов ListBoxa'a
        void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


    public class ListPeoples
    {

        public ObservableCollection<TeloPeople> _telopeople = new ObservableCollection<TeloPeople> { };
        public ObservableCollection<Holidays> _holidays = new ObservableCollection<Holidays> { };

        public void AddDefaultHolidays()
        {

            string pathToDate = Environment.CurrentDirectory + "\\СохраненныеПраздники\\ПеременныеПраздники.csv";

            if (File.Exists(pathToDate))
            {
                StreamReader srr = new StreamReader(pathToDate);
                string linne;
                while((linne = srr.ReadLine()) != null)
                {
                    Console.Write(linne);
                    foreach(var it in linne.Split(';'))
                    {
                        if (it != "")
                        {
                            _holidays.Add(new Holidays()
                            {
                                day = Convert.ToInt32(it.Split('.')[0]),
                                month = Convert.ToInt32(it.Split('.')[1])
                            });
                        }
                    }
                }
                srr.Close();
            }
            else
            {
                string[] Hol = { "01.01", "02.01", "03.01", "04.01", "05.01", "06.01", "08.01",
                "07.01","23.02","08.03", "01.05", "09.05", "12.06", "04.11"};
                foreach (string str in Hol)
                {
                    _holidays.Add(new Holidays()
                    {
                        day = Convert.ToInt32(str.Split('.')[0]),
                        month = Convert.ToInt32(str.Split('.')[1]),
                    });
                }

            }

        }

        public ListPeoples()
        {
            List<People> tmp = ClassInput.getData();
            if (tmp != null)
            {
                foreach (var t in tmp)
                    _telopeople.Add(new TeloPeople(t));
            }

            AddDefaultHolidays();
        }
        public ListPeoples(int flag) 
        {
            AddDefaultHolidays();

        }

        public ObservableCollection<TeloPeople> VisListPeople
        {
            get { return _telopeople; }
        }
        public ObservableCollection<Holidays> VisListHoliday
        {
            get { return _holidays; }
        }

        public void AddItem(string n = "", string j = "", string o = "")
        {
            _telopeople.Add(new TeloPeople(new People()
            {
                _Namep = n,
                _Jobp = j,
                _Okladp = o,
                Janp = 0,
                Julyp = 0,
                Febp = 0,
                Augp = 0,
                Marp = 0,
                Sepp = 0,
                Aprp = 0,
                Oktp = 0,
                Mayp = 0,
                Novp = 0,
                Junep = 0,
                Decp = 0,
                _Otpuskp = new ObservableCollection<string>()
            }));
        }
        public void DeleteItem(TeloPeople tp)
        {
            _telopeople.Remove(tp);
        }

        public void OutputToFile()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = Environment.CurrentDirectory;
            dlg.Filter = "csv files (*.csv)|*.csv";
            dlg.Title = "Сохранение файла";

            if (dlg.ShowDialog() == true)
            {
                StreamWriter sw = new StreamWriter(dlg.FileName, false, Encoding.UTF8);
                foreach (var p in _telopeople)
                {
                    string line = "";
                    foreach (var t in p._Otpusk)
                        line = line + t + "\t";

                    sw.WriteLine($"Name=\"{p._Name}\";Job=\"{p._Job}\";Oklad=\"{p._Oklad}\";" +
                        $"Jan=\"{50 - p._Jan}\";Feb=\"{50 - p._Feb}\";Mar=\"{50 - p._Mar}\";Apr=\"{50 - p._Apr}\";" +
                        $"May=\"{50 - p._May}\";June=\"{50 - p._June}\";July=\"{50 - p._July}\";Aug=\"{50 - p._Aug}\";" +
                        $"Sep=\"{50 - p._Sep}\";Okt=\"{50 - p._Okt}\";Nov=\"{50 - p._Nov}\";Dec=\"{50 - p._Dec}\";" +
                        $"Otpusk=\"{line}\"");
                }
                sw.Close();
            }

        }
        int i = 1;
        public void AutoSave()
        {
            string pathToAutoSave = Environment.CurrentDirectory + $"\\АвтоСохранения\\autosave{i}.csv";

            if (!Directory.Exists(Environment.CurrentDirectory + $"\\АвтоСохранения"))
                Directory.CreateDirectory(Environment.CurrentDirectory + $"\\АвтоСохранения");

                StreamWriter sw = new StreamWriter(pathToAutoSave, false, Encoding.UTF8);
            foreach (var p in _telopeople)
            {
                string line = "";
                foreach (var t in p._Otpusk)
                    line = line + t + "\t";

                sw.WriteLine($"Name=\"{p._Name}\";Job=\"{p._Job}\";Oklad=\"{p._Oklad}\";" +
                    $"Jan=\"{50 - p._Jan}\";Feb=\"{50 - p._Feb}\";Mar=\"{50 - p._Mar}\";Apr=\"{50 - p._Apr}\";" +
                    $"May=\"{50 - p._May}\";June=\"{50 - p._June}\";July=\"{50 - p._July}\";Aug=\"{50 - p._Aug}\";" +
                    $"Sep=\"{50 - p._Sep}\";Okt=\"{50 - p._Okt}\";Nov=\"{50 - p._Nov}\";Dec=\"{50 - p._Dec}\";" +
                    $"Otpusk=\"{line}\"");
            }
            sw.Close();

            i++;
            if (i == 16) i = 1;
        }


    }

}
