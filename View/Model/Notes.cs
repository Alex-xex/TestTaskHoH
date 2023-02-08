using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;
using System.Net.Http;

namespace View.Model
{
    public class Notes : INotifyPropertyChanged
    {
        public List<Note> notes { get; set; }
        public ObservableCollection<Note> notesMe { get; set; }
        public ObservableCollection<Note> NotesMe
        {
            get { return notesMe; }
            set
            {
                notesMe = value;
                OnPropertyChanged("Title");
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
