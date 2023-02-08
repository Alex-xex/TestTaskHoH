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
using View.Reader;

namespace View.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        private Note _selectedNote;
        private ObservableCollection<Note> _notes;

        static HttpClient httpClient = new HttpClient();
        public ObservableCollection<Note> Notes 
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged("Notes");
            }
        }
        public Notes notes { get; set; }

        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(async obj =>
                  {
                      Note note = SelectedNote;
                      if (note != null)
                      {
                          string noteid = "https://localhost:5001/api/note/" + note.Id.ToString();
                          using var response = await httpClient.DeleteAsync(noteid);
                          Notes.Remove(note);
                      }
                  },
                 (obj) => Notes.Count > 0));
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
            var currencyRates = Reader.Reader._download_serialized_json_data<Notes>("https://localhost:5001/api/note");       
            Notes = new ObservableCollection<Note>(currencyRates.notes);
            Console.Write("");
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
     
    }
}
