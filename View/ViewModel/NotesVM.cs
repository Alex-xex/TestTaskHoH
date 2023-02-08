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
    public class NotesVM : INotifyPropertyChanged
    {
        private Note _selectedNote;
        static HttpClient httpClient = new HttpClient();
        public ObservableCollection<Note> Notes { get; set; }
        

        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Note note = obj as Note;
                      if (note != null)
                      {
                          Notes.Remove(note);
                      }
                  },
                 (obj) => Notes.Count > -1));
            }
        }

        // команда апдейта
        RelayCommand? updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                    (updateCommand = new RelayCommand(obj =>
                    {
                        Note? note = obj as Note;
                        if (note != null)
                        {
                            Note updatednote = new Note();                           
                            Notes.Insert(0, updatednote);
                        }
                    }));
            }
        }

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                _selectedNote = value;
                OnPropertyChanged("SelectedNote");
            }
        }

        public NotesVM()
        {
            object? data = httpClient.GetFromJsonAsync("https://localhost:5001/api/note", typeof(Note));
            if(data is IList<Note> && data !=null)
            {
                Notes = (ObservableCollection<Note>?)data;
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
