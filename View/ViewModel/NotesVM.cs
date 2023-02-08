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
using System.Windows;

namespace View.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        private  Note _selectedNote;
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

        private RelayCommand changeCommand;
        public RelayCommand ChangeCommand
        {
            get
            {
                return changeCommand ??
                  (changeCommand = new RelayCommand(async obj =>
                  {
                      Locator.LocatorSingle.note = SelectedNote;
                      if (Locator.LocatorSingle.note != null)
                      {
                          Guid noteid = Locator.LocatorSingle.note.Id;
                          string noteref = "https://localhost:5001/api/note/" + noteid.ToString();
                          Locator.LocatorSingle.note = Reader.Reader._download_serialized_json_data<Note>(noteref);
                          Locator.LocatorSingle.note.Id = noteid;
                          var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                          NoteUpdate updatePage = new NoteUpdate();
                          updatePage.Show();
                          window.Close();
                      }
                  }));
            }
        }

        private RelayCommand changePageNew;
        public RelayCommand ChangePageNew
        {
            get
            {
                return changePageNew ??
                  (changePageNew = new RelayCommand(async obj =>
                  {
                      var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                      NotePage notePage = new NotePage();
                      notePage.Show();
                      window.Close();
                  }));
            }
        }

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                _selectedNote = value;
                Locator.LocatorSingle.note = value;
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
