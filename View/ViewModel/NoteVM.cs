using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using View.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace View.ViewModel
{
    public class NoteVM : INotifyPropertyChanged
    {
        private Note _note;
        static HttpClient httpClient = new HttpClient();
        public NoteVM(Note n)
        {
            _note = n;
            
        }

        public string Title
        {
            get { return _note.Title; }
            set
            {
                _note.Title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Info
        {
            get { return _note.Info; }
            set
            {
                _note.Info = value;
                OnPropertyChanged("Info");
            }
        }
        public bool Actual
        {
            get { return _note.Actual; }
            set
            {
                _note.Actual = value;
                OnPropertyChanged("Actual");
            }
        }

        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(async obj =>
                  {
                      Note note = new Note();
                      note.Title = _note.Title;
                      note.Info = _note.Info;
                      using var response = await httpClient.PostAsJsonAsync("https://localhost:5001/api/note", note);
                  
                  }));
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
