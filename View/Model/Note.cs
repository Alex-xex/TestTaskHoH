using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace View.Model
{
    public class Note : INotifyPropertyChanged
    {


        private string title;
        private string info;
        private bool actual;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }
        public bool Actual
        {
            get { return actual; }
            set
            {
                actual = value;
                OnPropertyChanged("Actual");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
