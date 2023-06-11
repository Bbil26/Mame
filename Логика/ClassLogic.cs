using System;
using System.Collections.Generic;
using System.IO;
using Загрузка__Выгруз;
using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Логика
{
    
    public class TeloPeople : INotifyPropertyChanged
    {
        private People _people;

        public TeloPeople(People p)
        {
            _people = p;
            _Otpusk = new ObservableCollection<string>();
            
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
            get { return _people.Febp;}
            set { _people.Febp = value;}
        }

        public double _Mar
        {
            get { return _people.Marp; }
            set { _people.Marp = value;}
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
            get { return _people._Namep; }
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
        
        public ListPeoples()
        {
            List<People> tmp = ClassInput.getData();
            if (tmp != null)
            {
                foreach (var t in tmp)
                    _telopeople.Add(new TeloPeople(t));
            }
        }
        public ListPeoples(int flag){ }

        public ObservableCollection<TeloPeople> VisListPeople
        {
            get { return _telopeople; }
        }

        public void AddItem(string n = "", string j = "", string o = "")
        {
            _telopeople.Add(new TeloPeople(new People()
                {
                _Namep = n,
                _Jobp = j,
                _Okladp = o,
            }));
        }
        public void DeleteItem(TeloPeople tp)
        {
            _telopeople.Remove(tp);
        }

        public void OutputToFile()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "csv files (*.csv)|*.csv";
            dlg.Title = "Сохранение файла";

            if (dlg.ShowDialog() == true)
            { 
                StreamWriter sw = new StreamWriter(dlg.FileName);
                foreach (var p in _telopeople)
                {
                    sw.WriteLine($"Name=\"{p._Name}\";Job=\"{p._Job}\";Oklad=\"{p._Oklad}\";" +
                        $"");
                }
                sw.Close();
            }

        }


    }

}
