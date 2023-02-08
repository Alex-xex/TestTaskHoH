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
using View.Locator;
using System.Windows;

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
                      LocatorSingle.note = new Note();
                      LocatorSingle.note.Title = _note.Title;
                      LocatorSingle.note.Info = _note.Info;
                      using var response = await httpClient.PostAsJsonAsync("https://localhost:5001/api/note", LocatorSingle.note);
                      var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                      ListNotes listNotes = new ListNotes();
                      listNotes.Show();
                      window.Close();
                  }));
            }
        }
        // команда апдейта
        RelayCommand? updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                    (updateCommand = new RelayCommand(async obj =>
                    {                    
                        Note updatednote = new Note();
                        updatednote.Title = _note.Title;
                        updatednote.Info = _note.Info;
                        updatednote.Id = _note.Id;
                        using var response = await httpClient.PutAsJsonAsync("https://localhost:5001/api/note", updatednote);
                        var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                        ListNotes listNotes = new ListNotes();
                        listNotes.Show();
                        window.Close();
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

        private RelayCommand changePageList;
        public RelayCommand ChangePageList
        {
            get
            {
                return changePageList ??
                  (changePageList = new RelayCommand(async obj =>
                  {
                      var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                      ListNotes listPage = new ListNotes();
                      listPage.Show();
                      window.Close();
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
